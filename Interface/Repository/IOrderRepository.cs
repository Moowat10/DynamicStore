using DynamicStore.Models;


namespace DynamicStore.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<decimal> GetTotalSalesAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Order>> GetOrdersByCustomerEmailAsync(string customerEmail);
    }
}
