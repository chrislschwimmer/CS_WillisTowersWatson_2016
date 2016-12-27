using CS_WillisTowersWatson_2016.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WillisTowersWatson_2016.Tests.MockServices
{
    public class MockDataService : IDataSerivce
    {
        public string ConnectionName()
        {
            return "using Mock data";
        }
    }
}
