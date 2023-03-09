using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<Category>> GetProductCategoriesByProductIdAsync(int productId);
        Task<IEnumerable<Product>> GetProductCategoriesByCategoryIdAsync(int categoryId);
    }
}
