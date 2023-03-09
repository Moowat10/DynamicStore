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
        private readonly IWarehouseServices _warehouseServices;

        public WarehouseController(IWarehouseServices warehouseServices)
        {
            _warehouseServices = warehouseServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehousesAsync()
        {
            return Ok(await _warehouseServices.GetAllWarehousesAsync());
        }

        [HttpGet("{warehouseId}")]
        public async Task<ActionResult<Warehouse>> GetWarehouseByIdAsync(int warehouseId)
        {
            var warehouse = await _warehouseServices.GetWarehouseByIdAsync(warehouseId);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<ActionResult<Warehouse>> CreateWarehouseAsync(Warehouse warehouse)
        {
            var addedWarehouse = await _warehouseServices.AddWarehouseAsync(warehouse);
            return Ok(addedWarehouse);
        }

        [HttpPut("{warehouseId}")]
        public async Task<ActionResult<Warehouse>> UpdateWarehouseAsync(int warehouseId, WarehouseDTO warehouse)
        {
            if (warehouseId != warehouse.WarehouseId)
            {
                return BadRequest();
            }

            var updatedWarehouse =  await _warehouseServices.UpdateWarehouseAsync(warehouseId, warehouse);

            if (updatedWarehouse == null)
            {
                return NotFound();
            }

            return Ok(updatedWarehouse);
        }

        [HttpDelete("{warehouseId}")]
        public async Task<IActionResult> DeleteWarehouseAsync(int warehouseId)
        {
            var existingWarehouse =  await _warehouseServices.DeleteWarehouseAsync(warehouseId);

            if (!existingWarehouse)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}