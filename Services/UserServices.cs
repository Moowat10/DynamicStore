using DynamicStore.DTO;
using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Repository;

namespace DynamicStore.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserRepository _userRepository;

        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }

        public async Task<User> AddUserAsync(NewUserDTO user)
        {
            var newUser = new User
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
            };
            newUser = await _userRepository.AddAsync(newUser);
            return newUser;
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var existingUser = await _userRepository.UpdateAsync(id, user);
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var result = await _userRepository.DeleteAsync(id);
            return result;
        }
    }
}
