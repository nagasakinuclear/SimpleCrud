using DatabaseSchemaReader;
using System;
using System.Diagnostics;

namespace SimpleCrud.SchemaReader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string providername = "System.Data.SqlClient";
            const string connectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=true;Initial Catalog=Northwind";

            var dbReader = new DatabaseReader(connectionString, providername);
            var schema = dbReader.ReadAll();

            foreach (var table in schema.Tables)
            {
                Debug.WriteLine("Table " + table.Name);

                foreach (var column in table.Columns)
                {
                    Debug.Write("\tColumn " + column.Name + "\t" + column.DataType.TypeName);
                    if (column.DataType.IsString) Debug.Write("(" + column.Length + ")");
                    if (column.IsPrimaryKey) Debug.Write("\tPrimary key");
                    if (column.IsForeignKey) Debug.Write("\tForeign key to " + column.ForeignKeyTable.Name);
                    Debug.WriteLine("");
                }
                //Table Products
                // Column ProductID int Primary key
                // Column ProductName nvarchar(40)
                // Column SupplierID int Foreign key to Suppliers
                // Column CategoryID int Foreign key to Categories
                // Column QuantityPerUnit nvarchar(20)
                // Column UnitPrice money
                // Column UnitsInStock smallint
                // Column UnitsOnOrder smallint
                // Column ReorderLevel smallint
                // Column Discontinued bit
            }
        }
    }
}
