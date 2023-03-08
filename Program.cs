using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Repository;
using DynamicStoreBackend.Repositories;
using DynamicStoreBackend.Services;
using DynamicStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<StoreRepository>();
builder.Services.AddScoped<IStoreServices, StoreServices>();
builder.Services.AddScoped<StorePermissionRepository>();
builder.Services.AddScoped<IStorePermissionServices, StorePermissionServices>();
builder.Services.AddScoped<RevenueRepository>();
builder.Services.AddScoped<IRevenueServices, RevenueServices>();
builder.Services.AddScoped<StoreStatisticsRepository>();
builder.Services.AddScoped<IStoreStatisticsServices, StoreStatisticsServices>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
