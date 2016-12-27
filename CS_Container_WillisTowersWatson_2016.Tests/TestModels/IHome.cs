using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Container_WillisTowersWatson_2016.Tests.TestModels
{
    internal interface IHome
    {
        string Address { get; set; }
        HomeType Dwelling { get; set; }
        void SetAddress(string address);
        string GetAddress();
    }

    internal enum HomeType
    {
        None,
        House,
        Apartment,
        
    }
}
