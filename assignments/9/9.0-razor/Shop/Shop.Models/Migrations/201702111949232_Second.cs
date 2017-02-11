namespace Shop.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Transactions", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Cart_Id" });
            DropIndex("dbo.Transactions", new[] { "Customer_Id" });
            DropColumn("dbo.Transactions", "TransactionTotal");
            DropColumn("dbo.Transactions", "Cart_Id");
            DropColumn("dbo.Transactions", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Customer_Id", c => c.Int());
            AddColumn("dbo.Transactions", "Cart_Id", c => c.Int());
            AddColumn("dbo.Transactions", "TransactionTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Transactions", "Customer_Id");
            CreateIndex("dbo.Transactions", "Cart_Id");
            AddForeignKey("dbo.Transactions", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Transactions", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
