using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public virtual List<Order> Bought { get; set; }
        public decimal Total
        {
            get
            {
                return Bought.Sum(q => q.Quantity * q.Product.Price);
            }
        }
        public Guid Signature { get; set; }

    }
}