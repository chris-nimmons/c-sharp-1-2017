using Shop.Models;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private ShopContext Context { get; set; }

        public TransactionsController()
        {
            Context = new ShopContext();
        }

        public ActionResult Index()
        {
            var products = Context.Products.ToList();
            return View(products);
        }

    }
}