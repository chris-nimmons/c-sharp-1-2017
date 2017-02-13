﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public virtual List<Order> Orders { get; set; }
        public decimal Total { get; set; }
     

        public Transaction()
        {
            Orders = new List<Order>();
            
        }
    }
}
