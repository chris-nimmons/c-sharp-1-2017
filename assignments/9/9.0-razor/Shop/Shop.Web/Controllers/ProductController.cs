using Shop.Models;
using Shop.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        private ShopContext Context { get; set; }

        public ProductController()
        {
            Context = new ShopContext();
        }
        public ActionResult Product(int id)
        {
            var product = Context.Products.Find(id);
                return View(product);
        }

    }

}