using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repository
{
    public class ProductCategoryRepository : Repository<ProductCategory> ,IProductCategoryRepository
    {

        public ProductCategoryRepository(DataContext context): base(context) {}
       

           public async Task<IEnumerable<Category>> GetProductCategoriesByProductIdAsync(int productId)
        {
            return await _context.ProductCategories
                .Include(pc => pc.Category)
                .Where(pc => pc.ProductId == productId)
                .Select(pc => pc.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductCategoriesByCategoryIdAsync(int categoryId)
        {
            return await _context.ProductCategories
                .Include(pc => pc.Product)
                .Where(pc => pc.CategoryId == categoryId)
                .Select(pc => pc.Product)
                .ToListAsync();
        }
 }
}
