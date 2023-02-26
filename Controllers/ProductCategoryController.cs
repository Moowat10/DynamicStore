using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryController(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategoriesAsync()
        {
            var productCategories = await _repository.GetProductCategoriesAsync();
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategoryByIdAsync(int id)
        {
            var productCategory = await _repository.GetProductCategoryByIdAsync(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategory>> AddProductCategoryAsync(ProductCategory productCategory)
        {
            var createdProductCategory = await _repository.AddProductCategoryAsync(productCategory);
            return CreatedAtAction(nameof(AddProductCategoryAsync), new { id = createdProductCategory.Id }, createdProductCategory);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductCategory>> UpdateProductCategoryAsync(int id, ProductCategory productCategory)
        {
            var existingProductCategory = await _repository.GetProductCategoryByIdAsync(id);

            if (existingProductCategory == null)
            {
                return NotFound();
            }

            if (productCategory.CategoryId != 0)
            {
                existingProductCategory.CategoryId = productCategory.CategoryId;
            }

            if (productCategory.ProductId != 0)
            {
                existingProductCategory.ProductId = productCategory.ProductId;
            }

            var updatedProductCategory = await _repository.UpdateProductCategoryAsync(id, existingProductCategory);
            return Ok(updatedProductCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductCategoryAsync(int id)
        {
            var existingProductCategory = await _repository.GetProductCategoryByIdAsync(id);

            if (existingProductCategory == null)
            {
                return NotFound();
            }

            await _repository.DeleteProductCategoryAsync(id);
            return NoContent();
        }
    }
}
