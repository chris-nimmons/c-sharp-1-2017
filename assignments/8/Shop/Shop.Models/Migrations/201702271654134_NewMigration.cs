namespace Shop.Web.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "Quantity");
            DropColumn("dbo.Transactions", "Product");
            DropColumn("dbo.Transactions", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transactions", "Product", c => c.String());
            AddColumn("dbo.Transactions", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
