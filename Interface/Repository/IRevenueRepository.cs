using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IRevenueRepository : IRepository<Revenue>
    {
        Task<IEnumerable<Revenue>> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate);
    
    }
}
