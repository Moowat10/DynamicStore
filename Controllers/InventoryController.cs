using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;
using DynamicStore.DTO;


namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryServices _inventoryServices;

        public InventoryController(IInventoryServices inventoryServices)
        {
            _inventoryServices = inventoryServices;
        }

        [HttpGet]
        public async Task<IEnumerable<Inventory>> GetInventoryAsync()
        {
            return await _inventoryServices.GetAllInventoryAsync();
        }

        [HttpGet("{inventoryId}")]
        public async Task<ActionResult<Inventory>> GetInventoryByIdAsync(int inventoryId)
        {
            var inventory = await _inventoryServices.GetInventoryByIdAsync(inventoryId);

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

            var addedInventory = await _inventoryServices.AddInventoryAsync(inventory);
            return addedInventory;
        }

        [HttpPut("{inventoryId}")]
        public async Task<ActionResult<Inventory>> UpdateInventoryAsync(int inventoryId, InventoryDTO inventoryDTO)
        {
            if (inventoryId != inventoryDTO.InventoryId)
            {
                return BadRequest();
            }

            var updatedInventory = await _inventoryServices.UpdateInventoryAsync(inventoryId, inventoryDTO);

            if (updatedInventory == null)
            {
                return NotFound();
            
            }
            return Ok(updatedInventory);
        }

        [HttpDelete("{inventoryId}")]
        public async Task<IActionResult> DeleteInventoryAsync(int inventoryId)
        {
            var existingInventory =  await _inventoryServices.DeleteInventoryAsync(inventoryId);

            if (!existingInventory)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpGet("TotalInventoryQuantity/{warehouseId}")]
           public async Task<ActionResult<int>> GetTotalInventoryQuantityAsync(int warehouseId)
        {
            var result = await _inventoryServices.GetTotalInventoryQuantityAsync(warehouseId);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("TotalInventoryAlertQuantity/{warehouseId}")]
        public async  Task<ActionResult<int>> GetTotalInventoryAlertQuantityAsync(int warehouseId)
        {
            var result = await _inventoryServices.GetTotalInventoryAlertQuantityAsync(warehouseId);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{warehouseId}")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventoryByWarehouseIdAsync(int warehouseId)
        {
            var inventories = await _inventoryServices.GetInventoryByWarehouseIdAsync(warehouseId);
            if (inventories == null)
            {
                return NotFound();
            }
            return Ok(inventories);
        }
        [HttpGet("GetLowInventories/{threshold}")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetLowInventoryAsync(int threshold)
        {
            var inventories = await _inventoryServices.GetLowInventoryAsync(threshold);
            if (inventories == null)
            {
                return NotFound();
            }
            return Ok(inventories);
        }
    }
}
