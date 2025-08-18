using Rcbi.AspNetCore.Helper;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Rcbi.Repository
{
    public class IispRepository : BaseRepository<TbModelResultMain>
    {
        /// <summary>
        /// 根据任务编号获取主表信息
        /// </summary>
        /// <param name="TaskNO">任务编号</param>
        /// <returns></returns>
        public TbModelResultMain GetModelResultMain(string TaskNO)
        {
            var sql = @"SELECT * FROM tb_model_result_main 
                                WHERE taskno=@taskno limit 0,1";
            var model = ExecuteReaderObject(sql,
                DbHelper.CreateParameter("@taskno", TaskNO));
            return model;
        }

        /// <summary>
        /// 根据任务编号更新主表任务状态
        /// </summary>
        /// <param name="TaskNo">任务编号</param>
        /// <param name="ModelStatus">任务状态</param>
        /// <returns></returns>
        public bool UpdateModelStatus(string TaskNo, string ModelStatus)
        {
            var sql = @"
               UPDATE tb_model_result_main SET modelstatus= @modelstatus
               WHERE taskno = @taskno;
              ";

            return this.ExecuteNonQuery(sql,
                     this.DbHelper.CreateParameter("@taskno", TaskNo),
                      this.DbHelper.CreateParameter("@modelstatus", ModelStatus)
                ) > 0;
        }


        /// <summary>
        /// 查询任务，分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetList(CommonQuery query, IList<Project> projects, out int total)
        {
            string where = string.Empty;
            List<DbParameter> param = new List<DbParameter>();

            foreach (var filter in query.Filters)
            {
                where += string.Format(" and a.{0} {1} @{2} ", filter.Filed, filter.Op, filter.Filed);
                param.Add(this.DbHelper.CreateParameter("@" + filter.Filed, filter.Data));
            }
            if(projects!=null&& projects.Count > 0)
            {
                List<string> projectCodes = projects.Select(a => a.ProjectCode).ToList();
                for(int i=0;i< projectCodes.Count;i++)
                {
                    projectCodes[i] = "'" + projectCodes[i]+ "'";
                }
                where +=string.Format("AND ProjectID in ({0})",string.Join(",",projectCodes));
            }
            param.Add(this.DbHelper.CreateParameter("@index", query.StartIndex));
            param.Add(this.DbHelper.CreateParameter("@size", query.PageSize));

            var querySql = string.Format("select a.* ,b.model_name,(select short_name from sys_project where code=a.projectid) as short_name from tb_model_result_main a,tb_model_type b where a.model_type=b.type_code and a.is_delete=0 {1} {0} order by a.create_time desc limit @index,@size", query.External, where);
            var totalSql = string.Format("select count(1) from tb_model_result_main a, tb_model_type b where  a.model_type=b.type_code and a.is_delete = 0 {1} {0}", query.External, where);
            total = ConvertHelper.ToInt32(this.ExecuteScalar(totalSql, param.ToArray()));
            return this.ExecuteDataTable(querySql, param.ToArray());
        }

        /// <summary>
        /// 根据id查询任务详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public DataTable GetDetailById(string id)
        {
            string sql = "select a.*,b.model_name from tb_model_result_main a,tb_model_type b where a.model_type=b.type_code and a.is_delete=0 and a.id=@id";
            return this.ExecuteDataTable(sql,
                this.DbHelper.CreateParameter("@id", id));
        }

        /// <summary>
        /// 根据id删除任务
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>

        public bool DeleteById(string id)
        {
            string sql = "update tb_model_result_main set is_delete=1 where id=@id ";
            return this.ExecuteNonQuery(sql,
                this.DbHelper.CreateParameter("@id", id)) > 0;
        }

        public string InsertModel(TbModelResultMain model)
        {
            string sql = @"INSERT INTO tb_model_result_main ( TaskNO, DataSource_StartDate, DataSource_EndDate,Facility_Type, Model_Type, ProjectID, Callback_Url ,is_delete,create_time,ModelStatus,is_submit )
                                VALUES (@TaskNO, @DataSource_StartDate, @DataSource_EndDate,@Facility_Type, @Model_Type, @ProjectID, @Callback_Url, @is_delete,@create_time,@ModelStatus,@is_submit );select @@IDENTITY ;";
            return this.ExecuteScalar(sql,
               this.DbHelper.CreateParameter("@TaskNO", model.taskno),
               this.DbHelper.CreateParameter("@DataSource_StartDate", model.datasource_startdate),
               this.DbHelper.CreateParameter("@DataSource_EndDate", model.datasource_enddate),
               this.DbHelper.CreateParameter("@Facility_Type", model.facility_type),
               this.DbHelper.CreateParameter("@Model_Type", model.model_type),
               this.DbHelper.CreateParameter("@ProjectID", model.projectid),
               this.DbHelper.CreateParameter("@Callback_Url", model.callback_url),
               this.DbHelper.CreateParameter("@is_delete", model.is_delete),
               this.DbHelper.CreateParameter("@create_time", DateTime.Now),
               this.DbHelper.CreateParameter("@ModelStatus", "Preparing"),
               this.DbHelper.CreateParameter("@is_submit", model.is_submit)).ToString();
        }


        public bool UpdateTask(TbModelResultMain model)
        {
            string sql = @"UPDATE tb_model_result_main 
                                    SET DataSource_StartDate=@DataSource_StartDate,
					                DataSource_EndDate=@DataSource_EndDate,
					                Facility_Type=@Facility_Type,
					                ProjectID=ProjectID,
					                Callback_Url=@Callback_Url
					                WHERE id=@id;";
            return this.ExecuteNonQuery(sql,
               this.DbHelper.CreateParameter("@id", model.id),
               this.DbHelper.CreateParameter("@DataSource_StartDate", model.datasource_startdate),
               this.DbHelper.CreateParameter("@DataSource_EndDate", model.datasource_enddate),
               this.DbHelper.CreateParameter("@Facility_Type", model.facility_type),
               this.DbHelper.CreateParameter("@ProjectID", model.projectid),
               this.DbHelper.CreateParameter("@Callback_Url", model.callback_url)) > 0;
        }

        public bool UpdateTaskStatus(string id)
        {
            string sql = @"UPDATE tb_model_result_main  
                                SET ModelStatus=@ModelStatus
                                WHERE id=@id;";
            return this.ExecuteNonQuery(sql,
              this.DbHelper.CreateParameter("@ModelStatus", "Start"),
              this.DbHelper.CreateParameter("@id", id)) > 0;
        }

        public string GetTaskNo(string id)
        {
            string sql = @"SELECT TaskNo from tb_model_result_main
                                WHERE id=@id;";
            return Convert.ToString(this.ExecuteScalar(sql,
              this.DbHelper.CreateParameter("@id", id)));
        }


    }
}
