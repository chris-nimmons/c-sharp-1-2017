namespace Shop.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Buildfix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customerid = c.Int(nullable: false),
                        Signature = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Cart_Id = c.Int(),
                        Transaction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.Transactions", t => t.Transaction_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Cart_Id)
                .Index(t => t.Transaction_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SKU = c.String(nullable: false),
                        Weight = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IMG = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Signature = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Address_1 = c.String(),
                        Address_2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Phone = c.String(),
                        Do_Not_Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        TransactionTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cart_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Cart_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "Customer_Id" });
            DropIndex("dbo.Transactions", new[] { "Cart_Id" });
            DropIndex("dbo.Orders", new[] { "Transaction_Id" });
            DropIndex("dbo.Orders", new[] { "Cart_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Carts");
        }
    }
}
