﻿// <auto-generated />
using CoffeeVendingMachine.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeVendingMachine.DataAccess.Migrations
{
    [DbContext(typeof(CoffeeVendingMachineDbContext))]
    [Migration("20230118230737_png")]
    partial class png
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoffeeVendingMachine.Domain.Models.Coffee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoffeeTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Coffee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoffeeTypeName = "Espresso",
                            Images = "./Images/espresso.jpg",
                            Price = 15f
                        },
                        new
                        {
                            Id = 2,
                            CoffeeTypeName = "Macchiato",
                            Images = "./Images/macchiato.jpg",
                            Price = 20f
                        },
                        new
                        {
                            Id = 3,
                            CoffeeTypeName = "Americano",
                            Images = "./Images/americano.jpg",
                            Price = 25f
                        },
                        new
                        {
                            Id = 4,
                            CoffeeTypeName = "Latte",
                            Images = "./Images/latte.jpg",
                            Price = 25f
                        },
                        new
                        {
                            Id = 5,
                            CoffeeTypeName = "Cappuccino",
                            Images = "./Images/cappuccino.jpg",
                            Price = 30f
                        },
                        new
                        {
                            Id = 6,
                            CoffeeTypeName = "Irish",
                            Images = "./Images/irish.jpg",
                            Price = 30f
                        });
                });

            modelBuilder.Entity("CoffeeVendingMachine.Domain.Models.Ingridients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Ingridients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Extra Sugar",
                            Price = 0f
                        },
                        new
                        {
                            Id = 2,
                            Name = "Creamer",
                            Price = 5f
                        },
                        new
                        {
                            Id = 3,
                            Name = "Caramelle",
                            Price = 5f
                        },
                        new
                        {
                            Id = 4,
                            Name = "Extra milk",
                            Price = 5f
                        });
                });

            modelBuilder.Entity("CoffeeVendingMachine.Domain.Models.NewModernCoffee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoffeeTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("NewModernCoffee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoffeeTypeName = "Frappe",
                            Images = "./Images/frappe.png",
                            Price = 40f
                        },
                        new
                        {
                            Id = 2,
                            CoffeeTypeName = "Glace",
                            Images = "./Images/glace.png",
                            Price = 35f
                        },
                        new
                        {
                            Id = 3,
                            CoffeeTypeName = "Mocha",
                            Images = "./Images/mocha.png",
                            Price = 25f
                        },
                        new
                        {
                            Id = 4,
                            CoffeeTypeName = "Romano",
                            Images = "./Images/romano.png",
                            Price = 25f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
