using DynamicStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IUserStorePermissionServices
    {
        Task<IEnumerable<UserStorePermission>> GetAllUserStorePermissionsAsync();
        Task<UserStorePermission> GetUserStorePermissionByIdAsync(int id);
        Task<UserStorePermission> AddUserStorePermissionAsync(UserStorePermission permission);
        Task<UserStorePermission> UpdateUserStorePermissionAsync(int id, UserStorePermission permission);
        Task<bool> DeleteUserStorePermissionAsync(int id);

    }
}
