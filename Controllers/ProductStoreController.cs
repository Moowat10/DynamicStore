using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductStoreController : ControllerBase
    {
        private readonly IProductStoreRepository _repository;

        public ProductStoreController(IProductStoreRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductStore>>> GetProductStores()
        {
            var productStores = await _repository.GetProductStoresAsync();
            return Ok(productStores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductStore>> GetProductStoreById(int id)
        {
            var productStore = await _repository.GetProductStoreByIdAsync(id);
            if (productStore == null)
            {
                return NotFound();
            }
            return Ok(productStore);
        }

        [HttpPost]
        public async Task<ActionResult<ProductStore>> AddProductStore(ProductStore productStore)
        {
            var newProductStore = await _repository.AddProductStoreAsync(productStore);
            return CreatedAtAction(nameof(GetProductStoreById), new { id = newProductStore.Id }, newProductStore);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductStore>> UpdateProductStoreAsync(int id, ProductStore productStore)
        {
            var existingProductStore = await _repository.GetProductStoreByIdAsync(id);

            if (existingProductStore == null)
            {
                return NotFound();
            }

            if (productStore.ProductId != null)
            {
                existingProductStore.ProductId = productStore.ProductId;
            }

            if (productStore.StoreId != null)
            {
                existingProductStore.StoreId = productStore.StoreId;
            }

            var updatedProductStore = await _repository.UpdateProductStoreAsync(id, existingProductStore);
            return Ok(updatedProductStore);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProductStoreAsync(int id)
        {
            var deleted = await _repository.DeleteProductStoreAsync(id);
            if (deleted)
            {
                return Ok(true);
            }
            return NotFound();
        }
    }
}
