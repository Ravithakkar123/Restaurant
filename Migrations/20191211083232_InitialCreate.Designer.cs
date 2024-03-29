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
    [Migration("20191211083232_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("CardOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Exp")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("FoodItemId")
                        .HasColumnType("int");

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("PaymentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("TotalAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FoodItemId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebApi.Models.Order", b =>
                {
                    b.HasOne("WebApi.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.FoodItem", "FoodItem")
                        .WithMany()
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
