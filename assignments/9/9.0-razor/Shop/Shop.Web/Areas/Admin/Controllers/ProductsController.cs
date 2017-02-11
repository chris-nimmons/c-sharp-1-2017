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
        // GET: Admin/Products

        public ProductsController()
        {
            Context = new ShopContext();
        }

        [Route("")]
        public ActionResult Index()
        {
            var products = Context.Products.ToList();
            return View(products);
        }


        [Route("{id}/Edit")]
        public ActionResult Edit(int id)
        {
            var product = Context.Products.Find(id);
            return View(product);

        }


        [Route("Edit")]
        public ActionResult Edit(Product product)
        {

            var existing = Context.Products.Find(product.Id);

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Weight = product.Weight;
            existing.SKU = product.SKU;
            existing.Quantity = product.Quantity;
            Context.SaveChanges();
            return View(existing);
        }

        [Route("Add")]
        public ActionResult Add()
        {
            return View();
        }



        [Route("Save")]
        public ActionResult Add(Product product)
        {
            var newProduct = Context.Products.Add(product);


            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.Weight = newProduct.Weight;
            product.SKU = newProduct.SKU;
            product.Quantity = newProduct.Quantity;
            product.IMG = newProduct.IMG;
            Context.SaveChanges();
            return View(newProduct.Id);
        }
        [Route("{id}/Delete")]
        public ActionResult Delete(int id)
        {
            var deleteProduct = Context.Products.Find(id);
            Context.SaveChanges();
            return Redirect("~/admin/products");
        }

    }
}
