using DynamicStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IProductStoreRepository
    {
        Task<IEnumerable<ProductStore>> GetProductStoresByProductIdAsync(int productId);
        Task<IEnumerable<ProductStore>> GetProductStoresByStoreIdAsync(int storeId);
    }
}
