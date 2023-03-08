using DynamicStoreBackend.Models;
using DynamicStore.DTO;

namespace DynamicStoreBackend.Repositories
{
    public interface IRevenueServices
    {
        Task<IEnumerable<Revenue>> GetAllRevenueAsync();
        Task<Revenue> GetRevenueByIdAsync(int revenueId);
        Task<Revenue> AddRevenueAsync(Revenue revenue);
        Task<Revenue> UpdateRevenueAsync(int revenueId, RevenueDTO revenue);
        Task<bool> DeleteRevenueAsync(int revenueId);
        Task<IEnumerable<Revenue>> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate);
    
    }
}
