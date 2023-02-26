using DynamicStore.Models;
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
        private readonly IRevenueRepository _revenueRepository;

        public RevenueController(IRevenueRepository revenueRepository)
        {
            _revenueRepository = revenueRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Revenue> GetById(int id)
        {
            var revenue = _revenueRepository.GetById(id);

            if (revenue == null)
            {
                return NotFound();
            }

            return revenue;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Revenue>> GetAll()
        {
            var revenues = _revenueRepository.GetAll();
            return Ok(revenues);
        }

        [HttpPost]
        public ActionResult<Revenue> Create(Revenue revenue)
        {
            _revenueRepository.Add(revenue);
            return CreatedAtAction(nameof(GetById), new { id = revenue.Id }, revenue);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Revenue revenue)
        {
            if (id != revenue.Id)
            {
                return BadRequest();
            }

            _revenueRepository.Update(revenue);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var revenue = _revenueRepository.GetById(id);

            if (revenue == null)
            {
                return NotFound();
            }

            _revenueRepository.Delete(revenue);
            return NoContent();
        }
    }
}
