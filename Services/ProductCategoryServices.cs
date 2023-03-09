using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Interface;
using DynamicStore.Repository;
using DynamicStore.Models;

namespace DynamicStore.Services
{
    public class ProductCategoryServices : IProductCategoryServices
    {
        private readonly ProductCategoryRepository _repository;

        public ProductCategoryServices(ProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync()
        {
            var productCategories = await _repository.GetAllAsync();
            return productCategories;
        }

        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id)
        {
            var productCategory = await _repository.GetByIdAsync(id);
            return productCategory;
        }

        public async Task<ProductCategory> AddProductCategoryAsync(ProductCategory productCategory)
        {
            var createdProductCategory = await _repository.AddAsync(productCategory);
            return createdProductCategory;
        }

        public async Task<ProductCategory> UpdateProductCategoryAsync(int id, ProductCategory productCategory)
        {
            var existingProductCategory = await _repository.GetByIdAsync(id);

            if (existingProductCategory == null)
            {
                return null;
            }

            if (productCategory.CategoryId != 0)
            {
                existingProductCategory.CategoryId = productCategory.CategoryId;
            }

            if (productCategory.ProductId != 0)
            {
                existingProductCategory.ProductId = productCategory.ProductId;
            }

            var updatedProductCategory = await _repository.UpdateAsync(id, existingProductCategory);
            return updatedProductCategory;
        }

        public async Task<bool> DeleteProductCategoryAsync(int id)
        {
            var existingProductCategory = await _repository.GetByIdAsync(id);

            if (existingProductCategory == null)
            {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }
          public async Task<IEnumerable<Category>> GetProductCategoriesByProductIdAsync(int productId)
        {
            return await _repository.GetProductCategoriesByProductIdAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetProductCategoriesByCategoryIdAsync(int categoryId)
        {
             return await _repository.GetProductCategoriesByCategoryIdAsync(categoryId);
        }
    }
}
