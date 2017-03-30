using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using Autofac;
using Autofac.Integration.Owin;
using Autofac.Integration.SignalR;
using System.Reflection;
using System.Configuration;
using SignalRServer.DependencyInjected;
using Microsoft.AspNet.SignalR.Infrastructure;
using Autofac.Core;
using Microsoft.AspNet.SignalR.Hubs;
using System.Web.Http;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(SignalRServer.Startup))]

namespace SignalRServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            //  Start SignalR configuration
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            hubConfiguration.EnableJavaScriptProxies = true;
            //  register SignalR hubs..  this call will register all of them at once
            builder.RegisterHubs(Assembly.GetExecutingAssembly());

            //  register dependencies            
            builder.RegisterType<ClientMsgManager>()
                .WithParameter(ResolvedParameter.ForNamed<IHubConnectionContext<dynamic>>("ClientMsgManagerContext"))
                .As<IClientMsgManager>()
                .SingleInstance();

            // The factory function for the IHubConnectionContext is using the resolver to get the IConnectionManager, 
            // and not the container itself (of course the container won't know about a IConnectionManager). 
            // Switched to use the default dependency resolver (GlobalHost.DependencyResolver) to get the IConnectionManager instead. 
            builder.Register(c => GlobalHost.DependencyResolver.Resolve<IConnectionManager>().GetHubContext<ChatHub>().Clients)
                .Named<IHubConnectionContext<dynamic>>("ClientMsgManagerContext");

            //builder.Register(c => GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients)
            //    .Named<IHubConnectionContext<dynamic>>("ClientMsgManagerContext");

            //  Start the Web API Configuration
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            //  app.UseWebApi(httpConfiguration);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            //  Set the SignalR dependency resolver to be Autofac
            hubConfiguration.Resolver = new AutofacDependencyResolver(container);
            hubConfiguration.Resolver.UseSqlServer(ConfigurationManager.ConnectionStrings["SignalR"].ConnectionString);

            //  Set the Web API dependency resolver to be Autofac
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //  Register teh Autofac middleware FIRST.  This also adds
            //  Autofac-injected middleware registered with the container
            app.UseAutofacMiddleware(container);
                        
            //  Add IdentityServer3 middleware --->  Must be in pipeline prior to SignalR to make 
            //  hub authorization work
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServer3.AccessTokenValidation.IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                RequiredScopes = new[] { "signalr" }
            });

            app.UseAutofacWebApi(httpConfiguration);
            app.UseWebApi(httpConfiguration);

            app.MapSignalR("/signalr", hubConfiguration);
        }
    }
}
