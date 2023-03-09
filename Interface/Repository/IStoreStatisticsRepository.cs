
namespace DynamicStore.Interface
{
    public interface IStoreStatisticsRepository
    {
        Task<int> GetTotalProductsAsync(int storeId);
        Task<int> GetTotalCategoriesAsync(int storeId);
        Task<decimal> GetTotalSalesAsync(int storeId);
        Task<int> GetTotalOrdersAsync(int storeId);
    }
}
