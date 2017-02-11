using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Shop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private ShopContext Context { get; set; }

        public ProductsController()
        {
            Context = new ShopContext();
        }

        // localhost/shop/Products/Products
        public ActionResult Product()
        {
            var products = Context.Products.Find();
            return View();
        }

        public ActionResult Products()
        {
            var products = Context.Products.ToList();

            return View(products);
        }
    }
}