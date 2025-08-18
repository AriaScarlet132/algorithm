using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;

using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

using Rcbi.Core.Extensions;
using Rcbi.Core.Attributes;

namespace Rcbi.AspNetCore.Helper
{
    public class DbHelper : IDisposable
    {
        private DbProviderFactory factory;
        private DbConnection connection;
        private DbTransaction transaction;
        private string connectionString;
        private static readonly Type attrType = typeof(ColumnAttribute);
        private static readonly Type nullableType = typeof(Nullable<>);
        private readonly int CommandTimeout = 5000;

        public DbConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
        
        public DbTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        public DbHelper(string connectionString, string dbProviderName)
        {
            this.connectionString = connectionString;
            this.factory = DbProviderFactories.GetDbProviderFactory(dbProviderName);
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void OpenConnection()
        {
            if (Connection == null)
            {
                Connection = factory.CreateConnection();
                Connection.ConnectionString = this.connectionString;
            }
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
            OpenConnection();
            if (Transaction == null)
                Transaction = Connection.BeginTransaction();
        }

        /// <summary>
        /// 提交事务 并且 释放并关闭资源
        /// </summary>
        public void CommitTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
                Dispose();
            }
        }

        /// <summary>
        /// 回滚事务 并且 释放并关闭资源
        /// </summary>
        public void RollbackTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction.Dispose();
                Transaction = null;
                Dispose();
            }
        }

        /// <summary>
        /// 如果没有开启事务就自动释放资源，关闭连接，否则在提交或回滚事务的时候释放
        /// </summary>
        public void Dispose()
        {
            if (Transaction == null)
            {
                if (Connection != null)
                {
                    Connection.Dispose();
                    Connection.Close();
                    Connection = null;
                }
            }
        }
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string parameterName, object value)
        {
            var param = factory.CreateParameter();
            param.ParameterName = parameterName;
            param.Value = value;
            return param;
        }
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string parameterName, object value, DbType dbType, int size)
        {
            var param = factory.CreateParameter();
            param.ParameterName = parameterName;
            param.Value = value;
            param.DbType = dbType;
            param.Size = size;

            return param;
        }
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string parameterName, object value, DbType dbType, int size, ParameterDirection direction)
        {
            var param = factory.CreateParameter();
            param.ParameterName = parameterName;
            param.Value = value;
            param.DbType = dbType;
            param.Size = size;
            param.Direction = direction;

            return param;
        }

        private DbCommand CreateCommand(CommandType cmdType, string cmdText, params DbParameter[] cmdParas)
        {
            DbCommand mand = Connection.CreateCommand();
            mand.CommandText = cmdText;
            mand.CommandType = cmdType;
            mand.CommandTimeout = CommandTimeout;
            if (cmdParas != null)
                mand.Parameters.AddRange(cmdParas);
            if (Transaction != null) mand.Transaction = Transaction;
            return mand;
        }

        /// <summary>
        /// 返回一个数据集
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText, CommandType cmdType, params DbParameter[] cmdParas)
        {
            cmdText = cmdText.Replace("()", "(0)");
            try
            {
                OpenConnection();
                DbCommand mand = CreateCommand(cmdType, cmdText, cmdParas);
                DbDataAdapter data = factory.CreateDataAdapter();
                data.SelectCommand = mand;
                DataSet ds = new DataSet();
                data.Fill(ds);
                return ds;
            }
            finally { Dispose(); }
        }
        /// <summary>
        /// 返回一个数据表
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string cmdText, params DbParameter[] cmdParas)
        {
            var ds = ExecuteDataSet(cmdText, CommandType.Text, cmdParas);

            return ds != null && ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }
        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, CommandType cmdType, params DbParameter[] cmdParas)
        {
            int result = 0;
            try
            {
                OpenConnection();
                DbCommand mand = CreateCommand(cmdType, cmdText, cmdParas);
                result = mand.ExecuteNonQuery();
            }
            finally
            {
                Dispose();
            }
            return result;
        }

        /// <summary>
        /// 返回结果集中第一行第一列
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public object ExecuteScalar(string cmdText, CommandType cmdType, params DbParameter[] cmdParas)
        {
            try
            {
                OpenConnection();
                DbCommand mand = CreateCommand(cmdType, cmdText, cmdParas);
                return mand.ExecuteScalar();
            }
            finally { Dispose(); }
        }

        /// <summary>
        /// 返回泛型集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public IList<T> ExecuteReaderList<T>(string cmdText, CommandType cmdType, params DbParameter[] cmdParas)
        {
            try
            {
                OpenConnection();
                DbCommand mand = CreateCommand(cmdType, cmdText, cmdParas);
                DbDataReader reader = mand.ExecuteReader();
                IList<T> list = ToList<T>(reader);
                return list;
            }
            finally { Dispose(); }
        }

        /// <summary>
        /// 返回一个对象 如数据库无结果返回将抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public T ExecuteReaderObject<T>(string cmdText, CommandType cmdType, params DbParameter[] cmdParas)
        {
            var list = ExecuteReaderList<T>(cmdText, cmdType, cmdParas);
            return list.Count > 0 ? list[0] : default(T);
        }

        /// <summary>
        /// 修改表名
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="originalName"></param>
        public void ModifyTableName(string newName, string originalName)
        {
            var sql = string.Format(@"ALTER TABLE {0} RENAME {1}", originalName, newName);

            OpenConnection();
            DbCommand mand = CreateCommand(CommandType.Text, sql, null);
            mand.ExecuteScalar();
        }

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public bool IsTableExists(string tableName, string dbName)
        {
            var sql = @"SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME=@tableName AND TABLE_SCHEMA = @dbName";

            OpenConnection();
            DbCommand mand = CreateCommand(CommandType.Text, sql,
                   this.CreateParameter("@tableName", tableName),
                   this.CreateParameter("@dbName", dbName)
                );
            DbDataAdapter data = factory.CreateDataAdapter();
            data.SelectCommand = mand;
            DataSet ds = new DataSet();
            data.Fill(ds);
            return ds.Tables[0].Rows.Count > 0;
        }

        /// <summary>
        /// 反射创建泛型集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        private IList<T> ToList<T>(DbDataReader reader)
        {
            Type type = typeof(T);
            IList<T> list = null;
            if (type.IsValueType || type == typeof(string))
                list = CreateValue<T>(reader, type);
            else
                list = CreateObject<T>(reader, type);
            reader.Dispose();
            reader.Close();
            return list;
        }

        private IList<T> CreateObject<T>(DbDataReader reader, Type type)
        {
            IList<T> list = new List<T>();
            PropertyInfo[] properties = type.GetProperties();
            string name = string.Empty, fieldName = string.Empty;
            Type fieldType = null;
            while (reader.Read())
            {
                T local = Activator.CreateInstance<T>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    name = reader.GetName(i);
                    foreach (PropertyInfo info in properties)
                    {
                        fieldName = info.IsDefined(attrType, false) ?
                            ((ColumnAttribute)info.GetCustomAttributes(attrType, false)[0]).Name : info.Name;

                        if (name.Equals(fieldName) && !(reader[fieldName] is DBNull))
                        {
                            fieldType = (info.PropertyType.IsGenericType &&
                                info.PropertyType.GetGenericTypeDefinition() == nullableType) ?
                                Nullable.GetUnderlyingType(info.PropertyType) : info.PropertyType;

                            if (fieldType.IsEnum)
                            {
                                info.SetValue(local, Enum.ToObject(fieldType, reader[fieldName]), null);
                            }
                            else
                            {
                                info.SetValue(local, Convert.ChangeType(reader[fieldName], fieldType), null);
                            }
                            break;
                        }
                    }
                }
                list.Add(local);
            }
            return list;
        }

        private IList<T> CreateValue<T>(DbDataReader reader, Type type)
        {
            IList<T> list = new List<T>();
            while (reader.Read())
            {
                T local = (T)Convert.ChangeType(reader[0], type, null);
                list.Add(local);
            }
            return list;
        }
    }

    internal static class DbProviderFactories
    {
        public static DbProviderFactory GetDbProviderFactory(string providerName)
        {
            if (providerName.IsNullOrEmpty())
                throw new ArgumentNullException("providerName");

            if (providerName == "MySql.Data.MySqlClient")
                return new MySqlClientFactory();

            else if (providerName == "System.Data.SqlClient")
                return SqlClientFactory.Instance;

            throw new NotSupportedException(providerName);
        }
    }
}
