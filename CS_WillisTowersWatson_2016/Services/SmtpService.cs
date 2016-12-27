using System;

namespace CS_WillisTowersWatson_2016.Services
{
    public class SmtpService : IMessageService
    {
        public SmtpService()
        {
            CreatedDateTime = DateTime.Now;
        }
        public DateTime CreatedDateTime { get; set; }
        public string SendMessage(string message)
        {
            return string.Format("sent Email message: {0}", message);
        }
    }
}