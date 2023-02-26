using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryStoreController : ControllerBase
    {
        private readonly ICategoryStoreRepository _categoryStoreRepository;

        public CategoryStoreController(ICategoryStoreRepository categoryStoreRepository)
        {
            _categoryStoreRepository = categoryStoreRepository;
        }

        // GET: api/CategoryStore
        [HttpGet]
        public async Task<IEnumerable<CategoryStore>> GetCategoryStoresAsync()
        {
            return await _categoryStoreRepository.GetCategoryStoresAsync();
        }

        // GET: api/CategoryStore/ByCategory/{categoryId}
        [HttpGet("ByCategory/{categoryId}")]
        public async Task<IEnumerable<Store>> GetStoresByCategoryIdAsync(int categoryId)
        {
            return await _categoryStoreRepository.GetStoresByCategoryIdAsync(categoryId);
        }

        // GET: api/CategoryStore/ByStore/{storeId}
        [HttpGet("ByStore/{storeId}")]
        public async Task<IEnumerable<Category>> GetCategoriesByStoreIdAsync(int storeId)
        {
            return await _categoryStoreRepository.GetCategoriesByStoreIdAsync(storeId);
        }

        // GET: api/CategoryStore/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryStore>> GetCategoryStoreByIdAsync(int id)
        {
            var categoryStore = await _categoryStoreRepository.GetCategoryStoreByIdAsync(id);

            if (categoryStore == null)
            {
                return NotFound();
            }

            return categoryStore;
        }

        // POST: api/CategoryStore
        [HttpPost]
        public async Task<ActionResult<CategoryStore>> AddCategoryStoreAsync(CategoryStore categoryStore)
        {
            var addedCategoryStore = await _categoryStoreRepository.AddCategoryStoreAsync(categoryStore);

            return CreatedAtAction(nameof(GetCategoryStoreByIdAsync), new { id = addedCategoryStore.Id }, addedCategoryStore);
        }

        // PUT: api/CategoryStore/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryStoreAsync(int id, CategoryStore categoryStore)
        {
            if (id != categoryStore.Id)
            {
                return BadRequest();
            }

            var existingCategoryStore = await _categoryStoreRepository.GetCategoryStoreByIdAsync(id);

            if (existingCategoryStore == null)
            {
                return NotFound();
            }

            if (categoryStore.CategoryId == null)
            {
                categoryStore.CategoryId = existingCategoryStore.CategoryId;
            }

            if (categoryStore.StoreId == null)
            {
                categoryStore.StoreId = existingCategoryStore.StoreId;
            }

            await _categoryStoreRepository.UpdateCategoryStoreAsync(id, categoryStore);

            return NoContent();
        }

        // DELETE: api/CategoryStore/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryStoreAsync(int id)
        {
            var categoryStore = await _categoryStoreRepository.GetCategoryStoreByIdAsync(id);

            if (categoryStore == null)
            {
                return NotFound();
            }

            await _categoryStoreRepository.DeleteCategoryStoreAsync(id);

            return NoContent();
        }
    }
}
