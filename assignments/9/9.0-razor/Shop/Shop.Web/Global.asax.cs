﻿using Newtonsoft.Json;
using Shop.Models;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Shop.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        public static Cart Cart;

        public WebApiApplication()
        {
            this.AuthenticateRequest += WebApiApplication_AuthenticateRequest;

        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();

            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        private void WebApiApplication_AuthenticateRequest(object sender, EventArgs e)
        {

            var cookieUser = HttpContext.Current.Request.Cookies["authentication"];
            var authentication = new AuthenticationContext();

            if (cookieUser == null)
            {
                var account = new Account() { Signature = Guid.NewGuid() };

            }
            else
            {
                var input = cookieUser.Value;
                UserModel user = JsonConvert.DeserializeObject<UserModel>(input);
                HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(user.Name), user.Roles.ToArray());
            }

            var cookie = HttpContext.Current.Request.Cookies["cart"];

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

                if (cart != null)
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