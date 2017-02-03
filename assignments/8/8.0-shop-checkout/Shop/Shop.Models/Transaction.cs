using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public virtual  List<Cart>Cart { get; set; }

        public Transaction()
        {
            Cart = new List<Cart>();
        }
    }
}
