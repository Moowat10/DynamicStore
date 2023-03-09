using DynamicStore.Models;
using DynamicStore.DTO;

namespace DynamicStore.Interface
{
    public interface IWarehouseServices
    {
        Task<IEnumerable<Warehouse>> GetAllWarehousesAsync();
        Task<Warehouse> GetWarehouseByIdAsync(int id);
        Task<Warehouse> AddWarehouseAsync(Warehouse warehouse);
        Task<Warehouse> UpdateWarehouseAsync(int warehouseId, WarehouseDTO warehouse);
        Task<bool> DeleteWarehouseAsync(int warehouseId);
    }
}
