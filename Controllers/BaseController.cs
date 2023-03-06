/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DynamicStore.DTO;
using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Services;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity, TDto> : ControllerBase
        where TEntity : class
        where TDto : class
    {
        private readonly IService<TEntity, TDto> _service;
        private readonly Mapper Mapper;

        public BaseController(IService<TEntity, TDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> GetAllAsync()
        {
            var dtos = await _service.GetAllAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> GetByIdAsync(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TDto>> CreateAsync(TDto dto)
        {
            var createdDto = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = GetEntityId(createdDto) }, createdDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TDto>> UpdateAsync(int id, TDto dto)
        {
            if (id != GetEntityId(dto))
            {
                return BadRequest();
            }
            var updatedDto = await _service.UpdateAsync(dto);
            if (updatedDto == null)
            {
                return NotFound();
            }
            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        private int GetEntityId(TDto dto)
        {
            var property = typeof(TDto).GetProperty("Id");
            if (property == null)
            {
                throw new InvalidOperationException($"DTO type {typeof(TDto)} does not have an 'Id' property.");
            }
            return (int)property.GetValue(dto);
        }
    }
}
*/