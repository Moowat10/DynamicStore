using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync(User user)
        {
            var addedUser = await _userRepository.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserByIdAsync), new { userId = addedUser.UserId }, addedUser);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(int userId, UserUpdateDTO user)
        {
            if (userId != user.UserId)
            {
                return BadRequest();
            }

            var existingUser = await _userRepository.GetUserByIdAsync(userId);

            if (existingUser == null)
            {
                return NotFound();
            }
            if(user.Username != null)
            existingUser.Username = user.Username;
            if (user.Password != null)
                existingUser.Password = user.Password;

            await _userRepository.UpdateUserAsync(userId, existingUser);

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(int userId)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userId);

            if (existingUser == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUserAsync(userId);

            return NoContent();
        }
    }
    }
