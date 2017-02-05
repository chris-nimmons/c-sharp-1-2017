namespace Shop.Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Models.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shop.Models.ShopContext context)
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