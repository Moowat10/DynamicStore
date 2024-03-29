﻿using DynamicStore.DTO;
using DynamicStore.Models;

namespace DynamicStore.Interface
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> AddUserAsync(NewUserDTO user);
        Task<User> UpdateUserAsync(int userId, User userDTO);
        Task<bool> DeleteUserAsync(int userId);
    }
}
