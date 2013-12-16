using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.SqlIds
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SqlIdAttribute : Attribute
    {
        public string Name { get; set; }

        public SqlIdAttribute() { }
        public SqlIdAttribute(string name)
        {
            this.Name = name;
        }
    }
}
