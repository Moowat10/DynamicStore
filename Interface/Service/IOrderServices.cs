using DynamicStore.Models;
using DynamicStore.DTO;


namespace DynamicStore.Interface
{
    public interface IOrderServices
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO);
        Task<Order> UpdateOrderAsync(int orderId, OrderDTO orderDTO);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<decimal> GetTotalSalesAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Order>> GetOrdersByCustomerEmailAsync(string customerEmail);
    }
}
