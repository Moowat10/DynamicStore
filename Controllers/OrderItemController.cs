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
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync()
        {
            return await _orderItemRepository.GetOrderItemsAsync();
        }

        [HttpGet("{orderItemId}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemByIdAsync(int orderItemId)
        {
            var orderItem = await _orderItemRepository.GetOrderItemByIdAsync(orderItemId);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> AddOrderItemAsync(OrderItemDTO orderItemDto)
        {
            var orderItem = new OrderItem
            {
                OrderId = orderItemDto.OrderId,
                ProductId = orderItemDto.ProductId,
                Quantity = orderItemDto.Quantity,
                Price = orderItemDto.Price
            };

            var addedOrderItem = await _orderItemRepository.AddOrderItemAsync(orderItem);
            return CreatedAtAction(nameof(GetOrderItemByIdAsync), new { orderItemId = addedOrderItem.OrderItemId }, addedOrderItem);
        }

        [HttpPut("{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItemAsync(int orderItemId, OrderItemDTO orderItemDto)
        {
            if (orderItemId != orderItemDto.OrderItemId)
            {
                return BadRequest();
            }

            var existingOrderItem = await _orderItemRepository.GetOrderItemByIdAsync(orderItemId);

            if (existingOrderItem == null)
            {
                return NotFound();
            }

            existingOrderItem.Quantity = orderItemDto.Quantity;
            existingOrderItem.Price = orderItemDto.Price;

            await _orderItemRepository.UpdateOrderItemAsync(orderItemId, existingOrderItem);

            return NoContent();
        }

        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int orderItemId)
        {
            var existingOrderItem = await _orderItemRepository.GetOrderItemByIdAsync(orderItemId);

            if (existingOrderItem == null)
            {
                return NotFound();
            }

            await _orderItemRepository.DeleteOrderItemAsync(orderItemId);

            return NoContent();
        }
    }
}
