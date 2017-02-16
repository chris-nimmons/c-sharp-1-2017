using Shop.Models;
using Shop.Web.Models;
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
        
        public ShopContext Context { get; set; }

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
            existing.Quantity = product.Quantity;
            existing.SKU = product.SKU;
            existing.Weight = product.Weight;

            Context.SaveChanges();
            return View(existing);
        }


        [Route("add")]
        public ActionResult Add()
        {
            return View();
        }


        [Route("add-do")]
        public ActionResult Add(Product product)
        {
            Context.Products.Add(product);

            Context.SaveChanges();
            return Redirect("~/admin/products");
        }


        //   /shop/admin/products/{id}/delete
        [Route("{id}/delete")]
        public ActionResult Delete(int id)
        {
            var existing = Context.Products.Find(id);
            Context.Products.Remove(existing);

            Context.SaveChanges();

            return Redirect("~/admin/products");
        }
    }
}


//Decide on a route.  /shop/admin/products/add
//Create an action to show the user the add view
//Create the view for add
//Style the user interface of the add view
//Create an action that adds product to the database.  
//Save to database.  
//return view for either add, edit, or products