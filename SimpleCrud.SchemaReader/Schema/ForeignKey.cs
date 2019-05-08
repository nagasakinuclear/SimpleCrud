using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.SchemaReader.Domain.Schema
{
    public class ForeignKey
    {
        public string ForeignName { get; set; }
        public string ReferencedTableName { get; set; }
        public SchematicTable ReferencedTable { get; set; }
    }
}
