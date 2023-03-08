using DynamicStore.DTO;
using DynamicStoreBackend.Models;
using DynamicStoreBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DynamicStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueServices _revenueServices;

        public RevenueController(IRevenueServices revenueServices)
        {
            _revenueServices = revenueServices;
    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Revenue> >GetRevenueByIdAsync(int id)
        {
            var revenue = await _revenueServices.GetRevenueByIdAsync(id);

            if (revenue == null)
            {
                return NotFound();
            }

            return Ok(revenue);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revenue>>> GetAllRevenueAsync()
        {
            var revenues = await _revenueServices.GetAllRevenueAsync();
            return Ok(revenues);
        }

        [HttpPost]
        public async Task<ActionResult<Revenue>> AddRevenueAsync(Revenue revenue)
        {
            var addedRevenue = await _revenueServices.AddRevenueAsync(revenue);
            return Ok(addedRevenue);
        }

        [HttpPut("{id}")]
        async public Task<IActionResult> UpdateRevenueAsync(int id, RevenueDTO revenue)
        {
           var updatedRevenue = await _revenueServices.UpdateRevenueAsync(id, revenue);
            if (updatedRevenue == null)
            {
                return NotFound();
            }

            return Ok(updatedRevenue);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevenueAsync(int id)
        {
            var revenue = await _revenueServices.DeleteRevenueAsync(id);

            if (!revenue)
            {
                return NotFound();
            }

            
            return Ok();
        }
    }
}
