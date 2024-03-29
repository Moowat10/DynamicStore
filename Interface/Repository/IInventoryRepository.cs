﻿using DynamicStore.Models;


namespace DynamicStore.Interface
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<int> GetTotalInventoryAlertQuantityAsync(int warehouseId);
        Task<IEnumerable<Inventory>> GetInventoryByWarehouseIdAsync(int warehouseId);
        Task<IEnumerable<Inventory>> GetLowInventoryAsync(int threshold);
        Task<int> GetTotalInventoryQuantityAsync(int warehouseId);
    }
}
