using DynamicStore.Data;
using DynamicStore.Repository;
using DynamicStore.Interfaces;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicStore.Repositories
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