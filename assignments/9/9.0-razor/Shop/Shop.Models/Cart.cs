﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public virtual List<Order> Orders { get; set; }
        public decimal Total { get; set; }

        public Guid Signature { get; set; }

        public Cart()
        {
            Orders = new List<Order>();
           
        }

    }
}