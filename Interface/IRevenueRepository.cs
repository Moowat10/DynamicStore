using DynamicStoreBackend.Models;

namespace DynamicStoreBackend.Repositories
{
    public interface IRevenueRepository
    {
        Revenue GetById(int id);
        IEnumerable<Revenue> GetAll();
        IEnumerable<Revenue> GetRevenuesForProduct(int productId, DateTime startDate, DateTime endDate);
        void Add(Revenue revenue);
        void Update(Revenue revenue);
        void Delete(Revenue revenue);
    }
}
