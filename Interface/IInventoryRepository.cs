using DynamicStore.Models;


namespace DynamicStore.Interface
{
    public interface IInventoryRepository
    {
        Task<List<Inventory>> GetAllInventoryAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task<Inventory> CreateInventoryAsync(Inventory inventory);
        Task<Inventory> UpdateInventoryAsync(Inventory inventory);
        Task DeleteInventoryAsync(Inventory inventory);
    }
}
