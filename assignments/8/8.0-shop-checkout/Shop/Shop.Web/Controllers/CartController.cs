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
        // GET: Cart
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
        public ActionResult Add(int id, string location)
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var product = Context.Products.Find(id);

            var cart = Context.Carts
                .Include(q => q.Orders)
                .Include(q => q.Orders.Select(r => r.Product))
                .First(q => q.Signature == signature);

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
            if (location == "product")
            {
                return RedirectToAction("Product", "Products", new { id = product.Id });
            }
            else if (location == "cart")
            {
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }


        }

        [Route("remove/{id}")]
        public ActionResult Remove(int id)
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var product = Context.Products.Find(id);

            var cart = Context.Carts
                .Include(q => q.Orders)
                .Include(q => q.Orders.Select(r => r.Product))
                .First(q => q.Signature == signature);

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

                Context.SaveChanges();
            }

            return RedirectToAction("Index", "Cart");
        }

        [Route("clear")]
        public ActionResult Clear()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var cart = Context.Carts.Include(q => q.Orders).First(q => q.Signature == signature);

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
               .Include(q => q.Orders)
               .Include(q => q.Orders.Select(r => r.Product))
               .First(q => q.Signature == signature);

            return View(cart);
        }


        [Route("checkout-do")]
        public ActionResult CheckoutDo()
        {
            var cookie = Request.Cookies["cart"];           //getting a cookie named cart
            var signature = Guid.Parse(cookie.Value);       //makes our signature a Guid instead of a string

            var cart = Context.Carts.Include(q => q.Orders).First(q => q.Signature == signature);   //contacts database and pulls the cart that matches that signature

            var transaction = new Transaction()     //create transaction
            {
                TimeStamp = DateTime.UtcNow             //utc now is universal time, always use it for DateTime
            };   

            foreach (var order in cart.Orders)
            {
                transaction.Orders.Add(order);          //adding each order to the transaction
            }

            Context.Transactions.Add(transaction);

            

            Context.SaveChanges();
            cart.Orders.Clear();
            Context.SaveChanges();

            return View();
        }

    }
}