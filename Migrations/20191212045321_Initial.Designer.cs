﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Models;

namespace WebApi.Migrations
{
    [DbContext(typeof(RestaurantDataContext))]
    [Migration("20191212045321_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CustomerNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("CustomerPinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WebApi.Models.FoodItem", b =>
                {
                    b.Property<int>("FoodItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FoodItemInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FoodItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FoodItemPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("FoodItemId");

                    b.ToTable("FoodItem");
                });

            modelBuilder.Entity("WebApi.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TotalAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("OrderId");

                    b.ToTable("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
