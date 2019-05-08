
using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Configuration.Contracts;
using SimpleCrud.DI.Configuration;
using SimpleCrud.DI.SchemaReader;
using SimpleCrud.Dtos.Configuration;
using SimpleCrud.SchemaReader.AppLogic.Contracts;
using System;

namespace SimpleCrud.Sandbox
{
    class Program
    {
        static void Main()
        {
            // TODO: read from config.json

            Func<string> getConnectionString = () =>
            {
                return @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Airport;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            };


            Func<string> getProviderName = () =>
            {
                return @"System.Data.SqlClient";
            };


            var serviceProvider = new ServiceCollection()
               .AddConfigurationDependencies()
               .AddSchemaReaderDependencies()
               .BuildServiceProvider();

            var configuration = serviceProvider.GetService<IConfiguration>();
            var dbReaderService = serviceProvider.GetService<IDbReaderService>();


            configuration.LoadConfiguration(new LoadConfigurationDto()
            {
                ConnectionString = getConnectionString(),
                ProviderName = getProviderName()             
            });

            var schema = dbReaderService.GetDataBaseSchema();

            Console.WriteLine();
        }
    }
}
