using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.DTO;

namespace DynamicStore.Services
{
    public class WarehouseServices : IWarehouseServices
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseServices(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<IEnumerable<Warehouse>> GetAllWarehousesAsync()
        {
            return await _warehouseRepository.GetAllAsync();
        }

        public async Task<Warehouse> GetWarehouseByIdAsync(int warehouseId)
        {
            return await _warehouseRepository.GetByIdAsync(warehouseId);
        }

        public async Task<Warehouse> AddWarehouseAsync(Warehouse warehouse)
        {
            return await _warehouseRepository.AddAsync(warehouse);
        }

        public async Task<Warehouse> UpdateWarehouseAsync(int warehouseId, WarehouseDTO warehouse)
        {
            var existingWarehouse = await _warehouseRepository.GetByIdAsync(warehouseId);

            if (existingWarehouse == null)
            {
                return null;
            }

            existingWarehouse.WarehouseName = warehouse.WarehouseName;
            existingWarehouse.WarehouseAddress = warehouse.WarehouseAddress;
            existingWarehouse.WarehousePhone = warehouse.WarehousePhone;
            existingWarehouse.WarehouseEmail = warehouse.WarehouseEmail;

           return  await _warehouseRepository.UpdateAsync(warehouseId ,existingWarehouse);
        }

        public async Task<bool> DeleteWarehouseAsync(int warehouseId)
        {
             var existingWarehouse = await _warehouseRepository.GetByIdAsync(warehouseId);
            if (existingWarehouse == null)
            {
                return false;
            }

            await _warehouseRepository.DeleteAsync(warehouseId);
            return true;
        }
    }
}
