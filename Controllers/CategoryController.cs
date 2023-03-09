using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;


namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAsync()
        {
            var category = await _categoryServices.GetCategoriesAsync();

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryServices.GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpPost]
        public async  Task<ActionResult<Category>> AddCategoryAsync(Category category)
        {
             var addedCategory = await _categoryServices.AddCategoryAsync(category);
            return Ok(addedCategory);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategoryAsync(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId)
            {
                return BadRequest();
            }

            var existingCategory =  await _categoryServices.UpdateCategoryAsync(categoryId, category);

            if(existingCategory == null)
            {
                NotFound();
            }

            return Ok(existingCategory);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryServices.DeleteCategoryAsync(categoryId);

            if (!category)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
