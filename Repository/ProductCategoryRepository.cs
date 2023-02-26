using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicStore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DataContext _context;

        public ProductCategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync()
        {
            return await _context.ProductCategories
                .Include(pc => pc.Product)
                .Include(pc => pc.Category)
                .ToListAsync();
        }

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

        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        public async Task<ProductCategory> AddProductCategoryAsync(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();
            return productCategory;
        }

        public async Task<ProductCategory> UpdateProductCategoryAsync(int id, ProductCategory productCategory)
        {
            var existingProductCategory = await _context.ProductCategories.FindAsync(id);

            if (existingProductCategory != null)
            {
                existingProductCategory.ProductId = productCategory.ProductId;
                existingProductCategory.CategoryId = productCategory.CategoryId;
                await _context.SaveChangesAsync();
            }

            return existingProductCategory;
        }

        public async Task<bool> DeleteProductCategoryAsync(int id)
        {
            var existingProductCategory = await _context.ProductCategories.FindAsync(id);

            if (existingProductCategory != null)
            {
                _context.ProductCategories.Remove(existingProductCategory);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
