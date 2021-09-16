using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Domain.Models;

namespace Users.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> AddUserAsync(User user);

        Task<bool> UpdateUserAsyn(User user);
    }
}