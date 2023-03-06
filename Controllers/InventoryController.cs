using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;
using DynamicStore.DTO;
using DynamicStore.DTO.DynamicStore.DTOs;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Inventory>> GetInventoryAsync()
        {
            return await _inventoryRepository.GetAllInventoryAsync();
        }

        [HttpGet("{inventoryId}")]
        public async Task<ActionResult<Inventory>> GetInventoryByIdAsync(int inventoryId)
        {
            var inventory = await _inventoryRepository.GetInventoryByIdAsync(inventoryId);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        [HttpPost]
        public async Task<ActionResult<Inventory>> AddInventoryAsync(InventoryDTO inventoryDTO)
        {
            var inventory = new Inventory
            {
               
                WarehouseId = inventoryDTO.WarehouseId,
                InventoryQuantity = inventoryDTO.InventoryQuantity,
                InventoryAlertQuantity = inventoryDTO.InventoryAlertQuantity
            };

            var addedInventory = await _inventoryRepository.CreateInventoryAsync(inventory);
            return CreatedAtAction(nameof(GetInventoryByIdAsync), new { inventoryId = addedInventory.InventoryId }, addedInventory);
        }

        [HttpPut("{inventoryId}")]
        public async Task<IActionResult> UpdateInventoryAsync(int inventoryId, InventoryDTO inventoryDTO)
        {
            if (inventoryId != inventoryDTO.InventoryId)
            {
                return BadRequest();
            }

            var existingInventory = await _inventoryRepository.GetInventoryByIdAsync(inventoryId);

            if (existingInventory == null)
            {
                return NotFound();
            }

           
            existingInventory.WarehouseId = inventoryDTO.WarehouseId;
            existingInventory.InventoryQuantity = inventoryDTO.InventoryQuantity;
            existingInventory.InventoryAlertQuantity = inventoryDTO.InventoryAlertQuantity;

            await _inventoryRepository.UpdateInventoryAsync(existingInventory);

            return NoContent();
        }

        [HttpDelete("{inventoryId}")]
        public async Task<IActionResult> DeleteInventoryAsync(int inventoryId)
        {
            var existingInventory = await _inventoryRepository.GetInventoryByIdAsync(inventoryId);

            if (existingInventory == null)
            {
                return NotFound();
            }

            await _inventoryRepository.DeleteInventoryAsync(existingInventory);

            return NoContent();
        }
    }
}
