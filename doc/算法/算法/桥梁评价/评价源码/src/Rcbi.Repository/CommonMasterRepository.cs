using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Rcbi.AspNetCore.Helper;
using Rcbi.Entity;
using Rcbi.Entity.Query;

namespace Rcbi.Repository
{
    /// <summary>
    /// 公共master数据库操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonMasterRepository<T> : BaseRepository<T> where T : BaseEntity
    {
        private static readonly Type attrType = typeof(ColumnAttribute);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetList(BaseQueryEntity query, out int total)
        {
            var tableInfo = this.TableInfo;

            var whereString = string.Empty;
            var orderBy = query.OrderBy;
            IList<DbParameter> parameters = null;

            var q = query as CommonQuery;
            if (q == null || !q.Where(this.DbHelper, out whereString, out parameters))
            {
                parameters = new List<DbParameter>();
            }

            var querySql = this.CreateQuerySql(tableInfo, whereString, query.StartIndex, query.PageSize, orderBy);
            var totalSql = string.Format("select count(1) from {0} where ({1}) and is_delete = 0",
                tableInfo.TabelName,
                whereString.Length == 0 ? DEFAULT_WHERE : "1=1 " + whereString.ToString());

            total = ConvertHelper.ToInt32(this.ExecuteScalar(totalSql, parameters.ToArray()));

            return this.ExecuteDataTable(querySql, parameters.ToArray());
        }

        /// <summary>
        /// 列表查询，不分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetList(BaseQueryEntity query)
        {
            var tableInfo = this.TableInfo;

            var whereString = string.Empty;
            IList<DbParameter> parameters = null;

            var q = query as CommonQuery;
            if (q == null || !q.Where(this.DbHelper, out whereString, out parameters))
            {
                parameters = new List<DbParameter>();
            }
            var querySql = this.CreateQuerySql(tableInfo, whereString, query != null ? query.OrderBy : string.Empty);

            return this.ExecuteDataTable(querySql, parameters.ToArray());
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object id)
        {
            var tableInfo = this.TableInfo;

            var sql = this.CreateQuerySql(tableInfo, "AND uuid=@uuid");

            return this.ExecuteReaderObject(sql,
                this.DbHelper.CreateParameter("@uuid", id));
        }

        public T GetByKey(object id)
        {
            var tableInfo = this.TableInfo;

            var sql = this.CreateQuerySql(tableInfo, "AND " + tableInfo.PrimaryKeys[0] + "=@id");

            DataTable dt = this.ExecuteDataTable(sql, this.DbHelper.CreateParameter("@id", id));

            if (dt.Rows.Count == 0)
                return default(T);

            return this.GetById(dt.Rows[0]["uuid"]);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override object Insert(T entity)
        {
            return Convert.ToInt32(base.Insert(entity));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            return base.Modify(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override int Delete(T entity)
        {
            return base.Delete(entity);
        }
    }
}
