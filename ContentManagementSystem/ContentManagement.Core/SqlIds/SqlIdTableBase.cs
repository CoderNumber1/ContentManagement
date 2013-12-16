using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ContentManagement.SqlIds
{
    public abstract class SqlIdTableBase<T>
        where T : class
    {
        private string _KeyColumnName = "Name";
        protected string KeyColumnName
        {
            get { return this._KeyColumnName; }
            set { this._KeyColumnName = value; }
        }

        private string _ValueColumnName = "Id";
        protected string ValueColumnName
        {
            get { return this._ValueColumnName; }
            set { this._ValueColumnName = value; }
        }

        protected string TableName { get; set; }

        protected SqlIdTableBase()
        {
            this.TableName = null;
        }
        public SqlIdTableBase(string tableName)
        {
            this.TableName = tableName;
        }
        public SqlIdTableBase(string tableName, ISqlIdDataService source)
        {
            this.TableName = tableName;
            this.PopulateSqlIds(source);
        }

        public void PopulateSqlIds(ISqlIdDataService source)
        {
            IEnumerable<T> idTable = source.GetIdTable<T>(this.TableName);
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object attr = property.GetCustomAttributes(typeof(SqlIdAttribute), true).FirstOrDefault();
                if (attr != null)
                {
                    string keyName = null;
                    var sqlId = (SqlIdAttribute)attr;
                    if (!string.IsNullOrEmpty(sqlId.Name))
                        keyName = sqlId.Name;
                    else
                        keyName = property.Name;

                    if (!string.IsNullOrEmpty(keyName))
                    {
                        int id = -1;
                        foreach (T row in idTable)
                        {
                            PropertyInfo[] rowProperties = row.GetType().GetProperties();
                            PropertyInfo keyColumn = rowProperties.FirstOrDefault(prop => prop.Name.ToUpper() == this.KeyColumnName.ToUpper());
                            if (keyColumn != null && keyColumn.GetValue(row, null).ToString().ToUpper() == keyName.ToUpper())
                            {
                                PropertyInfo idColumn = rowProperties.FirstOrDefault(prop => prop.Name.ToUpper() == this.ValueColumnName.ToUpper());
                                if (idColumn != null)
                                    id = (int)idColumn.GetValue(row, null);

                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
