using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public Cart Cart { get; set; }
        public Transaction Transaction { get; set; }

        public Customer()
        {
            Cart = new Cart();
            Transaction = new Transaction();

        }
    }
}
