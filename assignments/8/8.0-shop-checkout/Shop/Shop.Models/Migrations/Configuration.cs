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
            if(!context.Carts.Any())
            {
                var cart = new Cart();
                context.Carts.Add(cart);

                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var product = new Product() { Name = "R-9711 Destroyer", Price = 49, Quantity = 7, SKU = "80085", Weight = 2, DescriptionOne = "GET SOME", DescriotionTwo = "Easily Destroy Your Target!", Image = "https://cdn.instructables.com/F5Q/5T40/GGK2APZ7/F5Q5T40GGK2APZ7.SMALL.jpg" };
                context.Products.Add(product);
                product = new Product() { Name = "Depends", Price = 10, Quantity = 20, SKU = "123455", Weight = 3, DescriptionOne = "XXXL 16 pack. For the largest poos", DescriotionTwo = "Have an accident? Now it's okay! Nobody will ever know!", Image = "https://fa74d61d848a20b729bb-0251b36b713060ab3e0e8321940e01ff.ssl.cf2.rackcdn.com/0036000385340_CF_Horizontal_type_large.jpeg" };
                context.Products.Add(product);
                product = new Product() { Name = "Computer Mouse", Price = 10, Quantity = 5, SKU = "123478", Weight = 1, DescriptionOne = "Freshly Made!", DescriotionTwo = "Bringing nature and technology together!", Image = "https://cdn.instructables.com/FN5/FXSH/F0ZTLK0N/FN5FXSHF0ZTLK0N.MEDIUM.jpg" };
                context.Products.Add(product);

                context.SaveChanges();
            }
        }
    }
}
