using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShop.Models
{
    public class ShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CoreShop;Trusted_Connection=True;");
        }

        public DbSet<Product> Products { get; set; }

        public ShopContext() 
        {


            DbContextOptionsBuilder optionsbuilder = new DbContextOptionsBuilder();
            OnConfiguring(optionsbuilder);


        }


    }
}
