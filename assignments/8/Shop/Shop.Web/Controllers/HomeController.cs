﻿using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Models
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
            var products = Context.Products.ToList();
            return View(products);
        }

        public ActionResult Product(int id)
        {
            var product = Context.Products.Find(id);
            return View(product);
        }
    }
}