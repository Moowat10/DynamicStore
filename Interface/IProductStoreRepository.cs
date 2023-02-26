using DynamicStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IProductStoreRepository
    {
        Task<IEnumerable<ProductStore>> GetProductStoresAsync();
        Task<IEnumerable<ProductStore>> GetProductStoresByProductIdAsync(int productId);
        Task<IEnumerable<ProductStore>> GetProductStoresByStoreIdAsync(int storeId);
        Task<ProductStore> GetProductStoreByIdAsync(int id);
        Task<ProductStore> AddProductStoreAsync(ProductStore productStore);
        Task<ProductStore> UpdateProductStoreAsync(int id, ProductStore productStore);
        Task<bool> DeleteProductStoreAsync(int id);
    }
}
