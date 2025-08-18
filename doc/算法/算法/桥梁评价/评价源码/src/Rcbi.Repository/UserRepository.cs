using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using Rcbi.AspNetCore.Helper;
using Rcbi.Entity;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Query;
using Rcbi.Entity.Enums;
using Rcbi.Core.Extensions;

namespace Rcbi.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        /// <summary>
        /// 根据用户ID获取
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(long userId)
        {
            var sql = @"
                       SELECT a.*,
                           b.dept_name,
                           c.org_code,
                           c.org_name,
                           c.org_name_short
                         FROM sys_user a 
                       LEFT JOIN sys_org_dept b ON a.dept_id = b.dept_id
                       LEFT JOIN sys_org c ON a.org_id = c.org_id
                       WHERE a.user_id=@user_id
                    ";

            return this.ExecuteReaderObject(sql,
                         DbHelper.CreateParameter("@user_id", userId));
        }
        /// <summary>
        /// 根据用户名获取
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUser(string userName)
        {
            var sql = @"
                       SELECT a.*,
                           b.dept_name,
                           c.org_code,
                           c.org_name
                         FROM sys_user a 
                       LEFT JOIN sys_org_dept b ON a.dept_id = b.dept_id
                       LEFT JOIN sys_org c ON b.org_id = c.org_id
                       WHERE a.user_name=@user_name
                  ";

            return this.ExecuteReaderObject(sql,
                         DbHelper.CreateParameter("@user_name", userName));
        }

        public bool MyUserUpdate(User entity)
        {
            var sql = @"UPDATE sys_user 
                            SET real_name=@real_name,
                            sex=@sex,
                            mobile=@mobile,
                            telephone=@telephone,
                            update_user=@update_user,
                            update_date=@update_date,
                            birthday=@birthday,
                            email=@email
                        WHERE user_id=@users_id
                  ";

            return this.ExecuteNonQuery(sql,
                         DbHelper.CreateParameter("@real_name", entity.TrueName),
                         DbHelper.CreateParameter("@sex", entity.Sex),
                         DbHelper.CreateParameter("@mobile", entity.Mobile),
                         DbHelper.CreateParameter("@telephone", entity.Telephone),
                         DbHelper.CreateParameter("@update_user", entity.UpdateUser),
                         DbHelper.CreateParameter("@update_date", entity.UpdateDate),
                         DbHelper.CreateParameter("@birthday", entity.Birthday),
                         DbHelper.CreateParameter("@email", entity.Email),
                         DbHelper.CreateParameter("@users_id", entity.UserId)) > 0;

        }

        /// <summary>
        /// 根据用户名和密码获取
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string userName, string password)
        {
            var sql = @"
                        SELECT a.*,
                            b.dept_name,
                            c.org_code,
                            c.org_name
                            FROM sys_user a 
                        LEFT JOIN sys_org_dept b ON a.dept_id = b.dept_id
                        LEFT JOIN sys_org c ON b.org_id = c.org_id
                        WHERE a.user_name=@user_name and a.password=@password and ifnull(a.is_delete,0)=0
                    ";

            return this.ExecuteReaderObject(sql,
                         DbHelper.CreateParameter("@user_name", userName),
                         DbHelper.CreateParameter("@password", password));
        }

        /// <summary>
        /// 查询用户，分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetList(CommonQuery query, out int total)
        {
            var tableInfo = this.TableInfo;

            var querySql = this.CreateQuerySql(tableInfo, "", query.StartIndex, query.PageSize);
            var totalSql = string.Format("select count(1) from {0} where is_delete = 0",
                                  tableInfo.TabelName, query.StartIndex, query.PageSize);

            total = ConvertHelper.ToInt32(this.ExecuteScalar(totalSql, null));

            return this.ExecuteDataTable(querySql, null);
        }

        public DataTable GetList()
        {
            return ExecuteDataTable("SELECT user_id, real_name FROM sys_user WHERE is_delete = 0;");
        }

        /// <summary>
        /// 查询用户，不分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetList(CommonQuery query)
        {
            var tableInfo = this.TableInfo;

            var sql = this.CreateQuerySql(tableInfo, string.Empty);

            return this.ExecuteDataTable(sql, null);
        }

        public DataTable GetWsList()
        {
            return this.ExecuteDataTable("select user_id,real_name from ws_user where is_delete=0;", null);
        }


        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public int SetPassword(long userId, string newPassword)
        {
            var tableInfo = this.TableInfo;

            string sql = string.Format("update {0} set password=@password where user_id=@user_id and is_delete=0",
                                            tableInfo.TabelName);

            return this.ExecuteNonQuery(sql,
                         DbHelper.CreateParameter("@user_id", userId),
                         DbHelper.CreateParameter("@password", newPassword));
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateState(long userId, UserState state)
        {
            var tableInfo = this.TableInfo;

            string sql = string.Format("update {0} set state=@state where user_id=@user_id and is_delete=0",
                                           tableInfo.TabelName);

            return this.ExecuteNonQuery(sql,
                        DbHelper.CreateParameter("@user_id", userId),
                        DbHelper.CreateParameter("@state", (int)state));
        }

        /// <summary>
        /// 人员角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetRoles(long userId)
        {
            var sql = @"
                   SELECT a.* FROM sys_role a
                     LEFT JOIN sys_user_role b ON a.role_id = b.role_id
                   WHERE a.is_delete= 0 
                         AND b.user_id = @user_id
                ";

            return this.ExecuteDataTable(sql,
                       this.DbHelper.CreateParameter("@user_id", userId));
        }

        /// <summary>
        /// 设置人员角色列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataTable GetUserRole(int roleId)
        {
            var sql = @"SELECT 
                        c.dept_name_full,
                        a.true_name,
                        a.user_id,
                        a.login_id
                        FROM 
                         tb_user_role b
                        LEFT JOIN tb_user a ON a.user_id=b.user_id AND b.role_id=@role_id
                        LEFT JOIN sys_org_department c ON a.dept_code=c.dept_code

                        WHERE a.is_delete=0";

            return this.ExecuteDataTable(sql,
                       this.DbHelper.CreateParameter("@role_id", roleId));
        }

        public int RemoveUserRole(long userId, int roleId)
        {
            var sql = @"DELETE FROM tb_user_role WHERE user_id=@user_id and role_id=@role_id";
            return this.ExecuteNonQuery(sql, this.DbHelper.CreateParameter("@user_id", userId),
                this.DbHelper.CreateParameter("@role_id", roleId));
        }

        /// <summary>
        /// 设置人员角色列表(全部)
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public DataTable GetUserRoleAlls(BaseQueryEntity query)
        {
            var whereString = new StringBuilder();
            var parameters = new List<DbParameter>();

            var q = query as CommonQuery;
            if (q != null)
            {
                if (q.Filters.IsExists())
                {
                    for (var i = 0; i < q.Filters.Count; i++)
                    {
                        whereString.Append(" AND ");

                        whereString
                            .AppendLine()
                            .Append(q.Filters[i].ToString());

                        parameters.Add(
                            DbHelper.CreateParameter("@" + q.Filters[i].ParaString,
                            q.Filters[i].Data));
                    }
                }

                if (!q.External.IsNullOrEmpty())
                {
                    whereString.AppendFormat(" AND ({0})", q.External);
                }
            }

            var sql = @"SELECT * FROM(
                            SELECT 
                            b.dept_name_full,
                            a.true_name,
                            a.user_id,
                            a.login_id
                            FROM tb_user a 
                            LEFT JOIN sys_org_department b ON a.dept_code=b.dept_code
                            WHERE a.is_delete=0
                            )f  WHERE ({0})";

            sql = string.Format(sql, whereString.Length == 0 ? DEFAULT_WHERE : whereString.ToString());
            return this.ExecuteDataTable(sql, parameters.ToArray());
        }

        //
        public int DeleteRole(int roleId)
        {
            var sql = @"DELETE FROM tb_user_role  WHERE role_id =@role_id";

            return this.ExecuteNonQuery(sql,
                       this.DbHelper.CreateParameter("@role_id", roleId));
        }

        /// <summary>
        /// 根据openId获取
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public User GetUserByopenId(string openId)
        {
            var sql = @"
                       SELECT *
                       FROM sys_user  
                       WHERE wechat_open_id=@wechat_open_id
                  ";
            return this.ExecuteReaderObject(sql,
                         DbHelper.CreateParameter("@wechat_open_id", openId));
        }

        /// <summary>
        /// 根据Login_Id,Password 绑定OpenId,Binding_Date
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateUserBind(long userid, string openid)
        {
            var sql = @"
                   UPDATE sys_user 
                       SET 
                        wechat_open_id = @openid, 
                        update_date = @binding_date 
                   WHERE user_id = @user_id
                ";

            return this.ExecuteNonQuery(sql,
                  this.DbHelper.CreateParameter("@openid", openid),
                  this.DbHelper.CreateParameter("@binding_date", DateTime.Now),
                  this.DbHelper.CreateParameter("@user_id", userid)
                );
        }


        /// <summary>
        /// 微信用户解绑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateUserUnBind(string openid)
        {
            var sql = @"
                   UPDATE sys_user 
                       SET 
                        wechat_open_id = null 
                   WHERE wechat_open_id = @wechat_open_id
                ";

            return this.ExecuteNonQuery(sql,
                  this.DbHelper.CreateParameter("@wechat_open_id", openid)
                );
        }

        public DataTable GetPagedList(CommonQuery query, long projectId, out int total)
        {
            var sql = @"SELECT
                        	d.user_id,
                        	d.real_name,
                        	d.mobile,
                        	e.org_name,
                        	GROUP_CONCAT(c.role_name) AS role_name 
                        FROM
                        	tb_project_user a
                        	INNER JOIN sys_role c ON a.role_id = c.role_id
                        	INNER JOIN sys_user d ON a.user_id = d.user_id
                        	INNER JOIN sys_org e ON d.org_id = e.org_id 
                        WHERE
                        	a.project_id = @project_id 
                        	AND d.is_delete = 0 
                        	AND e.is_delete = 0 
                        GROUP BY
                        	d.user_id,
                        	d.real_name,
                        	d.mobile
                        	LIMIT @start, @size;
                
                        SELECT
                        	COUNT(1) AS total 
                        FROM
                        	(
                        	SELECT
                        		d.user_id,
                        		d.real_name,
                        		d.mobile,
                        		e.org_name,
                        		GROUP_CONCAT(c.role_name) AS role_name 
                        	FROM
                        		tb_project_user a
                        		INNER JOIN sys_role c ON a.role_id = c.role_id
                        		INNER JOIN sys_user d ON a.user_id = d.user_id
                        		INNER JOIN sys_org e ON d.org_id = e.org_id 
                        	WHERE
                        		a.project_id = 13 
                        		AND d.is_delete = 0 
                        		AND e.is_delete = 0 
                        	GROUP BY
                        		d.user_id,
                        		d.real_name,
                        	    d.mobile 
                        	) t";

            var ds = ExecuteDataSet(sql,
                DbHelper.CreateParameter("@project_id", projectId),
                DbHelper.CreateParameter("@start", query.StartIndex),
                DbHelper.CreateParameter("@size", query.PageSize));

            total = Convert.ToInt32(ds.Tables[1].Rows[0]["total"]);

            return ds.Tables[0];
        }

        public DataTable GetUserProject(string openid, int project_id)
        {
            var sql = string.Empty;
            sql += "SELECT                                                       ";
            sql += "  a.*                                                        ";
            sql += "FROM                                                         ";
            sql += "  tb_project_user a                                          ";
            sql += "  INNER JOIN tb_project b                                    ";
            sql += "    ON a.project_id = b.project_id                           ";
            sql += "WHERE (                                                      ";
            sql += "    b.project_id = @project_id                               ";
            sql += "    OR b.project_id_parent = @project_id                     ";
            sql += "  )                                                          ";
            sql += "  AND EXISTS                                                 ";
            sql += "  (SELECT                                                    ";
            sql += "    c.*                                                      ";
            sql += "  FROM                                                       ";
            sql += "    sys_user c                                               ";
            sql += "  WHERE c.wechat_open_id = @wechat_open_id                   ";
            sql += "    AND c.user_id = a.user_id)                               ";
            return this.DbHelper.ExecuteDataTable(sql,
                       this.DbHelper.CreateParameter("@project_id", project_id),
                       this.DbHelper.CreateParameter("@wechat_open_id", openid));
        }
    }
}
