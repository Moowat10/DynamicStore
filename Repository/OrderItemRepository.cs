using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repository
{
    public class OrderItemRepository :  Repository<OrderItem>, IOrderItemRepository
    {

        public OrderItemRepository(DataContext context) : base(context) {}
       
  
        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await this._context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }

    
    }
}