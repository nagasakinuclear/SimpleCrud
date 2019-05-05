using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.SchemaReader.RetrieveSchema
{
    public class ForeignKey
    {
        public string ForeignName { get; set; }
        public string ReferencedTableName { get; set; }
        public Table ReferencedTable { get; set; }
    }
}
