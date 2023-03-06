using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicStore.DTO;
using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Services;
using DynamicStore.Data;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreServices _storeServices;

        public StoreController(IStoreServices storeServices)
        {
            _storeServices = storeServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewStoreDTO>>> GetStoresAsync()
        {
            var stores = await _storeServices.GetStoresAsync();
            return Ok(stores);
        }

        [HttpGet("{storeId}")]
        public async Task<ActionResult<NewStoreDTO>> GetStoreByIdAsync(int storeId)
        {
            var store = await _storeServices.GetStoreByIdAsync(storeId);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult<NewStoreDTO>> AddStoreAsync(NewStoreDTO StoreDTO)
        {

            var newStore = await _storeServices.AddStoreAsync(StoreDTO);


            return CreatedAtAction(nameof(GetStoreByIdAsync), new { storeId = newStore.StoreId }, newStore);
        }

        [HttpPut("{storeId}")]
        public async Task<ActionResult<NewStoreDTO>> UpdateStoreAsync(int storeId, UpdateStoreDTO store)
        {
            if (storeId != store.StoreId)
            {
                return BadRequest();
            }

            var updatedStore = await _storeServices.UpdateStoreAsync(storeId, store);

            return Ok(updatedStore);
        }

        [HttpDelete("{storeId}")]
        public async Task<ActionResult> DeleteStoreAsync(int storeId)
        {
            var result = await _storeServices.DeleteStoreAsync(storeId);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}