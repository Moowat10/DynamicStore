using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Repository
{
    public class UserStorePermissionRepository : IUserStorePermissionRepository
    {
        private readonly DataContext _context;

        public UserStorePermissionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsAsync()
        {
            return await _context.UserStorePermissions.ToListAsync();
        }
        public async Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByUserIdAsync(int userId)
        {
            return await _context.UserStorePermissions.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByStoreIdAsync(int storeId)
        {
            return await _context.UserStorePermissions.Where(p => p.UserId == storeId).ToListAsync();
        }

        public async Task<UserStorePermission> GetUserStorePermissionByIdAsync(int id)
        {
            return await _context.UserStorePermissions.FindAsync(id);
        }

        public async Task<UserStorePermission> AddUserStorePermissionAsync(UserStorePermission userStorePermission)
        {
            _context.UserStorePermissions.Add(userStorePermission);
            await _context.SaveChangesAsync();
            return userStorePermission;
        }

        public async Task<UserStorePermission> UpdateUserStorePermissionAsync(int id, UserStorePermission userStorePermission)
        {
            var existingUserStorePermission = await _context.UserStorePermissions.FindAsync(id);

            if (existingUserStorePermission != null)
            {
                existingUserStorePermission.UserId = userStorePermission.UserId;
                existingUserStorePermission.PermissionId = userStorePermission.PermissionId;
                await _context.SaveChangesAsync();
            }

            return existingUserStorePermission;
        }

        public async Task<bool> DeleteUserStorePermissionAsync(int id)
        {
            var existingUserStorePermission = await _context.UserStorePermissions.FindAsync(id);

            if (existingUserStorePermission != null)
            {
                _context.UserStorePermissions.Remove(existingUserStorePermission);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
