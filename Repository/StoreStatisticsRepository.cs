using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class StoreStatisticsRepository : IStoreStatisticsRepository
{
    private readonly DataContext _dbContext;

    public StoreStatisticsRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<StoreStatistics>> GetAllStoreStatisticsAsync()
    {
        return await _dbContext.StoreStatistics.ToListAsync();
    }

    public async Task<StoreStatistics> GetStoreStatisticsByIdAsync(int id)
    {
        return await _dbContext.StoreStatistics.FirstOrDefaultAsync(x => x.StoreId== id);
    }

    public async Task<StoreStatistics> CreateStoreStatisticsAsync(StoreStatistics storeStatistics)
    {
        _dbContext.StoreStatistics.Add(storeStatistics);
        await _dbContext.SaveChangesAsync();
        return storeStatistics;
    }

    public async Task<StoreStatistics> UpdateStoreStatisticsAsync(StoreStatistics storeStatistics)
    {
        _dbContext.StoreStatistics.Update(storeStatistics);
        await _dbContext.SaveChangesAsync();
        return storeStatistics;
    }

    public async Task DeleteStoreStatisticsAsync(StoreStatistics storeStatistics)
    {
        _dbContext.StoreStatistics.Remove(storeStatistics);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> GetTotalProductsAsync(int storeId)
    {
        return await _dbContext.ProductStores.CountAsync(x => x.StoreId == storeId);
    }

    public async Task<int> GetTotalCategoriesAsync(int storeId)
    {
        return await _dbContext.CategoryStores.CountAsync(x => x.StoreId == storeId);
    }

    public async Task<decimal> GetTotalSalesAsync(int storeId)
    {
        return await _dbContext.OrderItems.Where(x => x.Order.StoreId == storeId).SumAsync(x => x.Price * x.Quantity);
    }

    public async Task<int> GetTotalOrdersAsync(int storeId)
    {
        return await _dbContext.Orders.CountAsync(x => x.StoreId == storeId);
    }
}