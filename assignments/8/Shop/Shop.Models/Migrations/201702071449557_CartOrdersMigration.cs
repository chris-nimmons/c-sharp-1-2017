namespace Shop.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartOrdersMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Cart_Id" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Cart_Id);
            
            DropColumn("dbo.Products", "Cart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Cart_Id", c => c.Int());
            DropForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Cart_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropTable("dbo.Orders");
            CreateIndex("dbo.Products", "Cart_Id");
            AddForeignKey("dbo.Products", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
