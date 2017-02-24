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
        public decimal Quantity { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public virtual List<Order> Bought { get; set; }

        public decimal Total
        {
            get
            {
                return Bought.Sum(q => q.Quantity * q.Price);
            }
        }

        public Guid Signature { get; set; }

        public Transaction()
        {
            Bought = new List<Order>();
        }
    }
}
