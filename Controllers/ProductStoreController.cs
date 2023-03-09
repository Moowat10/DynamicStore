using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductStoreController : ControllerBase
    {
        private readonly IProductStoreServices _productStoreServices;

        public ProductStoreController(IProductStoreServices services){
            _productStoreServices = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductStore>>> GetProductStores()
        {
            var productStores = await _productStoreServices.GetProductStoresAsync();
            return Ok(productStores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductStore>> GetProductStoreById(int id)
        {
            var productStore = await _productStoreServices.GetProductStoreByIdAsync(id);
            if (productStore == null)
            {
                return NotFound();
            }
            return Ok(productStore);
        }

        [HttpPost]
        public async Task<ActionResult<ProductStore>> AddProductStore(ProductStore productStore)
        {
            var newProductStore = await _productStoreServices.AddProductStoreAsync(productStore);
            return Ok(newProductStore);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductStore>> UpdateProductStoreAsync(int id, ProductStore productStore)
        {
            var updatedProductStore = await _productStoreServices.UpdateProductStoreAsync(id, productStore);
            if(updatedProductStore == null)
            {
                return NotFound();
            }
            return Ok(updatedProductStore);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProductStoreAsync(int id)
        {
            var deleted = await _productStoreServices.DeleteProductStoreAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
