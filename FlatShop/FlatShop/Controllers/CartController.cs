using FlatShop.Models.EF;
using FlatShop.Models.EF.MoreEF;
using FlatShop.Models.Function;
using FlatShop.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FlatShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.ReturnURL = System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString();
            var cart = Session[Common.Session.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }


        public ActionResult AddItem(long productID, int quantity)
        {
            string url = "/Home/Index";
            try
            {
                url = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }
            var product = new ProductF().FindEntity(productID);
            var cart = Session[Common.Session.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                CartItem line = list.Where(l => l.Product.ID == productID).FirstOrDefault();
                if (line!=null)
                {
                    line.Quantity += quantity;
                    if (line.Quantity <= 0)
                        Delete(line.Product.ID);
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[Common.Session.CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = new Product();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gan vao session
                Session[Common.Session.CartSession] = list;
            }
            return Redirect(url);
        }

        public JsonResult DeleteAll()
        {
            Session[Common.Session.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[Common.Session.CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[Common.Session.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsoncart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[Common.Session.CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsoncart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    //item.Quantity = jsonItem.Quantity;
                    if (jsonItem.Quantity > 0) item.Quantity = jsonItem.Quantity;
                    else Delete(item.Product.ID);
                }
            }
            Session[Common.Session.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [CustomAuthorizeAttribute(Roles = "Customer")]
        public ActionResult Payment()
        {
            var cart = Session[Common.Session.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }


        [HttpPost]
        [CustomAuthorizeAttribute(Roles ="Customer")]
        public ActionResult Payment(string customername, string customerphone, string customeraddress, decimal totalprice)
        {
            var order = new Order();
            order.OrderDate = DateTime.Now;
            order.ShipAddress = customeraddress;
            order.TotalPrice = totalprice;
            Account acc = (Account)Session[Common.Session.LoginSession];
            if (acc != null) order.CustomerEmail = acc.Email;

            try
            {
                var id = new OrderF().Insert(order);
                var cart = (List<CartItem>)Session[Common.Session.CartSession];

                var odf = new OrderDetailF();
                foreach(var item in cart)
                {
                    var od = new OrderDetail();
                    od.OrderID = id;
                    od.ProductID = item.Product.ID;
                    od.UnitPrice = item.Product.Price;
                    od.Quantity = item.Quantity;
                    odf.Insert(od);
                }
            }
            catch { }

            return RedirectToAction("Index","Home");
        }
    }
}