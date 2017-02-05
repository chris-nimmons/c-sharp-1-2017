namespace Shop.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shop.Web.Models.ApplicationDbContext context)
        {
            {
                //This method will be called after migrating to the latest version.

                //You can use the DbSet<T>.AddOrUpdate() helper extension method
                //to avoid creating duplicate seed data.E.g.
                var person = new DbSet<People>.AddOrUpdate();

                context.People.AddOrUpdate(
                p => p.FullName,
                virtual DbSet<P.Fullname> { FullName = "Andrew Peters" };
                string People { FullName = "Brice Lambson" };
                string People { FullName = "Rowan Miller" };
                )

            }
        }
    }
}
