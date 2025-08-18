using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using Rcbi.Core;
using Rcbi.Core.Attributes;
using Rcbi.Core.Extensions;
using Rcbi.AspNetCore.Helper;
using Rcbi.Entity;

namespace Rcbi.Repository
{
    public abstract class BaseRepository<T> : IDisposable where T : BaseEntity
    {
        protected DbHelper DbHelper;

        private const string SIMPLE_QUERY_SQL = "select {0} from {1} where ({2}) and is_delete=0 {4} {3}";
        protected const string DEFAULT_WHERE = "1=1";
        private TableInfo _tableInfo;

        /// <summary>
        /// 基础库帮助类构造
        /// </summary>
        public BaseRepository()
        {
            DbHelper = DBManager.CoreHelper;
        }

        /// <summary>
        /// DB中配置帮助类构造
        /// </summary>
        /// <param name="configName"></param>
        public BaseRepository(string configName)
        {
            DbHelper = DBManager.CreateDBHelper(configName);
        }
        /// <summary>
        /// 动态构造帮助类
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbProviderName"></param>
        public BaseRepository(string connectionString, string dbProviderName)
        {
            DbHelper = DBManager.CreateDBHelper(connectionString, dbProviderName);
        }

        /// <summary>
        /// 事务开始
        /// </summary>
        public void BeginTransaction()
        {
            DbHelper.BeginTransaction();
        }
        /// <summary>
        /// 事务提交
        /// </summary>
        public void CommitTransaction()
        {
            DbHelper.CommitTransaction();
        }
        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollbackTransaction()
        {
            DbHelper.RollbackTransaction();
        }
        /// <summary>
        /// 返回一个数据集
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText, params DbParameter[] cmdParas)
        {
            return DbHelper.ExecuteDataSet(cmdText, CommandType.Text, cmdParas);
        }
        /// <summary>
        /// 返回一个数据表
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string cmdText, params DbParameter[] cmdParas)
        {
            var ds = this.ExecuteDataSet(cmdText, cmdParas);

            return ds != null && ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }
        /// <summary>
        /// 返回记录条数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public int ExecuteRowCount(string cmdText, params DbParameter[] cmdParas)
        {
            var ds = this.ExecuteDataSet(cmdText, cmdParas);

            return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ds.Tables[0].Rows[0][0]) : 0;
        }

        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, params DbParameter[] cmdParas)
        {
            return DbHelper.ExecuteNonQuery(cmdText, CommandType.Text, cmdParas);
        }
        /// <summary>
        /// 返回结果集中第一行第一列
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public object ExecuteScalar(string cmdText, params DbParameter[] cmdParas)
        {
            return DbHelper.ExecuteScalar(cmdText, CommandType.Text, cmdParas);
        }
        /// <summary>
        /// 返回泛型集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public IList<T> ExecuteReaderList(string cmdText, params DbParameter[] cmdParas)
        {
            return DbHelper.ExecuteReaderList<T>(cmdText, CommandType.Text, cmdParas);
        }
        /// <summary>
        /// 返回一个对象 如数据库无结果返回将抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdText"></param>
        /// <param name="cmdParas"></param>
        /// <returns></returns>
        public T ExecuteReaderObject(string cmdText, params DbParameter[] cmdParas)
        {
            return DbHelper.ExecuteReaderObject<T>(cmdText, CommandType.Text, cmdParas);
        }
        /// <summary>
        /// 通用数据插入方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual object Insert(T entity)
        {
            TableInfo tableInfo = PocoData.ForType(typeof(T));

            List<string> columnNameList = new List<string>();
            List<string> valueNameList = new List<string>();
            List<DbParameter> valueList = new List<DbParameter>();

            int index = 0;
            string valueName = string.Empty;
            foreach (var column in tableInfo.ColumnInfos)
            {
                if (column.IsPrimaryKey ||
                    null == column.PropertyInfo.GetValue(entity) ||
                    column.PropertyInfo.IsDefined(typeof(NotInsertAttribute), false)) continue;

                valueName = string.Format("@{0}", index++);

                columnNameList.Add(column.ColumnName);
                valueNameList.Add(valueName);

                valueList.Add(
                   DbHelper.CreateParameter(
                     valueName,
                     column.PropertyInfo.GetValue(entity) ?? DBNull.Value)
                );
            }

            string cmdText = string.Format("insert into {0} ({1}) values ({2});select last_insert_id() as newid",
                                                tableInfo.TabelName,
                                                string.Join(",", columnNameList),
                                                string.Join(",", valueNameList));

            return this.ExecuteScalar(cmdText, valueList.ToArray());
        }
        /// <summary>
        /// 通用数据更新方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Modify(T entity)
        {
            TableInfo tableInfo = PocoData.ForType(typeof(T));

            /*
            if (null == tableInfo.PrimaryKeys || tableInfo.PrimaryKeys.Length == 0)
                throw new Exception(string.Format("实体{0}不存在Primary Key", typeof(T).Name));
            */

            List<string> setStringList = new List<string>();
            List<DbParameter> valueList = new List<DbParameter>();

            int index = 0;
            string valueName = string.Empty;
            ColumnInfo primaryKeyColumnInfo = null;
            foreach (var column in tableInfo.ColumnInfos)
            {
                if (column.PropertyInfo.IsDefined(typeof(NotUpdateAttribute), false))
                    continue;

                if (column.IsPrimaryKey)
                {
                    primaryKeyColumnInfo = column;
                    continue;
                }

                valueName = string.Format("@{0}", index++);
                setStringList.Add(string.Format("{0}={1}", column.ColumnName, valueName));

                valueList.Add(
                   DbHelper.CreateParameter(
                     valueName,
                     column.PropertyInfo.GetValue(entity) ?? DBNull.Value)
                );
            }

            valueList.Add(
                DbHelper.CreateParameter(
                  "@uuid",
                  entity.uuid
                ));

            string cmdText = string.Format("update {0} set {1} where {2} and is_delete=0",
                                                tableInfo.TabelName,
                                                string.Join(",", setStringList),
                                                "uuid=@uuid");

            return this.ExecuteNonQuery(cmdText, valueList.ToArray());
        }
        /// <summary>
        /// 通用删除方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Delete(T entity)
        {
            TableInfo tableInfo = PocoData.ForType(typeof(T));
            /*
            if (null == tableInfo.PrimaryKeys || tableInfo.PrimaryKeys.Length == 0)
                throw new Exception(string.Format("实体{0}不存在Primary Key", typeof(T).Name));
            */
            var model = entity as BaseModelEntity;

            if (model == null)
                throw new Exception("the type not is BaseModelEntity");
            /*
            var primaryKeyColumnInfo = tableInfo.ColumnInfos.Where((c) => 
                c.IsPrimaryKey)
                .FirstOrDefault();

            if (primaryKeyColumnInfo == null)
                throw new Exception("not find the Primary key");
            */
            List<string> setStringList = new List<string>();
            List<DbParameter> valueList = new List<DbParameter>();

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("is_delete", 1);
            dict.Add("update_user", model.UpdateUser);
            dict.Add("update_date", model.UpdateDate);

            foreach (var key in dict.Keys)
            {
                setStringList.Add(string.Format("{0}=@{0}", key));
                valueList.Add(DbHelper.CreateParameter("@" + key, dict[key]));
            }

            valueList.Add(DbHelper.CreateParameter("@uuid",
                        model.uuid));

            string cmdText = string.Format("update {0} set {1} where {2}",
                                               tableInfo.TabelName,
                                               string.Join(",", setStringList),
                                               "uuid=@uuid");

            return this.ExecuteNonQuery(cmdText, valueList.ToArray());
        }
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int BatchInsert(DataTable data, string tableName)
        {
            this.DbHelper.OpenConnection();
            using (var command = this.DbHelper.Connection.CreateCommand())
            {
                command.CommandText = GenerateInserSql(tableName, command, data);
                return command.ExecuteNonQuery();
            }
        }
        private string GenerateInserSql(string tableName, DbCommand command, DataTable table)
        {
            var names = new StringBuilder();
            var values = new StringBuilder();
            var count = table.Columns.Count;
            var i = 0;

            for (i = 0; i < count; i++)
            {
                names.AppendFormat("{0}", table.Columns[i].ColumnName);
                if (i < count - 1)
                    names.Append(",");
            }

            i = 0;
            foreach (DataRow row in table.Rows)
            {
                if (i > 0)
                {
                    values.Append(",");
                }
                values.Append("(");
                for (var j = 0; j < count; j++)
                {
                    var parameter = this.DbHelper.CreateParameter(string.Format("@{0}_{1}", i, j), row[j]);

                    values.Append(parameter.ParameterName);
                    command.Parameters.Add(parameter);

                    if (j < count - 1)
                    {
                        values.Append(",");
                    }
                }
                values.Append(")");
                i++;
            }
            return string.Format("insert into {0}({1}) values {2}", tableName, names, values);
        }
        /// <summary>
        /// 安全Like转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string SafeLike(string value)
        {
            return CommonHelper.SafeLike(value);
        }

        protected string[] GetFields(TableInfo tableInfo)
        {
            var columns = new List<string>();

            foreach (var c in tableInfo.ColumnInfos)
            {
                if (c.PropertyInfo.IsDefined(typeof(NotQueryAttribute), false))
                    continue;
                columns.Add(c.ColumnName);
            }

            return columns.ToArray();
        }

        protected string CreateQuerySql(TableInfo tableInfo, string whereString)
        {
            return string.Format(SIMPLE_QUERY_SQL,
                   string.Join(",", GetFields(tableInfo)),
                   tableInfo.TabelName,
                   whereString.IsNullOrEmpty() ? DEFAULT_WHERE : string.Join(" ", DEFAULT_WHERE, whereString),
                   string.Empty,
                   string.Empty
                );
        }

        protected string CreateQuerySql(TableInfo tableInfo, string whereString, string orderBy)
        {
            return string.Format(SIMPLE_QUERY_SQL,
                   string.Join(",", GetFields(tableInfo)),
                   tableInfo.TabelName,
                   whereString.IsNullOrEmpty() ? DEFAULT_WHERE : string.Join(" ", DEFAULT_WHERE, whereString),
                   string.Empty,
                   orderBy.IsNullOrEmpty() ? string.Empty : " order by " + orderBy
                );
        }

        protected string CreateQuerySql(TableInfo tableInfo, string whereString, int startIndex, int pageSize, string orderBy = null)
        {
            return string.Format(SIMPLE_QUERY_SQL,
                   string.Join(",", GetFields(tableInfo)),
                   tableInfo.TabelName,
                   whereString.IsNullOrEmpty() ? DEFAULT_WHERE : string.Join(" ", DEFAULT_WHERE, whereString),
                   string.Format("limit {0}, {1}", startIndex, pageSize),
                   orderBy.IsNullOrEmpty() ? string.Empty : " order by " + orderBy
                );
        }

        protected TableInfo TableInfo
        {
            get
            {
                if (_tableInfo == null)
                {
                    _tableInfo = PocoData.ForType(typeof(T));
                }

                return _tableInfo;
            }
            private set { }
        }

        public void Dispose()
        {
            if (DbHelper != null)
                DbHelper.Dispose();
        }
    }
}
