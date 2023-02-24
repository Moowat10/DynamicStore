using DynamicStore.Data;
using DynamicStore.DTO;
using DynamicStore.Interfaces;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicStore.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DataContext _dbContext;

        public OrderItemRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _dbContext.OrderItems.FindAsync(orderItemId);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _dbContext.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            var newOrderItem = new OrderItem
            {
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                Price = orderItem.Price
            };

            _dbContext.OrderItems.Add(newOrderItem);
            await _dbContext.SaveChangesAsync();

            return newOrderItem;
        }

        public async Task UpdateOrderItemAsync(int orderItemId, OrderItem orderItem)
        {
            var existingOrderItem = await _dbContext.OrderItems.FindAsync(orderItemId);

            existingOrderItem.OrderId = orderItem.OrderId;
            existingOrderItem.ProductId = orderItem.ProductId;
            existingOrderItem.Quantity = orderItem.Quantity;
            existingOrderItem.Price = orderItem.Price;

            _dbContext.OrderItems.Update(existingOrderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            var existingOrderItem = await _dbContext.OrderItems.FindAsync(orderItemId);

            _dbContext.OrderItems.Remove(existingOrderItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}
