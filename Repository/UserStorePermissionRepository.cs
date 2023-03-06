using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Repository
{
    public class UserStorePermissionRepository : Repository<UserStorePermission>, IUserStorePermissionRepository
    {

        public UserStorePermissionRepository(DataContext context) : base(context) { }       

        public async Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByUserIdAsync(int userId)
        {
            return await this._context.UserStorePermissions.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByStoreIdAsync(int storeId)
        {
            return await this._context.UserStorePermissions.Where(p => p.UserId == storeId).ToListAsync();
        }

    }
}
