using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Shop.Models.Models;

namespace Shop.Models
{
   public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Transaction> Transactions { get; set; }    
        public ShopContext() :base ("Name=ShopContext")
        {
            
        }
    }


}
