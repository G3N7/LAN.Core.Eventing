using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LAN.Core.DependencyInjection;
using LAN.Core.DependencyInjection.StructureMap;
using LAN.Core.Eventing;
using LAN.Core.Eventing.SignalR;
using StructureMap;

namespace RailsSharp.Example
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

			var container = new StructureMapContainer(new Container());
	        ContainerRegistry.DefaultContainer = container;
	        var handlerRepository = CompositionConfig.ConfigureApp(container);
			HandlerConfig.RegisterHandlers(handlerRepository);
	        var thing = container.GetInstance<ISignalRConnectionLookupService>();
			var thing1 = container.GetInstance<ISignalRGroupRegistrar>();
			var thing2 = container.GetInstance<IGroupLookupService>();
			var thing3 = container.GetInstance<IGroupLeaveService>();
			var thing4 = container.GetInstance<IGroupJoinService>();
        }
    }
}
