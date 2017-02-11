using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreShop.Models;

namespace CoreShop.Controllers
{
   [Route("api/[controller]")]
   public class ValuesController : Controller
   {
       private ShopContext Context { get; set; }
       public Dictionary<int, string> Values { get; set; }
       


       public ValuesController()
       {
            Context = new ShopContext();

           Values = new Dictionary<int, string>();
       }

       // GET api/values
       [HttpGet]
       public Dictionary<int, string> Get()
       {
           return Values;
       }

       // GET api/values/5
       [HttpGet("{id}")]
       public string Get(int id)
       {
           return Values[id];
       }

       // POST api/values
       [HttpPost]
       public void Post([FromBody]string value)
       {
           var key = Values.Keys.OrderByDescending(q => q).FirstOrDefault();
           Values.Add(++key, value);
       }

       // PUT api/values/5
       [HttpPut("{id}")]
       public void Put(int id, [FromBody]string value)
       {
           Values[id] = value;
       }

       // DELETE api/values/5
       [HttpDelete("{id}")]
       public void Delete(int id)
       {
           Values.Remove(id);
       }
   }
}