using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using Rcbi.AspNetCore.Helper;
using Rcbi.Core.Extensions;
using Rcbi.Entity;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Query;

namespace Rcbi.Repository
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public DataTable GetProjects(ProjectQuery query , out int total)
        {
            var whereString = new StringBuilder(); 

            var fields =
                " distinct a.*,c.content as facility_type_value,CASE WHEN IFNULL(b.id,0) = 0 THEN 0 ELSE 1 END has_role ";
            var count = "count(1) as total";

            var sql = @"SELECT  {1}
                        FROM sys_project a 
                        LEFT JOIN sys_project_user b ON a.code = b.project_code
                        LEFT JOIN sys_general_content c on a.facility_type=c.general_key and c.general_code='facility_type'
                        WHERE  a.is_delete = 0  {0} {2} ";
            if (!query.ProjectName.IsNullOrEmpty())
            {
                whereString.Append($" and ( a.short_name like '%{query.ProjectName}%' or  a.full_name like '%{query.ProjectName}%')"); 
            }
            var querySql = string.Format(sql, 
                whereString.ToString(),
                fields,
                string.Format("  limit {0}, {1}", query.Create().StartIndex, query.Create().EndIndex)
            );
            var totalSql = string.Format(sql, 
                whereString.ToString(),
                count,
                string.Empty
            );

            total = ConvertHelper.ToInt32(this.ExecuteDataTable(totalSql).Rows[0]["total"]);
            return this.ExecuteDataTable(querySql);

        }
        public DataTable GetProjects(long userId)
        { 
            //因为user表中user_code为空，讨论后修改为user_name关联 2020年6月30日 ljd
            var sql = @"SELECT distinct a.*,c.content as facility_type_value,CASE WHEN IFNULL(b.id,0) = 0 THEN 0 ELSE 1 END has_role 
                        FROM sys_project a 
                        LEFT JOIN sys_project_user b ON a.code = b.project_code
                        LEFT JOIN sys_general_content c on a.facility_type=c.general_key and c.general_code='facility_type'
                        INNER JOIN sys_user d on b.user_code=d.user_name
                        WHERE  a.is_delete = 0 and  d.user_id = @user_id ";

            return this.ExecuteDataTable(sql,
                       this.DbHelper.CreateParameter("@user_id", userId));

        }

        public DataTable GetProjects()
        {
            var sql = @"SELECT a.*,c.content as facility_type_value, 1 AS has_role 
                        FROM sys_project a
                        LEFT JOIN sys_general_content c on a.facility_type=c.general_key and c.general_code='facility_type'
                        WHERE a.is_delete = 0";

            return this.ExecuteDataTable(sql, null);
        }

        public DataTable GetChildProjects(long parentPid)
        {
            var sql = @"SELECT a.*,b.org_name AS supervision_org_name FROM tb_project a LEFT JOIN sys_org b ON a.supervision_org_id = b.org_id WHERE a.is_delete = 0 AND a.project_id_parent = @project_id_parent";

            return ExecuteDataTable(sql,
                       DbHelper.CreateParameter("@project_id_parent", parentPid));
        }

        public DataTable GetProject(long projectId)
        {
            var sql = @"SELECT
                        	b.content AS project_template_content,
                        	h.content AS project_status_content,
                        	c.project_name AS project_name_parent,
                        	c.project_name_short AS project_name_short_parent,
                        	d.org_name AS owner_org_name,
                        	e.org_name AS epc_org_name,
                        	f.org_name AS supervision_org_name,
                        	g.org_name AS pc_epc_org_name,
                        	a.* 
                        FROM
                        	tb_project a
                        	LEFT JOIN sys_general_content b ON a.project_template = b.general_key 
                        	AND b.general_code = 'project_template'
                        	LEFT JOIN sys_general_content h ON a.project_status = h.general_key 
                        	AND h.general_code = 'project_status'
                        	LEFT JOIN tb_project c ON a.project_id_parent = c.project_id
                        	LEFT JOIN sys_org d ON a.owner_org_id = d.org_id
                        	LEFT JOIN sys_org e ON a.epc_org_id = e.org_id
                        	LEFT JOIN sys_org f ON a.supervision_org_id = f.org_id
                        	LEFT JOIN sys_org g ON a.pc_epc_org_id = g.org_id 
                        WHERE
                        	a.is_delete = 0 
                        	AND a.project_id = @project_id LIMIT 1";

            return this.ExecuteDataTable(sql,
                       this.DbHelper.CreateParameter("@project_id", projectId));
        }

        public DataTable GetProject(string projectCode)
        {
            var sql = @"SELECT
                        	b.content AS project_template_content,
                        	h.content AS project_status_content,
                        	c.project_name AS project_name_parent,
                        	c.project_name_short AS project_name_short_parent,
                        	d.org_name AS owner_org_name,
                        	e.org_name AS epc_org_name,
                        	f.org_name AS supervision_org_name,
                        	g.org_name AS pc_epc_org_name,
                        	a.* 
                        FROM
                        	tb_project a
                        	LEFT JOIN sys_general_content b ON a.project_template = b.general_key 
                        	AND b.general_code = 'project_template'
                        	LEFT JOIN sys_general_content h ON a.project_status = h.general_key 
                        	AND h.general_code = 'project_status'
                        	LEFT JOIN tb_project c ON a.project_id_parent = c.project_id
                        	LEFT JOIN sys_org d ON a.owner_org_id = d.org_id
                        	LEFT JOIN sys_org e ON a.epc_org_id = e.org_id
                        	LEFT JOIN sys_org f ON a.supervision_org_id = f.org_id
                        	LEFT JOIN sys_org g ON a.pc_epc_org_id = g.org_id 
                        WHERE
                        	a.is_delete = 0 
                        	AND a.project_code = @project_code LIMIT 1";

            return this.ExecuteDataTable(sql,
                       this.DbHelper.CreateParameter("@project_code", projectCode));
        }

        public object GetBids(object parentPid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 去的上级项目id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public int GetParentIds(int projectId)
        {
            var sql = @"SELECT ifnull(project_id_parent,0) as project_id_parent FROM tb_project WHERE project_id = @projectId";

            return Convert.ToInt16(this.ExecuteScalar(sql,
                       this.DbHelper.CreateParameter("@projectId", projectId)));
        }


        public int RemoveProjects(long userId)
        {
            var sql = @"DELETE FROM tb_project_user WHERE user_id = @user_id";

            return this.ExecuteNonQuery(sql,
                       this.DbHelper.CreateParameter("@user_id", userId));
        }

        public bool IsExists(string projectCode)
        {
            var sql = @"select 1 from sys_project where code  = @project_code and is_delete = 0";
            return ExecuteReaderObject(sql,
                DbHelper.CreateParameter("@project_code", projectCode)) != null;
        }

        public bool IsExistsOrg(ProjectOrg model)
        {
            var sql = @"SELECT 1 FROM `tb_project_org` a WHERE a.project_id = @project_id AND a.org_id = @org_id AND a.is_delete = 0";
            return ExecuteReaderObject(sql,
                DbHelper.CreateParameter("@project_id", model.ProjectId),
                DbHelper.CreateParameter("@org_id", model.OrgId)) != null;
        }

        public DataTable GetBids()
        {
            var sql = @"SELECT
	                        a.project_id,
                        	a.project_code,
                        	a.project_name,
                        	a.project_name_short,
                        	a.manager_name,
                        	a.project_status,
                        	b.content AS project_status_name,
                        	c.org_name_short 
                        FROM
                        	tb_project a
                        	LEFT JOIN sys_general_content b ON b.general_code = 'project_status' 
                        	AND a.project_status = b.general_key
                        	LEFT JOIN sys_org c ON a.epc_org_id = c.org_id 
                        WHERE
                        	a.project_id_parent = 1 and a.is_delete=0;";

            return this.ExecuteDataTable(sql);
        }

        public DataTable GetAreas(int parentProjectId)
        {
            var sql = @"SELECT
                        	a.project_id,
                        	a.project_name_short,
                        	a.project_status,
                            
                        	b.content AS project_status_name,
                        	e.construction_name AS org_name_short,
                        	a.manager_name,
                        	ifnull(d.pc_count, 0) AS pc_count_done,
                        	ifnull(c.pc_count, 0) AS pc_count 
                        FROM
                        	tb_project a
                        	LEFT JOIN sys_general_content b ON b.general_code = 'project_status' 
                        	AND a.project_status = b.general_key
                        	LEFT JOIN (SELECT project_id, sum(pc_count) AS pc_count FROM pc_type_project WHERE is_delete = 0 GROUP BY project_id) c ON a.project_id = c.project_id
                        	LEFT JOIN (SELECT project_id, count(0) AS pc_count FROM pc_main WHERE is_delete = 0 and pc_status='8' GROUP BY project_id) d ON a.project_id = d.project_id
                        	LEFT JOIN (
                        	SELECT
                        		a.project_id,
                        		GROUP_CONCAT(b.org_name_short) AS construction_name 
                        	FROM
                        		tb_project_org a
                        		INNER JOIN sys_org b ON a.org_id = b.org_id 
                        	WHERE
                        		a.is_delete = 0 
                        		AND b.is_delete = 0 
                        	GROUP BY
                        		a.project_id 
                        	) e ON a.project_id = e.project_id 
                        WHERE
                        	a.project_id_parent = @parentProjectId;";

            return this.ExecuteDataTable(sql,
                DbHelper.CreateParameter("@parentProjectId", parentProjectId));
        }

        public DataTable GetListByLevels(params int[] levels)
        {
            var cond = levels == null || levels.Length == 0 ? 
                string.Empty : 
                $"AND tree_level IN({string.Join(",", levels)})";

            var sql = $"SELECT * FROM tb_project WHERE is_delete = 0 {cond}";

            return ExecuteDataTable(sql);
        }


        public DataTable GetAllConstructOrgs()
        {
            var sql = @"
                    SELECT 
	                    b.*,
	                    a.project_id AS org_project_id
                    FROM tb_project_org a
                    INNER JOIN sys_org b ON a.org_id=b.org_id
                    WHERE a.is_delete=0
                    ";

            return ExecuteDataTable(sql);
        }

        public DataTable GetProjectByUuid(string uuid)
        {
            var sql = @"SELECT
                        	a.*
                        FROM
                        	sys_project a
                        WHERE
                        	a.is_delete = 0 
                        	AND a.uuid = @uuid LIMIT 1";

            return this.ExecuteDataTable(sql,
                this.DbHelper.CreateParameter("@uuid", uuid));
        }

        public bool Update(Project entity,string userName)
        {
            var sql = @" 
            update sys_project 
            set 
            short_name=@short_name,
            full_name=@full_name,
            facility_type=@facility_type,
            position=@position,
            comment=@comment,
            update_user=@update_user,
            update_date=NOW()
            where uuid=@uuid";
            IList<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(this.DbHelper.CreateParameter("@short_name", entity.ShortName));
            parameters.Add(this.DbHelper.CreateParameter("@full_name", entity.FullName));
            parameters.Add(this.DbHelper.CreateParameter("@facility_type", entity.FacilityType));
            parameters.Add(this.DbHelper.CreateParameter("@position", entity.Position));
            parameters.Add(this.DbHelper.CreateParameter("@comment", entity.Comment));
            parameters.Add(this.DbHelper.CreateParameter("@update_user", userName));
            parameters.Add(this.DbHelper.CreateParameter("@uuid", entity.uuid));

            return this.ExecuteNonQuery(sql, parameters.ToArray())==1;
        }


        public DataTable GetUserByProjectCode(string projectCode)
        { 
            var sql = @" 
            select 
             a.*,
             b.project_code,
             CASE WHEN b.user_code IS NULL THEN 0 ELSE 1 END   as is_member
            from (
            select CONCAT('org',org_id) as id,org_code as itemCode,org_name as orgName,'' as userName, CONCAT('org',parent_id) as pid,'org' as type from sys_org 
            UNION ALL
            select user_id as id,user_name as itemCode,'' as orgName,real_name as userName,CONCAT('org',org_id) as pid ,'user' as type from sys_user) a
            left join sys_project_user b on a.itemCode =b.user_code and a.type='user' and b.project_code=@project_code
            where 1=1
            ORDER BY a.itemCode
            ";

            return this.ExecuteDataTable(sql,
                this.DbHelper.CreateParameter("@project_code", projectCode));

        }

        /// <summary>
        /// 删除项目人员
        /// </summary>
        /// <param name="projectCode"></param>
        /// <param name="userCode"></param>
        /// <returns>返回受影响行数</returns>
        public bool ProjectSetUserDel(string projectCode, string userCode)
        {
            try
            {
                this.BeginTransaction();
                var sql = "delete from sys_project_user where project_code=@project_code and user_code=@user_code";
                IList<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(this.DbHelper.CreateParameter("@project_code", projectCode));
                parameters.Add(this.DbHelper.CreateParameter("@user_code", userCode));
                if (this.ExecuteNonQuery(sql, parameters.ToArray()) != 1)
                {
                    throw  new Exception("删除记录不是一条，事务回滚");
                }
                this.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            { 
                this.RollbackTransaction();
                return false;
            } 
        }
        /// <summary>
        /// 新增项目人员
        /// </summary>
        /// <param name="projectCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public bool ProjectSetUserAdd(string projectCode, string userCode)
        {
            try
            { 
                var sql = " INSERT INTO sys_project_user(project_code,user_code) VALUES(@project_code,@user_code)";
                IList<DbParameter> parameters = new List<DbParameter>();
                parameters.Add(this.DbHelper.CreateParameter("@project_code", projectCode));
                parameters.Add(this.DbHelper.CreateParameter("@user_code", userCode));
                 
                return this.ExecuteNonQuery(sql, parameters.ToArray()) == 1;
            }
            catch (Exception ex )
            { 
                return false;
            }
        }
    }
}
