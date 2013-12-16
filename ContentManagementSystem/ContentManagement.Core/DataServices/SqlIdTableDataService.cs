using ContentManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.DataServices
{
    public class SqlIdTableDataService
        : SqlIds.ISqlIdDataService
    {
        public IEnumerable<T> GetIdTable<T>(string tableName) where T : class
        {
            object result;
            SqlIds.SqlIdTables table = (SqlIds.SqlIdTables)Enum.Parse(typeof(SqlIds.SqlIdTables), tableName);

            using(IContentManagementRepository repository = new ContentManagementRepository())
            {
                switch(table)
                {
                    case SqlIds.SqlIdTables.ContentTypes:
                        result = repository.GetContentTypes().ToList();
                        break;
                    case SqlIds.SqlIdTables.ConentSources:
                        result = repository.GetContentSources().ToList();
                        break;
                    case SqlIds.SqlIdTables.SecurityTypes:
                        result = repository.GetSecurityTypes().ToList();
                        break;
                    default:
                        result = null;
                        break;
                }
            }

            return result as IEnumerable<T>;
        }

        #region IDisposable
        private bool disposed = false;
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                { }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }
        ~SqlIdTableDataService()
        {
            this.Dispose(false);
        }
        #endregion
    }
}
