using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Container_WillisTowersWatson_2016.Tests.TestModels
{
    internal class CommunityMember
    {
        private IPerson _member;
        private IHome _home;
        public CommunityMember(IPerson member, IHome home)
        {
            _member = member;
            _home = home;
        }

        public string FullName()
        {
            return _member.FullName();
        }
    }
}
