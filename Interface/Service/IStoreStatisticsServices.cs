using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IStoreStatisticsServices
    {
        Task<IEnumerable<StoreStatistics>> GetAllStoreStatisticsAsync();
        Task<StoreStatistics> GetStoreStatisticsByIdAsync(int id);
        Task<StoreStatistics> CreateStoreStatisticsAsync(StoreStatistics storeStatistics);
        Task<StoreStatistics> UpdateStoreStatisticsAsync(int id, StoreStatistics storeStatistics);
        Task<bool> DeleteStoreStatisticsAsync(int id);
        Task<int> GetTotalProductsAsync(int storeId);
        Task<int> GetTotalCategoriesAsync(int storeId);
        Task<decimal> GetTotalSalesAsync(int storeId);
        Task<int> GetTotalOrdersAsync(int storeId);
    }
}
