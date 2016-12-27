using CS_WillisTowersWatson_2016.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WillisTowersWatson_2016.Tests.MockServices
{
    public class MockMessageSerivce : IMessageService
    {
        public DateTime CreatedDateTime { get; set; }

        public string SendMessage(string message)
        {
            return string.Format("sent Mock message: {0}", message);
        }
    }
}
