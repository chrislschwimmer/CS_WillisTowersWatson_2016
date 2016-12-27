using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_WillisTowersWatson_2016.Services
{
    public interface IMessageService
    {
        DateTime CreatedDateTime { get; set; }
        string SendMessage(string message);
    }
}