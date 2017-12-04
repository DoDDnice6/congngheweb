using FlatShop.Models.EF;
using FlatShop.Models.Function;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatShop.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(int? Category, int? Brand, string OrderBy, decimal? PriceMin, decimal? PriceMax,int? page,int? NumberPage)
        {
            List<Product> model = new ProductF().Products.ToList();
            ViewBag.category = Category;
            ViewBag.brand = Brand;
            ViewBag.orderby = OrderBy;
            ViewBag.pricemin = PriceMin;
            ViewBag.pricemax = PriceMax;
            ViewBag.numberpage = NumberPage;
            if (Category != null)
            {
                model = model.Where(x => x.CaterogyID == Category).ToList();
                ProductCategory category = new ProductCategoryF().FindEntity(Category.GetValueOrDefault(0));
                ViewBag.parentID = category.ParentID;
            }
            if (Brand != null) model = model.Where(x => x.BrandID == Brand).ToList();
            if (PriceMin != null && PriceMax != null) model = model.Where(x => x.Price >= PriceMin && x.Price <= PriceMax).ToList();
            if (OrderBy == "Name") model = model.OrderBy(x => x.Name).ToList();
            else if (OrderBy == "Price") model = model.OrderBy(x => x.Price).ToList();
            else model = model.OrderBy(x => x.ID).ToList();
            
            return View(model.ToPagedList(page?? 1,NumberPage?? 3));
        }


        [ChildActionOnly]
        public PartialViewResult Category(int? ParentID,int? Category)
        {
            ViewBag.category = Category;
            var model = new ProductCategoryF().ProductCategories.Where(x => x.ParentID == ParentID).ToList();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult BrandLeft(int? Category,int? Brand)
        {
            ViewBag.CategoryID = Category;
            ViewBag.brand = Brand;
            var model = new BrandF().Brands.ToList();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult PriceFilter(decimal PriceMin, decimal PriceMax)
        {
            string url = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            return Redirect("/Index?ParentID=1");
        }
    }
}