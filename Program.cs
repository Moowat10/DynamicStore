using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Repository;
using DynamicStore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductCategoryServices, ProductCategoryServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICategoryStoreServices, CategoryStoreServices>();
builder.Services.AddScoped<IProductStoreServices, ProductStoreServices>();
builder.Services.AddScoped<IRevenueServices, RevenueServices>();
builder.Services.AddScoped<IStorePermissionServices, StorePermissionServices>();
builder.Services.AddScoped<IUserStorePermissionServices, UserStorePermissionsServices>();
builder.Services.AddScoped<IStoreServices, StoreServices>();
builder.Services.AddScoped<IWarehouseServices, WarehouseServices>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IEmployeeAttendanceServices, EmployeeAttendanceServices>();
builder.Services.AddScoped<IStoreStatisticsServices, StoreStatisticsServices>();
builder.Services.AddScoped<IInventoryServices, InventoryServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryStoreRepository, CategoryStoreRepository>();
builder.Services.AddScoped<IProductStoreRepository, ProductStoreRepository>();
builder.Services.AddScoped<IRevenueRepository, RevenueRepository>();
builder.Services.AddScoped<IStorePermissionRepository, StorePermissionRepository>();
builder.Services.AddScoped<IUserStorePermissionRepository, UserStorePermissionRepository>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeAttendanceRepository, EmployeeAttendanceRepository>();
builder.Services.AddScoped<IStoreStatisticsRepository, StoreStatisticsRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
