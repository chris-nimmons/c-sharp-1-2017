using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
   public class Order
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quanity { get; set; }
        public decimal Price { get; set; }
       
    }

   
}
