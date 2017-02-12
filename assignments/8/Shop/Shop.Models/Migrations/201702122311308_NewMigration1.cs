namespace Shop.Web.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Signature", c => c.Guid(nullable: false));
            DropColumn("dbo.Transactions", "TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "TimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "Signature");
        }
    }
}
