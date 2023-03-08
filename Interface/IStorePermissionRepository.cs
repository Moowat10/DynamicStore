using DynamicStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Interface
{
    public interface IStorePermissionRepository
    {
        Task<IEnumerable<StorePermission>> GetStorePermissionsByStoreIdAsync(int storeId);

        Task<IEnumerable<StorePermission>> GetStorePermissionsByUserIdAsync(int userId);
    }
}