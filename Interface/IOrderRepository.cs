using DynamicStore.Models;


namespace DynamicStore.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(int orderId, Order order);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<decimal> GetTotalSalesAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Order>> GetOrdersByCustomerEmailAsync(string customerEmail);
    }
}
