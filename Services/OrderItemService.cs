using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.DTO;
using DynamicStore.Repository;

namespace DynamicStore.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly OrderItemRepository _orderItemRepository;

        public OrderItemService(OrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

         public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();
            return orderItems;
        }
        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            var existingOrder = await _orderItemRepository.GetByIdAsync(orderItemId);
            if(existingOrder == null)
            {
                return null;
            }
            return existingOrder;
        }
        public async Task<OrderItem> AddOrderItemAsync(OrderItemDTO orderItemDto)
        {
            var orderItem = new OrderItem
            {
                OrderId = orderItemDto.OrderId,
                ProductId = orderItemDto.ProductId,
                Quantity = orderItemDto.Quantity,
                Price = orderItemDto.Price
            };

            var addedOrderItem = await _orderItemRepository.AddAsync(orderItem);
            return addedOrderItem;
        }

        public async Task<OrderItem> UpdateOrderItemAsync(int orderItemId, OrderItemDTO orderItemDto)
        {
            var existingOrderItem = await _orderItemRepository.GetByIdAsync(orderItemId);

            if (existingOrderItem == null)
            {
                return null;
            }

            existingOrderItem.Quantity = orderItemDto.Quantity;
            existingOrderItem.Price = orderItemDto.Price;

            await _orderItemRepository.UpdateAsync(orderItemId, existingOrderItem);

            return existingOrderItem;
        }

        public async Task<bool> DeleteOrderItemAsync(int orderItemId)
        {
            var existingOrderItem = await _orderItemRepository.GetByIdAsync(orderItemId);

            if (existingOrderItem == null)
            {
                return false;
            }

            await _orderItemRepository.DeleteAsync(orderItemId);

            return true;
        }
           public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _orderItemRepository.GetOrderItemsByOrderIdAsync(orderId);
        }
    }

}