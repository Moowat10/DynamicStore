using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task<IEnumerable<Category>> GetProductCategoriesByProductIdAsync(int productId);
        Task<IEnumerable<Product>> GetProductCategoriesByCategoryIdAsync(int categoryId);
    }
}
