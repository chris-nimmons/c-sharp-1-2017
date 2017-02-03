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
                var product = new Product() { Name = "Nerf Gun", Price = 49, Quantity = 7, SKU = "80085", Weight = 2 };
                context.Products.Add(product);
                product = new Product() { Name = "Depends", Price = 10, Quantity = 20, SKU = "123455", Weight = 3 };
                context.Products.Add(product);
                product = new Product() { Name = "Computer Mouse", Price = 10, Quantity = 5, SKU = "123478", Weight = 1 };
                context.Products.Add(product);

                context.SaveChanges();
            }
        }
    }
}
