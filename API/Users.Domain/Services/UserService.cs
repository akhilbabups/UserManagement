using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Domain.Interfaces.Repository;
using Users.Domain.Interfaces.Services;
using Users.Domain.Models;

namespace Users.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await userRepository.GetUsersAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await userRepository.AddUserAsync(user);
        }

        public async Task<bool> UpdateUserAsyn(User user)
        {
            return true;
        }
    }
}