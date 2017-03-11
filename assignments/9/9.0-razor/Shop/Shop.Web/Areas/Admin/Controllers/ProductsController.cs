using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("products")]
    public class ProductsController : Controller
    {
        private ShopContext Context { get; set; }

        public ProductsController()
        {
            Context = new ShopContext();
        }

        [Route("")]
        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = Context.Products.ToList();
            return View(products);
        }

        // /shop/admin/products/{id}/edit
        [Route("{id}/edit")]
        public ActionResult Edit(int id)
        {
            var product = Context.Products.Find(id);
            return View(product);
        }

        [Route("edit")]
        public ActionResult Edit(Product product)
        {
            var existing = Context.Products.Find(product.Id);

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.SKU = product.SKU;
            existing.Quantity = product.Quantity;
            existing.Weight = product.Weight;
            existing.DescriptionOne = product.DescriptionOne;
            existing.DescriotionTwo = product.DescriotionTwo;
            existing.Image = product.Image;

            Context.SaveChanges();

            return View(existing);
        }

        [Route("{id}/delete")]
        public ActionResult Delete(int id)
        {
            var product = Context.Products.Find(id);
            Context.Products.Remove(product);

            Context.SaveChanges();

            return Redirect("~/admin/products");
        }

        [Route("add")]
        public ActionResult Add()
        {
            var product = new Product();
            return View(product);
        }

        [Route("add-do")]
        public ActionResult Add(Product product)
        {
            Context.Products.Add(product);

            Context.SaveChanges();

            return View(product);
        }

        [Route("transactions")]

        public ActionResult Transactions()
        {
            var transactions = Context.Transactions.ToList();
            return View(transactions);
        }



    }
}