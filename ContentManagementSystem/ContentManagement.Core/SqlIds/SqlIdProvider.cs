using ContentManagement.SqlIds.IdTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.SqlIds
{
    public class SqlIdProvider
    {
        private static Lazy<SqlIdProvider> _Instance = new Lazy<SqlIdProvider>(() => new SqlIdProvider());
        public static SqlIdProvider Instance { get { return _Instance.Value; } }
        private SqlIdProvider()
        {
            using (ISqlIdDataService source = new DataServices.SqlIdTableDataService())
            {
                this.Init(source);
            }
        }

        public SecurityTypes SecurityTypes { get; set; }
        public ContentSources ContentSources { get; set; }
        public ContentTypes ContentTypes { get; set; }
        public CoreContent CoreContent { get; set; }

        //public SqlIdProvider()
        //{
        //    this.SecurityTypes = new SecurityTypes();
        //    this.ContentSources = new ContentSources();
        //    this.ContentTypes = new ContentTypes();
        //}
        public void Init(ISqlIdDataService source)
        {
            this.SecurityTypes = new SecurityTypes(source);
            this.ContentSources = new ContentSources(source);
            this.ContentTypes = new ContentTypes(source);
            this.CoreContent = new CoreContent(source);
        }
    }
}
