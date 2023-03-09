using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Repository;
using DynamicStore.Repositories;
using DynamicStoreBackend.Repositories;
using DynamicStoreBackend.Services;
using DynamicStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductCategoryServices, ProductCategoryServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICategoryStoreServices, CategoryStoreServices>();
builder.Services.AddScoped<IProductStoreServices, ProductStoreServices>();
builder.Services.AddScoped<IRevenueServices, RevenueServices>();
builder.Services.AddScoped<IStorePermissionServices, StorePermissionServices>();
builder.Services.AddScoped<IStoreServices, StoreServices>();
builder.Services.AddScoped<IWarehouseServices, WarehouseServices>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IEmployeeAttendanceServices, EmployeeAttendanceServices>();
builder.Services.AddScoped<IStoreStatisticsServices, StoreStatisticsServices>();
builder.Services.AddScoped<IInventoryServices, InventoryServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductCategoryRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryStoreRepository>();
builder.Services.AddScoped<ProductStoreRepository>();
builder.Services.AddScoped<RevenueRepository>();
builder.Services.AddScoped<StorePermissionRepository>();
builder.Services.AddScoped<StoreRepository>();
builder.Services.AddScoped<WarehouseRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeAttendanceRepository>();
builder.Services.AddScoped<StoreStatisticsRepository>();
builder.Services.AddScoped<InventoryRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<OrderItemRepository>();
builder.Services.AddScoped<UserRepository>();
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
