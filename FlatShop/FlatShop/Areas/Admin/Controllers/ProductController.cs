using FlatShop.Models.EF;
using FlatShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product

        ProductF f = new ProductF();
        public ActionResult Index()
        {
            var model = new ProductF().Products.ToList();
            return View(model);
        }

        public ActionResult Detail(long ID)
        {
            var model = f.FindEntity(ID);
            var category = new ProductCategoryF().FindEntity(model.CaterogyID.GetValueOrDefault(-1));
            ViewBag.CategoryID = category.Name;
            var brand = new BrandF().FindEntity(model.BrandID.GetValueOrDefault(-1));
            ViewBag.BrandID = brand.Name;
            if (model != null)
            {
                return View(model);
            }
            return View();
        }

        public void SetViewBag(long? selectedID = null)
        {
            var f = new ProductCategoryF();
            ViewBag.CaterogyID = new SelectList(f.ProductCategories, "ID", "Name", selectedID);
            var Brand = new BrandF();
            ViewBag.BrandID = new SelectList(Brand.Brands, "ID", "Name", selectedID);
            var Country = new CountryF();
            ViewBag.CountryID = new SelectList(Country.Countrys, "ID", "Name", selectedID);
        }
        public ActionResult Insert()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Product model)
        {
            if (ModelState.IsValid)
            {
                f.Insert(model);
            }
            return RedirectToAction("Index");

        }

        public ActionResult Update(long ID)
        {
            SetViewBag();
            var model = f.FindEntity(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Product model)
        {
            f.Update(model);
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public ActionResult Delete(Product model)
        {
            f.Delete(model);
            return RedirectToAction("Index");
        }
    }
}