using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicStore.Repository
{
    public class CategoryStoreRepository : ICategoryStoreRepository
    {
        private readonly DataContext _context;

        public CategoryStoreRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryStore>> GetCategoryStoresAsync()
        {
            return await _context.CategoryStores
                .Include(cs => cs.Category)
                .Include(cs => cs.Store)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByStoreIdAsync(int storeId)
        {
            var categoryIds = await _context.CategoryStores
                .Where(cs => cs.StoreId == storeId)
                .Select(cs => cs.CategoryId)
                .ToListAsync();

            return await _context.Categories
                .Where(c => categoryIds.Contains(c.CategoryId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Store>> GetStoresByCategoryIdAsync(int categoryId)
        {
            var storeIds = await _context.CategoryStores
                .Where(cs => cs.CategoryId == categoryId)
                .Select(cs => cs.StoreId)
                .ToListAsync();

            return await _context.Stores
                .Where(s => storeIds.Contains(s.StoreId))
                .ToListAsync();
        }

        public async Task<CategoryStore> GetCategoryStoreByIdAsync(int id)
        {
            return await _context.CategoryStores
                .Include(cs => cs.Category)
                .Include(cs => cs.Store)
                .FirstOrDefaultAsync(cs => cs.Id == id);
        }

        public async Task<CategoryStore> AddCategoryStoreAsync(CategoryStore categoryStore)
        {
            _context.CategoryStores.Add(categoryStore);
            await _context.SaveChangesAsync();
            return categoryStore;
        }

        public async Task<CategoryStore> UpdateCategoryStoreAsync(int id, CategoryStore categoryStore)
        {
            var existingCategoryStore = await _context.CategoryStores.FindAsync(id);

            if (existingCategoryStore == null)
            {
                return null;
            }

            existingCategoryStore.CategoryId = categoryStore.CategoryId != 0 ? categoryStore.CategoryId : existingCategoryStore.CategoryId;
            existingCategoryStore.StoreId = categoryStore.StoreId != 0 ? categoryStore.StoreId : existingCategoryStore.StoreId;

            await _context.SaveChangesAsync();
            return existingCategoryStore;
        }

        public async Task<bool> DeleteCategoryStoreAsync(int id)
        {
            var categoryStore = await _context.CategoryStores.FindAsync(id);

            if (categoryStore == null)
            {
                return false;
            }

            _context.CategoryStores.Remove(categoryStore);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
