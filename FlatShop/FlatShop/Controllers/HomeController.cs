using FlatShop.Models;
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
    public class HomeController : Controller
    {
        // GET: Client/Home
        public ActionResult Index()
        {
            var model = new MenuF().Menus.ToList();
            return View(model);
        }
     
        public ActionResult Detail(long ID)
        {
            var model = new ProductF().FindEntity(ID);
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[Common.Session.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderUser()
        {
            var user = Session[Common.Session.LoginSession];
            return PartialView(user);
        }

        [ChildActionOnly]
        public PartialViewResult Brand()
        {
            var brand = new BrandF().Brands.ToList();
            return PartialView(brand);
        }

        [ChildActionOnly]
        public PartialViewResult MenuHeader(int? ParentID)
        {
            ViewBag.parentid = ParentID;
            var model = new MenuF().Menus.ToList();
            return PartialView(model);
        }


        [ChildActionOnly]
        public PartialViewResult ProductList(Menu Parent)
        {
            ViewBag.menu = Parent;
            List<ProductCategory> category = new ProductCategoryF().ProductCategories.Where(x => x.ParentID == Parent.ID).ToList();
            List<Product> product = new ProductF().Products.ToList();
            List<Product> model = new List<Product>();
            foreach (Product item in product)
            {
                if (category.Exists(x => x.ID == item.CaterogyID)) model.Add(new ProductF().FindEntity(item.ID));
            }
            return PartialView(model);
        }
    }
}