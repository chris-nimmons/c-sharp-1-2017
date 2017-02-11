using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Web.Controllers
{
    //express http://localhost:port/api/shop
    [RoutePrefix("api/shop")]
    public class ShopController : ApiController
    {
        private ShopContext Context { get; set; }

        public ShopController()
        {
            Context = new ShopContext();
        }


        //GET: /api/shop/products
        [HttpGet]
        [Route("products")]
        public List<Product> GetProducts(int page = 1, int size = 20)
        {
            int index = Math.Max(1, page) - 1;
            return Context.Products
                .OrderBy(q=>q.Id)
                .Skip(index * size)
                .Take(size)
                .ToList();
        }
    }
}
