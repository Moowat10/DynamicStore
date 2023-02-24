using System.Threading.Tasks;
using DynamicStore.Interface;
using DynamicStore.Models;
using Microsoft.AspNetCore.Mvc;


namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserStorePermissionsController : ControllerBase
    {
        private readonly IUserStorePermissionRepository _repository;

        public UserStorePermissionsController(IUserStorePermissionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStorePermission>>> GetUserStorePermissionsAsync()
        {
            var permissions = await _repository.GetUserStorePermissionsAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserStorePermission>> GetUserStorePermissionByIdAsync(int id)
        {
            var permission = await _repository.GetUserStorePermissionByIdAsync(id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        [HttpGet("byuser/{userId}")]
        public async Task<ActionResult<IEnumerable<UserStorePermission>>> GetUserStorePermissionsByUserIdAsync(int userId)
        {
            var permissions = await _repository.GetUserStorePermissionsByUserIdAsync(userId);
            return Ok(permissions);
        }

        [HttpGet("bystore/{storeId}")]
        public async Task<ActionResult<IEnumerable<UserStorePermission>>> GetUserStorePermissionsByStoreIdAsync(int storeId)
        {
            var permissions = await _repository.GetUserStorePermissionsByStoreIdAsync(storeId);
            return Ok(permissions);
        }

        [HttpPost]
        public async Task<ActionResult<UserStorePermission>> AddUserStorePermissionAsync(UserStorePermission permission)
        {
            await _repository.AddUserStorePermissionAsync(permission);
            return Ok(permission);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserStorePermissionAsync(int id, UserStorePermission permission)
        {
            if (id != permission.Id)
            {
                return BadRequest();
            }

            var existingPermission = await _repository.GetUserStorePermissionByIdAsync(id);
            if (existingPermission == null)
            {
                return NotFound();
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

            await _repository.UpdateUserStorePermissionAsync(id, existingPermission);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStorePermissionAsync(int id)
        {
            var existingPermission = await _repository.GetUserStorePermissionByIdAsync(id);
            if (existingPermission == null)
            {
                return NotFound();
            }

            await _repository.DeleteUserStorePermissionAsync(id);
            return NoContent();
        }
    }
}
