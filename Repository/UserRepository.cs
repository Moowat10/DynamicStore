using DynamicStore.Data;
using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Repository
{
    public class UserRepository :  Repository<User> , IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

    }
}
