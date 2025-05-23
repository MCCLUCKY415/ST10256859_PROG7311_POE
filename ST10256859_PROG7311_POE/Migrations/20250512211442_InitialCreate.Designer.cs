﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ST10256859_PROG7311_POE.DataBase;

#nullable disable

namespace ST10256859_PROG7311_POE.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250512211442_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("ST10256859_PROG7311_POE.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            ContactNumber = "1234567899",
                            FirstName = "Jenna",
                            LastName = "Kemm"
                        },
                        new
                        {
                            EmployeeID = 2,
                            ContactNumber = "1001001000",
                            FirstName = "Kayla",
                            LastName = "F"
                        });
                });

            modelBuilder.Entity("ST10256859_PROG7311_POE.Models.Farmer", b =>
                {
                    b.Property<int>("FarmerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FarmerID");

                    b.ToTable("Farmers");

                    b.HasData(
                        new
                        {
                            FarmerID = 1,
                            Address = "65 Ringwood Drive",
                            ContactNumber = "1234567899",
                            FirstName = "Dhiren",
                            LastName = "Ruthenavelu"
                        },
                        new
                        {
                            FarmerID = 2,
                            Address = "456 Oak Avenue",
                            ContactNumber = "2137465899",
                            FirstName = "Chad",
                            LastName = "Fairlie"
                        });
                });

            modelBuilder.Entity("ST10256859_PROG7311_POE.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FarmerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductID");

                    b.HasIndex("FarmerID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            Category = "Vegetable",
                            FarmerID = 1,
                            ProductName = "Tomatoes",
                            ProductionDate = new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 2,
                            Category = "Vegetable",
                            FarmerID = 1,
                            ProductName = "Carrots",
                            ProductionDate = new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 3,
                            Category = "Fruit",
                            FarmerID = 2,
                            ProductName = "Apples",
                            ProductionDate = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 4,
                            Category = "Vegetable",
                            FarmerID = 2,
                            ProductName = "Lettuce",
                            ProductionDate = new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ST10256859_PROG7311_POE.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FarmerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("FarmerID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "dhiren@gmail.com",
                            FarmerID = 1,
                            Password = "password123",
                            Role = "Farmer"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "chad@gmail.com",
                            FarmerID = 2,
                            Password = "password123",
                            Role = "Farmer"
                        },
                        new
                        {
                            UserID = 3,
                            Email = "jenna@gmail.com",
                            EmployeeID = 1,
                            Password = "password123",
                            Role = "Employee"
                        },
                        new
                        {
                            UserID = 4,
                            Email = "kayla@gmail.com",
                            EmployeeID = 2,
                            Password = "password123",
                            Role = "Employee"
                        });
                });

            modelBuilder.Entity("ST10256859_PROG7311_POE.Models.Product", b =>
                {
                    b.HasOne("ST10256859_PROG7311_POE.Models.Farmer", "Farmer")
                        .WithMany("Products")
                        .HasForeignKey("FarmerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("ST10256859_PROG7311_POE.Models.User", b =>
                {
                    b.HasOne("ST10256859_PROG7311_POE.Models.Employee", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("ST10256859_PROG7311_POE.Models.Farmer", "Farmer")
                        .WithMany("Users")
                        .HasForeignKey("FarmerID");

                    b.Navigation("Employee");

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("ST10256859_PROG7311_POE.Models.Employee", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ST10256859_PROG7311_POE.Models.Farmer", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
