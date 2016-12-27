using CS_Container_WillisTowersWatson_2016;
using CS_WillisTowersWatson_2016.Controllers;
using CS_WillisTowersWatson_2016.Services;
using CS_WillisTowersWatson_2016.Tests.MockServices;
using Xunit;

namespace CS_WillisTowersWatson_2016.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void TestMockServices()
        {
            var container = new Container();
            container.Register<HomeController, HomeController>();
            container.Register<IMessageService, MockMessageSerivce>();
            container.Register<IDataSerivce, MockDataService>();

            var controller = container.Resolve<HomeController>();
            var results = controller.Index();

            Assert.Equal("sent Mock message: test message", controller.ViewBag.Message);
            Assert.Equal("using Mock data", controller.ViewBag.Data);
        }
    }
}
