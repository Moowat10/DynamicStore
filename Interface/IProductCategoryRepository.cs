using DynamicStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<Category>> GetProductCategoriesByProductIdAsync(int productId);
        Task<IEnumerable<Product>> GetProductCategoriesByCategoryIdAsync(int categoryId);
    }
}
