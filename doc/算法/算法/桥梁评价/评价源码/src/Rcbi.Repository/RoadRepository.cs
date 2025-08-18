using Rcbi.Entity.Domain;
using Rcbi.Entity.OpenApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Rcbi.Repository
{
    public class RoadRepository
    {
        /// <summary>
        /// 车道基本信息
        /// </summary>
        public ModelRoadLaneInfo GetModelRoadLaneInfo(string line_code, string lane_code, string project_code)
        {
            string sql = "select * from tb_model_tunnel_data_laneinfo where LineCode=@LineCode AND LaneCode=@LaneCode AND project_code=@project_code";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderObject<ModelRoadLaneInfo>(sql, CommandType.Text,
                     DbHelper.CreateParameter("@LineCode", line_code),
                     DbHelper.CreateParameter("@LaneCode", lane_code),
                     DbHelper.CreateParameter("@project_code", project_code));
            }
        }
        /// <summary>
        /// 监测指标数据
        /// </summary>
        public ModelRoadIRI GetModelRoadIRI(string line_code, string lane_code, string project_code)
        {
            string sql = "select * from tb_Model_Road_IRI where line_no=@line_no AND lane_no=@lane_no AND project_code=@project_code AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderObject<ModelRoadIRI>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@line_no", line_code),
                    DbHelper.CreateParameter("@lane_no", lane_code),
                    DbHelper.CreateParameter("@project_code", project_code));
            }
        }

        /// <summary>
        /// 监测指标数据
        /// </summary>
        public IList<ModelRoadIRIQuery> GetModelRoadIRIList(ModelRoadIRIQuery model, out int count)
        {
            string sql = "select * from tb_Model_Road_IRI where task_no=@task_no  AND delete_flag=0 limit @page,@count";
            string count_sql = "select count(1) from tb_Model_Road_IRI where  task_no=@task_no  AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                       DbHelper.CreateParameter("@task_no", model.task_no)));
                return DbHelper.ExecuteReaderList<ModelRoadIRIQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        /// <summary>
        /// 路面病害等级
        /// </summary>
        public IList<ModelRoadDamageLevel> GetModelRoadDamageLevel()
        {
            string sql = "select * from tb_Model_Road_DamageLevel";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelRoadDamageLevel>(sql, CommandType.Text);
            }
        }
        /// <summary>
        /// 路面病害类型
        /// </summary>
        public IList<ModelRoadDamageType> GetModelRoadDamageType()
        {
            string sql = "select * from tb_Model_Road_DamageType";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelRoadDamageType>(sql, CommandType.Text);
            }
        }


        /// <summary>
        /// 路面病害数据
        /// </summary>
        public IList<ModelRoadDamage> GetModelRoadDamage(string line_code, string lane_code, string project_code)
        {
            string sql = "select * from tb_Model_Road_Damage where line_no=@line_no AND lane_no=@lane_no AND project_code=@project_code AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelRoadDamage>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@line_no", line_code),
                    DbHelper.CreateParameter("@lane_no", lane_code),
                    DbHelper.CreateParameter("@project_code", project_code));
            }
        }
        /// <summary>
        /// 路面检测单信息
        /// </summary>
        public ModelRoadCheckUnitInfo GetModelRoadCheckUnitInfo(string line_code, string lane_code, string project_code)
        {
            string sql = "select * from tb_Model_Road_CheckUnitInfo where line_no=@line_no AND lane_no=@lane_no AND project_code=@project_code AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderObject<ModelRoadCheckUnitInfo>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@line_no", line_code),
                    DbHelper.CreateParameter("@lane_no", lane_code),
                    DbHelper.CreateParameter("@project_code", project_code));
            }
        }

        /// <summary>
        /// 路面检测单信息List
        /// </summary>
        public IList<ModelRoadCheckUnitInfoQuery> GetModelRoadCheckUnitInfoList(ModelRoadCheckUnitInfoQuery model, out int count)
        {
            string sql = "select * from tb_Model_Road_CheckUnitInfo where task_no=@task_no AND delete_flag=0 limit @page,@count";
            string count_sql = "select count(1) from tb_Model_Road_CheckUnitInfo where  task_no=@task_no AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                      DbHelper.CreateParameter("@task_no", model.task_no)));
                return DbHelper.ExecuteReaderList<ModelRoadCheckUnitInfoQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        /// <summary>
        /// 线路基本信息
        /// </summary>
        public ModelRoadLineInfo GetModelRoadLineInfo(string line_code, string project_code)
        {
            string sql = "select * from tb_model_tunnel_data_lineinfo where LineCode=@LineCode AND project_code=@project_code";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderObject<ModelRoadLineInfo>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@LineCode", line_code),
                    DbHelper.CreateParameter("@project_code", project_code));
            }
        }

        /// <summary>
        /// 隧道车道级路面评价结果
        /// </summary>
        public IList<ModelRoadResultLane> GetModelRoadResultLane(string task_no)
        {
            string sql = "select * from tb_Model_Road_Result_Lane where task_no=@task_no and (delete_flag is null or delete_flag=0)";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelRoadResultLane>(sql,
                    CommandType.Text, DbHelper.CreateParameter("@task_no", task_no));
            }
        }


        /// <summary>
        /// 隧道单元级路面评价结果
        /// </summary>
        public IList<ModelRoadResultSection> GetModelRoadResultSection(string task_no)
        {
            string sql = "select * from tb_Model_Road_Result_Section where task_no=@task_no and (delete_flag is null or delete_flag=0)";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelRoadResultSection>(sql,
                    CommandType.Text, DbHelper.CreateParameter("@task_no", task_no));
            }
        }
        /// <summary>
        /// 隧道线路级路面评价结果
        /// </summary>
        public IList<ModelRoadResultLine> GetModelRoadResultLine(string task_no)
        {
            string sql = "select * from tb_Model_Road_Result_Line where task_no=@task_no and (delete_flag is null or delete_flag=0)";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelRoadResultLine>(sql,
                    CommandType.Text, DbHelper.CreateParameter("@task_no", task_no));
            }
        }
        /// <summary>
        /// 隧道整体路面评价结果
        /// </summary>
        public ModelRoadResultAll GetModelRoadResultAll(string task_no)
        {
            string sql = "select * from tb_Model_Road_Result_All where task_no=@task_no and (delete_flag is null or delete_flag=0)";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderObject<ModelRoadResultAll>(sql,
                    CommandType.Text, DbHelper.CreateParameter("@task_no", task_no));
            }
        }

        /// <summary>
        /// 新增车道基本信息
        /// </summary>
        public bool AddModelRoadLaneInfo(ModelRoadLaneInfo model)
        {
            string sql = "INSERT INTO tb_model_tunnel_data_laneinfo(LineCode,LaneCode,LaneWidth,LaneLength,project_code,Memo,datapushdate,delete_flag) VALUES(@LineCode,@LaneCode,@LaneWidth,@LaneLength,@project_code,@Memo,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LaneCode", model.LaneCode));
                param.Add(DbHelper.CreateParameter("@LaneWidth", model.LaneWidth));
                param.Add(DbHelper.CreateParameter("@LaneLength", model.LaneLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新车道基本信息
        /// </summary>
        public bool UpdateModelRoadLaneInfo(ModelRoadLaneInfo model, string id)
        {
            string sql = "UPDATE tb_model_tunnel_data_laneinfo SET LineCode=@LineCode,LaneCode=@LaneCode,LaneWidth=@LaneWidth,LaneLength=@LaneLength,project_code=@project_code,Memo=@Memo WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LaneCode", model.LaneCode));
                param.Add(DbHelper.CreateParameter("@LaneWidth", model.LaneWidth));
                param.Add(DbHelper.CreateParameter("@LaneLength", model.LaneLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新任务号
        /// </summary>
        public bool UpdateTaskNo(string task_no, DateTime start, DateTime end,string project_code)
        {
            string sql = @"UPDATE tb_Model_Road_IRI SET task_no=@task_no WHERE date>=@start AND date<=@end AND project_code=@project_code;
                           UPDATE tb_Model_Road_Damage SET task_no = @task_no WHERE date>= @start AND date<= @end AND project_code=@project_code; ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                param.Add(DbHelper.CreateParameter("@start", start));
                param.Add(DbHelper.CreateParameter("@end", end));
                param.Add(DbHelper.CreateParameter("@project_code", project_code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckModelRoadLaneInfo(ModelRoadLaneInfo model)
        {
            string sql = "SELECT id FROM tb_model_tunnel_data_laneinfo WHERE LineCode=@LineCode AND LaneCode=@LaneCode AND project_code=@project_code and (delete_flag is null or delete_flag=0)";

            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LaneCode", model.LaneCode));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                //param.Add(DbHelper.CreateParameter("@lanewidth", model.LaneWidth));
                //param.Add(DbHelper.CreateParameter("@lanelength", model.LaneLength));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增监测指标数据
        /// </summary>
        public bool AddModelRoadIRI(ModelRoadIRI model)
        {
            string sql = "INSERT INTO tb_Model_Road_IRI(date,line_no,lane_no,start_mileage,end_mileage,iri,rd,bpn,L0,project_code,datapushdate,delete_flag,basement,volume,task_no) VALUES(@date,@line_no,@lane_no,@start_mileage,@end_mileage,@iri,@rd,@bpn,@L0,@project_code,now(),@delete_flag,@basement,@volume,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@iri", model.iri));
                param.Add(DbHelper.CreateParameter("@rd", model.rd));
                param.Add(DbHelper.CreateParameter("@bpn", model.bpn));
                param.Add(DbHelper.CreateParameter("@L0", model.L0));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@delete_flag", 0));
                param.Add(DbHelper.CreateParameter("@basement", model.basement));
                param.Add(DbHelper.CreateParameter("@volume", model.volume));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新监测指标数据
        /// </summary>
        public bool UpdateModelRoadIRI(ModelRoadIRI model, string id)
        {
            string sql = "UPDATE tb_Model_Road_IRI SET date=@date,line_no=@line_no,lane_no=@lane_no,start_mileage=@start_mileage,end_mileage=@end_mileage,iri=@iri,rd=@rd,bpn=@bpn,L0=@L0,project_code=@project_code,basement=@basement,volume=@volume WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@iri", model.iri));
                param.Add(DbHelper.CreateParameter("@rd", model.rd));
                param.Add(DbHelper.CreateParameter("@bpn", model.bpn));
                param.Add(DbHelper.CreateParameter("@L0", model.L0));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@basement", model.basement));
                param.Add(DbHelper.CreateParameter("@volume", model.volume));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 修改监测指标数据
        /// </summary>
        public bool UpdateModelRoadIRI(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_Model_Road_IRI SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 批量新增监测指标数据
        /// </summary>
        public bool InsertModelRoadIRIList(List<ModelRoadIRI> list)
        {
            string sql = " INSERT INTO tb_Model_Road_IRI(date,line_no,lane_no,start_mileage,end_mileage,iri,rd,bpn,L0,project_code,create_date,delete_flag,basement,volume, task_no) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;

            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@date{0},@line_no{0},@lane_no{0},@start_mileage{0},@end_mileage{0},@iri{0},@rd{0},@bpn{0},@L0{0},@project_code{0},@create_date{0},@delete_flag{0},@basement{0},@volume{0},@task_no{0})", i));
                    param.Add(DbHelper.CreateParameter("@date" + i, model.date));
                    param.Add(DbHelper.CreateParameter("@line_no" + i, model.line_no));
                    param.Add(DbHelper.CreateParameter("@lane_no" + i, model.lane_no));
                    param.Add(DbHelper.CreateParameter("@start_mileage" + i, model.start_mileage));
                    param.Add(DbHelper.CreateParameter("@end_mileage" + i, model.end_mileage));
                    param.Add(DbHelper.CreateParameter("@iri" + i, model.iri));
                    param.Add(DbHelper.CreateParameter("@rd" + i, model.rd));
                    param.Add(DbHelper.CreateParameter("@bpn" + i, model.bpn));
                    param.Add(DbHelper.CreateParameter("@L0" + i, model.L0));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.Project_Code));
                    param.Add(DbHelper.CreateParameter("@create_date" + i, DateTime.Now));
                    param.Add(DbHelper.CreateParameter("@delete_flag" + i, 0));
                    param.Add(DbHelper.CreateParameter("@basement" + i, model.basement));
                    param.Add(DbHelper.CreateParameter("@volume" + i, model.volume));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.TaskNo));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }


        /// <summary>
        /// 删除监测指标数据
        /// </summary>
        public bool DeleteModelRoadIRI(int id)
        {
            string sql = "UPDATE tb_Model_Road_IRI SET delete_flag=1 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 删除监测指标数据
        /// </summary>
        public bool DeleteModelRoadIRIByTaskNo(string task_no)
        {
            string sql = "UPDATE tb_Model_Road_IRI SET delete_flag=1 WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckModelRoadIRI(ModelRoadIRI model)
        {
            string sql = "SELECT id FROM tb_Model_Road_IRI " +
                "                   WHERE line_no=@line_no AND lane_no=@lane_no AND" +
                "                               project_code=@project_code AND date=@date AND " +
                "                               start_mileage = @start_mileage AND end_mileage = @end_mileage AND" +
                "                               (delete_flag is null or delete_flag=0) and task_no=@task_no;";       
            
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));                
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增路面病害数据
        /// </summary>
        public bool AddModelRoadDamage(ModelRoadDamage model)
        {
            string sql = "INSERT INTO tb_Model_Road_Damage(date,line_no,lane_no,dis,pnt,catalog,name,severity,location,width,length,depth,project_code,datapushdate,delete_flag,task_no,section_code,start_mileage,end_mileage) VALUES(@date,@line_no,@lane_no,@dis,@pnt,@catalog,@name,@severity,@location,@width,@length,@depth,@project_code,now(),@delete_flag,@task_no,@section_code,@start_mileage,@end_mileage)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@dis", model.dis));
                param.Add(DbHelper.CreateParameter("@pnt", model.pnt));
                param.Add(DbHelper.CreateParameter("@catalog", model.catalog));
                param.Add(DbHelper.CreateParameter("@name", model.name));
                param.Add(DbHelper.CreateParameter("@severity", model.severity));
                param.Add(DbHelper.CreateParameter("@location", model.location));
                param.Add(DbHelper.CreateParameter("@width", model.width));
                param.Add(DbHelper.CreateParameter("@length", model.length));
                param.Add(DbHelper.CreateParameter("@depth", model.depth));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@delete_flag", 0));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        /// <summary>
        /// 修改路面病害数据
        /// </summary>
        public bool UpdateModelRoadDamage(ModelRoadDamage model, string id)
        {
            string sql = "UPDATE tb_Model_Road_Damage SET date=@date,line_no=@line_no,lane_no=@lane_no,dis=@dis,pnt=@pnt,catalog=@catalog,name=@name,severity=@severity,location=@location,width=@width,length=@length,depth=@depth,project_code=@project_code,section_code=@section_code,start_mileage=@start_mileage,end_mileage=@end_mileage WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@dis", model.dis));
                param.Add(DbHelper.CreateParameter("@pnt", model.pnt));
                param.Add(DbHelper.CreateParameter("@catalog", model.catalog));
                param.Add(DbHelper.CreateParameter("@name", model.name));
                param.Add(DbHelper.CreateParameter("@severity", model.severity));
                param.Add(DbHelper.CreateParameter("@location", model.location));
                param.Add(DbHelper.CreateParameter("@width", model.width));
                param.Add(DbHelper.CreateParameter("@length", model.length));
                param.Add(DbHelper.CreateParameter("@depth", model.depth));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));

                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 批量新增路面病害数据
        /// </summary>
        public bool InsertModelRoadDamageList(List<ModelRoadDamage> list)
        {
            string sql = " INSERT INTO tb_Model_Road_Damage(date,line_no,lane_no,dis,pnt,catalog,name,severity,location,width,length,depth,project_code,create_date,delete_flag,task_no,section_code,start_mileage,end_mileage) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;

            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@date{0},@line_no{0},@lane_no{0},@dis{0},@pnt{0},@catalog{0},@name{0},@severity{0},@location{0},@width{0},@length{0},@depth{0},@project_code{0},@create_date{0},@delete_flag{0},@task_no{0},@section_code{0},@start_mileage{0},@end_mileage{0})", i));
                    param.Add(DbHelper.CreateParameter("@date" + i, model.date));
                    param.Add(DbHelper.CreateParameter("@line_no" + i, model.line_no));
                    param.Add(DbHelper.CreateParameter("@lane_no" + i, model.lane_no));
                    param.Add(DbHelper.CreateParameter("@dis" + i, model.dis));
                    param.Add(DbHelper.CreateParameter("@pnt" + i, model.pnt));
                    param.Add(DbHelper.CreateParameter("@catalog" + i, model.catalog));
                    param.Add(DbHelper.CreateParameter("@name" + i, model.name));
                    param.Add(DbHelper.CreateParameter("@severity" + i, model.severity));
                    param.Add(DbHelper.CreateParameter("@location" + i, model.location));
                    param.Add(DbHelper.CreateParameter("@width" + i, model.width));
                    param.Add(DbHelper.CreateParameter("@length" + i, model.length));
                    param.Add(DbHelper.CreateParameter("@depth" + i, model.depth));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.Project_Code));
                    param.Add(DbHelper.CreateParameter("@create_date" + i, DateTime.Now));
                    param.Add(DbHelper.CreateParameter("@delete_flag" + i, 0));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.TaskNo));

                    param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                    param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                    param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 修改路面病害数据
        /// </summary>
        public bool UpdateModelRoadDamage(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_Model_Road_Damage SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 删除路面病害数据
        /// </summary>
        public bool DeleteModelRoadDamage(int id)
        {
            string sql = "UPDATE tb_Model_Road_Damage SET delete_flag=1 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 删除路面病害数据
        /// </summary>
        public bool DeleteModelRoadDamageByTaskNo(string task_no)
        {
            string sql = "UPDATE tb_Model_Road_Damage SET delete_flag=1 WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }

        }
        /// <summary>
        /// 路面路面病害数据List
        /// </summary>
        public IList<ModelRoadDamageQuery> GetModelRoadDamageList(ModelRoadDamageQuery model, out int count)
        {
            string sql = "select * from tb_Model_Road_Damage where task_no=@task_no AND delete_flag=0 limit @page,@count";
            string count_sql = "select count(1) from tb_Model_Road_Damage where  task_no=@task_no AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                      DbHelper.CreateParameter("@task_no", model.task_no)));
                return DbHelper.ExecuteReaderList<ModelRoadDamageQuery>(sql, CommandType.Text,
                       DbHelper.CreateParameter("@task_no", model.task_no),
                       DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                       DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckModelRoadDamage(ModelRoadDamage model)
        {
            string sql = "SELECT id FROM tb_Model_Road_Damage " +
                "                    WHERE date=@date AND line_no=@line_no AND lane_no=@lane_no AND " +
                "                                dis = @dis AND pnt = @pnt AND catalog = @catalog AND severity = @severity AND " +
                "                                project_code=@project_code and (delete_flag is null or delete_flag=0) and task_no=@task_no;";            
            
            List<DbParameter> param = new List<DbParameter>();
            
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@dis", model.dis));
                param.Add(DbHelper.CreateParameter("@pnt", model.pnt));
                param.Add(DbHelper.CreateParameter("@catalog", model.catalog));
                param.Add(DbHelper.CreateParameter("@severity", model.severity));
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增路面检测单信息
        /// </summary>
        public bool AddModelRoadCheckUnitInfo(ModelRoadCheckUnitInfo model)
        {
            string sql = "INSERT INTO tb_Model_Road_CheckUnitInfo(line_no,lane_no,start_mileage,end_mileage,project_code,datapushdate,delete_flag,section_code) VALUES(@line_no,@lane_no,@start_mileage,@end_mileage,@project_code,now(),0,@section_code)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 修改路面检测单信息
        /// </summary>
        public bool UpdateModelRoadCheckUnitInfo(ModelRoadCheckUnitInfo model, string id)
        {
            string sql = "UPDATE tb_Model_Road_CheckUnitInfo SET line_no=@line_no,lane_no=@lane_no,start_mileage=@start_mileage,end_mileage=@end_mileage,project_code=@project_code,section_code=@section_code  WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 批量新增路面检测单信息
        /// </summary>
        public bool InsertModelRoadCheckUnitInfoList(List<ModelRoadCheckUnitInfo> list)
        {
            string sql = " INSERT INTO tb_Model_Road_CheckUnitInfo(line_no,lane_no,start_mileage,end_mileage,project_code,create_date,delete_flag,section_code) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;

            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@line_no{0},@lane_no{0},@start_mileage{0},@end_mileage{0},@project_code{0},@create_date{0},@delete_flag{0},@section_code{0})", i));
                    param.Add(DbHelper.CreateParameter("@line_no" + i, model.line_no));
                    param.Add(DbHelper.CreateParameter("@lane_no" + i, model.lane_no));
                    param.Add(DbHelper.CreateParameter("@start_mileage" + i, model.start_mileage));
                    param.Add(DbHelper.CreateParameter("@end_mileage" + i, model.end_mileage));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.Project_Code));
                    param.Add(DbHelper.CreateParameter("@create_date" + i, DateTime.Now));
                    param.Add(DbHelper.CreateParameter("@delete_flag" + i, 0));
                    param.Add(DbHelper.CreateParameter("@section_code" + i, 0));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }


        /// <summary>
        /// 修改待评价项目的路面平整度信息 V2
        /// </summary>
        public bool UpdateModelRoadDataCheckvalue(ModelRoadDataCheckvalue model, int id)
        {
            string sql = "UPDATE tb_model_road_data_checkvalue SET date=@date,line_no=@line_no,lane_no=@lane_no,section_code=@section_code,start_mileage=@start_mileage,end_mileage=@end_mileage,iri=@iri,sfc=@sfc,pci=@pci,project_code=@project_code,task_no=@task_no  WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID" , model.ID));
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@iri", model.iri));
                param.Add(DbHelper.CreateParameter("@sfc", model.sfc));
                param.Add(DbHelper.CreateParameter("@pci", model.pci));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 批量新增待评价项目的路面平整度信息 V2
        /// </summary>
        public bool InsertModelRoadDataCheckvalueList(List<ModelRoadDataCheckvalue> list)
        {
            string sql = " INSERT INTO tb_model_road_data_checkvalue(date,line_no,lane_no,section_code,start_mileage,end_mileage,iri,sfc,pci,project_code,task_no) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;

            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@date{0},@line_no{0},@lane_no{0},@section_code{0},@start_mileage{0},@end_mileage{0},@iri{0},@sfc{0},@pci{0},@project_code{0},@task_no{0})", i));
                     
                    param.Add(DbHelper.CreateParameter("@date" + i, model.date));
                    param.Add(DbHelper.CreateParameter("@line_no" + i, model.line_no));
                    param.Add(DbHelper.CreateParameter("@lane_no" + i, model.lane_no));
                    param.Add(DbHelper.CreateParameter("@section_code" + i, model.section_code));
                    param.Add(DbHelper.CreateParameter("@start_mileage" + i, model.start_mileage));
                    param.Add(DbHelper.CreateParameter("@end_mileage" + i, model.end_mileage));
                    param.Add(DbHelper.CreateParameter("@iri" + i, model.iri));
                    param.Add(DbHelper.CreateParameter("@sfc" + i, model.sfc));
                    param.Add(DbHelper.CreateParameter("@pci" + i, model.pci));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 删除路面监测信息
        /// </summary>
        /// <returns></returns>
        public bool DeleteModelRoadCheckUnitInfoByTaskNo(string task_no)
        {
            string sql = "UPDATE tb_Model_Road_CheckUnitInfo SET delete_flag=1 WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 修改路面检测单信息
        /// </summary>
        public bool UpdateModelRoadCheckUnitInfo(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_Model_Road_CheckUnitInfo SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 删除路面检测单信息
        /// </summary>
        public bool DeleteModelRoadCheckUnitInfo(int id)
        {
            string sql = "UPDATE tb_Model_Road_CheckUnitInfo SET delete_flag=1 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckModelRoadCheckUnitInfo(ModelRoadCheckUnitInfo model)
        {
            string sql = "SELECT id FROM tb_Model_Road_CheckUnitInfo WHERE  line_no=@line_no AND lane_no=@lane_no AND project_code=@project_code and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增线路基本信息
        /// </summary>
        public bool AddModelRoadLineInfo(ModelRoadLineInfo model)
        {
            string sql = "INSERT INTO tb_model_tunnel_data_lineinfo(LineName,LineCode,LineLength,project_code,Memo,datapushdate,delete_flag) VALUES(@LineName,@LineCode,@LineLength,@project_code,@Memo,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineName", model.LineName));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LineLength", model.LineLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        /// <summary>
        /// 更新线路基本信息
        /// </summary>
        public bool UpdateModelRoadLineInfo(ModelRoadLineInfo model, string id)
        {
            string sql = "UPDATE tb_model_tunnel_data_lineinfo SET LineName=@LineName,LineCode=@LineCode,LineLength=@LineLength,project_code=@project_code,Memo=@Memo WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineName", model.LineName));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LineLength", model.LineLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckModelRoadLineInfo(ModelRoadLineInfo model)
        {
            string sql = "SELECT id FROM tb_model_tunnel_data_lineinfo WHERE  LineCode=@LineCode AND project_code=@project_code and (delete_flag is null or delete_flag=0) and linelength=@linelength";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@linelength", model.LineLength));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

    }
}
