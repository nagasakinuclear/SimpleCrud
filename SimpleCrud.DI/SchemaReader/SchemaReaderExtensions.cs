using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.SchemaReader.AppLogic;
using SimpleCrud.SchemaReader.AppLogic.Contracts;

namespace SimpleCrud.DI.SchemaReader
{
    public static class SchemaReaderExtensions
    {
        public static IServiceCollection AddSchemaReaderDependencies(this IServiceCollection services)
        {
            services.AddTransient<IDbReaderService, DbReaderService>();

            return services;
        }
    }
}
