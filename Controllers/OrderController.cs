using DynamicStore.DTO;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            var orderDTOs = orders.Select(order => new OrderDTO
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                OrderTotal = order.OrderTotal,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail
            }).ToList();

            return orderDTOs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderDTO = new OrderDTO
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                OrderTotal = order.OrderTotal,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail
            };

            return orderDTO;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrderAsync(OrderDTO orderDTO)
        {
            var order = new Order
            {
                OrderDate = orderDTO.OrderDate,
                OrderTotal = orderDTO.OrderTotal,
                CustomerName = orderDTO.CustomerName,
                CustomerEmail = orderDTO.CustomerEmail
            };

            var createdOrder = await _orderRepository.AddOrderAsync(order);

            var createdOrderDTO = new OrderDTO
            {
                OrderId = createdOrder.OrderId,
                OrderDate = createdOrder.OrderDate,
                OrderTotal = createdOrder.OrderTotal,
                CustomerName = createdOrder.CustomerName,
                CustomerEmail = createdOrder.CustomerEmail

            };

            return CreatedAtAction(nameof(GetOrderByIdAsync), new { id = createdOrderDTO.OrderId }, createdOrderDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, OrderDTO orderDTO)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            var order = new Order
            {
                OrderId = id,
                OrderDate = orderDTO.OrderDate,
                OrderTotal = orderDTO.OrderTotal,
                CustomerName = orderDTO.CustomerName,
                CustomerEmail = orderDTO.CustomerEmail
            };

            await _orderRepository.UpdateOrderAsync(id, order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            await _orderRepository.DeleteOrderAsync(existingOrder.OrderId);

            return NoContent();
        }
    }
}
