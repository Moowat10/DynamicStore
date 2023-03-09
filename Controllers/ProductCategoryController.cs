using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryServices _productCategoryServices;

        public ProductCategoryController(IProductCategoryServices Services)
        {
            _productCategoryServices = Services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategoriesAsync()
        {
            var productCategories = await _productCategoryServices.GetProductCategoriesAsync();
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategoryByIdAsync(int id)
        {
            var productCategory = await _productCategoryServices.GetProductCategoryByIdAsync(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }
        [HttpGet("{productId}")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategoriesByProductIdAsync(int productId)
        {
            var productCategories = await _productCategoryServices.GetProductCategoriesByProductIdAsync(productId);

            if (productCategories == null)
            {
                return NotFound();
            }

            return Ok(productCategories);
        }
         [HttpGet("{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategoriesByCategoryIdAsync(int categoryId)
        {
            var categoryProducts = await _productCategoryServices.GetProductCategoriesByCategoryIdAsync(categoryId);

            if (categoryProducts == null)
            {
                return NotFound();
            }

            return Ok(categoryProducts);
        }
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> AddProductCategoryAsync(ProductCategory productCategory)
        {
            var createdProductCategory = await _productCategoryServices.AddProductCategoryAsync(productCategory);
            return Ok(createdProductCategory);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductCategory>> UpdateProductCategoryAsync(int id, ProductCategory productCategory)
        {
            var updatedProductCategory = await _productCategoryServices.UpdateProductCategoryAsync(id, productCategory);

            if (updatedProductCategory == null)
            {
                return NotFound();
            }
           
            return Ok(updatedProductCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductCategoryAsync(int id)
        {
            var existingProductCategory =  await _productCategoryServices.DeleteProductCategoryAsync(id);

            if (!existingProductCategory)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
