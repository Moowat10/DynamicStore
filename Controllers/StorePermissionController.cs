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
        private readonly IStorePermissionServices _storePermissionServices;

        public StorePermissionController(IStorePermissionServices storePermissionServices)
        {
            _storePermissionServices = storePermissionServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorePermission>>> GetStorePermissionsAsync()
        {
            var storePermissions = await _storePermissionServices.GetStorePermissionsAsync();
            return Ok(storePermissions);
        }

        [HttpGet("store/{storeId}")]
        public async Task<ActionResult<IEnumerable<StorePermission>>> GetStorePermissionsByStoreIdAsync(int storeId)
        {
            var storePermissions = await _storePermissionServices.GetStorePermissionsByStoreIdAsync(storeId);
            return Ok(storePermissions);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<StorePermission>>> GetStorePermissionsByUserIdAsync(int userId)
        {
            var storePermissions = await _storePermissionServices.GetStorePermissionsByUserIdAsync(userId);
            return Ok(storePermissions);
        }

        [HttpGet("{permissionId}")]
        public async Task<ActionResult<StorePermission>> GetStorePermissionByIdAsync(int permissionId)
        {
            var storePermission = await _storePermissionServices.GetStorePermissionByIdAsync(permissionId);

            if (storePermission == null)
            {
                return NotFound();
            }

            return Ok(storePermission);
        }

        [HttpPost]
        public async Task<ActionResult<StorePermission>> AddStorePermissionAsync(StorePermission storePermission)
        {
            var addedStorePermission = await _storePermissionServices.AddStorePermissionAsync(storePermission);
            return Ok(addedStorePermission);
           
        }

        [HttpPut("{permissionId}")]
        public async Task<ActionResult<StorePermission>> UpdateStorePermissionAsync(int permissionId, StorePermission storePermission)
        {
            var updatedPermission = await _storePermissionServices.UpdateStorePermissionAsync(permissionId, storePermission);
            if (updatedPermission == null)
            {
                return NotFound();
            }

            return Ok(updatedPermission);
        }

        [HttpDelete("{permissionId}")]
        public async Task<ActionResult<bool>> DeleteStorePermissionAsync(int permissionId)
        {
            var deleted = await _storePermissionServices.DeleteStorePermissionAsync(permissionId);

            if (deleted)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
