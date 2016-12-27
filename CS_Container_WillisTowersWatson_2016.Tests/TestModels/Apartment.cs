using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Container_WillisTowersWatson_2016.Tests.TestModels
{
    internal class Apartment : IHome
    {
        //hiding contructors from the container
        internal Apartment()
        {

        }

        public string Address { get; set; }
        public HomeType Dwelling { get; set; }
        public void SetAddress(string address)
        {
            Dwelling = HomeType.House;
            Address = address;
        }
        public string GetAddress()
        {
            return Address;
        }

    }
}
