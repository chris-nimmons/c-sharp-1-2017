namespace Shop.Web.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Product", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Product");
        }
    }
}
