using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CSCloudAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize web services
            Application[Constants.KEY_APP_LOG_SERVICE] = new CSCloudLogServerProxy.CSCloudLogServiceClient();
            var dummyCallbackClient = new CSCloudClientDummy();
            Application[Constants.KEY_APP_SERVER] = new CSCloudServerProxy.CSCloudServerClient(new InstanceContext(dummyCallbackClient));
        }
    }
}
