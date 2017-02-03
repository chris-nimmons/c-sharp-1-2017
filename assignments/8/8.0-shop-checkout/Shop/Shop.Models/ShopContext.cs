using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Shop.Models
{
   public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ShopContext() :base ("Name=ShopContext")
        {

        }
    }
}
