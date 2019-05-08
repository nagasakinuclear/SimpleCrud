using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.SchemaReader.Domain.Schema
{
    public class SchematicTable
    {
        public string TableName { get; set; }
        public PrimaryKey PrimaryKey { get; set; }
        public List<Column> Columns { get; set; }
        public List<UniqueKey> UniqueKeys { get; set; }
        public List<ForeignKey> ForeignKeys { get; set; }

        public SchematicTable(string tableName)
        {
            UniqueKeys = new List<UniqueKey>();
            ForeignKeys = new List<ForeignKey>();
            Columns = new List<Column>();

            TableName = tableName;
        }
    }
}
