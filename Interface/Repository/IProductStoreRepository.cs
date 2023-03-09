using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IProductStoreRepository : IRepository<ProductStore>
    {
        Task<IEnumerable<ProductStore>> GetProductStoresByProductIdAsync(int productId);
        Task<IEnumerable<ProductStore>> GetProductStoresByStoreIdAsync(int storeId);
    }
}
