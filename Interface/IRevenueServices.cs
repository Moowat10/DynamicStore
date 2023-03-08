using DynamicStoreBackend.Models;

namespace DynamicStoreBackend.Repositories
{
    public interface IRevenueServices
    {
        Task<IEnumerable<Revenue>> GetAllRevenueAsync();
        Task<Revenue> GetRevenueByIdAsync(int revenueId);
        Task<Revenue> AddRevenueAsync(Revenue revenue);
        Task<Revenue> UpdateRevenueAsync(int revenueId, Revenue revenue);
        Task<bool> DeleteRevenueAsync(int revenueId);
        Task<IEnumerable<Revenue>> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate);
    
    }
}
