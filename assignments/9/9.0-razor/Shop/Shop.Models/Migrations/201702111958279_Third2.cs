namespace Shop.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "TransactionTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "TransactionTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
