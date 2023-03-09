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
        private readonly ICategoryStoreServices _categoryStoreServices;

        public CategoryStoreController(ICategoryStoreServices categoryStoreServices)
        {
            _categoryStoreServices = categoryStoreServices;
        }

        // GET: api/CategoryStore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetCategoryStoresAsync()
        {
            var categoryStores = await _categoryStoreServices.GetCategoryStoresAsync();

            if (categoryStores == null)
            {
                return NotFound();
            }

            return Ok(categoryStores);
        }

        // GET: api/CategoryStore/ByCategory/{categoryId}
        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Store>>> GetStoresByCategoryIdAsync(int categoryId)
        {
             var categoryStores = await _categoryStoreServices.GetStoresByCategoryIdAsync(categoryId);

            if (categoryStores == null)
            {
                return NotFound();
            }

            return Ok(categoryStores);
        }

        // GET: api/CategoryStore/ByStore/{storeId}
        [HttpGet("ByStore/{storeId}")]
        public async  Task<ActionResult<IEnumerable<Store>>> GetCategoriesByStoreIdAsync(int storeId)
        {
             var categoryStores = await _categoryStoreServices.GetCategoriesByStoreIdAsync(storeId);

            if (categoryStores == null)
            {
                return NotFound();
            }

            return Ok(categoryStores);
            
        }

        // GET: api/CategoryStore/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryStore>> GetCategoryStoreByIdAsync(int id)
        {
            var categoryStore = await _categoryStoreServices.GetCategoryStoreByIdAsync(id);

            if (categoryStore == null)
            {
                return NotFound();
            }

            return Ok(categoryStore);
        }

        // POST: api/CategoryStore
        [HttpPost]
        public async Task<ActionResult<CategoryStore>> AddCategoryStoreAsync(CategoryStore categoryStore)
        {
            var addedCategoryStore = await _categoryStoreServices.AddCategoryStoreAsync(categoryStore);

            return Ok(addedCategoryStore);
        }

        // PUT: api/CategoryStore/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryStore>> UpdateCategoryStoreAsync(int id, CategoryStore categoryStore)
        {
            if (id != categoryStore.Id)
            {
                return BadRequest();
            }

            var existingCategoryStore =  await _categoryStoreServices.UpdateCategoryStoreAsync(id, categoryStore);

            if(existingCategoryStore == null)
            {
                NotFound();
            }

            return Ok(existingCategoryStore);
        }

        // DELETE: api/CategoryStore/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryStoreAsync(int id)
        {
            var categoryStore = await _categoryStoreServices.DeleteCategoryStoreAsync(id);

            if (!categoryStore)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
