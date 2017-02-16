using CoreShop.CoreShopModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private ShopContext Context { get; set; }
        public List<Product> Products { get; set; }

        public ProductsController()
        {
            Context = new ShopContext();
        }

        [HttpGet]
        public List<Product> Get()
        {
            return Context.Products.ToList();
        }


        // GET api/values
        [HttpGet("{id}")]
        public object Get(int id)
        {
            var product = Context.Products.FirstOrDefault(p=>p.Id == id);
            return product;
        }

        // POST api/values
        [HttpPost]
        public Product Post([FromBody]Product product)
        {
            var newProduct = Context.Products.Add(product);
            Context.SaveChanges();

            return product;
        }

        // PUT api/values/5     edit
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody]Product product)
        {
            var newProduct = Context.Products.FirstOrDefault(p=>p.Id == id);
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.Quantity = product.Quantity;
            newProduct.Image = product.Image;
            newProduct.SKU = product.SKU;
            newProduct.DescriptionOne = product.DescriptionOne;
            newProduct.DescriptionTwo = product.DescriptionTwo;
            newProduct.Weight = product.Weight;
            Context.SaveChanges();
            return (product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = Context.Products.Find(id);
            Context.Products.Remove(product);
            Context.SaveChanges();


        }

    }
}
