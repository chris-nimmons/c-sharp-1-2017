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
            var cart = Context.Carts
                .Include(q => q.Orders)
                .Include(q => q.Orders.Select(r => r.Product))
                .First();

            return View(cart);


        }

        public ActionResult Add(int Id)
        {
            var product = Context.Products.Find(Id);

            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var products = new Product();
            var cart = Context.Carts
                .Include(q => q.Orders)
                .Include(q => q.Orders.Select(r => r.Product))
                .First(q=> q.Signature == signature);


            var order = cart.Orders.FirstOrDefault(q => q.Product.Id == product.Id);
            if (order != null)
            {
                if (order.Quantity < order.Product.Quantity)
                {
                    order.Quantity++;
                    Context.SaveChanges();
                }
            }
            else
            {
                order = new Order() { Product = product, Quantity = 1 };
                cart.Orders.Add(order);
                Context.SaveChanges();
            }



            return RedirectToAction("Product", "Home", new { id = product.Id });
        }
        public ActionResult Remove(int Id)
        {

            var cookie = Request.Cookies["Cart"];
            var signature = Guid.Parse(cookie.Value);
            var product = Context.Products.Find(Id);

            var cart = Context.Carts
            .Include(q => q.Orders)
            .Include(q => q.Orders.Select(r => r.Product.Id == product.Id))
            .First();


            var order = cart.Orders.FirstOrDefault(q => q.Product.Id == product.Id);

            if (order != null)
            {
                if (order.Quantity > 1)
                {
                    order.Quantity--;

                }
                else
                {
                    cart.Orders.Remove(order);
                }

                cart.Orders.Remove(order);
                Context.SaveChanges();
            }

            Context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Clear()
        {
            var cart = Context.Carts.First();

            cart.Orders.Clear();

            return RedirectToAction("Index");


        }

    }
}