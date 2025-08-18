using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Rcbi.Core.Attributes;

namespace Rcbi.Core.Extensions
{
    public static class DataTableExtension
    {
        private static readonly Type attrType = typeof(ColumnAttribute);
        private static readonly Type nullableType = typeof(Nullable<>);

        public static T ToEntity<T>(this DataRow row)
        {
            T entity = Activator.CreateInstance<T>();

            if (entity == null || row == null)
            {
                return default(T);
            }

            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();

            string fieldName = null;
            Type fieldType = null;

            foreach (PropertyInfo info in propertyInfos)
            {
                if (!info.CanWrite)
                    continue;

                fieldName = info.IsDefined(attrType, false) ?
                    ((ColumnAttribute)info.GetCustomAttributes(attrType, false)[0]).Name : info.Name;

                if (!row.Table.Columns.Contains(fieldName) ||
                    row[fieldName] is DBNull)
                    continue;

                fieldType = (info.PropertyType.IsGenericType &&
                        info.PropertyType.GetGenericTypeDefinition() == nullableType) ?
                        Nullable.GetUnderlyingType(info.PropertyType) : info.PropertyType;

                info.SetValue(entity,
                    fieldType.IsEnum ? Enum.Parse(fieldType, row[fieldName].ToString()) : Convert.ChangeType(row[fieldName], fieldType), null);
            }

            return entity;
        }

        public static object ToEntity(this DataRow row, Type type) 
        {
            object entity = Activator.CreateInstance(type);

            if (row == null || entity == null)
               return null;

            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();

            string fieldName = null;
            Type fieldType = null;

            foreach (PropertyInfo info in propertyInfos)
            {
                if (!info.CanWrite)
                    continue;

                fieldName = info.IsDefined(attrType, false) ?
                    ((ColumnAttribute)info.GetCustomAttributes(attrType, false)[0]).Name : info.Name;

                if (!row.Table.Columns.Contains(fieldName) ||
                    row[fieldName] is DBNull)
                    continue;

                fieldType = (info.PropertyType.IsGenericType &&
                        info.PropertyType.GetGenericTypeDefinition() == nullableType) ?
                        Nullable.GetUnderlyingType(info.PropertyType) : info.PropertyType;

                info.SetValue(entity,
                     fieldType.IsEnum ? Enum.Parse(fieldType, row[fieldName].ToString()) : Convert.ChangeType(row[fieldName], fieldType), null);
            }

            return entity;
        }

        public static IList<T> ToList<T>(this DataTable dt)
        {
            List<T> _list = new List<T>();

            foreach (DataRow _row in dt.Rows)
            {
                _list.Add(_row.ToEntity<T>());
            }

            return _list;
        }

        public static IEnumerable<JObject> ToJObjects(this DataTable dt)
        {
            var items = new List<JObject>();
            JObject item = null;

            foreach (DataRow dr in dt.Rows)
            {
                item = new JObject();
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dr[dc] == DBNull.Value)
                        item.Add(new JProperty(dc.ColumnName, null));
                    else if(dc.DataType == typeof(DateTime))
                        item.Add(new JProperty(dc.ColumnName, Convert.ToDateTime(dr[dc])));
                    else 
                        item.Add(new JProperty(dc.ColumnName, dr[dc].ToString()));
                }
                items.Add(item);
            }

            return items;
        }

        public static T ToDefaultOrFristEntity<T>(this DataTable dt)
        {
            return (dt == null || dt.Rows.Count == 0) ? 
                                 default(T) : dt.Rows[0].ToEntity<T>();
        }

        public static IList<object> ToList(this DataTable dt, Type type) 
        {
            IList<object> _list = new List<object>();

            foreach (DataRow _row in dt.Rows)
            {
                _list.Add(_row.ToEntity(type));
            }

            return _list;
        }

        public static string ToJson(this DataTable dt, string tableName) 
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                JsonSerializer ser = new JsonSerializer();
                jw.WriteStartObject();
                jw.WritePropertyName(tableName);
                jw.WriteStartArray();
                foreach (DataRow dr in dt.Rows)
                {
                    jw.WriteStartObject();

                    foreach (DataColumn dc in dt.Columns)
                    {
                        jw.WritePropertyName(dc.ColumnName);
                        ser.Serialize(jw, dr[dc].ToString());
                    }
                    jw.WriteEndObject();
                }
                jw.WriteEndArray();
                jw.WriteEndObject();

                sw.Close();
                jw.Close();
            }
            return sb.ToString();
        }

        public static bool IsEmpty(this DataTable dt) 
        {
            return dt == null || dt.Rows.Count == 0;
        }
    }
}
