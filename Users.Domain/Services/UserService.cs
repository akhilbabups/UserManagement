using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Domain.Interfaces.Repository;
using Users.Domain.Interfaces.Services;
using Users.Domain.Models;

namespace Users.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await _userRepository.AddUserAsync(user);
        }
    }
}
