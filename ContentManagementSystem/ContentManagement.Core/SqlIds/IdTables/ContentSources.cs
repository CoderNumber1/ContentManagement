using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.SqlIds.IdTables
{
    public class ContentSources
        : SqlIdTableBase<ContentManagement.Models.ContentSource>
    {
        [SqlId("File System")]
        public int FileSystem { get; set; }
        [SqlId]
        public int Database { get; set; }
        [SqlId]
        public int DLL { get; set; }
        [SqlId("Remote URL")]
        public int RemoteUrl { get; set; }

        public ContentSources()
            : base(SqlIdTables.ConentSources.ToString()) { }
        public ContentSources(ISqlIdDataService source)
            : this()
        {
            base.PopulateSqlIds(source);
        }
    }
}
