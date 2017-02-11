using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Shop.Web.Controllers
{
    [RoutePrefix("cart")]
    public class CartController : Controller
    {
        private ShopContext Context { get; set; }

        public CartController()
        {
            Context = new ShopContext();
        }
        [Route("")]
        public ActionResult Index()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var cart = Context.Carts
                .Include(q => q.Orders)
                .Include(q => q.Orders.Select(r => r.Product))
                .First(q => q.Signature == signature);
            return View(cart);
        }
        [Route("add/{id}")]
        public ActionResult Add(int id)
        {
            var product = Context.Products.Find(id);
            var cookie = Request.Cookies["cart"];

            var signature = Guid.Parse(cookie.Value);

            var cart = Context.Carts
                .Include(q => q.Orders)
                .Include(q => q.Orders.Select(r => r.Product))
                .First(q => q.Signature == signature);

            var order = cart.Orders.FirstOrDefault(q => q.Product.Id == product.Id);

            if (order != null)
            {
                if (order.Quanity < order.Product.Quanity)
                {
                    order.Quanity++;
                    Context.SaveChanges();
                }

            }
            else
            {
                order = new Order() { Product = product, Quanity = 1 };
                cart.Orders.Add(order);
                Context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [Route("remove/{id}")]
        public ActionResult Remove(int id)
        {
            var product = Context.Products.Find(id);

            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var cart = Context.Carts
                .Include(q => q.Orders)
                .Include(q => q.Orders.Select(r => r.Product))
                .First(q => q.Signature == signature);

            var order = cart.Orders.FirstOrDefault(q => q.Product.Id == product.Id);
            if (order != null)
            {
                if (order.Quanity > 1)
                {
                    order.Quanity--;
                }
                else
                {
                    cart.Orders.Remove(order);
                }
                Context.SaveChanges();
            }

            return RedirectToAction("Index", "Cart");
        }
        [Route("clear")]
        public ActionResult Clear()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var cart = Context.Carts.First(q => q.Signature == signature);
                
                

            cart.Orders.Clear();
            Context.SaveChanges();

            return RedirectToAction("Index", "Cart");

        }

        [Route("checkout")]
        public ActionResult Checkout()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var cart = Context.Carts
                .Include(q=>q.Orders)
                .Include(q=>q.Orders.Select(r=>r.Product))
                .First(q => q.Signature == signature);

            return View(cart);
        }


        [Route("checkout-do")]
        public ActionResult CheckoutDo()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var cart = Context.Carts.First(q => q.Signature == signature);

            var transaction = new Transaction();

            foreach (var order in cart.Orders)
            {
                transaction.Orders.Add(order);
            }

            transaction.TimeStamp = DateTime.UtcNow;

            Context.SaveChanges();

            cart.Orders.Clear();

            Context.SaveChanges();

            return View();

        }
    }
}
