namespace SignalRServer.DependencyInjected
{
    public interface IClientMsgManager
    {
        string MsgOfTheDay { get; set; }

        void BroadcastMessage(string name, string message);

        void SendMsgOfTheDay(string msg);
    }
}