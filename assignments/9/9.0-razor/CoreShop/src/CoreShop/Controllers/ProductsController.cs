using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreShop.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        static Dictionary<int, string> Products { get; set; }

        static ProductsController()
        {
            Products = new Dictionary<int, string>();
        }

        // GET: api/products
        [HttpGet]
        public Dictionary<int, string> Get()
        {
            return Products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "product";
        }

        // POST api/values
        [HttpPost]
        public void Add([FromBody]string product)
        {

            var key = Products.Keys.OrderByDescending(q => q).FirstOrDefault();
            Products.Add(++key, product);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string product)
        {
            Products[id] = product;

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Products.Remove(id);

        }
    }
}
