using DynamicStore.DTO;
using DynamicStore.Models;
using DynamicStore.Interface;
using DynamicStore.Repository;

namespace DynamicStore.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly OrderRepository _orderRepository;

        public OrderServices(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO)
        {
            var order = new Order
            {
                OrderDate = orderDTO.OrderDate,
                OrderTotal = orderDTO.OrderTotal,
                CustomerName = orderDTO.CustomerName,
                CustomerEmail = orderDTO.CustomerEmail
            };

            var createdOrder = await _orderRepository.AddAsync(order);

            var createdOrderDTO = new OrderDTO
            {
                OrderId = createdOrder.OrderId,
                OrderDate = createdOrder.OrderDate,
                OrderTotal = createdOrder.OrderTotal,
                CustomerName = createdOrder.CustomerName,
                CustomerEmail = createdOrder.CustomerEmail

            };

            return createdOrderDTO;
        }

        public async Task<Order> UpdateOrderAsync(int id, OrderDTO orderDTO)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);

            if (existingOrder == null)
            {
                return null;
            }

            var order = new Order
            {
                OrderId = id,
                OrderDate = orderDTO.OrderDate,
                OrderTotal = orderDTO.OrderTotal,
                CustomerName = orderDTO.CustomerName,
                CustomerEmail = orderDTO.CustomerEmail
            };

           return await _orderRepository.UpdateAsync(id, order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);

            if (existingOrder == null)
            {
                return false;
            }

            return await _orderRepository.DeleteAsync(existingOrder.OrderId);
        }
         public async Task<decimal> GetTotalSalesAsync(DateTime startDate, DateTime endDate)
        {
            return await _orderRepository.GetTotalSalesAsync(startDate, endDate);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerEmailAsync(string customerEmail)
        {
            return await _orderRepository.GetOrdersByCustomerEmailAsync(customerEmail);
        }
    }
}
