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
                var product = new Product() { Name = "Nerf Gun", Price = 49, Quanity = 10, SKU = "80085", Weight = 2, Image = "http://www.hasbro.com/common/productimages/en_US/51ba749950569047f523bab8bb6681ee/51C6604050569047F520640337FBD8BC.jpg", DescriptionOne = "Hand Cannon" };
                context.Products.Add(product);
                product = new Product() { Name = "Depends", Price = 10, Quanity = 10, SKU = "123455", Weight = 3, Image = "https://m.depend.com/images/product/product-image/prod06/New_Men_Fit.png", DescriptionOne = "Who wants to get up to pee?" };
                context.Products.Add(product);
                product = new Product() { Name = "Computer Mouse", Price = 10, Quanity = 10, SKU = "123478", Weight = 1, Image = "http://www.technocrazed.com/wp-content/uploads/2013/08/Crazy-Computer-Mouse-Designs-13.jpg", DescriptionOne = "Feels like Magic!" };
                context.Products.Add(product);

                context.SaveChanges();
            }
            if (!context.Customers.Any())
            {
                var customer = new Customer() { Name = "Ned Jones" };
                context.Customers.Add(customer);
                customer = new Customer() { Name = "Scruffy the Janitor" };
                context.Customers.Add(customer);
                customer = new Customer() { Name = "Steve" };
                context.Customers.Add(customer);

                context.SaveChanges();
            }
            
        }



    }
}
