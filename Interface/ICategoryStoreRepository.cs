using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface ICategoryStoreRepository
    {
        Task<IEnumerable<CategoryStore>> GetCategoryStoresAsync();
        Task<IEnumerable<Store>> GetStoresByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Category>> GetCategoriesByStoreIdAsync(int storeId);
        Task<CategoryStore> GetCategoryStoreByIdAsync(int id);
        Task<CategoryStore> AddCategoryStoreAsync(CategoryStore categoryStore);
        Task<CategoryStore> UpdateCategoryStoreAsync(int id, CategoryStore categoryStore);
        Task<bool> DeleteCategoryStoreAsync(int id);
    }
}
