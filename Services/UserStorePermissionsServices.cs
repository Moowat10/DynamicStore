using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Services
{
    public class UserStorePermissionsServices : IUserStorePermissionServices
    {
        private readonly IUserStorePermissionRepository _userStorePermissionRepository;

        public UserStorePermissionsServices(IUserStorePermissionRepository userStorePermissionRepository)
        {
            _userStorePermissionRepository = userStorePermissionRepository;
        }

        public async Task<IEnumerable<UserStorePermission>> GetAllUserStorePermissionsAsync()
        {
            return await _userStorePermissionRepository.GetAllAsync();
        }

        public async Task<UserStorePermission> GetUserStorePermissionByIdAsync(int id)
        {
            return await _userStorePermissionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByUserIdAsync(int userId)
        {
            return await _userStorePermissionRepository.GetUserStorePermissionsByUserIdAsync(userId);
        }

        public async Task<IEnumerable<UserStorePermission>> GetUserStorePermissionsByStoreIdAsync(int storeId)
        {
            return await _userStorePermissionRepository.GetUserStorePermissionsByStoreIdAsync(storeId);
        }

        public async Task<UserStorePermission> AddUserStorePermissionAsync(UserStorePermission permission)
        {
            await _userStorePermissionRepository.AddAsync(permission);
            return permission;
        }

        public async Task<UserStorePermission> UpdateUserStorePermissionAsync(int id, UserStorePermission permission)
        {
            var existingPermission = await _userStorePermissionRepository.GetByIdAsync(id);
            if (existingPermission == null)
            {
                return null;
            }

            // Update the desired properties
            if (permission.UserId != null)
            {
                existingPermission.UserId = permission.UserId;
            }

            if (permission.PermissionId != null)
            {
                existingPermission.PermissionId = permission.PermissionId;
            }

            await _userStorePermissionRepository.UpdateAsync(id, existingPermission);
            return existingPermission;
        }

        public async Task<bool> DeleteUserStorePermissionAsync(int id)
        {
            var existingPermission = await _userStorePermissionRepository.GetByIdAsync(id);
            if (existingPermission == null)
            {
                return false;
            }

            await _userStorePermissionRepository.DeleteAsync(id);
            return true;
        }
    }
}
