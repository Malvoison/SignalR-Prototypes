using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SignalRServer.DependencyInjected;

namespace SignalRServer.Controllers
{
    public class ClientMsgController : ApiController
    {
        private readonly IClientMsgManager _clientMsgManager;

        public ClientMsgController(IClientMsgManager clientMsgManager)
        {
            _clientMsgManager = clientMsgManager;
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void SendMsgOfTheDay([FromBody]string msg)
        {
            _clientMsgManager.SendMsgOfTheDay(msg);
        }
    }
}
