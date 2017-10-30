using FlatShop.Models.EF.MoreEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatShop.Models.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(HttpContext.Current==null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new 
                        {
                            Controller = "Login",
                            Action = "Index",
                            ReturnUrl = filterContext.HttpContext.Request.RawUrl
                        }
                        ));
            }

            var acc = (Account)HttpContext.Current.Session[Common.Session.LoginSession];

            if(acc==null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { Controller="Login",Action="Index",
                            ReturnUrl=filterContext.HttpContext.Request.RawUrl
                        }
                        ));
            }
            else
            {
                CustomPrincipal cp = new CustomPrincipal(acc);
                if(!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new { Controller = "Login", Action = "Index" }));
                }
            }
        }

    }
}