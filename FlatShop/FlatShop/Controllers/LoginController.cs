using FlatShop.Models.EF;
using FlatShop.Models.EF.MoreEF;
using FlatShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            string url = null;
            try
            {
                url = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }
            ViewBag.ReturnURL = url;//ReturnUrl;
            //ViewBag.ReturnURL = ReturnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index (Account model,string ReturnUrl)
        {
            if(String.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("", "Chưa nhập email");
                return View("Index", model);
            }

            var acc = new CustomerF().Login(model.Email, model.Password);


            if (acc == null)
            {
                Session[Common.Session.LoginSession] = null;
                ModelState.AddModelError("", "Người dùng không tồn tại");
                return View("Index", model);
            }
            else {
                Session[Common.Session.LoginSession] = acc;
                if(string.IsNullOrEmpty(ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }

        }
    }
}