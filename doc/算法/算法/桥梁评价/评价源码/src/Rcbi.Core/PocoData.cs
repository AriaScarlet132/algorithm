using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

using Rcbi.Core.Attributes;

namespace Rcbi.Core
{
    public class PocoData
    {
        private static readonly Dictionary<string, TableInfo> _typeTableInfoDictionary = new Dictionary<string, TableInfo>();
        private static readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
        private static int _rwLockTimeOut = 5000;//5s

        public static TableInfo ForType(Type type)
        {
            TableInfo tableInfo = null;
            string key = string.Format("PocoData_TableInfo_{0}", type.FullName);
            //read
            if (_rwLock.TryEnterReadLock(_rwLockTimeOut))
            {
                try
                {
                    if (_typeTableInfoDictionary.TryGetValue(key, out tableInfo))
                        return tableInfo;
                }
                finally
                {
                    _rwLock.ExitReadLock();
                }
            }

            //write
            if (_rwLock.TryEnterWriteLock(_rwLockTimeOut))
            {
                try
                {
                    //再次验证
                    if (_typeTableInfoDictionary.TryGetValue(key, out tableInfo))
                        return tableInfo;

                    #region 构建
                    tableInfo = new TableInfo();
                    List<ColumnInfo> columnInfoList = new List<ColumnInfo>();
                    List<string> primaryKeyList = new List<string>();

                    //解析Table信息
                    if (type.IsDefined(typeof(TableAttribute), false))
                    {
                        TableAttribute tableAttr = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), false)[0];
                        tableInfo.TabelName = tableAttr.Name;
                    }
                    else
                    {
                        tableInfo.TabelName = type.Name;
                    }
                    //tableInfo.Schema = tableAttr.Schema;

                    //解析字段信息
                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

#if DEBUG
                    if (properties.Length == 0)
                        throw new Exception(string.Format("请为{0}类型添加属性!!", type.Name));
#endif

                    foreach (PropertyInfo property in properties)
                    {
                        if (property.IsDefined(typeof(NotMappedAttribute))) continue;

                        ColumnInfo columnInfo = new ColumnInfo();
                        if (!property.IsDefined(typeof(ColumnAttribute), false))
                        {
                            columnInfo.ColumnName = property.Name;
                            columnInfo.FieldName = property.Name;
                            columnInfo.IsPrimaryKey = property.IsDefined(typeof(KeyAttribute), false);

                            //将主键添加到TableInfo
                            if (columnInfo.IsPrimaryKey)
                            {
                                primaryKeyList.Add(property.Name);
                            }
                        }
                        else
                        {
                            ColumnAttribute colAttr = (ColumnAttribute)property.GetCustomAttributes(typeof(ColumnAttribute), false)[0];
                            columnInfo.FieldName = property.Name;
                            if (string.IsNullOrEmpty(colAttr.Name))
                                columnInfo.ColumnName = property.Name;
                            else
                                columnInfo.ColumnName = colAttr.Name;
                            columnInfo.IsPrimaryKey = property.IsDefined(typeof(KeyAttribute), false);
                            //columnInfo.ColumnType = colAttr.ColumnType;
                            //columnInfo.Length = colAttr.Length;

                            //将主键添加到TableInfo
                            if (columnInfo.IsPrimaryKey)
                            {
                                primaryKeyList.Add(colAttr.Name);
                            }
                        }
                        columnInfo.PropertyInfo = property;
                        columnInfoList.Add(columnInfo);
                    }
                    #endregion
                    tableInfo.PrimaryKeys = primaryKeyList.ToArray();
                    tableInfo.ColumnInfos = columnInfoList.ToArray();
                    _typeTableInfoDictionary.Add(key, tableInfo);
                    return tableInfo;
                }
                finally
                {
                    _rwLock.ExitWriteLock();
                }
            }

            return tableInfo;
        }
    }

    public class TableInfo
    {
        public string TabelName { get; set; }

        //public string Schema { get; set; }

        public string[] PrimaryKeys { get; set; }

        public ColumnInfo[] ColumnInfos { get; set; }
    }

    public class ColumnInfo
    {
        /// <summary>
        /// 库中字段名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 代码中字段名
        /// </summary>
        public string FieldName { get; set; }

        //public DbType ColumnType { get; set; }

        public bool IsPrimaryKey { get; set; }

        //public int Length { get; set; }

        public System.Reflection.PropertyInfo PropertyInfo { get; set; }
    }
}
