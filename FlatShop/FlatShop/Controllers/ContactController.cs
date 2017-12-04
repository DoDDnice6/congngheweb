using FlatShop.Models.EF;
using FlatShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View(0);
        }
        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            model.CreateDate = DateTime.Now;
            var result = new ContactF().Insert(model);
            return View("Index",1);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}