using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicStore.Interfaces;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemServices;

        public OrderItemController(IOrderItemService orderItemServices)
        {
            _orderItemServices = orderItemServices;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync()
        {
            return await _orderItemServices.GetOrderItemsAsync();
        }

        [HttpGet("{orderItemId}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemByIdAsync(int orderItemId)
        {
            var orderItem = await _orderItemServices.GetOrderItemByIdAsync(orderItemId);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> AddOrderItemAsync(OrderItemDTO orderItemDto)
        {
            var addedOrderItem = await _orderItemServices.AddOrderItemAsync(orderItemDto);
            return addedOrderItem;
        }

        [HttpPut("{orderItemId}")]
        public async Task<ActionResult<OrderItem>> UpdateOrderItemAsync(int orderItemId, OrderItemDTO orderItemDto)
        {
            if (orderItemId != orderItemDto.OrderItemId)
            {
                return BadRequest();
            }

            var updatedOrderItem =  await _orderItemServices.UpdateOrderItemAsync(orderItemId, orderItemDto);

            if (updatedOrderItem == null)
            {
                return NotFound();
            }
    
            return Ok(updatedOrderItem);
        }

        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int orderItemId)
        {
            var existingOrderItem = await _orderItemServices.DeleteOrderItemAsync(orderItemId);

            if (!existingOrderItem)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
