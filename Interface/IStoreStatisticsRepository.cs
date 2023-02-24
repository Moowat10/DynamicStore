using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IStoreStatisticsRepository
    {
        Task<List<StoreStatistics>> GetAllStoreStatisticsAsync();
        Task<StoreStatistics> GetStoreStatisticsByIdAsync(int id);
        Task<StoreStatistics> CreateStoreStatisticsAsync(StoreStatistics storeStatistics);
        Task<StoreStatistics> UpdateStoreStatisticsAsync(StoreStatistics storeStatistics);
        Task DeleteStoreStatisticsAsync(StoreStatistics storeStatistics);
        Task<int> GetTotalProductsAsync(int storeId);
        Task<int> GetTotalCategoriesAsync(int storeId);
        Task<decimal> GetTotalSalesAsync(int storeId);
        Task<int> GetTotalOrdersAsync(int storeId);
    }
}
