﻿// <auto-generated />
using System;
using CarShop.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarShop.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230501131436_CreateTableGroupProduct")]
    partial class CreateTableGroupProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarShop.Database.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GroupDes")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("NotShow")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupDes = "خودروی خانواده",
                            GroupName = "sedan",
                            NotShow = false
                        },
                        new
                        {
                            Id = 2,
                            GroupDes = "خودروی اسپرت",
                            GroupName = "coupe",
                            NotShow = false
                        },
                        new
                        {
                            Id = 3,
                            GroupDes = "خودروی جوانان",
                            GroupName = "crossover",
                            NotShow = false
                        });
                });

            modelBuilder.Entity("CarShop.Database.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Des")
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<bool>("NotShow")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("SellOff")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CarShop.Database.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cfebfe75-7fd9-4728-81bd-dcddef7fb7bf"),
                            RoleName = "admin",
                            RoleTitle = "مدیر"
                        },
                        new
                        {
                            Id = new Guid("5fb70b0e-4aa7-4a7e-b08a-4795cd58295b"),
                            RoleName = "user",
                            RoleTitle = "کاربر"
                        });
                });

            modelBuilder.Entity("CarShop.Database.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ebfbfcb5-1c3b-44de-8daa-c38ededa5c0b"),
                            Code = 0,
                            IsActive = true,
                            Mobile = "09112223344",
                            Password = "25-D5-5A-D2-83-AA-40-0A-F4-64-C7-6D-71-3C-07-AD",
                            RoleId = new Guid("cfebfe75-7fd9-4728-81bd-dcddef7fb7bf")
                        });
                });

            modelBuilder.Entity("CarShop.Database.Models.Product", b =>
                {
                    b.HasOne("CarShop.Database.Models.Group", "Group")
                        .WithMany("Products")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("CarShop.Database.Models.User", b =>
                {
                    b.HasOne("CarShop.Database.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CarShop.Database.Models.Group", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CarShop.Database.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
