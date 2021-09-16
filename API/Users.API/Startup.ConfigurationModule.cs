using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Domain.Configurations;

namespace Users.API
{
    public static class ConfigurationModule
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UsersStorage>(configuration.GetSection("UsersStorage"));
            return services;
        }
    }
}