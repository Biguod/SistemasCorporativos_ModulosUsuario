﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModulosUsuario.Contexts;

namespace ModulosUsuario.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210604212901_addReserveTransactionType")]
    partial class addReserveTransactionType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModulosUsuario.Models.AddressUser", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("AddressUser");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BranchId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Unity")
                        .HasColumnType("int");

                    b.Property<int>("UnityTypeId")
                        .HasColumnType("int");

                    b.HasKey("MaterialId");

                    b.HasIndex("UnityTypeId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("ModulosUsuario.Models.MaterialTransaction", b =>
                {
                    b.Property<int>("MaterialTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnityValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaterialTransactionId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("StockId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("MaterialTransaction");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Permissions", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceList")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unity")
                        .HasColumnType("int");

                    b.Property<int>("UnityTypeId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("UnityTypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ModulosUsuario.Models.ProductTransaction", b =>
                {
                    b.Property<int>("ProductTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnityValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProductTransactionId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StockId");

                    b.HasIndex("TransactionTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductTransaction");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.HasKey("StockId");

                    b.HasIndex("BranchId")
                        .IsUnique();

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Tools", b =>
                {
                    b.Property<int>("ToolsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unity")
                        .HasColumnType("int");

                    b.Property<int>("UnityTypeId")
                        .HasColumnType("int");

                    b.HasKey("ToolsId");

                    b.HasIndex("UnityTypeId");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("ModulosUsuario.Models.ToolsLog", b =>
                {
                    b.Property<int>("ToolsLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FinalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToolsId")
                        .HasColumnType("int");

                    b.HasKey("ToolsLogId");

                    b.HasIndex("ToolsId");

                    b.ToTable("ToolsLog");
                });

            modelBuilder.Entity("ModulosUsuario.Models.ToolsTransaction", b =>
                {
                    b.Property<int>("ToolsTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnityValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ToolsTransactionId");

                    b.HasIndex("StockId");

                    b.HasIndex("ToolId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("ToolsTransaction");
                });

            modelBuilder.Entity("ModulosUsuario.Models.TransactionType", b =>
                {
                    b.Property<int>("TransactionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsIncoming")
                        .HasColumnType("bit");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionType");
                });

            modelBuilder.Entity("ModulosUsuario.Models.UnityType", b =>
                {
                    b.Property<int>("UnityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnityTypeId");

                    b.ToTable("UnityType");
                });

            modelBuilder.Entity("ModulosUsuario.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ModulosUsuario.Models.UsersPermissions", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int?>("PermissionsPermissionId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionsPermissionId");

                    b.ToTable("UsersPermissions");
                });

            modelBuilder.Entity("ModulosUsuario.Models.AddressUser", b =>
                {
                    b.HasOne("ModulosUsuario.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Material", b =>
                {
                    b.HasOne("ModulosUsuario.Models.UnityType", "UnityType")
                        .WithMany()
                        .HasForeignKey("UnityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnityType");
                });

            modelBuilder.Entity("ModulosUsuario.Models.MaterialTransaction", b =>
                {
                    b.HasOne("ModulosUsuario.Models.Material", "Material")
                        .WithMany("MaterialTransactions")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModulosUsuario.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModulosUsuario.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Stock");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Product", b =>
                {
                    b.HasOne("ModulosUsuario.Models.UnityType", "UnityType")
                        .WithMany()
                        .HasForeignKey("UnityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnityType");
                });

            modelBuilder.Entity("ModulosUsuario.Models.ProductTransaction", b =>
                {
                    b.HasOne("ModulosUsuario.Models.Product", "Product")
                        .WithMany("ProductTransactions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModulosUsuario.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModulosUsuario.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModulosUsuario.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Stock");

                    b.Navigation("TransactionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Stock", b =>
                {
                    b.HasOne("ModulosUsuario.Models.Branch", "Branch")
                        .WithOne("Stock")
                        .HasForeignKey("ModulosUsuario.Models.Stock", "BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Tools", b =>
                {
                    b.HasOne("ModulosUsuario.Models.UnityType", "UnityType")
                        .WithMany()
                        .HasForeignKey("UnityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnityType");
                });

            modelBuilder.Entity("ModulosUsuario.Models.ToolsLog", b =>
                {
                    b.HasOne("ModulosUsuario.Models.Tools", "Tool")
                        .WithMany("ToolsLogs")
                        .HasForeignKey("ToolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("ModulosUsuario.Models.ToolsTransaction", b =>
                {
                    b.HasOne("ModulosUsuario.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModulosUsuario.Models.Tools", "Tool")
                        .WithMany("ToolsTransactions")
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModulosUsuario.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");

                    b.Navigation("Tool");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("ModulosUsuario.Models.UsersPermissions", b =>
                {
                    b.HasOne("ModulosUsuario.Models.Permissions", "Permissions")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionsPermissionId");

                    b.HasOne("ModulosUsuario.Models.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permissions");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Branch", b =>
                {
                    b.Navigation("Stock");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Material", b =>
                {
                    b.Navigation("MaterialTransactions");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Permissions", b =>
                {
                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Product", b =>
                {
                    b.Navigation("ProductTransactions");
                });

            modelBuilder.Entity("ModulosUsuario.Models.Tools", b =>
                {
                    b.Navigation("ToolsLogs");

                    b.Navigation("ToolsTransactions");
                });

            modelBuilder.Entity("ModulosUsuario.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("UserPermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
