using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Configuration.Contracts;

namespace SimpleCrud.DI.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void AddConfigurationDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IConfiguration, SimpleCrud.Configuration.Configuration>();
        }
    }
}
