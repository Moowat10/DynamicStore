using System.Threading.Tasks;
using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Services;
using Microsoft.AspNetCore.Mvc;


namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserStorePermissionsController : ControllerBase
    {
        private readonly UserStorePermissionsServices _userStorePermissionsServices;

        public UserStorePermissionsController(DataContext context)
        {
            _userStorePermissionsServices = new UserStorePermissionsServices(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStorePermission>>> GetUserStorePermissionsAsync()
        {
            var permissions = await _userStorePermissionsServices.GetAllUserStorePermissionsAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserStorePermission>> GetUserStorePermissionByIdAsync(int id)
        {
            var permission = await _userStorePermissionsServices.GetUserStorePermissionByIdAsync(id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        [HttpGet("byuser/{userId}")]
        public async Task<ActionResult<IEnumerable<UserStorePermission>>> GetUserStorePermissionsByUserIdAsync(int userId)
        {
            var permissions = await _userStorePermissionsServices.GetUserStorePermissionsByUserIdAsync(userId);
            return Ok(permissions);
        }

        [HttpGet("bystore/{storeId}")]
        public async Task<ActionResult<IEnumerable<UserStorePermission>>> GetUserStorePermissionsByStoreIdAsync(int storeId)
        {
            var permissions = await _userStorePermissionsServices.GetUserStorePermissionsByStoreIdAsync(storeId);
            return Ok(permissions);
        }

        [HttpPost]
        public async Task<ActionResult<UserStorePermission>> AddUserStorePermissionAsync(UserStorePermission permission)
        {
            await _userStorePermissionsServices.AddUserStorePermissionAsync(permission);
            return Ok(permission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserStorePermissionAsync(int id, UserStorePermission permission)
        {
            if (id != permission.Id)
            {
                return BadRequest();
            }

            var updatedPermission = await _userStorePermissionsServices.UpdateUserStorePermissionAsync(id, permission);
            if (updatedPermission == null)
            {
                return NotFound();
            }
          
            return Ok(updatedPermission);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStorePermissionAsync(int id)
        {
            var existingPermission = await _userStorePermissionsServices.GetUserStorePermissionByIdAsync(id);
            if (existingPermission == null)
            {
                return NotFound();
            }

            await _userStorePermissionsServices.DeleteUserStorePermissionAsync(id);
            return Ok();
        }
    }
}
