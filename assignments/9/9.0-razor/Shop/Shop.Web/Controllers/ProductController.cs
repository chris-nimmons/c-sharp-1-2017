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
        //public ActionResult Products()
        //{
        //    return View();
        //}
        //public ActionResult ProductsListPartial(int page = 1, int size = 20)
        //{


        //    int index = Math.Max(1, page) - 1;
        //    var products = Context.Products
        //       .OrderBy(q => q.Id)
        //        .Skip(index * size)
        //        .Take(size)
        //        .ToList();
        //    return View(products);
        //}

        public ActionResult Product(int id)
        {
            var product = Context.Products.Find(id);
                return View(product);
        }

    }

}