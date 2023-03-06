using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class StoreStatisticsRepository : Repository<StoreStatistics>, IStoreStatisticsRepository
{

    public StoreStatisticsRepository(DataContext context) : base(context)   
    {
    
    }

    public async Task<int> GetTotalProductsAsync(int storeId)
    {
        return await this._context.ProductStores.CountAsync(x => x.StoreId == storeId);
    }

    public async Task<int> GetTotalCategoriesAsync(int storeId)
    {
        return await this._context.CategoryStores.CountAsync(x => x.StoreId == storeId);
    }

    public async Task<decimal> GetTotalSalesAsync(int storeId)
    {
        return await this._context.OrderItems.Where(x => x.Order.StoreId == storeId).SumAsync(x => x.Price * x.Quantity);
    }

    public async Task<int> GetTotalOrdersAsync(int storeId)
    {
        return await this._context.Orders.CountAsync(x => x.StoreId == storeId);
    }
}