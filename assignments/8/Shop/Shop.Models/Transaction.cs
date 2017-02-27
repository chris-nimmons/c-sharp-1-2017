using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Shop.Models
{
    public class Transaction 
    {
        public int Id { get; set; }
        public List<Order> Orders { get; set; }

        public decimal Total
        {
            get
            {
                return Orders.Sum(q => q.Price * q.Quantity);
            }
        }

        public Guid Signature { get; set; }

        public Transaction()
        {
            Orders = new List<Order>();
        }
    }
}
