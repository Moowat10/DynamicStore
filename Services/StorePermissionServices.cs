using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Services
{
    public class StorePermissionServices : IStorePermissionServices
    {
        private readonly IStorePermissionRepository _storePermissionRepository;

        public StorePermissionServices(IStorePermissionRepository storePermissionRepository)
        {
            _storePermissionRepository = storePermissionRepository;
        }

        public async Task<StorePermission> AddStorePermissionAsync(StorePermission storePermission)
        {
            // Perform null checks here
            if (storePermission == null)
            {
                throw new ArgumentNullException(nameof(storePermission));
            }

            var addedStorePermission = await _storePermissionRepository.AddAsync(storePermission);

            return addedStorePermission;
        }

        public async Task<bool> DeleteStorePermissionAsync(int permissionId)
        {
            var deleted = await _storePermissionRepository.DeleteAsync(permissionId);

            return deleted;
        }

        public async Task<StorePermission> GetStorePermissionByIdAsync(int permissionId)
        {
            var storePermission = await _storePermissionRepository.GetByIdAsync(permissionId);

            return storePermission;
        }

        public async Task<IEnumerable<StorePermission>> GetStorePermissionsAsync()
        {
            var storePermissions = await _storePermissionRepository.GetAllAsync();

            return storePermissions;
        }

        public async Task<IEnumerable<StorePermission>> GetStorePermissionsByStoreIdAsync(int storeId)
        {
            var storePermissions = await _storePermissionRepository.GetStorePermissionsByStoreIdAsync(storeId);

            return storePermissions;
        }

        public async Task<IEnumerable<StorePermission>> GetStorePermissionsByUserIdAsync(int userId)
        {
            var storePermissions = await _storePermissionRepository.GetStorePermissionsByUserIdAsync(userId);

            return storePermissions;
        }

        public async Task<StorePermission> UpdateStorePermissionAsync(int permissionId, StorePermission storePermission)
        {
            var existingPermission = await _storePermissionRepository.GetByIdAsync(permissionId);

            if (existingPermission == null)
            {
                throw new KeyNotFoundException($"StorePermission with id {permissionId} not found");
            }

            // Update only non-null properties
            if (storePermission != null)
            {
                if (storePermission.CanAddProducts != null)
                {
                    existingPermission.CanAddProducts = storePermission.CanAddProducts;
                }

                if (storePermission.CanEditProducts != null)
                {
                    existingPermission.CanEditProducts = storePermission.CanEditProducts;
                }

                if (storePermission.CanDeleteProducts != null)
                {
                    existingPermission.CanDeleteProducts = storePermission.CanDeleteProducts;
                }

                if (storePermission.CanViewOrders != null)
                {
                    existingPermission.CanViewOrders = storePermission.CanViewOrders;
                }

                if (storePermission.CanEditOrders != null)
                {
                    existingPermission.CanEditOrders = storePermission.CanEditOrders;
                }
                if (storePermission.CanAddEmployees != null)
                {
                    existingPermission.CanAddEmployees = storePermission.CanAddEmployees;
                }

                if (storePermission.CanEditEmployees != null)
                {
                    existingPermission.CanEditEmployees = storePermission.CanEditEmployees;
                }

                if (storePermission.CanDeleteEmployees != null)
                {
                    existingPermission.CanDeleteEmployees = storePermission.CanDeleteEmployees;
                }
            }

            var updatedPermission = await _storePermissionRepository.UpdateAsync(permissionId, existingPermission);

            return updatedPermission;
        }
    }
}
