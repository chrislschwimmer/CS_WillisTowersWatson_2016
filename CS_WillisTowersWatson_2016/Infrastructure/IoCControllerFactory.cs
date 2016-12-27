using CS_Container_WillisTowersWatson_2016;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace CS_WillisTowersWatson_2016.Infrastructure
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        private readonly Container container;

        public IoCControllerFactory(Container container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return container.Resolve(controllerType) as Controller;
        }
    }
}