namespace Shop.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingchars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Signature", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Signature");
        }
    }
}
