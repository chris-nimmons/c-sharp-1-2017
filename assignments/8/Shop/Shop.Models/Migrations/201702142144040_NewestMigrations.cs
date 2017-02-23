namespace Shop.Web.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewestMigrations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "Product");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Product", c => c.String());
        }
    }
}
