using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.SqlIds.IdTables
{
    public class SecurityTypes
        : SqlIdTableBase<ContentManagement.Models.SecurityType>
    {
        [SqlId]
        public int None { get; set; }
        [SqlId]
        public int Read { get; set; }
        [SqlId]
        public int Write { get; set; }
        [SqlId]
        public int Create { get; set; }
        [SqlId]
        public int Delete { get; set; }
        [SqlId]
        public int Full { get; set; }

        public SecurityTypes()
            : base(SqlIdTables.SecurityTypes.ToString()) { }
        public SecurityTypes(ISqlIdDataService source)
            : this()
        {
            base.PopulateSqlIds(source);
        }
    }
}
