using CS_Container_WillisTowersWatson_2016;
using CS_WillisTowersWatson_2016.Controllers;
using CS_WillisTowersWatson_2016.Services;

namespace CS_WillisTowersWatson_2016.Infrastructure
{
    public class BootStrapper
    {
        public static void Configure(Container container)
        {
            container.Register<HomeController, HomeController>();
            container.Register<AccountController, AccountController>();
            container.Register<IMessageService, SignalRService>();
            container.Register<IDataSerivce, OracleService>();
        }
    }
}