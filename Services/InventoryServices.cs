using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Repository;
using DynamicStore.DTO;
using System.Threading.Tasks;

namespace DynamicStore.Services
{
    public class InventoryServices : IInventoryServices
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryServices(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<Inventory>> GetAllInventoryAsync()
        {
            return await _inventoryRepository.GetAllAsync();
        }
        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            return await _inventoryRepository.AddAsync(inventory);
        }

        public async Task<bool> DeleteInventoryAsync(int inventoryId)
        {
            var existingInventory = await _inventoryRepository.GetByIdAsync(inventoryId);

            if (existingInventory != null)
            {
                await _inventoryRepository.DeleteAsync(inventoryId);
            }
            return false;
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            return await _inventoryRepository.GetByIdAsync(inventoryId);
        }

        public async Task<Inventory> UpdateInventoryAsync(int inventoryId, InventoryDTO inventoryDTO)
        {
            var existingInventory = await _inventoryRepository.GetByIdAsync(inventoryId);

            if (existingInventory != null)
            {
                existingInventory.InventoryQuantity = inventoryDTO.InventoryQuantity;
                existingInventory.InventoryAlertQuantity = inventoryDTO.InventoryAlertQuantity;

              return  await _inventoryRepository.UpdateAsync(inventoryId, existingInventory);
            }

            return null;
        }
         public async Task<int> GetTotalInventoryQuantityAsync(int warehouseId)
        {
            return await _inventoryRepository.GetTotalInventoryQuantityAsync(warehouseId);
        }

        public async Task<int> GetTotalInventoryAlertQuantityAsync(int warehouseId)
        {
            return await _inventoryRepository.GetTotalInventoryAlertQuantityAsync(warehouseId);
        }

        public async Task<IEnumerable<Inventory>> GetInventoryByWarehouseIdAsync(int warehouseId)
        {
            return await _inventoryRepository.GetInventoryByWarehouseIdAsync(warehouseId);
        }

        public async Task<IEnumerable<Inventory>> GetLowInventoryAsync(int threshold)
        {
            return await _inventoryRepository.GetLowInventoryAsync(threshold);
        }
    }
}
