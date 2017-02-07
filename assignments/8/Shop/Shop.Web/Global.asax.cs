using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Shop.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public WebApiApplication()
        {
            this.AuthenticateRequest += WebApiApplication_AuthenticateRequest;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        private void WebApiApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            var cookie = HttpContext.Current.Request.Cookies["Cart"];

            var context = new ShopContext();

            if (cookie == null)
            {
                var cart = new Cart() { Signature = Guid.NewGuid() };
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("cart", cart.Signature.ToString()));
                context.Carts.Add(cart);
                context.SaveChanges();

            }
            else
            {
                var signature = Guid.Parse(cookie.Value);
                var cart = context.Carts.FirstOrDefault(q => q.Signature == signature);
                if (cart == null)
                {
                }
                else
                {
                    cart = new Cart() { Signature = Guid.NewGuid() };
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("cart", cart.Signature.ToString()));
                    context.Carts.Add(cart);
                    context.SaveChanges();

                }
            }
        }
    }
}
