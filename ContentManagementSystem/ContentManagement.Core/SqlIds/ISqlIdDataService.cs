using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.SqlIds
{
    public interface ISqlIdDataService
        : IDisposable
    {
        IEnumerable<T> GetIdTable<T>(string tableName)
            where T : class;
    }
}
