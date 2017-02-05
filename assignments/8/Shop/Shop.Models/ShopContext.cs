using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ShopContext() : base("Name=ShopContext")
        {

        }
    }
}
