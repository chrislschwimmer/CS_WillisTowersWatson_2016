using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Container_WillisTowersWatson_2016.Tests.TestModels
{
    internal class Teacher : IPerson
    {
        public Teacher()
        {
            FirstName = "Erin";
            LastName = "Long";
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return string.Format("The Amazingly Underpaid {0} {1}", FirstName, LastName);
        }
    }
}
