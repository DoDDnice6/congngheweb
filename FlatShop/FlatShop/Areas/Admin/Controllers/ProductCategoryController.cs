using FlatShop.Models.EF;
using FlatShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryF f = new ProductCategoryF();
        public ActionResult Index()
        {
            var model = new ProductCategoryF().ProductCategories.ToList();
            return View(model);
        }


        public ActionResult Detail(int ID)
        {
            var model = f.FindEntity(ID);
            if (model != null)
            {
                return View(model);
            }
            return View();
        }
        public ActionResult Insert()
        {
            SetViewBag();
            return View();
        }
       

        public void SetViewBag(int? selectedID = null)
        {
            var f = new MenuF();
            ViewBag.ParentID = new SelectList(f.Menus.ToList(), "ID", "Text", selectedID);
        }
        [HttpPost]
        public ActionResult Insert(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                f.Insert(model);
            }
            return RedirectToAction("Index");

        }

        public ActionResult Update(int ID)
        {
            var model = f.FindEntity(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ProductCategory model)
        {
            f.Update(model);
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public ActionResult Delete(ProductCategory model)
        {
            f.Delete(model);
            return RedirectToAction("Index");
        }
    }
}