using CoreShop.Models;
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


        public ProductsController()
        {
            Context = new ShopContext();

        }
        [HttpGet("{id}")]
        public object Get(int id)
        {
            var product = Context.Products.FirstOrDefault(q=>q.Id==id);
            return (product);
        }

        [HttpPost]
        public Product Post([FromBody]Product product)
        {
            var newProducts = Context.Products.Add(product);
            Context.SaveChanges();
            return (product);
        }
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody]Product product)
        {
            var existing = Context.Products.FirstOrDefault(q=>q.Id == id);

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Quanity = product.Quanity;
            existing.SKU = product.SKU;
            existing.Weight = product.Weight;

            Context.SaveChanges();
            return (product);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            var product = Context.Products.Find(Id);
            Context.Products.Remove(product);
            Context.SaveChanges();
        }
    }
}