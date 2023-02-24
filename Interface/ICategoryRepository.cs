using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(int categoryId, Category category);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
