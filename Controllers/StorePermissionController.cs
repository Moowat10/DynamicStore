using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorePermissionController : ControllerBase
    {
        private readonly IStorePermissionRepository _storePermissionRepository;

        public StorePermissionController(IStorePermissionRepository storePermissionRepository)
        {
            _storePermissionRepository = storePermissionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorePermission>>> GetStorePermissionsAsync()
        {
            var storePermissions = await _storePermissionRepository.GetStorePermissionsAsync();
            return Ok(storePermissions);
        }

        [HttpGet("store/{storeId}")]
        public async Task<ActionResult<IEnumerable<StorePermission>>> GetStorePermissionsByStoreIdAsync(int storeId)
        {
            var storePermissions = await _storePermissionRepository.GetStorePermissionsByStoreIdAsync(storeId);
            return Ok(storePermissions);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<StorePermission>>> GetStorePermissionsByUserIdAsync(int userId)
        {
            var storePermissions = await _storePermissionRepository.GetStorePermissionsByUserIdAsync(userId);
            return Ok(storePermissions);
        }

        [HttpGet("{permissionId}")]
        public async Task<ActionResult<StorePermission>> GetStorePermissionByIdAsync(int permissionId)
        {
            var storePermission = await _storePermissionRepository.GetStorePermissionByIdAsync(permissionId);

            if (storePermission == null)
            {
                return NotFound();
            }

            return Ok(storePermission);
        }

        [HttpPost]
        public async Task<ActionResult<StorePermission>> AddStorePermissionAsync(StorePermission storePermission)
        {
            var addedStorePermission = await _storePermissionRepository.AddStorePermissionAsync(storePermission);
            return CreatedAtAction(nameof(GetStorePermissionByIdAsync), new { permissionId = addedStorePermission.PermissionId }, addedStorePermission);
        }

        [HttpPut("{permissionId}")]
        public async Task<ActionResult<StorePermission>> UpdateStorePermissionAsync(int permissionId, StorePermission storePermission)
        {
            var existingPermission = await _storePermissionRepository.GetStorePermissionByIdAsync(permissionId);

            if (existingPermission == null)
            {
                return NotFound();
            }

            // Update only non-null properties
            if (existingPermission != null)
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

            var updatedPermission = await _storePermissionRepository.UpdateStorePermissionAsync(permissionId, existingPermission);

            return Ok(updatedPermission);
        }

        [HttpDelete("{permissionId}")]
        public async Task<ActionResult<bool>> DeleteStorePermissionAsync(int permissionId)
        {
            var deleted = await _storePermissionRepository.DeleteStorePermissionAsync(permissionId);

            if (deleted)
            {
                return Ok(true);
            }

            return NotFound();
        }
    }
}
