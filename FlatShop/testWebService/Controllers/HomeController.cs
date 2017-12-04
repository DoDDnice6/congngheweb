using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testWebService.Controllers
{
    public class HomeController : Controller
    {
        private ServiceReference1.UserWebServiceSoapClient service = new ServiceReference1.UserWebServiceSoapClient();
        public ActionResult Index()
        {
            var model=service.ListAll1();
            
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}