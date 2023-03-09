using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IStorePermissionRepository
    {
        Task<IEnumerable<StorePermission>> GetStorePermissionsByStoreIdAsync(int storeId);

        Task<IEnumerable<StorePermission>> GetStorePermissionsByUserIdAsync(int userId);
    }
}