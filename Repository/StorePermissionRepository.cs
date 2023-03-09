using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicStore.Repository
{
    public class StorePermissionRepository : Repository<StorePermission>, IStorePermissionRepository
    {

        public StorePermissionRepository(DataContext context) : base(context) {}
       
        public async Task<IEnumerable<StorePermission>> GetStorePermissionsByStoreIdAsync(int storeId)
        {
            return await _context.StorePermissions.Where(p => p.StoreId == storeId).ToListAsync();
        }

        public async Task<IEnumerable<StorePermission>> GetStorePermissionsByUserIdAsync(int userId)
        {
            return await _context.StorePermissions.Where(p => p.UserId == userId).ToListAsync();
        }

    }
}
