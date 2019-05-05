

using SimpleCrud.SchemaReader.RetrieveSchema;
using System;

namespace SimpleCrud.SchemaReader
{
    public class Program
    {
        static void Main()
        {
            var sourceSchema = new TableSchema(GetConnectionString());

            Console.WriteLine();
        }

        private static string GetConnectionString()
        {
            return "data source=(LocalDb)\\MSSQLLocalDB;initial catalog=Airport;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        }

    }
}
