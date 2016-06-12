using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Presentation.MvcWeb.Controllers
{
    public class App1Controller : Controller
    {
        public ActionResult Index(string returnUrl)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return View("App");
            //}
            //ViewBag.ReturnUrl = returnUrl;
            //return View();
            return File(Server.MapPath("~/DemoApp/dist/") + "index.html", "text/html");
        }
    }
}