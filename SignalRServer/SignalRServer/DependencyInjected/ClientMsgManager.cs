using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace SignalRServer.DependencyInjected
{
    public class ClientMsgManager : IClientMsgManager
    {
        //  Private fields
        private readonly IHubConnectionContext<dynamic> Clients;
        private readonly Guid _instanceGuid;

        //  Public Properties
        public string MsgOfTheDay { get; set; }

        public ClientMsgManager(IHubConnectionContext<dynamic> clients)
        {
            if (clients == null)
            {
                throw new ArgumentException("clients");
            }

            Clients = clients;
            MsgOfTheDay = "Sometimes dead is better.";

            _instanceGuid = Guid.NewGuid();
        }

        public void BroadcastMessage(string name, string message)
        {
            Clients.All.Send(name, message);
        }        

        public void SendMsgOfTheDay(string msg)
        {
            
            Clients.All.Send("Fred", "Barney");
        }
    }
}