using Microsoft.AspNet.SignalR;
using SignalRServer.DependencyInjected;
using System;

namespace SignalRServer
{
    //[Authorize]    
    public class ChatHub : Hub
    {
        private readonly IClientMsgManager _clientMsgManager;

        public ChatHub (IClientMsgManager clientMsgManager)
        {
            if (clientMsgManager == null)
            {
                throw new ArgumentException("clientMsgManager");
            }

            _clientMsgManager = clientMsgManager;
        }
        
        public void Send(string name, string message)
        {
            //  Call the broadcastMessage method to update clients
            //Clients.All.broadcastMessage(name, message);
            Clients.All.Send(name, message);
        }

        public void SetMsgOfTheDay(string message)
        {
            _clientMsgManager.MsgOfTheDay = message;
            Clients.All.MsgOfTheDay(_clientMsgManager.MsgOfTheDay);
            _clientMsgManager.SendMsgOfTheDay(_clientMsgManager.MsgOfTheDay);
        }
    }
}