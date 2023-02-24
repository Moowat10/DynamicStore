using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;
using DynamicStore.DTO;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewStoreDTO>>> GetStoresAsync()
        {
            var stores = await _storeRepository.GetStoresAsync();
            var StoreDTOs = stores.Select(store => new NewStoreDTO
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                StoreAddress = store.StoreAddress,
                StoreEmail = store.StoreEmail,
                StorePhone = store.StorePhone
            }).ToList();

            return Ok(StoreDTOs);
        }

        [HttpGet("{storeId}")]
        public async Task<ActionResult<NewStoreDTO>> GetStoreByIdAsync(int storeId)
        {
            var store = await _storeRepository.GetStoreByIdAsync(storeId);
            if (store == null)
            {
                return NotFound();
            }

            var StoreDTO = new NewStoreDTO
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                StoreAddress = store.StoreAddress,
                StoreEmail = store.StoreEmail,
                StorePhone = store.StorePhone
            };

            return Ok(StoreDTO);
        }

        [HttpPost]
        public async Task<ActionResult<NewStoreDTO>> AddStoreAsync(NewStoreDTO StoreDTO)
        {
            var store = new Store
            {
                StoreName = StoreDTO.StoreName,
                StoreAddress = StoreDTO.StoreAddress,
                StoreEmail = StoreDTO.StoreEmail,
                StorePhone = StoreDTO.StorePhone
            };

            var newStore = await _storeRepository.AddStoreAsync(store);

            var newStoreDTO = new NewStoreDTO
            {
                StoreId = newStore.StoreId,
                StoreName = newStore.StoreName,
                StoreAddress = newStore.StoreAddress,
                StoreEmail = StoreDTO.StoreEmail,
                StorePhone = store.StorePhone
            };

            return CreatedAtAction(nameof(GetStoreByIdAsync), new { storeId = newStoreDTO.StoreId }, newStoreDTO);
        }

        [HttpPut("{storeId}")]
        public async Task<ActionResult<NewStoreDTO>> UpdateStoreAsync(int storeId, UpdateStoreDTO store)
        {
            if (storeId != store.StoreId)
            {
                return BadRequest();
            }

            var existingStore = await _storeRepository.GetStoreByIdAsync(storeId);

            if (existingStore == null)
            {
                return NotFound();
            }

            if (store.StoreName != null)
            {
                existingStore.StoreName = store.StoreName;
            }

            if (store.StoreAddress != null)
            {
                existingStore.StoreAddress = store.StoreAddress;
            }

            // Check if the nullable fields are not null, and update them accordingly
            if (store.StoreDescription != null)
            {
                existingStore.StoreDescription = store.StoreDescription;
            }

        

           

            var updatedStore = await _storeRepository.UpdateStoreAsync(storeId, existingStore);


            return Ok(updatedStore);
        }



        [HttpDelete("{storeId}")]
        public async Task<ActionResult> DeleteStoreAsync(int storeId)
        {
            var result = await _storeRepository.DeleteStoreAsync(storeId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
