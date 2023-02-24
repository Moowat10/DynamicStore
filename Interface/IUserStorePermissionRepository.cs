using DynamicStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IUserStorePermissionRepository
    {
        Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsAsync();
        Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByUserIdAsync(int userId);
        Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByStoreIdAsync(int storeId);
        Task<UserStorePermission> GetUserStorePermissionByIdAsync(int id);
        Task<UserStorePermission> AddUserStorePermissionAsync(UserStorePermission userStorePermission);
        Task<UserStorePermission> UpdateUserStorePermissionAsync(int id, UserStorePermission userStorePermission);
        Task<bool> DeleteUserStorePermissionAsync(int id);
    }
}
