using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

using Rcbi.AspNetCore.Helper;
using Rcbi.Entity;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Query;

namespace Rcbi.Repository
{
    public class GeneralRepository : BaseRepository<GeneralContent>
    {
        /// <summary>
        /// 根据编码获取字典配置
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetGeneralsByCode(string code)
        {
            var tableInfo = this.TableInfo;

            var sql = this.CreateQuerySql(tableInfo,
                           " and general_code=@general_code and IFNULL(general_key_parent,'')=''", "sort_num asc");

            return this.ExecuteDataTable(sql,
                         DbHelper.CreateParameter("@general_code", code));
        }

        /// <summary>
        /// 根据编码获取字典配置，带父级
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetGeneralsByCodeOfParent(string code)
        {
            var tableInfo = this.TableInfo;

            var sql = this.CreateQuerySql(tableInfo,
                           " and general_code=@general_code", "sort_num asc");

            return this.ExecuteDataTable(sql,
                         DbHelper.CreateParameter("@general_code", code));
        }

        public DataTable GetGeneralsByCodeOfChild(string code)
        {
            var tableInfo = this.TableInfo;

            var sql = this.CreateQuerySql(tableInfo,
                           " and general_code=@general_code and IFNULL(general_key_parent,'')<>''", "sort_num asc");

            return this.ExecuteDataTable(sql,
                         DbHelper.CreateParameter("@general_code", code));
        }

        /// <summary>
        /// 根据编码和Key获取字典配置
        /// </summary>
        /// <param name="code"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public DataTable GetGeneralsByCodeAndKey(string code, string key)
        {
            var tableInfo = this.TableInfo;

            var sql = this.CreateQuerySql(tableInfo,
                           " and general_code=@general_code and general_key=@general_key");

            return this.ExecuteDataTable(sql,
                         DbHelper.CreateParameter("@general_code", code),
                         DbHelper.CreateParameter("@general_key", key));
        }

        /// <summary>
        /// 字典类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTypes()
        {
            var sql = "select * from sys_general where is_delete = 0";

            return this.ExecuteDataTable(sql, null);
        }

        /// <summary>
        /// 字典父级类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetParentTypes()
        {
            var sql = "SELECT * FROM sys_general_content WHERE is_delete = 0 ";

            return this.ExecuteDataTable(sql, null);
        }

        /// <summary>
        /// 获取通用类容
        /// </summary>
        /// <returns></returns>
        public DataTable GetContents(string GenrealCode)
        {
            var sql = @"SELECT * FROM sys_general  WHERE general_code=@general_code";
            return this.ExecuteDataTable(sql,
                  this.DbHelper.CreateParameter("@general_code", GenrealCode));
        }

        /// <summary>
        /// 通用表更新
        /// </summary>
        /// <param name="generalCode"></param>
        /// <param name="generalKey"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public int UpdateGeneralByCodeAndKey(string generalCode,
            string generalKey,
            IList<KeyValuePair<string, object>> columns)
        {
            var sql = @"
                   UPDATE sys_general_content SET {0} WHERE general_code = @general_code AND general_key = @general_key
                ";

            IList<string> parametersString = new List<string>();
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(this.DbHelper.CreateParameter("@general_code", generalCode));
            parameters.Add(this.DbHelper.CreateParameter("@general_key", generalKey));

            foreach (var column in columns)
            {
                parametersString.Add(column.Key + "=@" + column.Key);
                parameters.Add(this.DbHelper.CreateParameter("@" + column.Key, column.Value));
            }

            sql = string.Format(sql, string.Join(",", parametersString));

            return this.ExecuteNonQuery(sql, parameters.ToArray());
        }

        /// <summary>
        /// 通用列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllGeneral(BaseQueryEntity query)
        {
            var whereString = string.Empty;
            var orderBy = query.OrderBy;
            IList<DbParameter> parameters = null;

            var q = query as CommonQuery;
            if (q == null || !q.Where(this.DbHelper, out whereString, out parameters))
            {
                parameters = new List<DbParameter>();
            }

            var sql = @"
                    SELECT a.* FROM sys_general_content a
                    INNER JOIN sys_general b ON a.general_code=b.general_code
                    WHERE a.is_delete<>'1' AND b.is_delete<>'1' AND ({0})
                ";
            sql = string.Format(sql, whereString.Length == 0 ? DEFAULT_WHERE : whereString);
            return this.ExecuteDataTable(sql, parameters.ToArray());
        }

        /// <summary>
        /// 通用列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetGeneralType()
        {
            return this.ExecuteDataTable("select * from sys_general_type where is_delete=0 order by sort_num;");
        }

        /// <summary>
        /// 通用列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetGeneral(int general_type_id)
        {
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(this.DbHelper.CreateParameter("@general_type_id", general_type_id));
            return this.ExecuteDataTable("select * from sys_general where is_delete=0 and general_type_id=@general_type_id order by sort_num;", parameters.ToArray());
        }

        /// <summary>
        /// 通用列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetGeneralContent(string general_code)
        {
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(this.DbHelper.CreateParameter("@general_code", general_code));
            return this.ExecuteDataTable("select * from sys_general_content where is_delete=0 and general_code=@general_code order by sort_num;", parameters.ToArray());
        }

        /// <summary>
        /// 通用列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetGeneralContent(string general_code,string general_key)
        {
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(this.DbHelper.CreateParameter("@general_code", general_code));
            parameters.Add(this.DbHelper.CreateParameter("@general_key", general_key));
            return this.ExecuteDataTable("select * from sys_general_content where is_delete=0 and general_code=@general_code and general_key=@general_key;", parameters.ToArray());
        }

        /// <summary>
        /// 通用列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetGeneralFields(string general_code)
        {
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(this.DbHelper.CreateParameter("@general_code", general_code));
            return this.ExecuteDataTable("select * from sys_general where general_code=@general_code;", parameters.ToArray());
        }

        public bool IsExists(string general_code, string general_key)
        {
            var sql = @"select 1 from sys_general_content where general_code = @general_code and general_key=@general_key and is_delete = 0";
            return ExecuteReaderObject(sql,
                DbHelper.CreateParameter("@general_code", general_code),
                DbHelper.CreateParameter("@general_key", general_key)) != null;
        }

        public DataTable GetProvinceCitys()
        {
            var sql = @"
                        SELECT 
                             b.city_id,
                             b.province_id,
                             a.province_code,
                             a.province_name,
                             b.city_code,
                             b.city_name,
                             b.risk_level
                        FROM `ep_province` a LEFT JOIN `ep_city` b 
                          ON a.province_id = b.province_id 
                        WHERE b.is_delete = 0 ORDER BY a.sort_num,b.sort_num
                        ";
            return ExecuteDataTable(sql);
        }

        public DataTable GetAreaDists()
        {
            var sql = @"
                        SELECT 
                             b.dist_id,
                             b.area_id,
                             a.area_code,
                             a.area_name,
                             b.dist_code,
                             b.dist_name
                        FROM `ep_area` a LEFT JOIN `ep_dist` b 
                          ON a.area_id = b.area_id 
                        WHERE b.is_delete = 0 ORDER BY a.sort_num,b.sort_num
                        ";
            return ExecuteDataTable(sql);
        }
    }
}
