using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;


namespace DynamicStore.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context) {}
        
        public async Task<decimal> GetTotalSalesAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .SumAsync(o => o.OrderTotal);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerEmailAsync(string customerEmail)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.CustomerEmail == customerEmail)
                .ToListAsync();
        }
    }
}
