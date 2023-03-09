using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreStatisticsController : ControllerBase
    {
        private readonly IStoreStatisticsServices _storeStatisticsServices;

        public StoreStatisticsController(IStoreStatisticsServices storeStatisticsServices)
        {
            _storeStatisticsServices = storeStatisticsServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<StoreStatistics>>> GetAllStoreStatisticsAsync()
        {
            var storeStatistics = await _storeStatisticsServices.GetAllStoreStatisticsAsync();
            return Ok(storeStatistics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreStatistics>> GetStoreStatisticsByIdAsync(int id)
        {
            var storeStatistics = await _storeStatisticsServices.GetStoreStatisticsByIdAsync(id);

            if (storeStatistics == null)
            {
                return NotFound();
            }

            return Ok(storeStatistics);
        }

        [HttpPost]
        public async Task<ActionResult<StoreStatistics>> CreateStoreStatisticsAsync(StoreStatistics storeStatistics)
        {
            var createdStoreStatistics = await _storeStatisticsServices.CreateStoreStatisticsAsync(storeStatistics);
            return CreatedAtAction(nameof(GetStoreStatisticsByIdAsync), new { id = createdStoreStatistics.StoreId }, createdStoreStatistics);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StoreStatistics>> UpdateStoreStatisticsAsync(int id, StoreStatistics storeStatistics)
        {
            if (id != storeStatistics.StoreId)
            {
                return BadRequest();
            }

            var updatedStoreStatistics = await _storeStatisticsServices.UpdateStoreStatisticsAsync(id, storeStatistics);

            if (updatedStoreStatistics == null)
            {
                return NotFound();
            }

            return Ok(updatedStoreStatistics);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreStatisticsAsync(int id)
        {
            var result = await _storeStatisticsServices.DeleteStoreStatisticsAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("total-products/{storeId}")]
        public async Task<ActionResult<int>> GetTotalProductsAsync(int storeId)
        {
            var totalProducts = await _storeStatisticsServices.GetTotalProductsAsync(storeId);
            return Ok(totalProducts);
        }

        [HttpGet("total-categories/{storeId}")]
        public async Task<ActionResult<int>> GetTotalCategoriesAsync(int storeId)
        {
            var totalCategories = await _storeStatisticsServices.GetTotalCategoriesAsync(storeId);
            return Ok(totalCategories);
        }

       
        [HttpGet("total-sales/{storeId}")]
        public async Task<ActionResult<decimal>> GetTotalSalesAsync(int storeId)
        {
            var totalSales = await _storeStatisticsServices.GetTotalSalesAsync(storeId);
            return Ok(totalSales);
        }

        [HttpGet("total-orders/{storeId}")]
        public async Task<ActionResult<int>> GetTotalOrdersAsync(int storeId)
        {
            var totalOrders = await _storeStatisticsServices.GetTotalOrdersAsync(storeId);
            return Ok(totalOrders);
        }
    }

}