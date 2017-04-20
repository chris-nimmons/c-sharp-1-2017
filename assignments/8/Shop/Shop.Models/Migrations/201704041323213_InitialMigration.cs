namespace Shop.Web.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Signature = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Transaction_Id = c.Int(),
                        Product_Id = c.Int(),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Transaction_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.Transaction_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(),
                        Weight = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Image = c.String(),
                        Signature = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "Transaction_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Cart_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "Transaction_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Carts");
        }
    }
}
