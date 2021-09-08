using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain.Configurations;
using Users.Domain.Interfaces.Repository;
using Users.Domain.Models;
using Users.Infrastructure.Extensions;
using Users.Infrastructure.MDO;

namespace Users.Infrastructure
{
    public class UserRepository : BaseConnectionFactory, IUserRepository
    {
        private static string collectionName = "users";
        private readonly IMongoCollection<UserDocument> _collection;
        public UserRepository(IOptions<UsersStorage> options) : base(options)
        {
            _collection = database.GetCollection<UserDocument>(collectionName);
        }

        public async Task<User> AddUserAsync(User user)
        {
            var userDocument = user.ToDocument();
            await _collection.InsertOneAsync(userDocument);
            return userDocument.ToModel();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var res =  await _collection.FindAsync<UserDocument>(x => true);
            var result = res.ToList();
            return result.ToModel();
        }

        public async Task<User> GetUserById(string id)
        {
            var res = await _collection.FindAsync<UserDocument>(x => x.Id == id);
            var result = await res.FirstOrDefaultAsync();
            return result.ToModel();
        }
    }
}
