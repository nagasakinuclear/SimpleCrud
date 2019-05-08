using SimpleCrud.SchemaReader.Domain.Schema;
using System.Collections.Generic;

namespace SimpleCrud.SchemaReader.AppLogic.Contracts
{
    public interface IDbReaderService
    {
        List<SchematicTable> GetDataBaseSchema();
    }
}