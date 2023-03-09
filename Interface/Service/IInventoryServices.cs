using DynamicStore.Models;
using DynamicStore.DTO;


namespace DynamicStore.Interface
{
    public interface IInventoryServices
    {
        Task<IEnumerable<Inventory>> GetAllInventoryAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task<Inventory> AddInventoryAsync(Inventory inventory);
        Task<Inventory> UpdateInventoryAsync(int inventoryId, InventoryDTO inventoryDTO);
        Task<bool> DeleteInventoryAsync(int inventoryId);
        Task<int> GetTotalInventoryQuantityAsync(int warehouseId);
        Task<int> GetTotalInventoryAlertQuantityAsync(int warehouseId);
        Task<IEnumerable<Inventory>> GetInventoryByWarehouseIdAsync(int warehouseId);
        Task<IEnumerable<Inventory>> GetLowInventoryAsync(int threshold);
        
    }
}
