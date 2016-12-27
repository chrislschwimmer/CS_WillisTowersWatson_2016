using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Container_WillisTowersWatson_2016.Tests.TestModels
{
    internal interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName();
    }
}
