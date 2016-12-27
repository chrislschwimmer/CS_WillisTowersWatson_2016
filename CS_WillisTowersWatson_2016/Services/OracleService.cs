using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS_WillisTowersWatson_2016.Services
{
    public class OracleService : IDataSerivce
    {
        public string ConnectionName()
        {
            return "Connected To Oracle database";
        }
    }
}