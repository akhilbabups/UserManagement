using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Users.Domain.Configurations;

namespace Users.Infrastructure
{
    public abstract class BaseConnectionFactory
    {
        private IMongoClient _client;
        internal IMongoDatabase database;
        private readonly UsersStorage _storageConfig;

        public BaseConnectionFactory(IOptions<UsersStorage> options)
        {
            _storageConfig = options.Value;
            GetClient();
            database = _client.GetDatabase(_storageConfig.DatabaseName);
        }

        /// <summary>
        /// Thread safe. Only one connection will be established for the application.
        /// </summary>
        private void GetClient()
        {
            if (_client == null)
            {
                _client = new MongoClient(_storageConfig.ConnectionString);
            }
        }
    }
}