using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Domain.Models;

namespace Users.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
