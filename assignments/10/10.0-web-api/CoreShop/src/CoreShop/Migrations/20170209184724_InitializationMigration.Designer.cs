using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreShop.CoreShopModels;

namespace CoreShop.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20170209184724_InitializationMigration")]
    partial class InitializationMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreShop.CoreShopModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescriotionTwo");

                    b.Property<string>("DescriptionOne");

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<string>("SKU")
                        .IsRequired();

                    b.Property<float>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
        }
    }
}
