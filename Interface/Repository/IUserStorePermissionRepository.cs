using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IUserStorePermissionRepository
    {
        Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByUserIdAsync(int userId);
        Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByStoreIdAsync(int storeId);
    }
}