using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.SqlIds.IdTables
{
    public class ContentTypes
        : SqlIdTableBase<ContentManagement.Models.ContentType>
    {
        [SqlId]
        public int User { get; set; }
        [SqlId("User Group")]
        public int UserGroup { get; set; }
        [SqlId("Users Collection")]
        public int UserCollection { get; set; }
        [SqlId("User Groups Collection")]
        public int UserGroupsCollection { get; set; }
        [SqlId("Content Collection")]
        public int ContentCollection { get; set; }
        [SqlId]
        public int Page { get; set; }
        [SqlId("Place Holder")]
        public int PlaceHolder { get; set; }
        [SqlId("Navigation Structure")]
        public int NavigationStructure { get; set; }

        public ContentTypes()
            : base(SqlIdTables.ContentTypes.ToString()) { }
        public ContentTypes(ISqlIdDataService source)
            : this()
        {
            base.PopulateSqlIds(source);
        }
    }
}
