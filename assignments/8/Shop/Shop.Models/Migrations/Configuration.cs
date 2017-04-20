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

                var product = new Product() { Name = "Nerf  Gun", Price = 49, Quantity = 7, SKU = "00000", Weight = 10, Image = "http://d2rormqr1qwzpz.cloudfront.net/photos/2012/05/29/38134-maverick.jpg" };
                context.Products.Add(product);
                product = new Product() { Name = "Computer Monitor", Price = 10, Quantity = 20, SKU = "00110", Weight = 3, Image = "https://www.bhphotovideo.com/images/images2500x2500/acer_um_fg6aa_b01_gn246hl_bbid_24_3d_ready_1073477.jpg" };
                context.Products.Add(product);
                product = new Product() { Name = "Computer Mouse", Price = 5, Quantity = 3, SKU = "11110", Weight = 1, Image = "https://i.kinja-img.com/gawker-media/image/upload/s--Jo7sinAv--/c_scale,f_auto,fl_progressive,q_80,w_800/aoj4ajmkg11pq7jdwkm5.jpg" };
                context.Products.Add(product);

                context.SaveChanges();
            }
        }

    }
}
