namespace TheIronYard.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deparmentalization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id, cascadeDelete: true)
                .Index(t => t.School_Id);
            
            CreateTable(
                "dbo.InstructorDepartments",
                c => new
                    {
                        Instructor_Id = c.Int(nullable: false),
                        Department_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_Id, t.Department_Id })
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Department_Id);
            
            AddColumn("dbo.Courses", "Department_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Department_Id");
            AddForeignKey("dbo.Courses", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.InstructorDepartments", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.InstructorDepartments", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.Courses", "Department_Id", "dbo.Departments");
            DropIndex("dbo.InstructorDepartments", new[] { "Department_Id" });
            DropIndex("dbo.InstructorDepartments", new[] { "Instructor_Id" });
            DropIndex("dbo.Departments", new[] { "School_Id" });
            DropIndex("dbo.Courses", new[] { "Department_Id" });
            DropColumn("dbo.Courses", "Department_Id");
            DropTable("dbo.InstructorDepartments");
            DropTable("dbo.Departments");
        }
    }
}
