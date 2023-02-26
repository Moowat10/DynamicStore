using DynamicStore.Models;
using DynamicStoreBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Data
{
    public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }

            // Define the DbSets
            public DbSet<Store> Stores { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Warehouse> Warehouses { get; set; }
            public DbSet<Inventory> Inventory { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderItem> OrderItems { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<StorePermission> StorePermissions { get; set; }
            public DbSet<UserStorePermission> UserStorePermissions { get; set; }

            public DbSet<ProductCategory> ProductCategories { get; set; }
            public DbSet<ProductStore> ProductStores { get; set; }
            public DbSet<CategoryStore> CategoryStores { get; set; }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
            public DbSet<Finance> Finances { get; set; }
            public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Tax> Taxes { get; set; }

        public DbSet<StoreStatistics> StoreStatistics { get; set; }
        }
}
