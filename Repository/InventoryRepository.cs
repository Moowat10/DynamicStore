using Microsoft.EntityFrameworkCore;
using DynamicStore.Data;
using DynamicStore.Models;
using DynamicStore.Interface;

namespace DynamicStore.Repository
{
    public class InventoryRepository : Repository<Inventory> , IInventoryRepository
    {

        public InventoryRepository(DataContext context) : base(context) { }
        public async Task<int> GetTotalInventoryQuantityAsync(int warehouseId)
        {
            return await this._context.Inventory
                .Where(i => i.WarehouseId == warehouseId)
                .SumAsync(i => i.InventoryQuantity);
        }

        public async Task<int> GetTotalInventoryAlertQuantityAsync(int warehouseId)
        {
            return await this._context.Inventory
                .Where(i => i.WarehouseId == warehouseId && i.InventoryQuantity <= i.InventoryAlertQuantity)
                .CountAsync();
        }

        public async Task<IEnumerable<Inventory>> GetInventoryByWarehouseIdAsync(int warehouseId)
        {
            return await this._context.Inventory
                .Include(i => i.InventoryId)
                .Where(i => i.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Inventory>> GetLowInventoryAsync(int threshold)
        {
            return await this._context.Inventory
                .Include(i => i.InventoryId)
                .Where(i => i.InventoryQuantity <= i.InventoryAlertQuantity * threshold)
                .ToListAsync();
        }
    }
}
