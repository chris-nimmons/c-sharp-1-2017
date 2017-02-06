using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class ProductBindingModel
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string SKU { get; set; }
            public float Weight { get; set; }
            public int Quantity { get; set; }        

    }
}