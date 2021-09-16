using Microsoft.Extensions.DependencyInjection;
using Users.Domain.Interfaces.Repository;
using Users.Domain.Interfaces.Services;
using Users.Domain.Services;
using Users.Infrastructure;

namespace Users.API
{
    public static class BindingModule
    {
        public static IServiceCollection Binding(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>();
            return services;
        }
    }
}