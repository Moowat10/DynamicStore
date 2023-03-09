using DynamicStore.DTO;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderServices.GetOrdersAsync();
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
            var order = await _orderServices.GetOrderByIdAsync(id);

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
        public async Task<ActionResult<OrderDTO>> AddOrderAsync(OrderDTO orderDTO)
        {
         
            var createdOrder = await _orderServices.AddOrderAsync(orderDTO);
            return createdOrder;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrderAsync(int id, OrderDTO orderDTO)
        {
            var updatedOrder = await _orderServices.UpdateOrderAsync(id, orderDTO);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var existingOrder = await  _orderServices.DeleteOrderAsync(id);

            if (!existingOrder)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
