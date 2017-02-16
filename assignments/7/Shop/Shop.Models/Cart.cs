using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    class Cart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public Cart()
        {
            Products = new List<Product>();
        }
    }
}
