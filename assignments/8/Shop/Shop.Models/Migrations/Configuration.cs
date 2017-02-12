using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Shop.Web.Models;
using Shop.Models;

namespace Shop.Web.Models
{
    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }



        protected override void Seed(ShopContext context)
        {
            if (!context.Products.Any())
            {
                var product = new Product() { Name = "Nerf  Gun", Price = 49, Quantity = 7, SKU = "00000", Weight = 10 };
                context.Products.Add(product);
                product = new Product() { Name = "Computer Monitor", Price = 10, Quantity = 20, SKU = "00110", Weight = 3 };
                context.Products.Add(product);
                product = new Product() { Name = "Computer Mouse", Price = 5, Quantity = 3, SKU = "11110", Weight = 1 };
                context.Products.Add(product);

                context.SaveChanges();
            }
        }

    }
}
