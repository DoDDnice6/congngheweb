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
    public class RegistryController : Controller
    {
        // GET: Registry
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Registry model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserF();
                if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var cus = new User();
                    cus.Name = model.Name;
                    cus.Email = model.Email;
                    cus.Phone = model.Password;
                    cus.Address = model.Address;
                    cus.Password = model.Password;
                    var result = dao.Insert(cus);
                    if (result)
                    {
                        RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                       
                    }
                }
                
            }
            return View();
        }
    }
}