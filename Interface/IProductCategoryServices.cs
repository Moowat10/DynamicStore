using DynamicStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IProductCategoryServices
    {
        Task<IEnumerable<ProductCategory>> GetProductCategoriesAsync();
        Task<IEnumerable<Category>> GetProductCategoriesByProductIdAsync(int productId);
        Task<IEnumerable<Product>> GetProductCategoriesByCategoryIdAsync(int categoryId);
        Task<ProductCategory> GetProductCategoryByIdAsync(int id);
        Task<ProductCategory> AddProductCategoryAsync(ProductCategory productCategory);
        Task<ProductCategory> UpdateProductCategoryAsync(int id, ProductCategory productCategory);
        Task<bool> DeleteProductCategoryAsync(int id);
    }
}
