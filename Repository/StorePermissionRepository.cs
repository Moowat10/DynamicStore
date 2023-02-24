using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DynamicStore.Repository
{
    public class StorePermissionRepository : IStorePermissionRepository
    {
        private readonly DataContext _context;

        public StorePermissionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StorePermission>> GetStorePermissionsAsync()
        {
            return await _context.StorePermissions.ToListAsync();
        }

        public async Task<IEnumerable<StorePermission>> GetStorePermissionsByStoreIdAsync(int storeId)
        {
            return await _context.StorePermissions.Where(p => p.StoreId == storeId).ToListAsync();
        }

        public async Task<IEnumerable<StorePermission>> GetStorePermissionsByUserIdAsync(int userId)
        {
            return await _context.StorePermissions.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<StorePermission> GetStorePermissionByIdAsync(int permissionId)
        {
            return await _context.StorePermissions.FindAsync(permissionId);
        }

        public async Task<StorePermission> AddStorePermissionAsync(StorePermission storePermission)
        {
            _context.StorePermissions.Add(storePermission);
            await _context.SaveChangesAsync();
            return storePermission;
        }

        public async Task<StorePermission> UpdateStorePermissionAsync(int permissionId, StorePermission storePermission)
        {
            var existingPermission = await _context.StorePermissions.FindAsync(permissionId);

            if (existingPermission != null)
            {
                existingPermission.CanAddProducts = storePermission.CanAddProducts;
                existingPermission.CanEditProducts = storePermission.CanEditProducts;
                existingPermission.CanDeleteProducts = storePermission.CanDeleteProducts;
                existingPermission.CanViewOrders = storePermission.CanViewOrders;
                existingPermission.CanEditOrders = storePermission.CanEditOrders;
                existingPermission.CanAddEmployees = storePermission.CanAddEmployees;
                existingPermission.CanEditEmployees = storePermission.CanEditEmployees;
                existingPermission.CanDeleteEmployees = storePermission.CanDeleteEmployees;

                await _context.SaveChangesAsync();
            }

            return existingPermission;
        }

        public async Task<bool> DeleteStorePermissionAsync(int permissionId)
        {
            var existingPermission = await _context.StorePermissions.FindAsync(permissionId);

            if (existingPermission != null)
            {
                _context.StorePermissions.Remove(existingPermission);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
