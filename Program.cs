using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Repository;
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
builder.Services.AddScoped<IProductStoreServices, ProductStoreServices>();
builder.Services.AddScoped<IRevenueServices, RevenueServices>();
builder.Services.AddScoped<IStorePermissionServices, StorePermissionServices>();
builder.Services.AddScoped<IStoreServices, StoreServices>();
builder.Services.AddScoped<IStoreStatisticsServices, StoreStatisticsServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductStoreRepository>();
builder.Services.AddScoped<RevenueRepository>();
builder.Services.AddScoped<StorePermissionRepository>();
builder.Services.AddScoped<StoreRepository>();
builder.Services.AddScoped<StoreStatisticsRepository>();
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
