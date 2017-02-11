using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Shop.Web.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext Context { get; set; }

        public HomeController()
        {
            Context = new ShopContext();
        }
        public ActionResult Index()
        {
           
            ViewBag.Title = "Home Page";
            var products = Context.Products.ToList();
            return View(products);
        }

    }
}
