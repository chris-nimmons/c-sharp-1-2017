using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public Product(string id)
        {
            Id = Convert.ToInt32(id);
        }
    }
}
