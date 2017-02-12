using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;
namespace Shop.Models
{
    public class Transaction
    {
        public int Id { get; set; }
         public DateTime TimeStamp { get; set; }
        public virtual decimal TransactionTotal { get; set; }
        public Customer Customer { get; set; }
        public Cart Cart { get; set; }
        public virtual List<Order> Orders { get; set; }

        public Transaction()
        {
            Orders = new List<Order>();
    
             
        }
    }
}
