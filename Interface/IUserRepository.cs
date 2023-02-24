using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(int userId, User user);
        Task<bool> DeleteUserAsync(int userId);
    }
}
