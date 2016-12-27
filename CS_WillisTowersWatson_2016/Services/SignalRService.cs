using System;

namespace CS_WillisTowersWatson_2016.Services
{
    public class SignalRService : IMessageService
    {
        public SignalRService()
        {
            CreatedDateTime = DateTime.Now;
        }
        public DateTime CreatedDateTime { get; set; }
        public string SendMessage(string message)
        {
            return string.Format("sent SignalR message: {0}", message);
        }
    }
}