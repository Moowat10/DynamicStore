using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Repository;

namespace DynamicStore.Services
{
    public class CategoryStoreServices : ICategoryStoreServices
    {
        private readonly CategoryStoreRepository _categoryStoreRepository;

        public CategoryStoreServices(CategoryStoreRepository categoryStoreRepository)
        {
            _categoryStoreRepository = categoryStoreRepository;
        }

        public async Task<IEnumerable<CategoryStore>> GetCategoryStoresAsync()
        {
            return await _categoryStoreRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Store>> GetStoresByCategoryIdAsync(int categoryId)
        {
            return await _categoryStoreRepository.GetStoresByCategoryIdAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategoriesByStoreIdAsync(int storeId)
        {
            return await _categoryStoreRepository.GetCategoriesByStoreIdAsync(storeId);
        }

        public async Task<CategoryStore> GetCategoryStoreByIdAsync(int id)
        {
            return await _categoryStoreRepository.GetByIdAsync(id);
        }

        public async Task<CategoryStore> AddCategoryStoreAsync(CategoryStore categoryStore)
        {
            return await _categoryStoreRepository.AddAsync(categoryStore);
        }

        public async Task<CategoryStore> UpdateCategoryStoreAsync(int id, CategoryStore categoryStore)
        {
            var existingCategoryStore = await _categoryStoreRepository.GetByIdAsync(id);

            if (existingCategoryStore == null)
            {
                return null;
            }

            if (categoryStore.CategoryId != 0)
            {
                categoryStore.CategoryId = existingCategoryStore.CategoryId;
            }

            if (categoryStore.StoreId != 0)
            {
                categoryStore.StoreId = existingCategoryStore.StoreId;
            }

            return await _categoryStoreRepository.UpdateAsync(id, categoryStore);
        }

        public async Task<bool> DeleteCategoryStoreAsync(int id)
        {
            var categoryStore = await _categoryStoreRepository.GetByIdAsync(id);

            if (categoryStore == null)
            {
                return false;
            }

            await _categoryStoreRepository.DeleteAsync(id);

            return true;
        }
    }
}
