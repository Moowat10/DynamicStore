using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IStorePermissionRepository : IRepository<StorePermission>
    {
        Task<IEnumerable<StorePermission>> GetStorePermissionsByStoreIdAsync(int storeId);

        Task<IEnumerable<StorePermission>> GetStorePermissionsByUserIdAsync(int userId);
    }
}