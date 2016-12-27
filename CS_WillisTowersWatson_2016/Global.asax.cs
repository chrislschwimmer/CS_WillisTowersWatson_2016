using CS_Container_WillisTowersWatson_2016;
using CS_WillisTowersWatson_2016.Infrastructure;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CS_WillisTowersWatson_2016
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            BootStrapper.Configure(container);
            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory(container));
        }
    }
}
