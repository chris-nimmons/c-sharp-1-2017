using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Cart  
    {
        public int Id { get; set; }
        public virtual List<Product> Products { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }
    }   
}
