using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Sandbox
{
    class Program
    {
        static void Main()
        {

            var serviceProvider = new ServiceCollection()
               .AddSingleton<IFooService, FooService>()
               .AddSingleton<IBarService, BarService>()
               .BuildServiceProvider();


            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            //do the actual work here
            var bar = serviceProvider.GetService<IBarService>();
            bar.DoSomeRealWork();

            logger.LogDebug("All done!");
            var sourceSchema = new TableSchema(GetConnectionString());

            Console.WriteLine();
        }
    }
}
