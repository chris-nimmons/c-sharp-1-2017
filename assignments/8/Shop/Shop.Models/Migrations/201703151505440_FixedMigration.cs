namespace Shop.Web.Models
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Name", c => c.String());
            AddColumn("dbo.Carts", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "Signature", c => c.Guid());
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Transactions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Signature = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Products", "Discriminator");
            DropColumn("dbo.Products", "Signature");
            DropColumn("dbo.Carts", "Price");
            DropColumn("dbo.Carts", "Name");
        }
    }
}
