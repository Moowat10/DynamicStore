using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface ICategoryStoreRepository
    {
        Task<IEnumerable<Store>> GetStoresByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Category>> GetCategoriesByStoreIdAsync(int storeId);
    }
}
