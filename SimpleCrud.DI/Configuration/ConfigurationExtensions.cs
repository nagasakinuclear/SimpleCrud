using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Configuration.Contracts;

namespace SimpleCrud.DI.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddConfigurationDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IConfiguration, SimpleCrud.Configuration.Configuration>();

            return services;
        }
    }
}
