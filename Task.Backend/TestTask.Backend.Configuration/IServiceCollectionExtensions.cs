using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestTask.Backend.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppConfiguration>(configuration);

            return services;
        }
    }
}
