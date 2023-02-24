using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public CategoryController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _dbContext.Categories.FindAsync(categoryId);
        }
        [HttpPost]
        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
        [HttpPut("{id}")]
        public async Task<Category> UpdateCategoryAsync(int categoryId, Category category)
        {
            var existingCategory = await _dbContext.Categories.FindAsync(categoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.CategoryDescription = category.CategoryDescription;

                _dbContext.Categories.Update(existingCategory);
                await _dbContext.SaveChangesAsync();

                return existingCategory;
            }
            return null;
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var existingCategory = await _dbContext.Categories.FindAsync(categoryId);
            if (existingCategory != null)
            {
                _dbContext.Categories.Remove(existingCategory);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
