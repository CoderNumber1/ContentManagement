using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.SqlIds.IdTables
{
    public class CoreContent
        : SqlIdTableBase<ContentManagement.Models.Content>
    {
        [SqlId("User Groups")]
        public int UserGroups { get; set; }
        [SqlId]
        public int Users { get; set; }
        [SqlId("Main Collection")]
        public int MainCollection { get; set; }
        [SqlId("Content Collection")]
        public int ContentCollection { get; set; }

        public CoreContent()
            : base(SqlIdTables.Content.ToString()) { }
        public CoreContent(ISqlIdDataService source)
            : this()
        {
            base.PopulateSqlIds(source);
        }
    }
}
