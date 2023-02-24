using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Warehouse>> GetWarehousesAsync()
        {
            return await _warehouseRepository.GetAllWarehousesAsync();
        }

        [HttpGet("{warehouseId}")]
        public async Task<ActionResult<Warehouse>> GetWarehouseByIdAsync(int warehouseId)
        {
            var warehouse = await _warehouseRepository.GetWarehouseByIdAsync(warehouseId);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        [HttpPost]
        public async Task<ActionResult<Warehouse>> CreateWarehouseAsync(Warehouse warehouse)
        {
            var addedWarehouse = await _warehouseRepository.CreateWarehouseAsync(warehouse);
            return CreatedAtAction(nameof(GetWarehouseByIdAsync), new { warehouseId = addedWarehouse.WarehouseId }, addedWarehouse);
        }

        [HttpPut("{warehouseId}")]
        public async Task<IActionResult> UpdateWarehouseAsync(int warehouseId, WarehouseDTO warehouse)
        {
            if (warehouseId != warehouse.WarehouseId)
            {
                return BadRequest();
            }

            var existingWarehouse = await _warehouseRepository.GetWarehouseByIdAsync(warehouseId);

            if (existingWarehouse == null)
            {
                return NotFound();
            }

            existingWarehouse.WarehouseName = warehouse.WarehouseName;
            existingWarehouse.WarehouseAddress = warehouse.WarehouseAddress;
            existingWarehouse.WarehousePhone = warehouse.WarehousePhone;
            existingWarehouse.WarehouseEmail = warehouse.WarehouseEmail;

            await _warehouseRepository.UpdateWarehouseAsync(existingWarehouse);

            return NoContent();
        }

        [HttpDelete("{warehouseId}")]
        public async Task<IActionResult> DeleteWarehouseAsync(int warehouseId)
        {
            var existingWarehouse = await _warehouseRepository.GetWarehouseByIdAsync(warehouseId);

            if (existingWarehouse == null)
            {
                return NotFound();
            }

            await _warehouseRepository.DeleteWarehouseAsync(existingWarehouse);

            return NoContent();
        }
    }
}