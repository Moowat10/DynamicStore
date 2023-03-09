using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace DynamicStore.Services
{
    
    public class CategoryServices : ICategoryServices
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryServices(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        
        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetByIdAsync(categoryId);
           
        }
    
        public async Task<Category> AddCategoryAsync(Category category)
        {
            return await _categoryRepository.AddAsync(category);
        }
       
        public async Task<Category> UpdateCategoryAsync(int categoryId, Category category)
        {
               var existingCategory = await _categoryRepository.GetByIdAsync(categoryId);

            if (existingCategory == null)
            {
                return null;
            }

            if (category.CategoryDescription != null)
            {
                existingCategory.CategoryDescription = category.CategoryDescription;
            }

            if (category.CategoryName != null)
            {
                existingCategory.CategoryName = category.CategoryName;
            }

            return await _categoryRepository.UpdateAsync(categoryId, existingCategory);
        }
      
        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                return false;
            }

            await _categoryRepository.DeleteAsync(categoryId);

            return true;
        }
    }
}
