using CS_Container_WillisTowersWatson_2016.Tests.TestModels;
using System;
using Xunit;

namespace CS_Container_WillisTowersWatson_2016.Tests
{
    public class ContainerTests
    {
        [Fact]
        public void ShouldResolveTrasient()
        {
            var container = new Container();
            container.Register<IPerson, Teacher>(Lifecycle.Transient);

            var member = container.Resolve<IPerson>();
            Assert.Equal("The Amazingly Underpaid Erin Long", member.FullName());
        }

        [Fact]
        public void ShouldResolveTrasientTwice()
        {
            var container = new Container();
            container.Register<IPerson, Teacher>(Lifecycle.Transient);

            var member = container.Resolve<IPerson>();
            member.FirstName = "Becky";
            member.LastName = "Reece";

            var member2 = container.Resolve<IPerson>();

            Assert.Equal("The Amazingly Underpaid Erin Long", member2.FullName());
            Assert.Equal("The Amazingly Underpaid Becky Reece", member.FullName());
        }

        [Fact]
        public void ShouldDefaultToTrasientAndResolve()
        {
            var container = new Container();
            container.Register<IPerson, Teacher>();

            var member = container.Resolve<IPerson>();
            Assert.Equal("The Amazingly Underpaid Erin Long", member.FullName());
        }

        [Fact]
        public void ShouldResolveAndInjectParameter()
        {
            var container = new Container();
            container.Register<CommunityMember, CommunityMember>();
            container.Register<IPerson, Teacher>();
            container.Register<IHome, House>();

            var member = container.Resolve<CommunityMember>();
            Assert.Equal("The Amazingly Underpaid Erin Long", member.FullName());
        }

        [Fact]
        public void ShouldThrowNotRegisteredException()
        {
            var container = new Container();
            Assert.Throws<Exception>(() =>{
                var pet = container.Resolve<IPerson>();
            });
        }

        [Fact]
        public void ShouldResolveSingletonInstance()
        {
            var container = new Container();
            container.Register<IPerson, Teacher>(Lifecycle.Singleton);

            var member = container.Resolve<IPerson>();
            member.FirstName = "Becky";
            member.LastName = "Reece";

            var member2 = container.Resolve<IPerson>();

            //member2 is the same as member
            Assert.Equal("The Amazingly Underpaid Becky Reece", member2.FullName());
        }

        [Fact]
        public void ShouldThrowFirstParameterNotRegisteredException()
        {
            //only the first parameter will show in the exception
            var container = new Container();
            container.Register<CommunityMember, CommunityMember>();
            var ex = Assert.Throws<Exception>(() => {
                var member = container.Resolve<CommunityMember>();
            });
            Console.WriteLine(ex);
        }

        [Fact]
        public void ShouldThrowIHomeParameterNotRegisteredException()
        {
            var container = new Container();
            container.Register<CommunityMember, CommunityMember>();
            container.Register<IPerson, Teacher>();
            var ex = Assert.Throws<Exception>(() => {
                var member = container.Resolve<CommunityMember>();
            });
            Assert.Equal("type CS_Container_WillisTowersWatson_2016.Tests.TestModels.IHome not found in registered objects collection", ex.Message);
        }

        [Fact]
        public void ShouldThrowIPersonParameterNotRegisteredException()
        {
            var container = new Container();
            container.Register<CommunityMember, CommunityMember>();
            container.Register<IHome, House>();
            var ex = Assert.Throws<Exception>(() => {
                var member = container.Resolve<CommunityMember>();
            });
            Assert.Equal("type CS_Container_WillisTowersWatson_2016.Tests.TestModels.IPerson not found in registered objects collection", ex.Message);
        }

        [Fact]
        public void ShouldThrowContructorNotFoundException()
        {
            var container = new Container();
            container.Register<CommunityMember, CommunityMember>();
            container.Register<IPerson, Teacher>();
            container.Register<IHome, Apartment>();
            var ex = Assert.Throws<Exception>(() => {
                var member = container.Resolve<CommunityMember>();
            });
            Assert.Equal("unable to resolve contructor for type CS_Container_WillisTowersWatson_2016.Tests.TestModels.IHome", ex.Message);
        }
    }
}
