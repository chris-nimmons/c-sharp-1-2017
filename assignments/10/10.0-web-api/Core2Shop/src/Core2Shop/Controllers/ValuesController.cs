using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Core2Shop.Models;

namespace Core2Shop.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ShopContext Context { get; set; }

        public ValuesController()
        {
            Context = new ShopContext();

        }




        [HttpGet("{id}")]
        public object Get(int id)
        {
            var product = Context.Products.Find(id);
            return product;
        }



        [HttpPut]
        public Product Put([FromBody]Product product)
        {
            var newProduct = Context.Products.Add(product);
            Context.SaveChanges();
            return (product);
        }


        [HttpPost("{id}")]
        public Product Post(int id, [FromBody] Product product)
        {
            var existing = Context.Products.Find(id);

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Weight = product.Weight;
            existing.SKU = product.SKU;
            existing.Quantity = product.Quantity;
            Context.SaveChanges();

            return (product);
        }




        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingProduct = Context.Products.Find(id);
            Context.Products.Remove(existingProduct);
            Context.SaveChanges();
        }
    }
}