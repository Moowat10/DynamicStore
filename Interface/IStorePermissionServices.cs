using DynamicStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IStorePermissionServices
    {
        Task<IEnumerable<StorePermission>> GetStorePermissionsAsync();

        Task<IEnumerable<StorePermission>> GetStorePermissionsByStoreIdAsync(int storeId);

        Task<IEnumerable<StorePermission>> GetStorePermissionsByUserIdAsync(int userId);

        Task<StorePermission> GetStorePermissionByIdAsync(int permissionId);

        Task<StorePermission> AddStorePermissionAsync(StorePermission storePermission);

        Task<StorePermission> UpdateStorePermissionAsync(int permissionId, StorePermission storePermission);

        Task<bool> DeleteStorePermissionAsync(int permissionId);
    }
}