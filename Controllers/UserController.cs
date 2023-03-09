using DynamicStore.Models;
using DynamicStore.DTO;
using Microsoft.AspNetCore.Mvc;
using DynamicStore.Interface;

namespace DynamicStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userServices.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewUserDTO user)
        {
            var newUser = await _userServices.AddUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            var existingUser = await _userServices.UpdateUserAsync(id, user);

            if (existingUser == null)
            {
                return NotFound();
            }

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userServices.DeleteUserAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
