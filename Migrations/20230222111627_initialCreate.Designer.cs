﻿// <auto-generated />
using System;
using DynamicStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DynamicStore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230222111627_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DynamicStore.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("StoreId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DynamicStore.Models.CategoryStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StoreId");

                    b.ToTable("CategoryStores");
                });

            modelBuilder.Entity("DynamicStore.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmployeeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EmployeeHireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EmployeeSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DynamicStore.Models.EmployeeAttendance", b =>
                {
                    b.Property<int>("EmployeeAttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeAttendanceId"));

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Bonus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("HolidayLeft")
                        .HasColumnType("int");

                    b.Property<decimal>("HolidayPenaltyAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsHoliday")
                        .HasColumnType("bit");

                    b.Property<decimal>("Loan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ShiftEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShiftStartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeAttendanceId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeAttendance");
                });

            modelBuilder.Entity("DynamicStore.Models.Finance", b =>
                {
                    b.Property<int>("finance_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("finance_id"));

                    b.Property<decimal>("finance_amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("finance_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("finance_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("finance_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("store_id")
                        .HasColumnType("int");

                    b.HasKey("finance_id");

                    b.HasIndex("store_id");

                    b.ToTable("Finances");
                });

            modelBuilder.Entity("DynamicStore.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"));

                    b.Property<int>("InventoryAlertQuantity")
                        .HasColumnType("int");

                    b.Property<int>("InventoryQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("InventoryId");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("DynamicStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("StoreId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DynamicStore.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("DynamicStore.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DynamicStore.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("DynamicStore.Models.ProductStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductStores");
                });

            modelBuilder.Entity("DynamicStore.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("StoreAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("DynamicStore.Models.StorePermission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"));

                    b.Property<bool>("CanAddProducts")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteProducts")
                        .HasColumnType("bit");

                    b.Property<bool>("CanEditOrders")
                        .HasColumnType("bit");

                    b.Property<bool>("CanEditProducts")
                        .HasColumnType("bit");

                    b.Property<bool>("CanViewOrders")
                        .HasColumnType("bit");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PermissionId");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("StorePermissions");
                });

            modelBuilder.Entity("DynamicStore.Models.StoreStatistics", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("total_categories")
                        .HasColumnType("int");

                    b.Property<int>("total_inventory")
                        .HasColumnType("int");

                    b.Property<int>("total_orders")
                        .HasColumnType("int");

                    b.Property<int>("total_products")
                        .HasColumnType("int");

                    b.Property<decimal>("total_sales")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("StoreId");

                    b.ToTable("StoreStatistics");
                });

            modelBuilder.Entity("DynamicStore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DynamicStore.Models.UserStorePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserStorePermissions");
                });

            modelBuilder.Entity("DynamicStore.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"));

                    b.Property<string>("WarehouseAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehousePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WarehouseId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("DynamicStore.Models.Category", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", null)
                        .WithMany("Categories")
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("DynamicStore.Models.CategoryStore", b =>
                {
                    b.HasOne("DynamicStore.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.Employee", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.EmployeeAttendance", b =>
                {
                    b.HasOne("DynamicStore.Models.Employee", "Employee")
                        .WithMany("EmployeeAttendances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DynamicStore.Models.Finance", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Stores")
                        .WithMany("Finances")
                        .HasForeignKey("store_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stores");
                });

            modelBuilder.Entity("DynamicStore.Models.Inventory", b =>
                {
                    b.HasOne("DynamicStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicStore.Models.Warehouse", "Warehouse")
                        .WithMany("Inventories")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DynamicStore.Models.Order", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.OrderItem", b =>
                {
                    b.HasOne("DynamicStore.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DynamicStore.Models.Product", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", null)
                        .WithMany("Products")
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("DynamicStore.Models.ProductCategory", b =>
                {
                    b.HasOne("DynamicStore.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DynamicStore.Models.ProductStore", b =>
                {
                    b.HasOne("DynamicStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.StorePermission", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany("Permissions")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicStore.Models.User", null)
                        .WithMany("Permissions")
                        .HasForeignKey("UserId");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.StoreStatistics", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithOne("StoreStatistics")
                        .HasForeignKey("DynamicStore.Models.StoreStatistics", "StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.UserStorePermission", b =>
                {
                    b.HasOne("DynamicStore.Models.StorePermission", "StorePermission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicStore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StorePermission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DynamicStore.Models.Employee", b =>
                {
                    b.Navigation("EmployeeAttendances");
                });

            modelBuilder.Entity("DynamicStore.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("DynamicStore.Models.Store", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Finances");

                    b.Navigation("Orders");

                    b.Navigation("Permissions");

                    b.Navigation("Products");

                    b.Navigation("StoreStatistics")
                        .IsRequired();
                });

            modelBuilder.Entity("DynamicStore.Models.User", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("DynamicStore.Models.Warehouse", b =>
                {
                    b.Navigation("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
