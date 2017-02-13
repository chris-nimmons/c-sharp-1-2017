using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreShop.Migrations
{
    public partial class SpellingChangeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriotionTwo",
                table: "Products",
                newName: "DescriptionTwo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionTwo",
                table: "Products",
                newName: "DescriotionTwo");
        }
    }
}
