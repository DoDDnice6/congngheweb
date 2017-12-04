using FlatShop.Models.EF;
using FlatShop.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatShop.Controllers
{
    public class ProductCategoryController : Controller
    {
        public ActionResult Index(int? ParentID)
        {
            ViewBag.parentID = ParentID;
            List<ProductCategory> category = new ProductCategoryF().ProductCategories.Where(x => x.ParentID == ParentID).ToList();
            List<Product> product = new ProductF().Products.ToList();
            List<Product> model = new List<Product>();
            foreach (Product item in product)
            {
                if (category.Exists(x => x.ID == item.CaterogyID)) model.Add(new ProductF().FindEntity(item.ID));
            }
            return View(model);
        }
        public ActionResult SortBy(string key_,List<Product> model)
        {
            if (key_ == "Name")
                model.OrderBy(x => x.Name).ToList();
            else if (key_ == "Price") model.OrderBy(x => x.Price).ToList();
            return View("Index", model);
        }
    }
}