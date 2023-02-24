using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreStatisticsController : ControllerBase
    {
        private readonly IStoreStatisticsRepository _repository;

        public StoreStatisticsController(IStoreStatisticsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<StoreStatistics>>> GetAllStoreStatisticsAsync()
        {
            var storeStatistics = await _repository.GetAllStoreStatisticsAsync();
            return Ok(storeStatistics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreStatistics>> GetStoreStatisticsByIdAsync(int id)
        {
            var storeStatistics = await _repository.GetStoreStatisticsByIdAsync(id);

            if (storeStatistics == null)
            {
                return NotFound();
            }

            return Ok(storeStatistics);
        }

        [HttpPost]
        public async Task<ActionResult<StoreStatistics>> CreateStoreStatisticsAsync(StoreStatistics storeStatistics)
        {
            var createdStoreStatistics = await _repository.CreateStoreStatisticsAsync(storeStatistics);
            return CreatedAtAction(nameof(GetStoreStatisticsByIdAsync), new { id = createdStoreStatistics.StoreId }, createdStoreStatistics);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StoreStatistics>> UpdateStoreStatisticsAsync(int id, StoreStatistics storeStatistics)
        {
            if (id != storeStatistics.StoreId)
            {
                return BadRequest();
            }

            var updatedStoreStatistics = await _repository.UpdateStoreStatisticsAsync(storeStatistics);

            if (updatedStoreStatistics == null)
            {
                return NotFound();
            }

            return Ok(updatedStoreStatistics);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreStatisticsAsync(int id)
        {
            var storeStatistics = await _repository.GetStoreStatisticsByIdAsync(id);

            if (storeStatistics == null)
            {
                return NotFound();
            }

            await _repository.DeleteStoreStatisticsAsync(storeStatistics);

            return NoContent();
        }

        [HttpGet("total-products/{storeId}")]
        public async Task<ActionResult<int>> GetTotalProductsAsync(int storeId)
        {
            var totalProducts = await _repository.GetTotalProductsAsync(storeId);
            return Ok(totalProducts);
        }

        [HttpGet("total-categories/{storeId}")]
        public async Task<ActionResult<int>> GetTotalCategoriesAsync(int storeId)
        {
            var totalCategories = await _repository.GetTotalCategoriesAsync(storeId);
            return Ok(totalCategories);
        }

       
        [HttpGet("total-sales/{storeId}")]
        public async Task<ActionResult<decimal>> GetTotalSalesAsync(int storeId)
        {
            var totalSales = await _repository.GetTotalSalesAsync(storeId);
            return Ok(totalSales);
        }

        [HttpGet("total-orders/{storeId}")]
        public async Task<ActionResult<int>> GetTotalOrdersAsync(int storeId)
        {
            var totalOrders = await _repository.GetTotalOrdersAsync(storeId);
            return Ok(totalOrders);
        }
    }

}