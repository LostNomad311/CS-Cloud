using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSCloudAdmin.Controllers
{
    public class MonitorController : Controller
    {
        //
        // GET: /Monitor/
        public ActionResult Index()
        {
            var server = (CSCloudServerProxy.ICSCloudServer)HttpContext.Application[Constants.KEY_APP_SERVER];
            ViewBag.Clients = server.GetClients(false);
            ViewBag.Commands = server.GetExecutedCommands();

            return View();
        }
	}
}