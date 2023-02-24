using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IWarehouseRepository
    {
        Task<List<Warehouse>> GetAllWarehousesAsync();
        Task<Warehouse> GetWarehouseByIdAsync(int id);
        Task<Warehouse> CreateWarehouseAsync(Warehouse warehouse);
        Task<Warehouse> UpdateWarehouseAsync(Warehouse warehouse);
        Task DeleteWarehouseAsync(Warehouse warehouse);
    }
}
