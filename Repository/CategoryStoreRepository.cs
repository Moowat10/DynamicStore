using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;


namespace DynamicStore.Repository
{
    public class CategoryStoreRepository : Repository<CategoryStore>, ICategoryStoreRepository
    {

        public CategoryStoreRepository(DataContext context) : base(context)
        {
           
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
}
}
