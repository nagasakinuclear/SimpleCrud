
using SimpleCrud.Configuration.Contracts;
using SimpleCrud.SchemaReader.RetrieveSchema.Options.SelectionIndex;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SimpleCrud.SchemaReader.RetrieveSchema
{
    public class TableSchema
    {
        private IConfiguration _configuration;
        public TableSchema(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void GetDataBaseSchema()
        {
            List<Table> _tables = new List<Table>();

            using (SqlConnection connection = new SqlConnection(_configuration.ConnectionString))
            {
                connection.Open();

                DataTable schemaTables = connection.GetSchema(CollectionNameOptions.Tables);

                foreach (DataRow rowTable in schemaTables.Rows)
                {
                    String tableName = rowTable.ItemArray[(int)TableSelectionIndex.Name].ToString();
                    Table currentTable = new Table(tableName);

                    string[] restrictionsColumns = new string[4];
                    restrictionsColumns[(int)RestrictionSelectionIndex.TableName] = tableName;
                    DataTable schemaColumns = connection.GetSchema(CollectionNameOptions.Columns, restrictionsColumns);

                    foreach (DataRow rowColumn in schemaColumns.Rows)
                    {
                        string ColumnName = rowColumn[(int)ColumnSelectionIndex.Name].ToString();
                        string ColumnType = rowColumn[(int)ColumnSelectionIndex.Type].ToString();

                        currentTable.Columns.Add(new Column() { Name = ColumnName, Type = ColumnType });
                    }

                    string[] restrictionsPrimaryKey = new string[4];
                    restrictionsPrimaryKey[(int)RestrictionSelectionIndex.TableName] = tableName;
                    DataTable schemaPrimaryKey = connection.GetSchema(CollectionNameOptions.IndexColumns, restrictionsColumns);

                    foreach (DataRow rowPrimaryKey in schemaPrimaryKey.Rows)
                    {
                        string indexName = rowPrimaryKey[2].ToString();

                        if (indexName.IndexOf("PK_") != -1)
                        {
                            currentTable.PrimaryKey = new PrimaryKey()
                            {
                                FieldName = rowPrimaryKey[6].ToString(),
                                PrimaryKeyName = indexName
                            };
                        }

                        if (indexName.IndexOf("UQ_") != -1)
                        {
                            currentTable.UniqueKeys.Add(new UniqueKey()
                            {
                                FieldName = rowPrimaryKey[6].ToString(),
                                UniqueKeyName = indexName
                            });
                        }
                    }

                    string[] restrictionsForeignKeys = new string[4];
                    restrictionsForeignKeys[(int)RestrictionSelectionIndex.TableName] = tableName;
                    DataTable schemaForeignKeys = connection.GetSchema(CollectionNameOptions.ForeignKeys, restrictionsColumns);

                    foreach (DataRow rowFK in schemaForeignKeys.Rows)
                    {
                        var foreignName = rowFK[(int)ForeignKeySelectionIndex.Name].ToString();
                        var referencedTableName = rowFK[(int)ForeignKeySelectionIndex.ReferencedTableName].ToString();

                        currentTable.ForeignKeys.Add(new ForeignKey()
                        {
                            ForeignName = foreignName,
                            ReferencedTableName = referencedTableName
                        });
                    }

                    _tables.Add(currentTable);
                }
            }
        }
    }
}
