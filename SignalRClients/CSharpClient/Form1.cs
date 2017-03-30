using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Diagnostics;
using Microsoft.AspNet.SignalR.Client;


namespace CSharpClient
{
    public partial class frmSignalRClient : Form
    {
        public frmSignalRClient()
        {
            InitializeComponent();
        }

        //  Private fields
        private JObject bearerToken;
        private IHubProxy chatHubProxy;
        private HubConnection hubConnection;
        private void pbSimpleTest_Click(object sender, EventArgs e)
        {
            var disco = DiscoveryClient.GetAsync("http://localhost:5000").Result;
            var tokenClient = new TokenClient(disco.TokenEndpoint, "cadenceengine", "igotyersecret");
            var tokenResponse = tokenClient.RequestClientCredentialsAsync("signalr").Result;

            if (!tokenResponse.IsError)
            {
                Trace.WriteLine(tokenResponse.Json);
                bearerToken = tokenResponse.Json;
            }
            else
            {
                Trace.WriteLine("HTTP status: " + tokenResponse.HttpStatusCode);
                Trace.WriteLine("HTTP error: " + tokenResponse.HttpErrorReason);
            }
        }

        private void pbConnect_Click(object sender, EventArgs e)
        {
            Console.WriteLine("pbConnect_Click");
            hubConnection = new HubConnection("http://localhost:17519");
            hubConnection.Headers.Add("Authorization",
                String.Format("Bearer {0}", bearerToken.GetValue("access_token").ToString()));

            chatHubProxy = hubConnection.CreateHubProxy("ChatHub");
            chatHubProxy.On<string, string>("Send", (name, message) => Console.WriteLine("Name: {0} Message: {1}", name, message));
            chatHubProxy.On<string>("MsgOfTheDay", (msg) => Console.WriteLine("Msg of the day: {0}", msg));

            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.TraceWriter = Console.Out;
            hubConnection.Error += ex => Console.WriteLine("SignalR error: {0}", ex.Message);

            hubConnection.Start();
        }

        private void pbChatSend_Click(object sender, EventArgs e)
        {
            chatHubProxy.Invoke("Send", new object[] { "Fred", "My Message" });
        }

        private void pbSetMessage_Click(object sender, EventArgs e)
        {
            chatHubProxy.Invoke("SetMsgOfTheDay", new object[] { "Scooby Doo!!!!" });
        }
    }
}
