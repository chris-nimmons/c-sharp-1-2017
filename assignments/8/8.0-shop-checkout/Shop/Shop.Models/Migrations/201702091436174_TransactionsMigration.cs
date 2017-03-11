namespace Shop.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionsMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Transaction_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Transaction_Id");
            AddForeignKey("dbo.Orders", "Transaction_Id", "dbo.Transactions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Transaction_Id", "dbo.Transactions");
            DropIndex("dbo.Orders", new[] { "Transaction_Id" });
            DropColumn("dbo.Orders", "Transaction_Id");
            DropColumn("dbo.Orders", "Price");
            DropTable("dbo.Transactions");
        }
    }
}
