using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IProductStoreRepository
    {
        Task<IEnumerable<ProductStore>> GetProductStoresByProductIdAsync(int productId);
        Task<IEnumerable<ProductStore>> GetProductStoresByStoreIdAsync(int storeId);
    }
}
