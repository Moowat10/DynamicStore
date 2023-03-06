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
    [Migration("20230304222435_ssss")]
    partial class ssss
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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

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

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

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

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<decimal>("finance_amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("finance_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("finance_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("finance_type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("finance_id");

                    b.HasIndex("StoreId");

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

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("InventoryId");

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

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("InventoryId");

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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("DynamicStore.Models.StorePermission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"));

                    b.Property<bool>("CanAddEmployees")
                        .HasColumnType("bit");

                    b.Property<bool>("CanAddProducts")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteEmployees")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDeleteProducts")
                        .HasColumnType("bit");

                    b.Property<bool>("CanEditEmployees")
                        .HasColumnType("bit");

                    b.Property<bool>("CanEditOrders")
                        .HasColumnType("bit");

                    b.Property<bool>("CanEditProducts")
                        .HasColumnType("bit");

                    b.Property<bool>("CanViewOrders")
                        .HasColumnType("bit");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
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

                    b.HasIndex("UserId");

                    b.ToTable("UserStorePermissions");
                });

            modelBuilder.Entity("DynamicStore.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseId"));

                    b.Property<int>("AvailableCapacity")
                        .HasColumnType("int");

                    b.Property<int>("InventoriesCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<double>("LengthInMeters")
                        .HasColumnType("float");

                    b.Property<decimal>("PricePerSquareFoot")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("TotalCapacity")
                        .HasColumnType("int");

                    b.Property<string>("WarehouseAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseGeolocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarehousePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WidthInMeters")
                        .HasColumnType("float");

                    b.HasKey("WarehouseId");

                    b.HasIndex("StoreId");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("DynamicStore.Models.WarehouseImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseImage");
                });

            modelBuilder.Entity("DynamicStoreBackend.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("DynamicStoreBackend.Models.Payroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StoreId");

                    b.ToTable("Payrolls");
                });

            modelBuilder.Entity("DynamicStoreBackend.Models.Revenue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Revenues");
                });

            modelBuilder.Entity("DynamicStoreBackend.Models.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Taxes");
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
                    b.HasOne("DynamicStore.Models.Store", null)
                        .WithMany("Employees")
                        .HasForeignKey("StoreId");

                    b.HasOne("DynamicStore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany("Finances")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.Inventory", b =>
                {
                    b.HasOne("DynamicStore.Models.Warehouse", "Warehouse")
                        .WithMany("Inventories")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DynamicStore.Models.Order", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", null)
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("DynamicStore.Models.Inventory", null)
                        .WithMany("Products")
                        .HasForeignKey("InventoryId");

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

            modelBuilder.Entity("DynamicStore.Models.Store", b =>
                {
                    b.HasOne("DynamicStore.Models.User", null)
                        .WithMany("Stores")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DynamicStore.Models.StorePermission", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", null)
                        .WithMany("Permissions")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicStore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DynamicStore.Models.StoreStatistics", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.UserStorePermission", b =>
                {
                    b.HasOne("DynamicStore.Models.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DynamicStore.Models.Warehouse", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.WarehouseImage", b =>
                {
                    b.HasOne("DynamicStore.Models.Warehouse", "Warehouse")
                        .WithMany("Images")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DynamicStoreBackend.Models.Expense", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStoreBackend.Models.Payroll", b =>
                {
                    b.HasOne("DynamicStore.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStoreBackend.Models.Revenue", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStoreBackend.Models.Tax", b =>
                {
                    b.HasOne("DynamicStore.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DynamicStore.Models.Employee", b =>
                {
                    b.Navigation("EmployeeAttendances");
                });

            modelBuilder.Entity("DynamicStore.Models.Inventory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DynamicStore.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("DynamicStore.Models.Store", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Finances");

                    b.Navigation("Orders");

                    b.Navigation("Permissions");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DynamicStore.Models.User", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Stores");
                });

            modelBuilder.Entity("DynamicStore.Models.Warehouse", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
