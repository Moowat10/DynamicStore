using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;


namespace DynamicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            var products = await _productServices.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await _productServices.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProductAsync(Product product)
        {
            var addedProduct = await _productServices.AddProductAsync(product);
            return Ok(addedProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProductAsync(int id, Product product)
        {
         
            var updatedProduct = await _productServices.UpdateProductAsync(id, product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProductAsync(int id)
        {
            var deleted = await _productServices.DeleteProductAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok(deleted);
        }
    }
}
