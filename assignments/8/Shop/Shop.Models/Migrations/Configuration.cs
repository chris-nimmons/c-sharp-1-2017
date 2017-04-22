namespace Shop.Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Web.Models.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shop.Web.Models.ShopContext context)
        {

              context.Products.AddOrUpdate(
                p => p.Name,
                new Product { Id = 0020, Image = "http://d2rormqr1qwzpz.cloudfront.net/photos/2012/05/29/38134-maverick.jpg", Name = "Nerf Gun", Price = 22, Quantity = 1, SKU = "1033322", Weight = 20},
                new Product { Id = 1100, Image = "https://fthmb.tqn.com/IGeUu5uA5QFjYrzQ_LRAZxUBdx0=/1000x819/filters:fill(auto,1)/about/dell-ultrasharp-u2412m-lcd-monitor-56a6f9cc3df78cf772913a70.jpg", Name = "Computer Moniter", Price = 22, Quantity = 1, SKU = "1033322", Weight = 20 },
                new Product { Id = 2220, Image = "https://i.kinja-img.com/gawker-media/image/upload/s--Jo7sinAv--/c_scale,f_auto,fl_progressive,q_80,w_800/aoj4ajmkg11pq7jdwkm5.jpg", Name = "Computer Mouse", Price = 22, Quantity = 1, SKU = "1033322", Weight = 20 }
              );

        }
    }
}
