using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Shop.Web.Models
{
    [RoutePrefix("cart")]
    public class CartController : Controller
    {
        // GET: Cart
        public ShopContext Context { get; set; }



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
                if (order.Quantity < order.Product.Quantity)
                {
                    order = new Order() { Product = product, Price = 5.00M, Quantity = 1 };
                    order.Quantity++;
                    cart.Orders.Add(order);
                    Context.SaveChanges();
                }
            }
            else
            {
                order = new Order() { Product = product, Price = 0.00M , Quantity = 1};
                cart.Orders.Add(order);
                Context.SaveChanges();
            }


            return RedirectToAction("Product", "Home", new { id = product.Id });
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

                cart.Orders.Remove(order);
                Context.SaveChanges();
            }

            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Route("clear")]
        public ActionResult Clear()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            //Including objects in the query (q)

            var cart = Context.Carts
            .Include(q => q.Orders)
            .Include(q => q.Orders.Select(r => r.Product))
            .First(q => q.Signature == signature);

            cart.Orders.Clear();

            Context.SaveChanges();

            return RedirectToAction("Index");
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

            var transaction = new Transaction() { Signature = Guid.NewGuid() };

            foreach (var order in cart.Orders)
            {
                transaction.Orders.Add(order);
            }
            //TODO: Add transaction to context.  
            Context.Transactions.Add(transaction);
            //TODO: clear cart here.
            cart.Orders.Clear();
            Context.SaveChanges();

            return RedirectToAction("checkout-do");
        }

        [Route("checkout-do")]
        public ActionResult CheckoutDo()
        {
            return View();
        }


        [Route("transactions")]
        public ActionResult Transactions()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);

            var transactions = Context.Transactions
                .Include(q => q.Orders)
                .Include(q => q.Orders.Select(r => r.Product))
                .ToList();





            return View(transactions);
        }
    }
}