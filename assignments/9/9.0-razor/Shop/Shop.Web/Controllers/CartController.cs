﻿using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Shop.Web.Controllers
{
    [RoutePrefix("shop")]
    public class CartController : Controller

    {

        private ShopContext Context { get; set; }

        public CartController()
        {
            Context = new ShopContext();
        }
        public ActionResult CartView()
        {
            var cookie = Request.Cookies["cart"];

            var signature = Guid.Parse(cookie.Value);

            var cart = Context.Carts
             .Include(q => q.Orders)
             .Include(q => q.Orders.Select(r => r.Product))
             .First(q => q.Signature == signature);
            return View(cart);
        }

        public List<Product> Products()
        {
            return new List<Product>();
        }



        public ActionResult NewCustomer(Customer customer)
        {
            var newCustomer = Context.Customers.Add(customer);
            customer.Name = newCustomer.Name;
            customer.Email = newCustomer.Email;
            customer.Address_1 = newCustomer.Address_1;
            customer.Address_2 = newCustomer.Address_2;
            customer.City = newCustomer.City;
            customer.State = newCustomer.State;
            customer.Signature = new Guid();
            Context.SaveChanges();
            return RedirectToAction("Cartview");
        }

        public ActionResult Add(int id)
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);
            var product = Context.Products.Find(id);
            var customer = Context.Customers.Find(id);
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
            return RedirectToAction("CartView");
        }
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

            return RedirectToAction("CartView");
        }

        public ActionResult Clear()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);
            var cart = Context.Carts
            .Include(q => q.Orders)
            .Include(q => q.Orders.Select(s => s.Product))
            .First(q => q.Signature == signature);
            cart.Orders.Clear();
            Context.SaveChanges();
            return RedirectToAction("CartView");
        }

        public ActionResult PaymentPageView()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);
            var cart = Context.Carts
             .Include(q => q.Orders)
             .Include(q => q.Orders.Select(r => r.Product))
             .First(q => q.Signature == signature);
            return View(cart);

        }
        public ActionResult CheckoutDo()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);
            var cart = Context.Carts.First(q => q.Signature == signature);
            return View();
        }
        public ActionResult Checkout()
        {
            var cookie = Request.Cookies["cart"];
            var signature = Guid.Parse(cookie.Value);
            var cart = Context.Carts
            .Include(q => q.Orders)
            .Include(q => q.Orders.Select(s => s.Product))
            .First(q => q.Signature == signature);

            //var customer = Context.Customers
            //.First(q => q.Signature == signature);

            var transaction = new Transaction();
            foreach (var order in cart.Orders)
            {
                transaction.Orders.Add(order);
                transaction.TransactionTotal += (order.Quantity * order.Product.Price);
            }

            transaction.TimeStamp = DateTime.UtcNow;
            Context.SaveChanges();
            cart.Orders.Clear();
            Context.Transactions.Add(transaction);
            Context.SaveChanges();
            return RedirectToAction("CheckoutDo");
        }
    }
}
