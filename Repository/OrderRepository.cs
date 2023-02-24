using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(int orderId, Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(orderId);

            if (existingOrder != null)
            {
                // Update scalar properties
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.OrderTotal = order.OrderTotal;
                existingOrder.CustomerName = order.CustomerName;
                existingOrder.CustomerEmail = order.CustomerEmail;

                // Remove existing order items
                _context.OrderItems.RemoveRange(existingOrder.OrderItems);

                // Add new order items
                foreach (var item in order.OrderItems)
                {
                    existingOrder.OrderItems.Add(item);
                }

                await _context.SaveChangesAsync();
            }

            return existingOrder;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var existingOrder = await _context.Orders.FindAsync(orderId);

            if (existingOrder != null)
            {
                _context.Orders.Remove(existingOrder);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

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
