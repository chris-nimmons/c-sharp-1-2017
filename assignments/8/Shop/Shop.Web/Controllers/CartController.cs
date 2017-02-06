using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Shop.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ShopContext Context { get; set; }
        
        public CartController()
        {
            Context = new ShopContext();
        }
        public ActionResult Index()
        {
            var cart = Context.Carts.Include(q => q.Products).First();
            return View(cart);
        }

        public ActionResult Add(int Id)
        {
            var product = Context.Products.Find(Id);
            var cart = Context.Carts.First();
            cart.Products.Add(product);
            Context.SaveChanges();
            return RedirectToAction("Product", "Home", new { Id = product.Id });
        }
        public ActionResult Remove(int Id)
        {
            var product = Context.Products.Find(Id);

            var cart = Context.Carts.First();
            cart.Products.Remove(product);

            Context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Clear()
        {
            var cart = Context.Carts.First();

             cart.Products.Clear();

            return RedirectToAction("Index");


        }

    }
}