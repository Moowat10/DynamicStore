using DynamicStoreBackend.Models;

namespace DynamicStoreBackend.Repositories
{
    public interface IRevenueRepository
    {
        Task<IEnumerable<Revenue>> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate);
    
    }
}
