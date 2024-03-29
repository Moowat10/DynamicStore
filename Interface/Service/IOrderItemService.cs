﻿using DynamicStore.DTO;
using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync();
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
        Task<OrderItem> AddOrderItemAsync(OrderItemDTO orderItemDto);
        Task<OrderItem> UpdateOrderItemAsync(int orderItemId, OrderItemDTO orderItemDto);
        Task<bool> DeleteOrderItemAsync(int orderItemId);
   
    }
}
