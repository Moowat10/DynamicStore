using Microsoft.EntityFrameworkCore;
using DynamicStore.Data;
using DynamicStore.Models;
using DynamicStore.Interface;

namespace DynamicStore.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _context;

        public InventoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Inventory>> GetAllInventoryAsync()
        {
            return await _context.Inventory.ToListAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _context.Inventory.FindAsync(id);
        }

        public async Task<Inventory> CreateInventoryAsync(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory> UpdateInventoryAsync(Inventory inventory)
        {
            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task DeleteInventoryAsync(Inventory inventory)
        {
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTotalInventoryQuantityAsync(int warehouseId)
        {
            return await _context.Inventory
                .Where(i => i.WarehouseId == warehouseId)
                .SumAsync(i => i.InventoryQuantity);
        }

        public async Task<int> GetTotalInventoryAlertQuantityAsync(int warehouseId)
        {
            return await _context.Inventory
                .Where(i => i.WarehouseId == warehouseId && i.InventoryQuantity <= i.InventoryAlertQuantity)
                .CountAsync();
        }

        public async Task<List<Inventory>> GetInventoryByWarehouseAsync(int warehouseId)
        {
            return await _context.Inventory
                .Include(i => i.Product)
                .Where(i => i.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<List<Inventory>> GetLowInventoryAsync(int threshold)
        {
            return await _context.Inventory
                .Include(i => i.Product)
                .Where(i => i.InventoryQuantity <= i.InventoryAlertQuantity * threshold)
                .ToListAsync();
        }
    }
}
