using Shop.Models;
using Shop.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    [RouteArea("shop")]
    [RoutePrefix("customer")]
    public class CustomerController : Controller
    {
        private ShopContext Context { get; set; }
        public CustomerController()
        {
            Context = new ShopContext();
        }
        public ActionResult Customers()
        {
            return View();
        }
        public ActionResult AccountCreated()
        {

            return RedirectToAction("Cart/Cartview");
        }
        
    }
}