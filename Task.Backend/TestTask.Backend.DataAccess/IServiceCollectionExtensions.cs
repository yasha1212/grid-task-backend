using Microsoft.Extensions.DependencyInjection;
using TestTask.Backend.DataAccess.Json;
using TestTask.Backend.DataAccess.Repositories.Users;

namespace TestTask.Backend.DataAccess
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services) 
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IUserRepository, JsonUserRepository>();

            return services;
        }
    }
}

