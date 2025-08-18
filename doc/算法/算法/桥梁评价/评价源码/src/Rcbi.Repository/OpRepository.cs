using Rcbi.Entity.Domain;
using Rcbi.Entity.OpenApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace Rcbi.Repository
{
    public class OpRepository
    {

        /// <summary>
        /// 更新任务号
        /// </summary>
        public bool UpdateTaskNo(string task_no, DateTime start, DateTime end, string project_code)
        {
            string sql = @"UPDATE tb_model_op_teidata SET task_no=@task_no WHERE  project_code=@project_code AND MonitorDate>=@start AND MonitorDate<=@end;
                           UPDATE tb_model_op_dtidata SET task_no=@task_no WHERE  project_code=@project_code AND MonitorDate>=@start AND MonitorDate<=@end;
                           UPDATE tb_model_op_dfrdata SET task_no=@task_no WHERE  project_code=@project_code AND MonitorDate>=@start AND MonitorDate<=@end;
                           UPDATE tb_model_op_lrdata SET task_no=@task_no WHERE  project_code=@project_code AND MonitorDate>=@start AND MonitorDate<=@end;
                           UPDATE tb_model_op_mcidata SET task_no=@task_no WHERE  project_code=@project_code AND RealDate>=@start AND RealDate<=@end;
                           UPDATE tb_model_op_mbidata SET task_no=@task_no WHERE  project_code=@project_code AND DocCommitdate>=@start AND DocCommitdate<=@end;
                           UPDATE tb_model_op_mssidata SET task_no=@task_no WHERE  project_code=@project_code AND DocCommitdate>=@start AND DocCommitdate<=@end;
                           UPDATE tb_model_op_ucidata SET task_no=@task_no WHERE  project_code=@project_code AND InvestDate>=@start AND InvestDate<=@end;
                           UPDATE tb_model_op_dsidata SET task_no=@task_no WHERE  project_code=@project_code AND MonitorDate>=@start AND MonitorDate<=@end;";

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



        #region 用户服务指标评价等级
        /// <summary>
        /// 数据重复验证用户服务指标评价等级
        /// </summary>
        public string RepeatCheckModelOpCsiCriteria(ModelOpCsiCriteria model)
        {
            string sql = "SELECT id FROM tb_model_op_csi_criteria WHERE project_code=@project_code AND LevelName=@LevelName and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增用户服务指标评价等级
        /// </summary>
        public bool AddModelOpCsiCriteria(ModelOpCsiCriteria model)
        {
            string sql = "INSERT INTO tb_model_op_csi_criteria(MinValue,`MaxValue`,LevelName,LevelValue,project_code,DataPushDate) VALUES(@MinValue,@MaxValue,@LevelName,@LevelValue,@project_code,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_csi_criteria
        /// </summary>
        public bool UpdateModelOpCsiCriteria(ModelOpCsiCriteria model, string id)
        {
            string sql = "UPDATE tb_model_op_csi_criteria SET `MinValue`=@MinValue,`MaxValue`=@MaxValue,LevelName=@LevelName,LevelValue=@LevelValue,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 内业管理服务指标评价等级
        /// <summary>
        /// 数据重复验证内业管理服务指标评价等级
        /// </summary>
        public string RepeatCheckModelOpMsiCriteria(ModelOpMsiCriteria model)
        {
            string sql = "SELECT id FROM tb_model_op_msi_criteria WHERE project_code=@project_code AND LevelName=@LevelName and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增内业管理服务指标评价等级
        /// </summary>
        public bool AddModelOpMsiCriteria(ModelOpMsiCriteria model)
        {
            string sql = "INSERT INTO tb_model_op_msi_criteria(MinValue,`MaxValue`,LevelName,LevelValue,project_code,DataPushDate) VALUES(@MinValue,@MaxValue,@LevelName,@LevelValue,@project_code,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_msi_criteria
        /// </summary>
        public bool UpdateModelOpMsiCriteria(ModelOpMsiCriteria model, string id)
        {
            string sql = "UPDATE tb_model_op_msi_criteria SET `MinValue`=@MinValue,`MaxValue`=@MaxValue,LevelName=@LevelName,LevelValue=@LevelValue,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region FWCI指数评价等级
        /// <summary>
        /// 数据重复验证FWCI指数评价等级
        /// </summary>
        public string RepeatCheckModelOpFwciCriteria(ModelOpFwciCriteria model)
        {
            string sql = "SELECT id FROM tb_model_op_fwci_criteria WHERE project_code=@project_code AND LevelName=@LevelName and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增FWCI指数评价等级
        /// </summary>
        public bool AddModelOpFwciCriteria(ModelOpFwciCriteria model)
        {
            string sql = "INSERT INTO tb_model_op_fwci_criteria(MinValue,`MaxValue`,LevelName,LevelValue,project_code,DataPushDate) VALUES(@MinValue,@MaxValue,@LevelName,@LevelValue,@project_code,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_fwci_criteria
        /// </summary>
        public bool UpdateModelOpFwciCriteria(ModelOpFwciCriteria model, string id)
        {
            string sql = "UPDATE tb_model_op_fwci_criteria SET `MinValue`=@MinValue,`MaxValue`=@MaxValue,LevelName=@LevelName,LevelValue=@LevelValue,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 安全服务指标评价等级
        /// <summary>
        /// 数据重复验证安全服务指标评价等级
        /// </summary>
        public string RepeatCheckModelOpSsiCriteria(ModelOpSsiCriteria model)
        {
            string sql = "SELECT id FROM tb_model_op_ssi_criteria WHERE project_code=@project_code AND LevelName=@LevelName and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增安全服务指标评价等级
        /// </summary>
        public bool AddModelOpSsiCriteria(ModelOpSsiCriteria model)
        {
            string sql = "INSERT INTO tb_model_op_ssi_criteria(MinValue,`MaxValue`,LevelName,LevelValue,project_code,DataPushDate) VALUES(@MinValue,@MaxValue,@LevelName,@LevelValue,@project_code,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_ssi_criteria
        /// </summary>
        public bool UpdateModelOpSsiCriteria(ModelOpSsiCriteria model, string id)
        {
            string sql = "UPDATE tb_model_op_ssi_criteria SET `MinValue`=@MinValue,`MaxValue`=@MaxValue,LevelName=@LevelName,LevelValue=@LevelValue,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 交通服务指标评价等级
        /// <summary>
        /// 数据重复验证交通服务指标评价等级
        /// </summary>
        public string RepeatCheckModelOpTsiCriteria(ModelOpTsiCriteria model)
        {
            string sql = "SELECT id FROM tb_model_op_tsi_criteria WHERE project_code=@project_code AND LevelName=@LevelName and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增交通服务指标评价等级
        /// </summary>
        public bool AddModelOpTsiCriteria(ModelOpTsiCriteria model)
        {
            string sql = "INSERT INTO tb_model_op_tsi_criteria(MinValue,`MaxValue`,LevelName,LevelValue,project_code,DataPushDate) VALUES(@MinValue,@MaxValue,@LevelName,@LevelValue,@project_code,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_tsi_criteria
        /// </summary>
        public bool UpdateModelOpTsiCriteria(ModelOpTsiCriteria model, string id)
        {
            string sql = "UPDATE tb_model_op_tsi_criteria SET `MinValue`=@MinValue,`MaxValue`=@MaxValue,LevelName=@LevelName,LevelValue=@LevelValue,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MinValue", model.MinValue));
                param.Add(DbHelper.CreateParameter("@MaxValue", model.MaxValue));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@LevelValue", model.LevelValue));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region CO一氧化碳指数业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpCodata(ModelOpCodata model)
        {
            string sql = "SELECT id FROM tb_model_op_codata WHERE project_code=@project_code AND LineCode=@LineCode AND Position=@Position AND Mileage=@Mileage AND DeviceNo=@DeviceNo  AND MonitorMonth=@MonitorMonth and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpCodata(ModelOpCodata model)
        {
            string sql = "INSERT INTO tb_model_op_codata(project_code,task_no,LineCode,Position,Mileage,DeviceNo,MonitorYear,MonitorMonth,MonitorData,DataPushDate) VALUES(@project_code,@task_no,@LineCode,@Position,@Mileage,@DeviceNo,@MonitorYear,@MonitorMonth,@MonitorData,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public bool UpdateModelOpCodata(ModelOpCodata model, string id)
        {
            string sql = "UPDATE tb_model_op_codata SET project_code=@project_code,LineCode=@LineCode,Position=@Position,Mileage=@Mileage,DeviceNo=@DeviceNo,MonitorYear=@MonitorYear,MonitorMonth=@MonitorMonth,MonitorData=@MonitorData WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 交牵引排堵TEI业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpTeidata(ModelOpTeidata model)
        {
            string sql = "SELECT id FROM tb_model_op_teidata WHERE project_code=@project_code AND LineCode=@LineCode AND MonitorDate=@MonitorDate  and (delete_flag is null or delete_flag=0)  and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpTeidata(ModelOpTeidata model)
        {
            string sql = "INSERT INTO tb_model_op_teidata(project_code,task_no,LineCode,MonitorDate,M1amount,M2amount,Totalinday,DataPushDate) VALUES(@project_code,@task_no,@LineCode,@MonitorDate,@M1amount,@M2amount,@Totalinday,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@M1amount", model.M1amount));
                param.Add(DbHelper.CreateParameter("@M2amount", model.M2amount));
                param.Add(DbHelper.CreateParameter("@Totalinday", model.Totalinday));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_teidata
        /// </summary>
        public bool UpdateModelOpTeidata(ModelOpTeidata model, string id)
        {
            string sql = "UPDATE tb_model_op_teidata SET project_code=@project_code,LineCode=@LineCode,MonitorDate=@MonitorDate,M1amount=@M1amount,M2amount=@M2amount,Totalinday=@Totalinday WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@M1amount", model.M1amount));
                param.Add(DbHelper.CreateParameter("@M2amount", model.M2amount));
                param.Add(DbHelper.CreateParameter("@Totalinday", model.Totalinday));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 交通流量DTI线路业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDtidata(ModelOpDtidata model)
        {
            string sql = "SELECT id FROM tb_model_op_dtidata WHERE project_code=@project_code AND LineCode=@LineCode AND MonitorDate=@MonitorDate and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpDtidata(ModelOpDtidata model)
        {
            string sql = "INSERT INTO tb_model_op_dtidata(project_code,task_no,Year,Month,TrafficPeak4h,TrafficTotal,MiniBus,LargeBus,LargeTruck,Articulated) VALUES(@project_code,@task_no,@Year,@Month,@TrafficPeak4h,@TrafficTotal,@MiniBus,@LargeBus,@LargeTruck,@Articulated)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@Year", model.Year));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@TrafficPeak4h", model.TrafficPeak4h));
                param.Add(DbHelper.CreateParameter("@TrafficTotal", model.TrafficTotal));
                param.Add(DbHelper.CreateParameter("@MiniBus", model.MiniBus));
                param.Add(DbHelper.CreateParameter("@LargeBus", model.LargeBus));
                param.Add(DbHelper.CreateParameter("@LargeTruck", model.LargeTruck));
                param.Add(DbHelper.CreateParameter("@Articulated", model.Articulated));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_dtidata
        /// </summary>
        public bool UpdateModelOpDtidata(ModelOpDtidata model, string id)
        {
            string sql = "UPDATE tb_model_op_dtidata SET project_code=@project_code,LineCode=@LineCode,MonitorDate=@MonitorDate,TunneltrafficTotal=@TunneltrafficTotal,TunneltrafficMax=@TunneltrafficMax,Tunneltraffic57=@Tunneltraffic57,Tunneltraffic1719=@Tunneltraffic1719,Lane1=@Lane1,Lane1Trafficnum=@Lane1Trafficnum,Lane1Traffic57=@Lane1Traffic57,Lane1Traffic1719=@Lane1Traffic1719,Lane2=@Lane2,Lane2Trafficnum=@Lane2Trafficnum,Lane2Traffic57=@Lane2Traffic57,Lane2Traffic1719=@Lane2Traffic1719,Lane3=@Lane3,Lane3Trafficnum=@Lane3Trafficnum,Lane3Traffic57=@Lane3Traffic57,Lane3Traffic1719=@Lane3Traffic1719,Lane4=@Lane4,Lane4Trafficnum=@Lane4Trafficnum,Lane4Traffic57=@Lane4Traffic57,Lane4Traffic1719=@Lane4Traffic1719,Lane5=@Lane5,Lane5Trafficnum=@Lane5Trafficnum,Lane5Traffic57=@Lane5Traffic57,Lane5Traffic1719=@Lane5Traffic1719,Lane6=@Lane6,Lane61Trafficnum=@Lane61Trafficnum,Lane6Traffic57=@Lane6Traffic57,Lane6Traffic1719=@Lane6Traffic1719 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@Year", model.Year));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@TrafficPeak4h", model.TrafficPeak4h));
                param.Add(DbHelper.CreateParameter("@TrafficTotal", model.TrafficTotal));
                param.Add(DbHelper.CreateParameter("@MiniBus", model.MiniBus));
                param.Add(DbHelper.CreateParameter("@LargeBus", model.LargeBus));
                param.Add(DbHelper.CreateParameter("@LargeTruck", model.LargeTruck));
                param.Add(DbHelper.CreateParameter("@Articulated", model.Articulated));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region  交通畅通率DFR业务信息
        /// <summary>
        /// 数据重复验证交
        /// </summary>
        public string RepeatCheckModelOpDfrdata(ModelOpDfrdata model)
        {
            string sql = "SELECT id FROM tb_model_op_dfrdata WHERE project_code=@project_code AND LineCode=@LineCode AND MonitorDate=@MonitorDate and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpDfrdata(ModelOpDfrdata model)
        {
            string sql = "INSERT INTO tb_model_op_dfrdata(project_code,task_no,LineCode,MonitorDate,DelayTimes,DataPushDate) VALUES(@project_code,@task_no,@LineCode,@MonitorDate,@DelayTimes,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@DelayTimes", model.DelayTimes));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_dfrdata
        /// </summary>
        public bool UpdateModelOpDfrdata(ModelOpDfrdata model, string id)
        {
            string sql = "UPDATE tb_model_op_dfrdata SET project_code=@project_code,LineCode=@LineCode,MonitorDate=@MonitorDate,DelayTimes=@DelayTimes WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@DelayTimes", model.DelayTimes));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 交通路面荷载LR业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpLrdata(ModelOpLrdata model)
        {
            string sql = "SELECT id FROM tb_model_op_lrdata WHERE project_code=@project_code AND LineCode=@LineCode AND MonitorDate=@MonitorDate and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpLrdata(ModelOpLrdata model)
        {
            string sql = "INSERT INTO tb_model_op_lrdata(project_code,task_no,LineCode,MonitorDate,TotalCar,SmallCarAmount,BigCarAmount,MediumCarAmount,TruckAmount,BusAmount1,BusAmount2,BusAmount3,BusAmount4,VanAmount1,VanAmount2,VanAmount3,VanAmount4,VanAmount5,TruckAmount1,TruckAmount2,DataPushDate) VALUES(@project_code,@task_no,@LineCode,@MonitorDate,@TotalCar,@SmallCarAmount,@BigCarAmount,@MediumCarAmount,@TruckAmount,@BusAmount1,@BusAmount2,@BusAmount3,@BusAmount4,@VanAmount1,@VanAmount2,@VanAmount3,@VanAmount4,@VanAmount5,@TruckAmount1,@TruckAmount2,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@TotalCar", model.TotalCar));
                param.Add(DbHelper.CreateParameter("@SmallCarAmount", model.SmallCarAmount));
                param.Add(DbHelper.CreateParameter("@BigCarAmount", model.BigCarAmount));
                param.Add(DbHelper.CreateParameter("@MediumCarAmount", model.MediumCarAmount));
                param.Add(DbHelper.CreateParameter("@TruckAmount", model.TruckAmount));
                param.Add(DbHelper.CreateParameter("@BusAmount1", model.BusAmount1));
                param.Add(DbHelper.CreateParameter("@BusAmount2", model.BusAmount2));
                param.Add(DbHelper.CreateParameter("@BusAmount3", model.BusAmount3));
                param.Add(DbHelper.CreateParameter("@BusAmount4", model.BusAmount4));
                param.Add(DbHelper.CreateParameter("@VanAmount1", model.VanAmount1));
                param.Add(DbHelper.CreateParameter("@VanAmount2", model.VanAmount2));
                param.Add(DbHelper.CreateParameter("@VanAmount3", model.VanAmount3));
                param.Add(DbHelper.CreateParameter("@VanAmount4", model.VanAmount4));
                param.Add(DbHelper.CreateParameter("@VanAmount5", model.VanAmount5));
                param.Add(DbHelper.CreateParameter("@TruckAmount1", model.TruckAmount1));
                param.Add(DbHelper.CreateParameter("@TruckAmount2", model.TruckAmount2));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_lrdata
        /// </summary>
        public bool UpdateModelOpLrdata(ModelOpLrdata model, string id)
        {
            string sql = "UPDATE tb_model_op_lrdata SET project_code=@project_code,LineCode=@LineCode,MonitorDate=@MonitorDate,TotalCar=@TotalCar,SmallCarAmount=@SmallCarAmount,BigCarAmount=@BigCarAmount,MediumCarAmount=@MediumCarAmount,TruckAmount=@TruckAmount,BusAmount1=@BusAmount1,BusAmount2=@BusAmount2,BusAmount3=@BusAmount3,BusAmount4=@BusAmount4,VanAmount1=@VanAmount1,VanAmount2=@VanAmount2,VanAmount3=@VanAmount3,VanAmount4=@VanAmount4,VanAmount5=@VanAmount5,TruckAmount1=@TruckAmount1,TruckAmount2=@TruckAmount2 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@TotalCar", model.TotalCar));
                param.Add(DbHelper.CreateParameter("@SmallCarAmount", model.SmallCarAmount));
                param.Add(DbHelper.CreateParameter("@BigCarAmount", model.BigCarAmount));
                param.Add(DbHelper.CreateParameter("@MediumCarAmount", model.MediumCarAmount));
                param.Add(DbHelper.CreateParameter("@TruckAmount", model.TruckAmount));
                param.Add(DbHelper.CreateParameter("@BusAmount1", model.BusAmount1));
                param.Add(DbHelper.CreateParameter("@BusAmount2", model.BusAmount2));
                param.Add(DbHelper.CreateParameter("@BusAmount3", model.BusAmount3));
                param.Add(DbHelper.CreateParameter("@BusAmount4", model.BusAmount4));
                param.Add(DbHelper.CreateParameter("@VanAmount1", model.VanAmount1));
                param.Add(DbHelper.CreateParameter("@VanAmount2", model.VanAmount2));
                param.Add(DbHelper.CreateParameter("@VanAmount3", model.VanAmount3));
                param.Add(DbHelper.CreateParameter("@VanAmount4", model.VanAmount4));
                param.Add(DbHelper.CreateParameter("@VanAmount5", model.VanAmount5));
                param.Add(DbHelper.CreateParameter("@TruckAmount1", model.TruckAmount1));
                param.Add(DbHelper.CreateParameter("@TruckAmount2", model.TruckAmount2));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 亮度或照度BI业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpBidata(ModelOpBidata model)
        {
            string sql = "SELECT id FROM tb_model_op_bidata WHERE project_code=@project_code AND LineCode=@LineCode AND Deviceno=@Deviceno AND Position=@Position AND Mileage=@Mileage and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Deviceno", model.Deviceno));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpBidata(ModelOpBidata model)
        {
            string sql = "INSERT INTO tb_model_op_bidata(project_code,task_no,LineCode,Position,Mileage,Deviceno,MonitorYear,MonitorMonth,MonitorData,DataPushDate,uniformdata) VALUES(@project_code,@task_no,@LineCode,@Position,@Mileage,@Deviceno,@MonitorYear,@MonitorMonth,@MonitorData,now(),@uniformdata)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@Deviceno", model.Deviceno));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));
                
                param.Add(DbHelper.CreateParameter("@uniformdata", model.uniformdata));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_bidata
        /// </summary>
        public bool UpdateModelOpBidata(ModelOpBidata model, string id)
        {
            string sql = "UPDATE tb_model_op_bidata SET project_code=@project_code,LineCode=@LineCode,Position=@Position,Mileage=@Mileage,Deviceno=@Deviceno,MonitorYear=@MonitorYear,MonitorMonth=@MonitorMonth,MonitorData=@MonitorData,uniformdata=@uniformdata WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@Deviceno", model.Deviceno));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));

                param.Add(DbHelper.CreateParameter("@uniformdata", model.uniformdata));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 内业成本绩效MCI业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpMcidata(ModelOpMcidata model)
        {
            string sql = "SELECT id FROM tb_model_op_mcidata WHERE project_code=@project_code AND DocYear=@DocYear AND Month=@Month and (delete_flag is null or delete_flag=0)  and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpMcidata(ModelOpMcidata model)
        {
            string sql = "INSERT INTO tb_model_op_mcidata(project_code,task_no,Month,RealCost,RealPerformance,RealDate,PlanCost,PlanPerformance,PlanDate,DataPushDate,DocYear) VALUES(@project_code,@task_no,@Month,@RealCost,@RealPerformance,@RealDate,@PlanCost,@PlanPerformance,@PlanDate,now(),@DocYear)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@RealCost", model.RealCost));
                param.Add(DbHelper.CreateParameter("@RealPerformance", model.RealPerformance));
                param.Add(DbHelper.CreateParameter("@RealDate", model.RealDate));
                param.Add(DbHelper.CreateParameter("@PlanCost", model.PlanCost));
                param.Add(DbHelper.CreateParameter("@PlanPerformance", model.PlanPerformance));
                param.Add(DbHelper.CreateParameter("@PlanDate", model.PlanDate));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_mcidata
        /// </summary>
        public bool UpdateModelOpMcidata(ModelOpMcidata model, string id)
        {
            string sql = "UPDATE tb_model_op_mcidata SET project_code=@project_code,Month=@Month,RealCost=@RealCost,RealPerformance=@RealPerformance,RealDate=@RealDate,PlanCost=@PlanCost,PlanPerformance=@PlanPerformance,PlanDate=@PlanDate,DocYear=@DocYear WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@RealCost", model.RealCost));
                param.Add(DbHelper.CreateParameter("@RealPerformance", model.RealPerformance));
                param.Add(DbHelper.CreateParameter("@RealDate", model.RealDate));
                param.Add(DbHelper.CreateParameter("@PlanCost", model.PlanCost));
                param.Add(DbHelper.CreateParameter("@PlanPerformance", model.PlanPerformance));
                param.Add(DbHelper.CreateParameter("@PlanDate", model.PlanDate));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 内业报编制MBI业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpMbidata(ModelOpMbidata model)
        {
            string sql = "SELECT id FROM tb_model_op_mbidata WHERE project_code=@project_code  AND DocYear=@DocYear AND DocCode=@DocCode and task_no=@task_no and (delete_flag is null or delete_flag=0)"; List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@DocCode", model.DocCode));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpMbidata(ModelOpMbidata model)
        {
            string sql = "INSERT INTO tb_model_op_mbidata(project_code,task_no,DocCode,DocName_Spec,DocName_Company,DocComplete,DocCommitdate,DataPushDate,DocYear) VALUES(@project_code,@task_no,@DocCode,@DocName_Spec,@DocName_Company,@DocComplete,@DocCommitdate,now(),@DocYear)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@DocCode", model.DocCode));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocNameSpec));
                param.Add(DbHelper.CreateParameter("@DocName_Company", model.DocNameCompany));
                param.Add(DbHelper.CreateParameter("@DocComplete", model.DocComplete));
                param.Add(DbHelper.CreateParameter("@DocCommitdate", model.DocCommitdate));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_mbidata
        /// </summary>
        public bool UpdateModelOpMbidata(ModelOpMbidata model, string id)
        {
            string sql = "UPDATE tb_model_op_mbidata SET project_code=@project_code,DocCode=@DocCode,DocName_Spec=@DocName_Spec,DocName_Company=@DocName_Company,DocComplete=@DocComplete,DocCommitdate=@DocCommitdate,DocYear=@DocYear WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@DocCode", model.DocCode));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocNameSpec));
                param.Add(DbHelper.CreateParameter("@DocName_Company", model.DocNameCompany));
                param.Add(DbHelper.CreateParameter("@DocComplete", model.DocComplete));
                param.Add(DbHelper.CreateParameter("@DocCommitdate", model.DocCommitdate));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 内业档案资料信息化MII业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpMiidata(ModelOpMiidata model)
        {
            string sql = "SELECT id FROM tb_model_op_miidata WHERE project_code=@project_code AND DocYear=@DocYear AND DocCode=@DocCode and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@DocCode", model.DocCode));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpMiidata(ModelOpMiidata model)
        {
            string sql = "INSERT INTO tb_model_op_miidata(project_code,task_no,DocCode,DocName_Spec,DocName_Company,DocComplete,DataPushDate,DocYear) VALUES(@project_code,@task_no,@DocCode,@DocName_Spec,@DocName_Company,@DocComplete,now(),@DocYear)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@DocCode", model.DocCode));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocNameSpec));
                param.Add(DbHelper.CreateParameter("@DocName_Company", model.DocNameCompany));
                param.Add(DbHelper.CreateParameter("@DocComplete", model.DocComplete));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_miidata
        /// </summary>
        public bool UpdateModelOpMiidata(ModelOpMiidata model, string id)
        {
            string sql = "UPDATE tb_model_op_miidata SET project_code=@project_code,DocCode=@DocCode,DocName_Spec=@DocName_Spec,DocName_Company=@DocName_Company,DocComplete=@DocComplete,DocYear=@DocYear WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@DocCode", model.DocCode));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocNameSpec));
                param.Add(DbHelper.CreateParameter("@DocName_Company", model.DocNameCompany));
                param.Add(DbHelper.CreateParameter("@DocComplete", model.DocComplete));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 内业管理制度MSSI业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpMssidata(ModelOpMssidata model)
        {
            string sql = "SELECT id FROM tb_model_op_mssidata WHERE project_code=@project_code AND DocType=@DocType AND DocYear=@DocYear AND DocName_Spec=@DocName_Spec and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@DocType", model.DocType));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocNameSpec));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpMssidata(ModelOpMssidata model)
        {
            string sql = "INSERT INTO tb_model_op_mssidata(project_code,task_no,DocType,DocName_Spec,DocName_Company,DocComplete,DocCommitDate,DataPushDate,DocYear) VALUES(@project_code,@task_no,@DocType,@DocName_Spec,@DocName_Company,@DocComplete,@DocCommitDate,now(),@DocYear)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@DocType", model.DocType));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocNameSpec));
                param.Add(DbHelper.CreateParameter("@DocName_Company", model.DocNameCompany));
                param.Add(DbHelper.CreateParameter("@DocComplete", model.DocComplete));
                param.Add(DbHelper.CreateParameter("@DocCommitDate", model.DocCommitDate));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_mssidata
        /// </summary>
        public bool UpdateModelOpMssidata(ModelOpMssidata model, string id)
        {
            string sql = "UPDATE tb_model_op_mssidata SET project_code=@project_code,DocType=@DocType,DocName_Spec=@DocName_Spec,DocName_Company=@DocName_Company,DocComplete=@DocComplete,DocCommitDate=@DocCommitDate,DocYear=@DocYear WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@DocType", model.DocType));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocNameSpec));
                param.Add(DbHelper.CreateParameter("@DocName_Company", model.DocNameCompany));
                param.Add(DbHelper.CreateParameter("@DocComplete", model.DocComplete));
                param.Add(DbHelper.CreateParameter("@DocCommitDate", model.DocCommitDate));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 可吸入颗粒物浓度PM2.5业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpPmdata(ModelOpPmdata model)
        {
            string sql = "SELECT id FROM tb_model_op_pmdata WHERE project_code=@project_code AND LineCode=@LineCode AND Position=@Position AND Mileage=@Mileage AND DeviceNo=@DeviceNo  AND MonitorMonth=@MonitorMonth and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpPmdata(ModelOpPmdata model)
        {
            string sql = "INSERT INTO tb_model_op_pmdata(project_code,task_no,LineCode,Position,Mileage,DeviceNo,MonitorYear,MonitorMonth,MonitorData,DataPushDate) VALUES(@project_code,@task_no,@LineCode,@Position,@Mileage,@DeviceNo,@MonitorYear,@MonitorMonth,@MonitorData,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_pmdata
        /// </summary>
        public bool UpdateModelOpPmdata(ModelOpPmdata model, string id)
        {
            string sql = "UPDATE tb_model_op_pmdata SET project_code=@project_code,LineCode=@LineCode,Position=@Position,Mileage=@Mileage,DeviceNo=@DeviceNo,MonitorYear=@MonitorYear,MonitorMonth=@MonitorMonth,MonitorData=@MonitorData WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 噪音DI业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDidata(ModelOpDidata model)
        {
            string sql = "SELECT id FROM tb_model_op_didata WHERE project_code=@project_code AND LineCode=@LineCode AND Position=@Position AND Mileage=@Mileage AND DeviceNo=@DeviceNo AND MonitorYear=@MonitorYear and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpDidata(ModelOpDidata model)
        {
            string sql = "INSERT INTO tb_model_op_didata(project_code,task_no,LineCode,Position,Mileage,DeviceNo,MonitorYear,MonitorMonthDay,MonitorDataDay,MonitorMonthNight,MonitorDataNight,DataPushDate,MonitorData) VALUES(@project_code,@task_no,@LineCode,@Position,@Mileage,@DeviceNo,@MonitorYear,@MonitorMonthDay,@MonitorDataDay,@MonitorMonthNight,@MonitorDataNight,now(),@MonitorData)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonthDay", model.MonitorMonthDay));
                param.Add(DbHelper.CreateParameter("@MonitorDataDay", model.MonitorDataDay));
                param.Add(DbHelper.CreateParameter("@MonitorMonthNight", model.MonitorMonthNight));
                param.Add(DbHelper.CreateParameter("@MonitorDataNight", model.MonitorDataNight));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_didata
        /// </summary>
        public bool UpdateModelOpDidata(ModelOpDidata model, string id)
        {
            string sql = "UPDATE tb_model_op_didata SET project_code=@project_code,LineCode=@LineCode,Position=@Position,Mileage=@Mileage,DeviceNo=@DeviceNo,MonitorYear=@MonitorYear,MonitorMonthDay=@MonitorMonthDay,MonitorDataDay=@MonitorDataDay,MonitorMonthNight=@MonitorMonthNight,MonitorDataNight=@MonitorDataNight,MonitorData=@MonitorData WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonthDay", model.MonitorMonthDay));
                param.Add(DbHelper.CreateParameter("@MonitorDataDay", model.MonitorDataDay));
                param.Add(DbHelper.CreateParameter("@MonitorMonthNight", model.MonitorMonthNight));
                param.Add(DbHelper.CreateParameter("@MonitorDataNight", model.MonitorDataNight));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 安全事故率RV业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpRvdata(ModelOpRvdata model)
        {
            string sql = "SELECT id FROM tb_model_op_rvdata WHERE project_code=@project_code AND LineCode=@LineCode AND MonitorYear=@MonitorYear AND MonitorMonth=@MonitorMonth and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpRvdata(ModelOpRvdata model)
        {
            string sql = "INSERT INTO tb_model_op_rvdata(project_code,task_no,LineCode,MonitorYear,MonitorMonth,Accident_Num,Broke_Down,Average_Stream,DataPushDate) VALUES(@project_code,@task_no,@LineCode,@MonitorYear,@MonitorMonth,@Accident_Num,@Broke_Down,@Average_Stream,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@Accident_Num", model.AccidentNum));
                param.Add(DbHelper.CreateParameter("@Broke_Down", model.BrokeDown));
                param.Add(DbHelper.CreateParameter("@Average_Stream", model.AverageStream));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_rvdata
        /// </summary>
        public bool UpdateModelOpRvdata(ModelOpRvdata model, string id)
        {
            string sql = "UPDATE tb_model_op_rvdata SET project_code=@project_code,LineCode=@LineCode,MonitorYear=@MonitorYear,MonitorMonth=@MonitorMonth,Accident_Num=@Accident_Num,Broke_Down=@Broke_Down,Average_Stream=@Average_Stream WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@Accident_Num", model.AccidentNum));
                param.Add(DbHelper.CreateParameter("@Broke_Down", model.BrokeDown));
                param.Add(DbHelper.CreateParameter("@Average_Stream", model.AverageStream));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 用户满意度UCVI业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpUcvidata(ModelOpUcvidata model)
        {
            string sql = "SELECT id FROM tb_model_op_ucvidata WHERE project_code=@project_code AND DataYear=@DataYear AND DataMonth=@DataMonth and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@DataYear", model.DataYear));
                param.Add(DbHelper.CreateParameter("@DataMonth", model.DataMonth));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpUcvidata(ModelOpUcvidata model)
        {
            string sql = "INSERT INTO tb_model_op_ucvidata(project_code,task_no,DataYear,DataMonth,DelayAmount,HandleAmount,DataPushDate) VALUES(@project_code,@task_no,@DataYear,@DataMonth,@DelayAmount,@HandleAmount,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@DataYear", model.DataYear));
                param.Add(DbHelper.CreateParameter("@DataMonth", model.DataMonth));
                param.Add(DbHelper.CreateParameter("@DelayAmount", model.DelayAmount));
                param.Add(DbHelper.CreateParameter("@HandleAmount", model.HandleAmount));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_ucvidata
        /// </summary>
        public bool UpdateModelOpUcvidata(ModelOpUcvidata model, string id)
        {
            string sql = "UPDATE tb_model_op_ucvidata SET project_code=@project_code,DataYear=@DataYear,DataMonth=@DataMonth,DelayAmount=@DelayAmount,HandleAmount=@HandleAmount WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@DataYear", model.DataYear));
                param.Add(DbHelper.CreateParameter("@DataMonth", model.DataMonth));
                param.Add(DbHelper.CreateParameter("@DelayAmount", model.DelayAmount));
                param.Add(DbHelper.CreateParameter("@HandleAmount", model.HandleAmount));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 用户舒适度UCI业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpUcidata(ModelOpUcidata model)
        {
            string sql = "SELECT id FROM tb_model_op_ucidata WHERE project_code=@project_code AND InvestDate=@InvestDate  AND InvestContent=@InvestContent and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@InvestDate", model.InvestDate));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@InvestContent", model.InvestContent));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpUcidata(ModelOpUcidata model)
        {
            string sql = "INSERT INTO tb_model_op_ucidata(project_code,task_no,InvestDate,InvestContent,CustomerAge,CustomerSex,SatisfactsCore,UnsatisFactreason,DataPushDate) VALUES(@project_code,@task_no,@InvestDate,@InvestContent,@CustomerAge,@CustomerSex,@SatisfactsCore,@UnsatisFactreason,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@InvestDate", model.InvestDate));
                param.Add(DbHelper.CreateParameter("@InvestContent", model.InvestContent));
                param.Add(DbHelper.CreateParameter("@CustomerAge", model.CustomerAge));
                param.Add(DbHelper.CreateParameter("@CustomerSex", model.CustomerSex));
                param.Add(DbHelper.CreateParameter("@SatisfactsCore", model.SatisfactsCore));
                param.Add(DbHelper.CreateParameter("@UnsatisFactreason", model.UnsatisFactreason));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_ucidata
        /// </summary>
        public bool UpdateModelOpUcidata(ModelOpUcidata model, string id)
        {
            string sql = "UPDATE tb_model_op_ucidata SET project_code=@project_code,InvestDate=@InvestDate,InvestContent=@InvestContent,CustomerAge=@CustomerAge,CustomerSex=@CustomerSex,SatisfactsCore=@SatisfactsCore,UnsatisFactreason=@UnsatisFactreason WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@InvestDate", model.InvestDate));
                param.Add(DbHelper.CreateParameter("@InvestContent", model.InvestContent));
                param.Add(DbHelper.CreateParameter("@CustomerAge", model.CustomerAge));
                param.Add(DbHelper.CreateParameter("@CustomerSex", model.CustomerSex));
                param.Add(DbHelper.CreateParameter("@SatisfactsCore", model.SatisfactsCore));
                param.Add(DbHelper.CreateParameter("@UnsatisFactreason", model.UnsatisFactreason));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 能见度VI业务信息
        /// <summary>
        /// 数据重复验证能见度VI业务信息
        /// </summary>
        public string RepeatCheckModelOpVidata(ModelOpVidata model)
        {
            string sql = "SELECT id FROM tb_model_op_vidata WHERE project_code=@project_code AND monitoryear=@monitoryear AND monitormonth=@monitormonth AND linecode=@linecode AND mileage=@mileage  and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@monitoryear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@monitormonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@linecode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增能见度VI业务信息
        /// </summary>
        public bool AddModelOpVidata(ModelOpVidata model)
        {
            string sql = "INSERT INTO tb_model_op_vidata(project_code,task_no,linecode,position,mileage,deviceno,monitoryear,monitormonth,monitordata,datapushdate,delete_flag) VALUES(@project_code,@task_no,@linecode,@position,@mileage,@deviceno,@monitoryear,@monitormonth,@monitordata,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@linecode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@position", model.Position));
                param.Add(DbHelper.CreateParameter("@mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@deviceno", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@monitoryear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@monitormonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@monitordata", model.MonitorData));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_vidata
        /// </summary>
        public bool UpdateModelOpVidata(ModelOpVidata model, string id)
        {
            string sql = "UPDATE tb_model_op_vidata SET project_code=@project_code,task_no=@task_no,linecode=@linecode,position=@position,mileage=@mileage,deviceno=@deviceno,monitoryear=@monitoryear,monitormonth=@monitormonth,monitordata=@monitordata WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@linecode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@position", model.Position));
                param.Add(DbHelper.CreateParameter("@mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@deviceno", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@monitoryear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@monitormonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@monitordata", model.MonitorData));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        #endregion

        #region 行驶速率DSI业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDsidata(ModelOpDsidata model)
        {
            string sql = "SELECT id FROM tb_model_op_dsidata WHERE project_code=@project_code AND LineCode=@LineCode AND MonitorDate=@MonitorDate and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpDsidata(ModelOpDsidata model)
        {
            string sql = "INSERT INTO tb_model_op_dsidata(project_code,task_no,LineCode,MonitorDate,MonitorLength,PassTime,DataPushDate) VALUES(@project_code,@task_no,@LineCode,@MonitorDate,@MonitorLength,@PassTime,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@MonitorLength", model.MonitorLength));
                param.Add(DbHelper.CreateParameter("@PassTime", model.PassTime));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_dsidata
        /// </summary>
        public bool UpdateModelOpDsidata(ModelOpDsidata model, string id)
        {
            string sql = "UPDATE tb_model_op_dsidata SET project_code=@project_code,LineCode=@LineCode,MonitorDate=@MonitorDate,MonitorLength=@MonitorLength,PassTime=@PassTime WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@MonitorLength", model.MonitorLength));
                param.Add(DbHelper.CreateParameter("@PassTime", model.PassTime));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 隧道交通流量业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpTunneltrafficinfo(ModelOpTunneltrafficinfo model)
        {
            string sql = "SELECT id FROM tb_model_op_tunneltrafficinfo WHERE BuildStartDate=@BuildStartDate AND BuildEndDate=@BuildEndDate AND CommitDate=@CommitDate AND CqType=@CqType  AND project_code=@project_code and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@BuildStartDate", model.BuildStartDate));
                param.Add(DbHelper.CreateParameter("@BuildEndDate", model.BuildEndDate));
                param.Add(DbHelper.CreateParameter("@CommitDate", model.CommitDate));
                param.Add(DbHelper.CreateParameter("@CqType", model.CqType));

                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpTunneltrafficinfo(ModelOpTunneltrafficinfo model)
        {
            string sql = "INSERT INTO tb_model_op_tunneltrafficinfo(task_no,BuildStartDate,BuildEndDate,CommitDate,OpstartDate,BigMaintainStartDate,BigMaintainEndDate,EntryAmount,ExitAmount,StructureType,TunnelDirection,CqType,Crossriver,Opattribute,TunnelLength,TunnelWidth,TunnelPureWidth,TunnelShape,CqThick,CqStrength,DesignSpeed,DesignLoading,DesignFlowing,OwnerUnit,DesignUnit,ContructUnit,OperationUnit,NewContractStartDate,NewContractEndDate,DataPushDate) VALUES(@task_no,@BuildStartDate,@BuildEndDate,@CommitDate,@OpstartDate,@BigMaintainStartDate,@BigMaintainEndDate,@EntryAmount,@ExitAmount,@StructureType,@TunnelDirection,@CqType,@Crossriver,@Opattribute,@TunnelLength,@TunnelWidth,@TunnelPureWidth,@TunnelShape,@CqThick,@CqStrength,@DesignSpeed,@DesignLoading,@DesignFlowing,@OwnerUnit,@DesignUnit,@ContructUnit,@OperationUnit,@NewContractStartDate,@NewContractEndDate,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@BuildStartDate", model.BuildStartDate));
                param.Add(DbHelper.CreateParameter("@BuildEndDate", model.BuildEndDate));
                param.Add(DbHelper.CreateParameter("@CommitDate", model.CommitDate));
                param.Add(DbHelper.CreateParameter("@OpstartDate", model.OpstartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainStartDate", model.BigMaintainStartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainEndDate", model.BigMaintainEndDate));
                param.Add(DbHelper.CreateParameter("@EntryAmount", model.EntryAmount));
                param.Add(DbHelper.CreateParameter("@ExitAmount", model.ExitAmount));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@TunnelDirection", model.TunnelDirection));
                param.Add(DbHelper.CreateParameter("@CqType", model.CqType));
                param.Add(DbHelper.CreateParameter("@Crossriver", model.Crossriver));
                param.Add(DbHelper.CreateParameter("@Opattribute", model.Opattribute));
                param.Add(DbHelper.CreateParameter("@TunnelLength", model.TunnelLength));
                param.Add(DbHelper.CreateParameter("@TunnelWidth", model.TunnelWidth));
                param.Add(DbHelper.CreateParameter("@TunnelPureWidth", model.TunnelPureWidth));
                param.Add(DbHelper.CreateParameter("@TunnelShape", model.TunnelShape));
                param.Add(DbHelper.CreateParameter("@CqThick", model.CqThick));
                param.Add(DbHelper.CreateParameter("@CqStrength", model.CqStrength));
                param.Add(DbHelper.CreateParameter("@DesignSpeed", model.DesignSpeed));
                param.Add(DbHelper.CreateParameter("@DesignLoading", model.DesignLoading));
                param.Add(DbHelper.CreateParameter("@DesignFlowing", model.DesignFlowing));
                param.Add(DbHelper.CreateParameter("@OwnerUnit", model.OwnerUnit));
                param.Add(DbHelper.CreateParameter("@DesignUnit", model.DesignUnit));
                param.Add(DbHelper.CreateParameter("@ContructUnit", model.ContructUnit));
                param.Add(DbHelper.CreateParameter("@OperationUnit", model.OperationUnit));
                param.Add(DbHelper.CreateParameter("@NewContractStartDate", model.NewContractStartDate));
                param.Add(DbHelper.CreateParameter("@NewContractEndDate", model.NewContractEndDate));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_tunneltrafficinfo
        /// </summary>
        public bool UpdateModelOpTunneltrafficinfo(ModelOpTunneltrafficinfo model, string id)
        {
            string sql = "UPDATE tb_model_op_tunneltrafficinfo SET BuildStartDate=@BuildStartDate,BuildEndDate=@BuildEndDate,CommitDate=@CommitDate,OpstartDate=@OpstartDate,BigMaintainStartDate=@BigMaintainStartDate,BigMaintainEndDate=@BigMaintainEndDate,EntryAmount=@EntryAmount,ExitAmount=@ExitAmount,StructureType=@StructureType,TunnelDirection=@TunnelDirection,CqType=@CqType,Crossriver=@Crossriver,Opattribute=@Opattribute,TunnelLength=@TunnelLength,TunnelWidth=@TunnelWidth,TunnelPureWidth=@TunnelPureWidth,TunnelShape=@TunnelShape,CqThick=@CqThick,CqStrength=@CqStrength,DesignSpeed=@DesignSpeed,DesignLoading=@DesignLoading,DesignFlowing=@DesignFlowing,OwnerUnit=@OwnerUnit,DesignUnit=@DesignUnit,ContructUnit=@ContructUnit,OperationUnit=@OperationUnit,NewContractStartDate=@NewContractStartDate,NewContractEndDate=@NewContractEndDate WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@BuildStartDate", model.BuildStartDate));
                param.Add(DbHelper.CreateParameter("@BuildEndDate", model.BuildEndDate));
                param.Add(DbHelper.CreateParameter("@CommitDate", model.CommitDate));
                param.Add(DbHelper.CreateParameter("@OpstartDate", model.OpstartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainStartDate", model.BigMaintainStartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainEndDate", model.BigMaintainEndDate));
                param.Add(DbHelper.CreateParameter("@EntryAmount", model.EntryAmount));
                param.Add(DbHelper.CreateParameter("@ExitAmount", model.ExitAmount));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@TunnelDirection", model.TunnelDirection));
                param.Add(DbHelper.CreateParameter("@CqType", model.CqType));
                param.Add(DbHelper.CreateParameter("@Crossriver", model.Crossriver));
                param.Add(DbHelper.CreateParameter("@Opattribute", model.Opattribute));
                param.Add(DbHelper.CreateParameter("@TunnelLength", model.TunnelLength));
                param.Add(DbHelper.CreateParameter("@TunnelWidth", model.TunnelWidth));
                param.Add(DbHelper.CreateParameter("@TunnelPureWidth", model.TunnelPureWidth));
                param.Add(DbHelper.CreateParameter("@TunnelShape", model.TunnelShape));
                param.Add(DbHelper.CreateParameter("@CqThick", model.CqThick));
                param.Add(DbHelper.CreateParameter("@CqStrength", model.CqStrength));
                param.Add(DbHelper.CreateParameter("@DesignSpeed", model.DesignSpeed));
                param.Add(DbHelper.CreateParameter("@DesignLoading", model.DesignLoading));
                param.Add(DbHelper.CreateParameter("@DesignFlowing", model.DesignFlowing));
                param.Add(DbHelper.CreateParameter("@OwnerUnit", model.OwnerUnit));
                param.Add(DbHelper.CreateParameter("@DesignUnit", model.DesignUnit));
                param.Add(DbHelper.CreateParameter("@ContructUnit", model.ContructUnit));
                param.Add(DbHelper.CreateParameter("@OperationUnit", model.OperationUnit));
                param.Add(DbHelper.CreateParameter("@NewContractStartDate", model.NewContractStartDate));
                param.Add(DbHelper.CreateParameter("@NewContractEndDate", model.NewContractEndDate));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 隧道基础业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpTunnelbasicinfo(ModelOpTunnelbasicinfo model)
        {
            //string sql = "SELECT id FROM tb_model_tunnel_data_basicinfo WHERE BuildStartDate=@BuildStartDate AND BuildEndDate=@BuildEndDate AND CommitDate=@CommitDate AND CqType=@CqType  AND project_code=@project_code  and (delete_flag is null or delete_flag=0)";
            //List<DbParameter> param = new List<DbParameter>();
            //using (var DbHelper = DBManager.CoreHelper)
            //{
            //    param.Add(DbHelper.CreateParameter("@BuildStartDate", model.BuildStartDate));
            //    param.Add(DbHelper.CreateParameter("@BuildEndDate", model.BuildEndDate));
            //    param.Add(DbHelper.CreateParameter("@CommitDate", model.CommitDate));
            //    param.Add(DbHelper.CreateParameter("@CqType", model.CqType));
            //    param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
            //    return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            //}
            string sql = "SELECT id FROM tb_model_tunnel_data_basicinfo WHERE project_code=@project_code  and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpTunnelbasicinfo(ModelOpTunnelbasicinfo model)
        {
            string sql = "INSERT INTO tb_model_tunnel_data_basicinfo(project_code,BuildStartDate,BuildEndDate,CommitDate,OpstartDate,BigMaintainStartDate,BigMaintainEndDate,EntryAmount,ExitAmount,StructureType,TunnelDirection,CqType,CrosSriver,Opattribute,TunnelLength,TunnelWidth,TunnelPureWidth,TunnelShape,CqThick,CqStrength,DesignSpeed,DesignLoading,DesignShaft,DesignFlowing,OwnerUnit,DesignUnit,ContructUnit,OperationUnit,NewContractStartDate,NewContractEndDate,DataPushDate,DesignBi,DesignDi,DesignPm,DesignCo,DesignVi,DesignMCIScore,TunnelType,DesignEntranceBI,DesignExitBI,DesignBaseBI) VALUES(@project_code,@BuildStartDate,@BuildEndDate,@CommitDate,@OpstartDate,@BigMaintainStartDate,@BigMaintainEndDate,@EntryAmount,@ExitAmount,@StructureType,@TunnelDirection,@CqType,@CrosSriver,@Opattribute,@TunnelLength,@TunnelWidth,@TunnelPureWidth,@TunnelShape,@CqThick,@CqStrength,@DesignSpeed,@DesignLoading,@DesignShaft,@DesignFlowing,@OwnerUnit,@DesignUnit,@ContructUnit,@OperationUnit,@NewContractStartDate,@NewContractEndDate,now(),@DesignBi,@DesignDi,@DesignPm,@DesignCo,@DesignVi,@DesignMCIScore,@TunnelType,@DesignEntranceBI,@DesignExitBI,@DesignBaseBI)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                //param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@BuildStartDate", model.BuildStartDate));
                param.Add(DbHelper.CreateParameter("@BuildEndDate", model.BuildEndDate));
                param.Add(DbHelper.CreateParameter("@CommitDate", model.CommitDate));
                param.Add(DbHelper.CreateParameter("@OpstartDate", model.OpstartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainStartDate", model.BigMaintainStartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainEndDate", model.BigMaintainEndDate));
                param.Add(DbHelper.CreateParameter("@EntryAmount", model.EntryAmount));
                param.Add(DbHelper.CreateParameter("@ExitAmount", model.ExitAmount));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@TunnelDirection", model.TunnelDirection));
                param.Add(DbHelper.CreateParameter("@CqType", model.CqType));
                param.Add(DbHelper.CreateParameter("@CrosSriver", model.CrosSriver));
                param.Add(DbHelper.CreateParameter("@Opattribute", model.Opattribute));
                param.Add(DbHelper.CreateParameter("@TunnelLength", model.TunnelLength));
                param.Add(DbHelper.CreateParameter("@TunnelWidth", model.TunnelWidth));
                param.Add(DbHelper.CreateParameter("@TunnelPureWidth", model.TunnelPureWidth));
                param.Add(DbHelper.CreateParameter("@TunnelShape", model.TunnelShape));
                param.Add(DbHelper.CreateParameter("@CqThick", model.CqThick));
                param.Add(DbHelper.CreateParameter("@CqStrength", model.CqStrength));
                param.Add(DbHelper.CreateParameter("@DesignSpeed", model.DesignSpeed));
                param.Add(DbHelper.CreateParameter("@DesignLoading", model.DesignLoading));
                param.Add(DbHelper.CreateParameter("@DesignShaft", model.DesignShaft));
                param.Add(DbHelper.CreateParameter("@DesignFlowing", model.DesignFlowing));
                param.Add(DbHelper.CreateParameter("@OwnerUnit", model.OwnerUnit));
                param.Add(DbHelper.CreateParameter("@DesignUnit", model.DesignUnit));
                param.Add(DbHelper.CreateParameter("@ContructUnit", model.ContructUnit));
                param.Add(DbHelper.CreateParameter("@OperationUnit", model.OperationUnit));
                param.Add(DbHelper.CreateParameter("@NewContractStartDate", model.NewContractStartDate));
                param.Add(DbHelper.CreateParameter("@NewContractEndDate", model.NewContractEndDate));

                param.Add(DbHelper.CreateParameter("@DesignBi", model.DesignBi));
                param.Add(DbHelper.CreateParameter("@DesignDi", model.DesignDi));
                param.Add(DbHelper.CreateParameter("@DesignPm", model.DesignPm));
                param.Add(DbHelper.CreateParameter("@DesignCo", model.DesignCo));
                param.Add(DbHelper.CreateParameter("@DesignVi", model.DesignVi));
                param.Add(DbHelper.CreateParameter("@DesignMCIScore", model.DesignMCIScore));

                param.Add(DbHelper.CreateParameter("@TunnelType", model.TunnelType));
                param.Add(DbHelper.CreateParameter("@DesignEntranceBI", model.DesignEntranceBI));
                param.Add(DbHelper.CreateParameter("@DesignExitBI", model.DesignExitBI));
                param.Add(DbHelper.CreateParameter("@DesignBaseBI", model.DesignBaseBI));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tunnel_data_basicinfo
        /// </summary>
        public bool UpdateModelOpTunnelbasicinfo(ModelOpTunnelbasicinfo model, string id)
        {
            string sql = "UPDATE tb_model_tunnel_data_basicinfo SET project_code=@project_code,BuildStartDate=@BuildStartDate,BuildEndDate=@BuildEndDate,CommitDate=@CommitDate,OpstartDate=@OpstartDate,BigMaintainStartDate=@BigMaintainStartDate,BigMaintainEndDate=@BigMaintainEndDate,EntryAmount=@EntryAmount,ExitAmount=@ExitAmount,StructureType=@StructureType,TunnelDirection=@TunnelDirection,CqType=@CqType,CrosSriver=@CrosSriver,Opattribute=@Opattribute,TunnelLength=@TunnelLength,TunnelWidth=@TunnelWidth,TunnelPureWidth=@TunnelPureWidth,TunnelShape=@TunnelShape,CqThick=@CqThick,CqStrength=@CqStrength,DesignSpeed=@DesignSpeed,DesignLoading=@DesignLoading,DesignShaft=@DesignShaft,DesignFlowing=@DesignFlowing,OwnerUnit=@OwnerUnit,DesignUnit=@DesignUnit,ContructUnit=@ContructUnit,OperationUnit=@OperationUnit,NewContractStartDate=@NewContractStartDate,NewContractEndDate=@NewContractEndDate,DesignBi=@DesignBi,DesignDi=@DesignDi,DesignPm=@DesignPm,DesignCo=@DesignCo,DesignVi=@DesignVi,DesignMCIScore=@DesignMCIScore,TunnelType=@TunnelType,DesignEntranceBI=@DesignEntranceBI,DesignExitBI=@DesignExitBI,DesignBaseBI=@DesignBaseBI WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {

                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                //param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@BuildStartDate", model.BuildStartDate));
                param.Add(DbHelper.CreateParameter("@BuildEndDate", model.BuildEndDate));
                param.Add(DbHelper.CreateParameter("@CommitDate", model.CommitDate));
                param.Add(DbHelper.CreateParameter("@OpstartDate", model.OpstartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainStartDate", model.BigMaintainStartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainEndDate", model.BigMaintainEndDate));
                param.Add(DbHelper.CreateParameter("@EntryAmount", model.EntryAmount));
                param.Add(DbHelper.CreateParameter("@ExitAmount", model.ExitAmount));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@TunnelDirection", model.TunnelDirection));
                param.Add(DbHelper.CreateParameter("@CqType", model.CqType));
                param.Add(DbHelper.CreateParameter("@CrosSriver", model.CrosSriver));
                param.Add(DbHelper.CreateParameter("@Opattribute", model.Opattribute));
                param.Add(DbHelper.CreateParameter("@TunnelLength", model.TunnelLength));
                param.Add(DbHelper.CreateParameter("@TunnelWidth", model.TunnelWidth));
                param.Add(DbHelper.CreateParameter("@TunnelPureWidth", model.TunnelPureWidth));
                param.Add(DbHelper.CreateParameter("@TunnelShape", model.TunnelShape));
                param.Add(DbHelper.CreateParameter("@CqThick", model.CqThick));
                param.Add(DbHelper.CreateParameter("@CqStrength", model.CqStrength));
                param.Add(DbHelper.CreateParameter("@DesignSpeed", model.DesignSpeed));
                param.Add(DbHelper.CreateParameter("@DesignLoading", model.DesignLoading));
                param.Add(DbHelper.CreateParameter("@DesignShaft", model.DesignShaft));
                param.Add(DbHelper.CreateParameter("@DesignFlowing", model.DesignFlowing));
                param.Add(DbHelper.CreateParameter("@OwnerUnit", model.OwnerUnit));
                param.Add(DbHelper.CreateParameter("@DesignUnit", model.DesignUnit));
                param.Add(DbHelper.CreateParameter("@ContructUnit", model.ContructUnit));
                param.Add(DbHelper.CreateParameter("@OperationUnit", model.OperationUnit));
                param.Add(DbHelper.CreateParameter("@NewContractStartDate", model.NewContractStartDate));
                param.Add(DbHelper.CreateParameter("@NewContractEndDate", model.NewContractEndDate));

                param.Add(DbHelper.CreateParameter("@DesignBi", model.DesignBi));
                param.Add(DbHelper.CreateParameter("@DesignDi", model.DesignDi));
                param.Add(DbHelper.CreateParameter("@DesignPm", model.DesignPm));
                param.Add(DbHelper.CreateParameter("@DesignCo", model.DesignCo));
                param.Add(DbHelper.CreateParameter("@DesignVi", model.DesignVi));
                param.Add(DbHelper.CreateParameter("@DesignMCIScore", model.DesignMCIScore));
                param.Add(DbHelper.CreateParameter("@id", id));

                param.Add(DbHelper.CreateParameter("@TunnelType", model.TunnelType));
                param.Add(DbHelper.CreateParameter("@DesignEntranceBI", model.DesignEntranceBI));
                param.Add(DbHelper.CreateParameter("@DesignExitBI", model.DesignExitBI));
                param.Add(DbHelper.CreateParameter("@DesignBaseBI", model.DesignBaseBI));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 隧道线路基本业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpLineinfo(ModelOpLineinfo model)
        {
            string sql = "SELECT id FROM tb_model_tunnel_data_lineinfo WHERE LineCode=@LineCode AND project_code=@project_code and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpLineinfo(ModelOpLineinfo model)
        {
            string sql = "INSERT INTO tb_model_tunnel_data_lineinfo(LineName,LineCode,LineLength,project_code,task_no,Memo,datapushdate,StructureType,StructureTypeLength) VALUES(@LineName,@LineCode,@LineLength,@project_code,@task_no,@Memo,now(),@StructureType,@StructureTypeLength)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineName", model.LineName));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LineLength", model.LineLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@StructureTypeLength", model.StructureTypeLength));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_lineinfo
        /// </summary>
        public bool UpdateModelOpLineinfo(ModelOpLineinfo model, string id)
        {
            string sql = "UPDATE tb_model_tunnel_data_lineinfo SET LineName=@LineName,LineCode=@LineCode,LineLength=@LineLength,project_code=@project_code,Memo=@Memo,StructureType=@StructureType,StructureTypeLength=@StructureTypeLength WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineName", model.LineName));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LineLength", model.LineLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));

                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@StructureTypeLength", model.StructureTypeLength));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 隧道车道基本业务信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpLaneinfo(ModelOpLaneinfo model)
        {
            //string sql = "SELECT id FROM tb_model_op_laneinfo WHERE LineCode=@LineCode AND LaneCode=@LaneCode AND project_code=@project_code and (delete_flag is null or delete_flag=0)";
            string sql = "SELECT id FROM tb_model_tunnel_data_laneinfo WHERE LineCode=@LineCode AND LaneCode=@LaneCode AND project_code=@project_code and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LaneCode", model.LaneCode));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpLaneinfo(ModelOpLaneinfo model)
        {
            //string sql = "INSERT INTO tb_model_op_laneinfo(LineCode,LaneCode,LaneWidth,LaneLength,project_code,task_no,Memo,DataPushDate) VALUES(@LineCode,@LaneCode,@LaneWidth,@LaneLength,@project_code,@task_no,@Memo,now())";
            string sql = "INSERT INTO tb_model_tunnel_data_laneinfo(LineCode,LaneCode,LaneWidth,LaneLength,project_code,task_no,Memo,DataPushDate) VALUES(@LineCode,@LaneCode,@LaneWidth,@LaneLength,@project_code,@task_no,@Memo,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LaneCode", model.LaneCode));
                param.Add(DbHelper.CreateParameter("@LaneWidth", model.LaneWidth));
                param.Add(DbHelper.CreateParameter("@LaneLength", model.LaneLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_laneinfo
        /// </summary>
        public bool UpdateModelOpLaneinfo(ModelOpLaneinfo model, string id)
        {
            //string sql = "UPDATE tb_model_op_laneinfo SET LineCode=@LineCode,LaneCode=@LaneCode,LaneWidth=@LaneWidth,LaneLength=@LaneLength,project_code=@project_code,Memo=@Memo WHERE id=@id";
            string sql = "UPDATE tb_model_tunnel_data_laneinfo SET LineCode=@LineCode,LaneCode=@LaneCode,LaneWidth=@LaneWidth,LaneLength=@LaneLength,project_code=@project_code,Memo=@Memo WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LaneCode", model.LaneCode));
                param.Add(DbHelper.CreateParameter("@LaneWidth", model.LaneWidth));
                param.Add(DbHelper.CreateParameter("@LaneLength", model.LaneLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));

                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));

                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion


        /// <summary>
        /// 查询运营服务安全服务类指标评价结果
        /// </summary>
        public ModelOpResultSsi GetModelOpResultSsi(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_result_ssi WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpResultSsi>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询运营服务交通服务类指标评价结果
        /// </summary>
        public ModelOpResultTsi GetModelOpResultTsi(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_result_tsi WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpResultTsi>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询运营服务内业管理类指标评价结果
        /// </summary>
        public ModelOpResultMsi GetModelOpResultMsi(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_result_msi WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpResultMsi>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询运营服务总体技术状况评价结果
        /// </summary>
        public ModelOpResultAll GetModelOpResultAll(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_result_all WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpResultAll>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 运营服务分类项目评价结果
        /// </summary>
        public ModelOpResultClassification GetModelOpResultClassification(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_result_classification WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpResultClassification>(sql, CommandType.Text, param.ToArray());
            }
        }


        /// <summary>
        /// 查询运营服务用户服务类指标评价结果
        /// </summary>
        public ModelOpResultCsi GetModelOpResultCsi(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_result_csi WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpResultCsi>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 运营服务子指标评价结果
        /// </summary>
        public ModelOpResultIndexevaluation GetModelOpResultIndexevaluation(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_result_indexevaluation WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpResultIndexevaluation>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 运营服务分类项目评价结果
        /// </summary>
        public ModelOpResultMidevaluation ModelOpResultMidevaluation(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_result_midevaluation WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpResultMidevaluation>(sql, CommandType.Text, param.ToArray());
            }
        }

        #region CO一氧化碳指数业务信息Web
        public IList<ModelOpCodataQuery> GetModelOpCodataList(ModelOpCodataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_codata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_codata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpCodataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpCodata(int id)
        {
            string sql = "UPDATE tb_model_op_codata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpCodata(string task_no)
        {
            string sql = "UPDATE tb_model_op_codata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpCodata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_codata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpCodata(ModelOpCodataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_codata(project_code,task_no,LineCode,Position,Mileage,DeviceNo,MonitorYear,MonitorMonth,MonitorData,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@LineCode,@Position,@Mileage,@DeviceNo,@MonitorYear,@MonitorMonth,@MonitorData,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpCodataList(List<ModelOpCodataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_codata(project_code,task_no,LineCode,Position,Mileage,DeviceNo,MonitorYear,MonitorMonth,MonitorData,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@Position{0},@Mileage{0},@DeviceNo{0},@MonitorYear{0},@MonitorMonth{0},@MonitorData{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@Position" + i, model.Position));
                    param.Add(DbHelper.CreateParameter("@Mileage" + i, model.Mileage));
                    param.Add(DbHelper.CreateParameter("@DeviceNo" + i, model.DeviceNo));
                    param.Add(DbHelper.CreateParameter("@MonitorYear" + i, model.MonitorYear));
                    param.Add(DbHelper.CreateParameter("@MonitorMonth" + i, model.MonitorMonth));
                    param.Add(DbHelper.CreateParameter("@MonitorData" + i, model.MonitorData));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 交牵引排堵TEI业务信息Web
        public IList<ModelOpTeidataQuery> GetModelOpTeidataList(ModelOpTeidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_teidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_teidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpTeidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpTeidata(int id)
        {
            string sql = "UPDATE tb_model_op_teidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpTeidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_teidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpTeidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_teidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpTeidata(ModelOpTeidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_teidata(project_code,task_no,LineCode,MonitorDate,M1amount,M2amount,Totalinday,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@LineCode,@MonitorDate,@M1amount,@M2amount,@Totalinday,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@M1amount", model.M1amount));
                param.Add(DbHelper.CreateParameter("@M2amount", model.M2amount));
                param.Add(DbHelper.CreateParameter("@Totalinday", model.Totalinday));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpTeidataList(List<ModelOpTeidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_teidata(project_code,task_no,LineCode,MonitorDate,M1amount,M2amount,Totalinday,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@MonitorDate{0},@M1amount{0},@M2amount{0},@Totalinday{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@MonitorDate" + i, model.MonitorDate));
                    param.Add(DbHelper.CreateParameter("@M1amount" + i, model.M1amount));
                    param.Add(DbHelper.CreateParameter("@M2amount" + i, model.M2amount));
                    param.Add(DbHelper.CreateParameter("@Totalinday" + i, model.Totalinday));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 交通流量DTI线路业务信息Web
        public IList<ModelOpDtidataQuery> GetModelOpDtidataList(ModelOpDtidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_dtidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_dtidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpDtidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpDtidata(int id)
        {
            string sql = "UPDATE tb_model_op_dtidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpDtidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_dtidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpDtidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_dtidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpDtidata(ModelOpDtidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_dtidata(project_code,task_no,LineCode,MonitorDate,TunneltrafficTotal,TunneltrafficMax,Tunneltraffic57,Tunneltraffic1719,Lane1,Lane1Trafficnum,Lane1Traffic57,Lane1Traffic1719,Lane2,Lane2Trafficnum,Lane2Traffic57,Lane2Traffic1719,Lane3,Lane3Trafficnum,Lane3Traffic57,Lane3Traffic1719,Lane4,Lane4Trafficnum,Lane4Traffic57,Lane4Traffic1719,Lane5,Lane5Trafficnum,Lane5Traffic57,Lane5Traffic1719,Lane6,Lane61Trafficnum,Lane6Traffic57,Lane6Traffic1719,DataPushDate,delete_flag,Year,Month,TrafficPeak4h,TrafficTotal,MiniBus,LargeBus,LargeTruck,Articulated) VALUES(@project_code,@task_no,@LineCode,@MonitorDate,@TunneltrafficTotal,@TunneltrafficMax,@Tunneltraffic57,@Tunneltraffic1719,@Lane1,@Lane1Trafficnum,@Lane1Traffic57,@Lane1Traffic1719,@Lane2,@Lane2Trafficnum,@Lane2Traffic57,@Lane2Traffic1719,@Lane3,@Lane3Trafficnum,@Lane3Traffic57,@Lane3Traffic1719,@Lane4,@Lane4Trafficnum,@Lane4Traffic57,@Lane4Traffic1719,@Lane5,@Lane5Trafficnum,@Lane5Traffic57,@Lane5Traffic1719,@Lane6,@Lane61Trafficnum,@Lane6Traffic57,@Lane6Traffic1719,now(),0,@Year,@Month,@TrafficPeak4h,@TrafficTotal,@MiniBus,@LargeBus,@LargeTruck,@Articulated)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@TunneltrafficTotal", model.TunneltrafficTotal));
                param.Add(DbHelper.CreateParameter("@TunneltrafficMax", model.TunneltrafficMax));
                param.Add(DbHelper.CreateParameter("@Tunneltraffic57", model.Tunneltraffic57));
                param.Add(DbHelper.CreateParameter("@Tunneltraffic1719", model.Tunneltraffic1719));
                param.Add(DbHelper.CreateParameter("@Lane1", model.Lane1));
                param.Add(DbHelper.CreateParameter("@Lane1Trafficnum", model.Lane1Trafficnum));
                param.Add(DbHelper.CreateParameter("@Lane1Traffic57", model.Lane1Traffic57));
                param.Add(DbHelper.CreateParameter("@Lane1Traffic1719", model.Lane1Traffic1719));
                param.Add(DbHelper.CreateParameter("@Lane2", model.Lane2));
                param.Add(DbHelper.CreateParameter("@Lane2Trafficnum", model.Lane2Trafficnum));
                param.Add(DbHelper.CreateParameter("@Lane2Traffic57", model.Lane2Traffic57));
                param.Add(DbHelper.CreateParameter("@Lane2Traffic1719", model.Lane2Traffic1719));
                param.Add(DbHelper.CreateParameter("@Lane3", model.Lane3));
                param.Add(DbHelper.CreateParameter("@Lane3Trafficnum", model.Lane3Trafficnum));
                param.Add(DbHelper.CreateParameter("@Lane3Traffic57", model.Lane3Traffic57));
                param.Add(DbHelper.CreateParameter("@Lane3Traffic1719", model.Lane3Traffic1719));
                param.Add(DbHelper.CreateParameter("@Lane4", model.Lane4));
                param.Add(DbHelper.CreateParameter("@Lane4Trafficnum", model.Lane4Trafficnum));
                param.Add(DbHelper.CreateParameter("@Lane4Traffic57", model.Lane4Traffic57));
                param.Add(DbHelper.CreateParameter("@Lane4Traffic1719", model.Lane4Traffic1719));
                param.Add(DbHelper.CreateParameter("@Lane5", model.Lane5));
                param.Add(DbHelper.CreateParameter("@Lane5Trafficnum", model.Lane5Trafficnum));
                param.Add(DbHelper.CreateParameter("@Lane5Traffic57", model.Lane5Traffic57));
                param.Add(DbHelper.CreateParameter("@Lane5Traffic1719", model.Lane5Traffic1719));
                param.Add(DbHelper.CreateParameter("@Lane6", model.Lane6));
                param.Add(DbHelper.CreateParameter("@Lane61Trafficnum", model.Lane61Trafficnum));
                param.Add(DbHelper.CreateParameter("@Lane6Traffic57", model.Lane6Traffic57));
                param.Add(DbHelper.CreateParameter("@Lane6Traffic1719", model.Lane6Traffic1719));

                param.Add(DbHelper.CreateParameter("@Year", model.Year));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@TrafficPeak4h", model.TrafficPeak4h));
                param.Add(DbHelper.CreateParameter("@TrafficTotal", model.TrafficTotal));
                param.Add(DbHelper.CreateParameter("@MiniBus", model.MiniBus));
                param.Add(DbHelper.CreateParameter("@LargeBus", model.LargeBus));
                param.Add(DbHelper.CreateParameter("@LargeTruck", model.LargeTruck));
                param.Add(DbHelper.CreateParameter("@Articulated", model.Articulated));




                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpDtidataList(List<ModelOpDtidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_dtidata(project_code,task_no,LineCode,MonitorDate,TunneltrafficTotal,TunneltrafficMax,Tunneltraffic57,Tunneltraffic1719,Lane1,Lane1Trafficnum,Lane1Traffic57,Lane1Traffic1719,Lane2,Lane2Trafficnum,Lane2Traffic57,Lane2Traffic1719,Lane3,Lane3Trafficnum,Lane3Traffic57,Lane3Traffic1719,Lane4,Lane4Trafficnum,Lane4Traffic57,Lane4Traffic1719,Lane5,Lane5Trafficnum,Lane5Traffic57,Lane5Traffic1719,Lane6,Lane61Trafficnum,Lane6Traffic57,Lane6Traffic1719,DataPushDate,delete_flag,Year,Month,TrafficPeak4h,TrafficTotal,MiniBus,LargeBus,LargeTruck,Articulated) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@MonitorDate{0},@TunneltrafficTotal{0},@TunneltrafficMax{0},@Tunneltraffic57{0},@Tunneltraffic1719{0},@Lane1{0},@Lane1Trafficnum{0},@Lane1Traffic57{0},@Lane1Traffic1719{0},@Lane2{0},@Lane2Trafficnum{0},@Lane2Traffic57{0},@Lane2Traffic1719{0},@Lane3{0},@Lane3Trafficnum{0},@Lane3Traffic57{0},@Lane3Traffic1719{0},@Lane4{0},@Lane4Trafficnum{0},@Lane4Traffic57{0},@Lane4Traffic1719{0},@Lane5{0},@Lane5Trafficnum{0},@Lane5Traffic57{0},@Lane5Traffic1719{0},@Lane6{0},@Lane61Trafficnum{0},@Lane6Traffic57{0},@Lane6Traffic1719{0},now(),0,@Year{0},@Month{0},@TrafficPeak4h{0},@TrafficTotal{0},@MiniBus{0},@LargeBus{0},@LargeTruck{0},@Articulated{0})", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@MonitorDate" + i, model.MonitorDate));
                    param.Add(DbHelper.CreateParameter("@TunneltrafficTotal" + i, model.TunneltrafficTotal));
                    param.Add(DbHelper.CreateParameter("@TunneltrafficMax" + i, model.TunneltrafficMax));
                    param.Add(DbHelper.CreateParameter("@Tunneltraffic57" + i, model.Tunneltraffic57));
                    param.Add(DbHelper.CreateParameter("@Tunneltraffic1719" + i, model.Tunneltraffic1719));
                    param.Add(DbHelper.CreateParameter("@Lane1" + i, model.Lane1));
                    param.Add(DbHelper.CreateParameter("@Lane1Trafficnum" + i, model.Lane1Trafficnum));
                    param.Add(DbHelper.CreateParameter("@Lane1Traffic57" + i, model.Lane1Traffic57));
                    param.Add(DbHelper.CreateParameter("@Lane1Traffic1719" + i, model.Lane1Traffic1719));
                    param.Add(DbHelper.CreateParameter("@Lane2" + i, model.Lane2));
                    param.Add(DbHelper.CreateParameter("@Lane2Trafficnum" + i, model.Lane2Trafficnum));
                    param.Add(DbHelper.CreateParameter("@Lane2Traffic57" + i, model.Lane2Traffic57));
                    param.Add(DbHelper.CreateParameter("@Lane2Traffic1719" + i, model.Lane2Traffic1719));
                    param.Add(DbHelper.CreateParameter("@Lane3" + i, model.Lane3));
                    param.Add(DbHelper.CreateParameter("@Lane3Trafficnum" + i, model.Lane3Trafficnum));
                    param.Add(DbHelper.CreateParameter("@Lane3Traffic57" + i, model.Lane3Traffic57));
                    param.Add(DbHelper.CreateParameter("@Lane3Traffic1719" + i, model.Lane3Traffic1719));
                    param.Add(DbHelper.CreateParameter("@Lane4" + i, model.Lane4));
                    param.Add(DbHelper.CreateParameter("@Lane4Trafficnum" + i, model.Lane4Trafficnum));
                    param.Add(DbHelper.CreateParameter("@Lane4Traffic57" + i, model.Lane4Traffic57));
                    param.Add(DbHelper.CreateParameter("@Lane4Traffic1719" + i, model.Lane4Traffic1719));
                    param.Add(DbHelper.CreateParameter("@Lane5" + i, model.Lane5));
                    param.Add(DbHelper.CreateParameter("@Lane5Trafficnum" + i, model.Lane5Trafficnum));
                    param.Add(DbHelper.CreateParameter("@Lane5Traffic57" + i, model.Lane5Traffic57));
                    param.Add(DbHelper.CreateParameter("@Lane5Traffic1719" + i, model.Lane5Traffic1719));
                    param.Add(DbHelper.CreateParameter("@Lane6" + i, model.Lane6));
                    param.Add(DbHelper.CreateParameter("@Lane61Trafficnum" + i, model.Lane61Trafficnum));
                    param.Add(DbHelper.CreateParameter("@Lane6Traffic57" + i, model.Lane6Traffic57));
                    param.Add(DbHelper.CreateParameter("@Lane6Traffic1719" + i, model.Lane6Traffic1719));

                    param.Add(DbHelper.CreateParameter("@Year" + i, model.Year));
                    param.Add(DbHelper.CreateParameter("@Month" + i, model.Month));
                    param.Add(DbHelper.CreateParameter("@TrafficPeak4h" + i, model.TrafficPeak4h));
                    param.Add(DbHelper.CreateParameter("@TrafficTotal" + i, model.TrafficTotal));
                    param.Add(DbHelper.CreateParameter("@MiniBus" + i, model.MiniBus));
                    param.Add(DbHelper.CreateParameter("@LargeBus" + i, model.MiniBus));
                    param.Add(DbHelper.CreateParameter("@LargeTruck" + i, model.MiniBus));
                    param.Add(DbHelper.CreateParameter("@Articulated" + i, model.MiniBus));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 交通畅通率DFR业务信息Web
        public IList<ModelOpDfrdataQuery> GetModelOpDfrdataList(ModelOpDfrdataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_dfrdata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_dfrdata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpDfrdataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpDfrdata(int id)
        {
            string sql = "UPDATE tb_model_op_dfrdata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpDfrdata(string task_no)
        {
            string sql = "UPDATE tb_model_op_dfrdata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpDfrdata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_dfrdata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpDfrdata(ModelOpDfrdataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_dfrdata(project_code,task_no,LineCode,MonitorDate,DelayTimes,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@LineCode,@MonitorDate,@DelayTimes,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@DelayTimes", model.DelayTimes));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpDfrdataList(List<ModelOpDfrdataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_dfrdata(project_code,task_no,LineCode,MonitorDate,DelayTimes,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@MonitorDate{0},@DelayTimes{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@MonitorDate" + i, model.MonitorDate));
                    param.Add(DbHelper.CreateParameter("@DelayTimes" + i, model.DelayTimes));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 交通路面荷载LR业务信息Web
        public IList<ModelOpLrdataQuery> GetModelOpLrdataList(ModelOpLrdataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_lrdata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_lrdata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpLrdataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpLrdata(int id)
        {
            string sql = "UPDATE tb_model_op_lrdata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpLrdata(string task_no)
        {
            string sql = "UPDATE tb_model_op_lrdata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpLrdata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_lrdata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpLrdata(ModelOpLrdataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_lrdata(project_code,task_no,LineCode,MonitorDate,TotalCar,SmallCarAmount,BigCarAmount,MediumCarAmount,TruckAmount,BusAmount1,BusAmount2,BusAmount3,BusAmount4,VanAmount1,VanAmount2,VanAmount3,VanAmount4,VanAmount5,TruckAmount1,TruckAmount2,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@LineCode,@MonitorDate,@TotalCar,@SmallCarAmount,@BigCarAmount,@MediumCarAmount,@TruckAmount,@BusAmount1,@BusAmount2,@BusAmount3,@BusAmount4,@VanAmount1,@VanAmount2,@VanAmount3,@VanAmount4,@VanAmount5,@TruckAmount1,@TruckAmount2,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@TotalCar", model.TotalCar));
                param.Add(DbHelper.CreateParameter("@SmallCarAmount", model.SmallCarAmount));
                param.Add(DbHelper.CreateParameter("@BigCarAmount", model.BigCarAmount));
                param.Add(DbHelper.CreateParameter("@MediumCarAmount", model.MediumCarAmount));
                param.Add(DbHelper.CreateParameter("@TruckAmount", model.TruckAmount));
                param.Add(DbHelper.CreateParameter("@BusAmount1", model.BusAmount1));
                param.Add(DbHelper.CreateParameter("@BusAmount2", model.BusAmount2));
                param.Add(DbHelper.CreateParameter("@BusAmount3", model.BusAmount3));
                param.Add(DbHelper.CreateParameter("@BusAmount4", model.BusAmount4));
                param.Add(DbHelper.CreateParameter("@VanAmount1", model.VanAmount1));
                param.Add(DbHelper.CreateParameter("@VanAmount2", model.VanAmount2));
                param.Add(DbHelper.CreateParameter("@VanAmount3", model.VanAmount3));
                param.Add(DbHelper.CreateParameter("@VanAmount4", model.VanAmount4));
                param.Add(DbHelper.CreateParameter("@VanAmount5", model.VanAmount5));
                param.Add(DbHelper.CreateParameter("@TruckAmount1", model.TruckAmount1));
                param.Add(DbHelper.CreateParameter("@TruckAmount2", model.TruckAmount2));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpLrdataList(List<ModelOpLrdataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_lrdata(project_code,task_no,LineCode,MonitorDate,TotalCar,SmallCarAmount,BigCarAmount,MediumCarAmount,TruckAmount,BusAmount1,BusAmount2,BusAmount3,BusAmount4,VanAmount1,VanAmount2,VanAmount3,VanAmount4,VanAmount5,TruckAmount1,TruckAmount2,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@MonitorDate{0},@TotalCar{0},@SmallCarAmount{0},@BigCarAmount{0},@MediumCarAmount{0},@TruckAmount{0},@BusAmount1{0},@BusAmount2{0},@BusAmount3{0},@BusAmount4{0},@VanAmount1{0},@VanAmount2{0},@VanAmount3{0},@VanAmount4{0},@VanAmount5{0},@TruckAmount1{0},@TruckAmount2{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@MonitorDate" + i, model.MonitorDate));
                    param.Add(DbHelper.CreateParameter("@TotalCar" + i, model.TotalCar));
                    param.Add(DbHelper.CreateParameter("@SmallCarAmount" + i, model.SmallCarAmount));
                    param.Add(DbHelper.CreateParameter("@BigCarAmount" + i, model.BigCarAmount));
                    param.Add(DbHelper.CreateParameter("@MediumCarAmount" + i, model.MediumCarAmount));
                    param.Add(DbHelper.CreateParameter("@TruckAmount" + i, model.TruckAmount));
                    param.Add(DbHelper.CreateParameter("@BusAmount1" + i, model.BusAmount1));
                    param.Add(DbHelper.CreateParameter("@BusAmount2" + i, model.BusAmount2));
                    param.Add(DbHelper.CreateParameter("@BusAmount3" + i, model.BusAmount3));
                    param.Add(DbHelper.CreateParameter("@BusAmount4" + i, model.BusAmount4));
                    param.Add(DbHelper.CreateParameter("@VanAmount1" + i, model.VanAmount1));
                    param.Add(DbHelper.CreateParameter("@VanAmount2" + i, model.VanAmount2));
                    param.Add(DbHelper.CreateParameter("@VanAmount3" + i, model.VanAmount3));
                    param.Add(DbHelper.CreateParameter("@VanAmount4" + i, model.VanAmount4));
                    param.Add(DbHelper.CreateParameter("@VanAmount5" + i, model.VanAmount5));
                    param.Add(DbHelper.CreateParameter("@TruckAmount1" + i, model.TruckAmount1));
                    param.Add(DbHelper.CreateParameter("@TruckAmount2" + i, model.TruckAmount2));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 亮度或照度BI业务信息Web
        public IList<ModelOpBidataQuery> GetModelOpBidataList(ModelOpBidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_bidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_bidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpBidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpBidata(int id)
        {
            string sql = "UPDATE tb_model_op_bidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpBidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_bidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpBidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_bidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpBidata(ModelOpBidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_bidata(project_code,task_no,LineCode,Position,Mileage,Deviceno,MonitorYear,MonitorMonth,MonitorData,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@LineCode,@Position,@Mileage,@Deviceno,@MonitorYear,@MonitorMonth,@MonitorData,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@Deviceno", model.Deviceno));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpBidataList(List<ModelOpBidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_bidata(project_code,task_no,LineCode,Position,Mileage,Deviceno,MonitorYear,MonitorMonth,MonitorData,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@Position{0},@Mileage{0},@Deviceno{0},@MonitorYear{0},@MonitorMonth{0},@MonitorData{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@Position" + i, model.Position));
                    param.Add(DbHelper.CreateParameter("@Mileage" + i, model.Mileage));
                    param.Add(DbHelper.CreateParameter("@Deviceno" + i, model.Deviceno));
                    param.Add(DbHelper.CreateParameter("@MonitorYear" + i, model.MonitorYear));
                    param.Add(DbHelper.CreateParameter("@MonitorMonth" + i, model.MonitorMonth));
                    param.Add(DbHelper.CreateParameter("@MonitorData" + i, model.MonitorData));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 内业成本绩效MCI业务信息Web
        public IList<ModelOpMcidataQuery> GetModelOpMcidataList(ModelOpMcidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_mcidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_mcidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpMcidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpMcidata(int id)
        {
            string sql = "UPDATE tb_model_op_mcidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpMcidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_mcidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpMcidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_mcidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpMcidata(ModelOpMcidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_mcidata(project_code,task_no,Month,RealCost,RealPerformance,RealDate,PlanCost,PlanPerformance,PlanDate,DataPushDate,delete_flag,DocYear) VALUES(@project_code,@task_no,@Month,@RealCost,@RealPerformance,@RealDate,@PlanCost,@PlanPerformance,@PlanDate,now(),0,@DocYear)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@RealCost", model.RealCost));
                param.Add(DbHelper.CreateParameter("@RealPerformance", model.RealPerformance));
                param.Add(DbHelper.CreateParameter("@RealDate", model.RealDate));
                param.Add(DbHelper.CreateParameter("@PlanCost", model.PlanCost));
                param.Add(DbHelper.CreateParameter("@PlanPerformance", model.PlanPerformance));
                param.Add(DbHelper.CreateParameter("@PlanDate", model.PlanDate));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpMcidataList(List<ModelOpMcidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_mcidata(project_code,task_no,Month,RealCost,RealPerformance,RealDate,PlanCost,PlanPerformance,PlanDate,DataPushDate,delete_flag,DocYear) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@Month{0},@RealCost{0},@RealPerformance{0},@RealDate{0},@PlanCost{0},@PlanPerformance{0},@PlanDate{0},now(),0,@DocYear{0})", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@Month" + i, model.Month));
                    param.Add(DbHelper.CreateParameter("@RealCost" + i, model.RealCost));
                    param.Add(DbHelper.CreateParameter("@RealPerformance" + i, model.RealPerformance));
                    param.Add(DbHelper.CreateParameter("@RealDate" + i, model.RealDate));
                    param.Add(DbHelper.CreateParameter("@PlanCost" + i, model.PlanCost));
                    param.Add(DbHelper.CreateParameter("@PlanPerformance" + i, model.PlanPerformance));
                    param.Add(DbHelper.CreateParameter("@PlanDate" + i, model.PlanDate));
                    param.Add(DbHelper.CreateParameter("@DocYear" + i, model.DocYear));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 内业报编制MBI业务信息Web
        public IList<ModelOpMbidataQuery> GetModelOpMbidataList(ModelOpMbidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_mbidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_mbidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpMbidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpMbidata(int id)
        {
            string sql = "UPDATE tb_model_op_mbidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpMbidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_mbidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpMbidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_mbidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpMbidata(ModelOpMbidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_mbidata(project_code,task_no,DocCode,DocName_Spec,DocName_Company,DocComplete,DocCommitdate,DataPushDate,delete_flag,DocYear) VALUES(@project_code,@task_no,@DocCode,@DocName_Spec,@DocName_Company,@DocComplete,@DocCommitdate,now(),0,@DocYear)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@DocCode", model.DocCode));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocName_Spec));
                param.Add(DbHelper.CreateParameter("@DocName_Company", model.DocName_Company));
                param.Add(DbHelper.CreateParameter("@DocComplete", model.DocComplete));
                param.Add(DbHelper.CreateParameter("@DocCommitdate", model.DocCommitdate));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpMbidataList(List<ModelOpMbidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_mbidata(project_code,task_no,DocCode,DocName_Spec,DocName_Company,DocComplete,DocCommitdate,DataPushDate,delete_flag,DocYear) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@DocCode{0},@DocName_Spec{0},@DocName_Company{0},@DocComplete{0},@DocCommitdate{0},now(),0,@DocYear{0})", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@DocCode" + i, model.DocCode));
                    param.Add(DbHelper.CreateParameter("@DocName_Spec" + i, model.DocName_Spec));
                    param.Add(DbHelper.CreateParameter("@DocName_Company" + i, model.DocName_Company));
                    param.Add(DbHelper.CreateParameter("@DocComplete" + i, model.DocComplete));
                    param.Add(DbHelper.CreateParameter("@DocCommitdate" + i, model.DocCommitdate));
                    param.Add(DbHelper.CreateParameter("@DocYear" + i, model.DocYear));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 内业档案资料信息化MII业务信息Web
        public IList<ModelOpMiidataQuery> GetModelOpMiidataList(ModelOpMiidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_miidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_miidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpMiidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpMiidata(int id)
        {
            string sql = "UPDATE tb_model_op_miidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpMiidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_miidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpMiidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_miidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpMiidata(ModelOpMiidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_miidata(project_code,task_no,DocCode,DocName_Spec,DocName_Company,DocYear,DocComplete,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@DocCode,@DocName_Spec,@DocName_Company,@DocYear,@DocComplete,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@DocCode", model.DocCode));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocName_Spec));
                param.Add(DbHelper.CreateParameter("@DocName_Company", model.DocName_Company));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                param.Add(DbHelper.CreateParameter("@DocComplete", model.DocComplete));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpMiidataList(List<ModelOpMiidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_miidata(project_code,task_no,DocCode,DocName_Spec,DocName_Company,DocYear,DocComplete,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@DocCode{0},@DocName_Spec{0},@DocName_Company{0},@DocYear{0},@DocComplete{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@DocCode" + i, model.DocCode));
                    param.Add(DbHelper.CreateParameter("@DocName_Spec" + i, model.DocName_Spec));
                    param.Add(DbHelper.CreateParameter("@DocName_Company" + i, model.DocName_Company));
                    param.Add(DbHelper.CreateParameter("@DocYear" + i, model.DocYear));
                    param.Add(DbHelper.CreateParameter("@DocComplete" + i, model.DocComplete));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 内业管理制度MSSI业务信息Web
        public IList<ModelOpMssidataQuery> GetModelOpMssidataList(ModelOpMssidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_mssidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_mssidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpMssidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpMssidata(int id)
        {
            string sql = "UPDATE tb_model_op_mssidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpMssidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_mssidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpMssidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_mssidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpMssidata(ModelOpMssidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_mssidata(project_code,task_no,DocType,DocName_Spec,DocName_Company,DocComplete,DocCommitDate,DataPushDate,delete_flag,DocYear) VALUES(@project_code,@task_no,@DocType,@DocName_Spec,@DocName_Company,@DocComplete,@DocCommitDate,now(),0,@DocYear)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@DocType", model.DocType));
                param.Add(DbHelper.CreateParameter("@DocName_Spec", model.DocName_Spec));
                param.Add(DbHelper.CreateParameter("@DocName_Company", model.DocName_Company));
                param.Add(DbHelper.CreateParameter("@DocComplete", model.DocComplete));
                param.Add(DbHelper.CreateParameter("@DocCommitDate", model.DocCommitDate));
                param.Add(DbHelper.CreateParameter("@DocYear", model.DocYear));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpMssidataList(List<ModelOpMssidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_mssidata(project_code,task_no,DocType,DocName_Spec,DocName_Company,DocComplete,DocCommitDate,DataPushDate,delete_flag,DocYear) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@DocType{0},@DocName_Spec{0},@DocName_Company{0},@DocComplete{0},@DocCommitDate{0},now(),0,@DocYear{0})", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@DocType" + i, model.DocType));
                    param.Add(DbHelper.CreateParameter("@DocName_Spec" + i, model.DocName_Spec));
                    param.Add(DbHelper.CreateParameter("@DocName_Company" + i, model.DocName_Company));
                    param.Add(DbHelper.CreateParameter("@DocComplete" + i, model.DocComplete));
                    param.Add(DbHelper.CreateParameter("@DocCommitDate" + i, model.DocCommitDate));
                    param.Add(DbHelper.CreateParameter("@DocYear" + i, model.DocYear));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion



        #region 可吸入颗粒物浓度PM2.5业务信息Web
        public IList<ModelOpPmdataQuery> GetModelOpPmdataList(ModelOpPmdataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_pmdata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_pmdata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpPmdataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpPmdata(int id)
        {
            string sql = "UPDATE tb_model_op_pmdata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpPmdata(string task_no)
        {
            string sql = "UPDATE tb_model_op_pmdata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpPmdata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_pmdata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpPmdata(ModelOpPmdataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_pmdata(project_code,task_no,LineCode,Position,Mileage,DeviceNo,MonitorYear,MonitorMonth,MonitorData,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@LineCode,@Position,@Mileage,@DeviceNo,@MonitorYear,@MonitorMonth,@MonitorData,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@MonitorData", model.MonitorData));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpPmdataList(List<ModelOpPmdataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_pmdata(project_code,task_no,LineCode,Position,Mileage,DeviceNo,MonitorYear,MonitorMonth,MonitorData,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@Position{0},@Mileage{0},@DeviceNo{0},@MonitorYear{0},@MonitorMonth{0},@MonitorData{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@Position" + i, model.Position));
                    param.Add(DbHelper.CreateParameter("@Mileage" + i, model.Mileage));
                    param.Add(DbHelper.CreateParameter("@DeviceNo" + i, model.DeviceNo));
                    param.Add(DbHelper.CreateParameter("@MonitorYear" + i, model.MonitorYear));
                    param.Add(DbHelper.CreateParameter("@MonitorMonth" + i, model.MonitorMonth));
                    param.Add(DbHelper.CreateParameter("@MonitorData" + i, model.MonitorData));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 噪音DI业务信息Web
        public IList<ModelOpDidataQuery> GetModelOpDidataList(ModelOpDidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_didata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_didata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpDidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpDidata(int id)
        {
            string sql = "UPDATE tb_model_op_didata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpDidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_didata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpDidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_didata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpDidata(ModelOpDidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_didata(project_code,task_no,LineCode,Position,Mileage,DeviceNo,MonitorYear,MonitorMonthDay,MonitorDataDay,MonitorMonthNight,MonitorDataNight,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@LineCode,@Position,@Mileage,@DeviceNo,@MonitorYear,@MonitorMonthDay,@MonitorDataDay,@MonitorMonthNight,@MonitorDataNight,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Position", model.Position));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@DeviceNo", model.DeviceNo));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonthDay", model.MonitorMonthDay));
                param.Add(DbHelper.CreateParameter("@MonitorDataDay", model.MonitorDataDay));
                param.Add(DbHelper.CreateParameter("@MonitorMonthNight", model.MonitorMonthNight));
                param.Add(DbHelper.CreateParameter("@MonitorDataNight", model.MonitorDataNight));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpDidataList(List<ModelOpDidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_didata(project_code,task_no,LineCode,Position,Mileage,DeviceNo,MonitorYear,MonitorMonthDay,MonitorDataDay,MonitorMonthNight,MonitorDataNight,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@Position{0},@Mileage{0},@DeviceNo{0},@MonitorYear{0},@MonitorMonthDay{0},@MonitorDataDay{0},@MonitorMonthNight{0},@MonitorDataNight{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@Position" + i, model.Position));
                    param.Add(DbHelper.CreateParameter("@Mileage" + i, model.Mileage));
                    param.Add(DbHelper.CreateParameter("@DeviceNo" + i, model.DeviceNo));
                    param.Add(DbHelper.CreateParameter("@MonitorYear" + i, model.MonitorYear));
                    param.Add(DbHelper.CreateParameter("@MonitorMonthDay" + i, model.MonitorMonthDay));
                    param.Add(DbHelper.CreateParameter("@MonitorDataDay" + i, model.MonitorDataDay));
                    param.Add(DbHelper.CreateParameter("@MonitorMonthNight" + i, model.MonitorMonthNight));
                    param.Add(DbHelper.CreateParameter("@MonitorDataNight" + i, model.MonitorDataNight));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 安全事故率RV业务信息Web
        public IList<ModelOpRvdataQuery> GetModelOpRvdataList(ModelOpRvdataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_rvdata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_rvdata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpRvdataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpRvdata(int id)
        {
            string sql = "UPDATE tb_model_op_rvdata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpRvdata(string task_no)
        {
            string sql = "UPDATE tb_model_op_rvdata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpRvdata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_rvdata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpRvdata(ModelOpRvdataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_rvdata(project_code,task_no,LineCode,MonitorYear,MonitorMonth,Accident_Num,Broke_Down,Average_Stream,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@LineCode,@MonitorYear,@MonitorMonth,@Accident_Num,@Broke_Down,@Average_Stream,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorYear", model.MonitorYear));
                param.Add(DbHelper.CreateParameter("@MonitorMonth", model.MonitorMonth));
                param.Add(DbHelper.CreateParameter("@Accident_Num", model.Accident_Num));
                param.Add(DbHelper.CreateParameter("@Broke_Down", model.Broke_Down));
                param.Add(DbHelper.CreateParameter("@Average_Stream", model.Average_Stream));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpRvdataList(List<ModelOpRvdataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_rvdata(project_code,task_no,LineCode,MonitorYear,MonitorMonth,Accident_Num,Broke_Down,Average_Stream,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@MonitorYear{0},@MonitorMonth{0},@Accident_Num{0},@Broke_Down{0},@Average_Stream{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@MonitorYear" + i, model.MonitorYear));
                    param.Add(DbHelper.CreateParameter("@MonitorMonth" + i, model.MonitorMonth));
                    param.Add(DbHelper.CreateParameter("@Accident_Num" + i, model.Accident_Num));
                    param.Add(DbHelper.CreateParameter("@Broke_Down" + i, model.Broke_Down));
                    param.Add(DbHelper.CreateParameter("@Average_Stream" + i, model.Average_Stream));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 用户满意度UCVI业务信息Web
        public IList<ModelOpUcvidataQuery> GetModelOpUcvidataList(ModelOpUcvidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_ucvidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_ucvidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpUcvidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpUcvidata(int id)
        {
            string sql = "UPDATE tb_model_op_ucvidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpUcvidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_ucvidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpUcvidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_ucvidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpUcvidata(ModelOpUcvidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_ucvidata(project_code,task_no,DataYear,DataMonth,DelayAmount,HandleAmount,DataPushDate,delete_flag,Nr) VALUES(@project_code,@task_no,@DataYear,@DataMonth,@DelayAmount,@HandleAmount,now(),0,@Nr)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@DataYear", model.DataYear));
                param.Add(DbHelper.CreateParameter("@DataMonth", model.DataMonth));
                param.Add(DbHelper.CreateParameter("@DelayAmount", model.DelayAmount));
                param.Add(DbHelper.CreateParameter("@HandleAmount", model.HandleAmount));
                param.Add(DbHelper.CreateParameter("@Nr", model.Nr));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpUcvidataList(List<ModelOpUcvidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_ucvidata(project_code,task_no,DataYear,DataMonth,DelayAmount,HandleAmount,DataPushDate,delete_flag,Nr) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@DataYear{0},@DataMonth{0},@DelayAmount{0},@HandleAmount{0},now(),0,@Nr{0})", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@DataYear" + i, model.DataYear));
                    param.Add(DbHelper.CreateParameter("@DataMonth" + i, model.DataMonth));
                    param.Add(DbHelper.CreateParameter("@DelayAmount" + i, model.DelayAmount));
                    param.Add(DbHelper.CreateParameter("@HandleAmount" + i, model.HandleAmount));
                    param.Add(DbHelper.CreateParameter("@Nr" + i, model.Nr));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 用户舒适度UCI业务信息Web
        public IList<ModelOpUcidataQuery> GetModelOpUcidataList(ModelOpUcidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_ucidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_ucidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpUcidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpUcidata(int id)
        {
            string sql = "UPDATE tb_model_op_ucidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpUcidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_ucidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpUcidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_ucidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpUcidata(ModelOpUcidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_ucidata(project_code,task_no,InvestDate,InvestContent,CustomerAge,CustomerSex,SatisfactsCore,UnsatisFactreason,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@InvestDate,@InvestContent,@CustomerAge,@CustomerSex,@SatisfactsCore,@UnsatisFactreason,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@InvestDate", model.InvestDate));
                param.Add(DbHelper.CreateParameter("@InvestContent", model.InvestContent));
                param.Add(DbHelper.CreateParameter("@CustomerAge", model.CustomerAge));
                param.Add(DbHelper.CreateParameter("@CustomerSex", model.CustomerSex));
                param.Add(DbHelper.CreateParameter("@SatisfactsCore", model.SatisfactsCore));
                param.Add(DbHelper.CreateParameter("@UnsatisFactreason", model.UnsatisFactreason));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpUcidataList(List<ModelOpUcidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_ucidata(project_code,task_no,InvestDate,InvestContent,CustomerAge,CustomerSex,SatisfactsCore,UnsatisFactreason,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@InvestDate{0},@InvestContent{0},@CustomerAge{0},@CustomerSex{0},@SatisfactsCore{0},@UnsatisFactreason{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@InvestDate" + i, model.InvestDate));
                    param.Add(DbHelper.CreateParameter("@InvestContent" + i, model.InvestContent));
                    param.Add(DbHelper.CreateParameter("@CustomerAge" + i, model.CustomerAge));
                    param.Add(DbHelper.CreateParameter("@CustomerSex" + i, model.CustomerSex));
                    param.Add(DbHelper.CreateParameter("@SatisfactsCore" + i, model.SatisfactsCore));
                    param.Add(DbHelper.CreateParameter("@UnsatisFactreason" + i, model.UnsatisFactreason));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion


        #region 能见度VI业务信息Web
        public IList<ModelOpVidataQuery> GetModelOpVidataList(ModelOpVidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_vidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_vidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpVidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpVidata(int id)
        {
            string sql = "UPDATE tb_model_op_vidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpVidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_vidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpVidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_vidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpVidata(ModelOpVidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_vidata(project_code,task_no,linecode,position,mileage,deviceno,monitoryear,monitormonth,monitordata,datapushdate,delete_flag) VALUES(@project_code,@task_no,@linecode,@position,@mileage,@deviceno,@monitoryear,@monitormonth,@monitordata,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@linecode", model.linecode));
                param.Add(DbHelper.CreateParameter("@position", model.position));
                param.Add(DbHelper.CreateParameter("@mileage", model.mileage));
                param.Add(DbHelper.CreateParameter("@deviceno", model.deviceno));
                param.Add(DbHelper.CreateParameter("@monitoryear", model.monitoryear));
                param.Add(DbHelper.CreateParameter("@monitormonth", model.monitormonth));
                param.Add(DbHelper.CreateParameter("@monitordata", model.monitordata));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpVidataList(List<ModelOpVidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_vidata(project_code,task_no,linecode,position,mileage,deviceno,monitoryear,monitormonth,monitordata,datapushdate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@linecode{0},@position{0},@mileage{0},@deviceno{0},@monitoryear{0},@monitormonth{0},@monitordata{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@linecode" + i, model.linecode));
                    param.Add(DbHelper.CreateParameter("@position" + i, model.position));
                    param.Add(DbHelper.CreateParameter("@mileage" + i, model.mileage));
                    param.Add(DbHelper.CreateParameter("@deviceno" + i, model.deviceno));
                    param.Add(DbHelper.CreateParameter("@monitoryear" + i, model.monitoryear));
                    param.Add(DbHelper.CreateParameter("@monitormonth" + i, model.monitormonth));
                    param.Add(DbHelper.CreateParameter("@monitordata" + i, model.monitordata));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion




        #region 行驶速率DSI业务信息Web
        public IList<ModelOpDsidataQuery> GetModelOpDsidataList(ModelOpDsidataQuery model, out int count)
        {
            string sql = "select* from tb_model_op_dsidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_dsidata where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpDsidataQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpDsidata(int id)
        {
            string sql = "UPDATE tb_model_op_dsidata SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpDsidata(string task_no)
        {
            string sql = "UPDATE tb_model_op_dsidata SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpDsidata(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_dsidata SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpDsidata(ModelOpDsidataQuery model)
        {
            string sql = "INSERT INTO tb_model_op_dsidata(project_code,task_no,LineCode,MonitorDate,MonitorLength,PassTime,DataPushDate,delete_flag) VALUES(@project_code,@task_no,@LineCode,@MonitorDate,@MonitorLength,@PassTime,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@MonitorLength", model.MonitorLength));
                param.Add(DbHelper.CreateParameter("@PassTime", model.PassTime));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpDsidataList(List<ModelOpDsidataQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_dsidata(project_code,task_no,LineCode,MonitorDate,MonitorLength,PassTime,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@LineCode{0},@MonitorDate{0},@MonitorLength{0},@PassTime{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@MonitorDate" + i, model.MonitorDate));
                    param.Add(DbHelper.CreateParameter("@MonitorLength" + i, model.MonitorLength));
                    param.Add(DbHelper.CreateParameter("@PassTime" + i, model.PassTime));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 隧道交通流量业务信息Web
        public IList<ModelOpTunneltrafficinfoQuery> GetModelOpTunneltrafficinfoList(ModelOpTunneltrafficinfoQuery model, out int count)
        {
            string sql = "select* from tb_model_op_tunneltrafficinfo where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_tunneltrafficinfo where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpTunneltrafficinfoQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpTunneltrafficinfo(int id)
        {
            string sql = "UPDATE tb_model_op_tunneltrafficinfo SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpTunneltrafficinfo(string task_no)
        {
            string sql = "UPDATE tb_model_op_tunneltrafficinfo SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpTunneltrafficinfo(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_tunneltrafficinfo SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpTunneltrafficinfo(ModelOpTunneltrafficinfoQuery model)
        {
            string sql = "INSERT INTO tb_model_op_tunneltrafficinfo(BuildStartDate,BuildEndDate,CommitDate,OpstartDate,BigMaintainStartDate,BigMaintainEndDate,EntryAmount,ExitAmount,StructureType,TunnelDirection,CqType,Crossriver,Opattribute,TunnelLength,TunnelWidth,TunnelPureWidth,TunnelShape,CqThick,CqStrength,DesignSpeed,DesignLoading,DesignFlowing,OwnerUnit,DesignUnit,ContructUnit,OperationUnit,NewContractStartDate,NewContractEndDate,DataPushDate,project_code,task_no,delete_flag) VALUES(@BuildStartDate,@BuildEndDate,@CommitDate,@OpstartDate,@BigMaintainStartDate,@BigMaintainEndDate,@EntryAmount,@ExitAmount,@StructureType,@TunnelDirection,@CqType,@Crossriver,@Opattribute,@TunnelLength,@TunnelWidth,@TunnelPureWidth,@TunnelShape,@CqThick,@CqStrength,@DesignSpeed,@DesignLoading,@DesignFlowing,@OwnerUnit,@DesignUnit,@ContructUnit,@OperationUnit,@NewContractStartDate,@NewContractEndDate,now(),@project_code,@task_no,0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@BuildStartDate", model.BuildStartDate));
                param.Add(DbHelper.CreateParameter("@BuildEndDate", model.BuildEndDate));
                param.Add(DbHelper.CreateParameter("@CommitDate", model.CommitDate));
                param.Add(DbHelper.CreateParameter("@OpstartDate", model.OpstartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainStartDate", model.BigMaintainStartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainEndDate", model.BigMaintainEndDate));
                param.Add(DbHelper.CreateParameter("@EntryAmount", model.EntryAmount));
                param.Add(DbHelper.CreateParameter("@ExitAmount", model.ExitAmount));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@TunnelDirection", model.TunnelDirection));
                param.Add(DbHelper.CreateParameter("@CqType", model.CqType));
                param.Add(DbHelper.CreateParameter("@Crossriver", model.Crossriver));
                param.Add(DbHelper.CreateParameter("@Opattribute", model.Opattribute));
                param.Add(DbHelper.CreateParameter("@TunnelLength", model.TunnelLength));
                param.Add(DbHelper.CreateParameter("@TunnelWidth", model.TunnelWidth));
                param.Add(DbHelper.CreateParameter("@TunnelPureWidth", model.TunnelPureWidth));
                param.Add(DbHelper.CreateParameter("@TunnelShape", model.TunnelShape));
                param.Add(DbHelper.CreateParameter("@CqThick", model.CqThick));
                param.Add(DbHelper.CreateParameter("@CqStrength", model.CqStrength));
                param.Add(DbHelper.CreateParameter("@DesignSpeed", model.DesignSpeed));
                param.Add(DbHelper.CreateParameter("@DesignLoading", model.DesignLoading));
                param.Add(DbHelper.CreateParameter("@DesignFlowing", model.DesignFlowing));
                param.Add(DbHelper.CreateParameter("@OwnerUnit", model.OwnerUnit));
                param.Add(DbHelper.CreateParameter("@DesignUnit", model.DesignUnit));
                param.Add(DbHelper.CreateParameter("@ContructUnit", model.ContructUnit));
                param.Add(DbHelper.CreateParameter("@OperationUnit", model.OperationUnit));
                param.Add(DbHelper.CreateParameter("@NewContractStartDate", model.NewContractStartDate));
                param.Add(DbHelper.CreateParameter("@NewContractEndDate", model.NewContractEndDate));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpTunneltrafficinfoList(List<ModelOpTunneltrafficinfoQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_tunneltrafficinfo(BuildStartDate,BuildEndDate,CommitDate,OpstartDate,BigMaintainStartDate,BigMaintainEndDate,EntryAmount,ExitAmount,StructureType,TunnelDirection,CqType,Crossriver,Opattribute,TunnelLength,TunnelWidth,TunnelPureWidth,TunnelShape,CqThick,CqStrength,DesignSpeed,DesignLoading,DesignFlowing,OwnerUnit,DesignUnit,ContructUnit,OperationUnit,NewContractStartDate,NewContractEndDate,DataPushDate,project_code,task_no,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@BuildStartDate{0},@BuildEndDate{0},@CommitDate{0},@OpstartDate{0},@BigMaintainStartDate{0},@BigMaintainEndDate{0},@EntryAmount{0},@ExitAmount{0},@StructureType{0},@TunnelDirection{0},@CqType{0},@Crossriver{0},@Opattribute{0},@TunnelLength{0},@TunnelWidth{0},@TunnelPureWidth{0},@TunnelShape{0},@CqThick{0},@CqStrength{0},@DesignSpeed{0},@DesignLoading{0},@DesignFlowing{0},@OwnerUnit{0},@DesignUnit{0},@ContructUnit{0},@OperationUnit{0},@NewContractStartDate{0},@NewContractEndDate{0},now(),@project_code{0},@task_no{0},0)", i));
                    param.Add(DbHelper.CreateParameter("@BuildStartDate" + i, model.BuildStartDate));
                    param.Add(DbHelper.CreateParameter("@BuildEndDate" + i, model.BuildEndDate));
                    param.Add(DbHelper.CreateParameter("@CommitDate" + i, model.CommitDate));
                    param.Add(DbHelper.CreateParameter("@OpstartDate" + i, model.OpstartDate));
                    param.Add(DbHelper.CreateParameter("@BigMaintainStartDate" + i, model.BigMaintainStartDate));
                    param.Add(DbHelper.CreateParameter("@BigMaintainEndDate" + i, model.BigMaintainEndDate));
                    param.Add(DbHelper.CreateParameter("@EntryAmount" + i, model.EntryAmount));
                    param.Add(DbHelper.CreateParameter("@ExitAmount" + i, model.ExitAmount));
                    param.Add(DbHelper.CreateParameter("@StructureType" + i, model.StructureType));
                    param.Add(DbHelper.CreateParameter("@TunnelDirection" + i, model.TunnelDirection));
                    param.Add(DbHelper.CreateParameter("@CqType" + i, model.CqType));
                    param.Add(DbHelper.CreateParameter("@Crossriver" + i, model.Crossriver));
                    param.Add(DbHelper.CreateParameter("@Opattribute" + i, model.Opattribute));
                    param.Add(DbHelper.CreateParameter("@TunnelLength" + i, model.TunnelLength));
                    param.Add(DbHelper.CreateParameter("@TunnelWidth" + i, model.TunnelWidth));
                    param.Add(DbHelper.CreateParameter("@TunnelPureWidth" + i, model.TunnelPureWidth));
                    param.Add(DbHelper.CreateParameter("@TunnelShape" + i, model.TunnelShape));
                    param.Add(DbHelper.CreateParameter("@CqThick" + i, model.CqThick));
                    param.Add(DbHelper.CreateParameter("@CqStrength" + i, model.CqStrength));
                    param.Add(DbHelper.CreateParameter("@DesignSpeed" + i, model.DesignSpeed));
                    param.Add(DbHelper.CreateParameter("@DesignLoading" + i, model.DesignLoading));
                    param.Add(DbHelper.CreateParameter("@DesignFlowing" + i, model.DesignFlowing));
                    param.Add(DbHelper.CreateParameter("@OwnerUnit" + i, model.OwnerUnit));
                    param.Add(DbHelper.CreateParameter("@DesignUnit" + i, model.DesignUnit));
                    param.Add(DbHelper.CreateParameter("@ContructUnit" + i, model.ContructUnit));
                    param.Add(DbHelper.CreateParameter("@OperationUnit" + i, model.OperationUnit));
                    param.Add(DbHelper.CreateParameter("@NewContractStartDate" + i, model.NewContractStartDate));
                    param.Add(DbHelper.CreateParameter("@NewContractEndDate" + i, model.NewContractEndDate));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 隧道基础业务信息Web
        public IList<ModelOpTunnelbasicinfoQuery> GetModelOpTunnelbasicinfoList(ModelOpTunnelbasicinfoQuery model, out int count)
        {
            string sql = "select* from tb_model_tunnel_data_basicinfo where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_tunnel_data_basicinfo where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpTunnelbasicinfoQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpTunnelbasicinfo(int id)
        {
            string sql = "UPDATE tb_model_tunnel_data_basicinfo SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpTunnelbasicinfo(string task_no)
        {
            string sql = "UPDATE tb_model_tunnel_data_basicinfo SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpTunnelbasicinfo(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_tunnel_data_basicinfo SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpTunnelbasicinfo(ModelOpTunnelbasicinfoQuery model)
        {
            string sql = "INSERT INTO tb_model_tunnel_data_basicinfo(project_code,task_no,BuildStartDate,BuildEndDate,CommitDate,OpstartDate,BigMaintainStartDate,BigMaintainEndDate,EntryAmount,ExitAmount,StructureType,TunnelDirection,CqType,CrosSriver,Opattribute,TunnelLength,TunnelWidth,TunnelPureWidth,TunnelShape,CqThick,CqStrength,DesignSpeed,DesignLoading,DesignShaft,DesignFlowing,OwnerUnit,DesignUnit,ContructUnit,OperationUnit,NewContractStartDate,NewContractEndDate,DataPushDate,DesignBi,DesignDi,DesignPm,DesignCo,DesignVi,DesignMCIScore,delete_flag,TunnelType,DesignEntranceBI,DesignExitBI,DesignBaseBI) VALUES(@project_code,@task_no,@BuildStartDate,@BuildEndDate,@CommitDate,@OpstartDate,@BigMaintainStartDate,@BigMaintainEndDate,@EntryAmount,@ExitAmount,@StructureType,@TunnelDirection,@CqType,@CrosSriver,@Opattribute,@TunnelLength,@TunnelWidth,@TunnelPureWidth,@TunnelShape,@CqThick,@CqStrength,@DesignSpeed,@DesignLoading,@DesignShaft,@DesignFlowing,@OwnerUnit,@DesignUnit,@ContructUnit,@OperationUnit,@NewContractStartDate,@NewContractEndDate,now(),@DesignBi,@DesignDi,@DesignPm,@DesignCo,@DesignVi,@DesignMCIScore,0,@TunnelType,@DesignEntranceBI,@DesignExitBI,@DesignBaseBI)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@BuildStartDate", model.BuildStartDate));
                param.Add(DbHelper.CreateParameter("@BuildEndDate", model.BuildEndDate));
                param.Add(DbHelper.CreateParameter("@CommitDate", model.CommitDate));
                param.Add(DbHelper.CreateParameter("@OpstartDate", model.OpstartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainStartDate", model.BigMaintainStartDate));
                param.Add(DbHelper.CreateParameter("@BigMaintainEndDate", model.BigMaintainEndDate));
                param.Add(DbHelper.CreateParameter("@EntryAmount", model.EntryAmount));
                param.Add(DbHelper.CreateParameter("@ExitAmount", model.ExitAmount));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@TunnelDirection", model.TunnelDirection));
                param.Add(DbHelper.CreateParameter("@CqType", model.CqType));
                param.Add(DbHelper.CreateParameter("@CrosSriver", model.CrosSriver));
                param.Add(DbHelper.CreateParameter("@Opattribute", model.Opattribute));
                param.Add(DbHelper.CreateParameter("@TunnelLength", model.TunnelLength));
                param.Add(DbHelper.CreateParameter("@TunnelWidth", model.TunnelWidth));
                param.Add(DbHelper.CreateParameter("@TunnelPureWidth", model.TunnelPureWidth));
                param.Add(DbHelper.CreateParameter("@TunnelShape", model.TunnelShape));
                param.Add(DbHelper.CreateParameter("@CqThick", model.CqThick));
                param.Add(DbHelper.CreateParameter("@CqStrength", model.CqStrength));
                param.Add(DbHelper.CreateParameter("@DesignSpeed", model.DesignSpeed));
                param.Add(DbHelper.CreateParameter("@DesignLoading", model.DesignLoading));
                param.Add(DbHelper.CreateParameter("@DesignShaft", model.DesignShaft));
                param.Add(DbHelper.CreateParameter("@DesignFlowing", model.DesignFlowing));
                param.Add(DbHelper.CreateParameter("@OwnerUnit", model.OwnerUnit));
                param.Add(DbHelper.CreateParameter("@DesignUnit", model.DesignUnit));
                param.Add(DbHelper.CreateParameter("@ContructUnit", model.ContructUnit));
                param.Add(DbHelper.CreateParameter("@OperationUnit", model.OperationUnit));
                param.Add(DbHelper.CreateParameter("@NewContractStartDate", model.NewContractStartDate));
                param.Add(DbHelper.CreateParameter("@NewContractEndDate", model.NewContractEndDate));
                param.Add(DbHelper.CreateParameter("@DesignBi", model.DesignBi));
                param.Add(DbHelper.CreateParameter("@DesignDi", model.DesignDi));
                param.Add(DbHelper.CreateParameter("@DesignPm", model.DesignPm));
                param.Add(DbHelper.CreateParameter("@DesignCo", model.DesignCo));
                param.Add(DbHelper.CreateParameter("@DesignVi", model.DesignVi));
                param.Add(DbHelper.CreateParameter("@DesignMCIScore", model.DesignMCIScore));

                param.Add(DbHelper.CreateParameter("@TunnelType", model.TunnelType));
                param.Add(DbHelper.CreateParameter("@DesignEntranceBI", model.DesignEntranceBI));
                param.Add(DbHelper.CreateParameter("@DesignExitBI", model.DesignExitBI));
                param.Add(DbHelper.CreateParameter("@DesignBaseBI", model.DesignBaseBI));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpTunnelbasicinfoList(List<ModelOpTunnelbasicinfoQuery> list)
        {
            string sql = "INSERT INTO tb_model_tunnel_data_basicinfo(project_code,task_no,BuildStartDate,BuildEndDate,CommitDate,OpstartDate,BigMaintainStartDate,BigMaintainEndDate,EntryAmount,ExitAmount,StructureType,TunnelDirection,CqType,CrosSriver,Opattribute,TunnelLength,TunnelWidth,TunnelPureWidth,TunnelShape,CqThick,CqStrength,DesignSpeed,DesignLoading,DesignShaft,DesignFlowing,OwnerUnit,DesignUnit,ContructUnit,OperationUnit,NewContractStartDate,NewContractEndDate,DataPushDate,DesignBi,DesignDi,DesignPm,DesignCo,DesignVi,DesignMCIScore,delete_flag,TunnelType,DesignEntranceBI,DesignExitBI,DesignBaseBI) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@project_code{0},@task_no{0},@BuildStartDate{0},@BuildEndDate{0},@CommitDate{0},@OpstartDate{0},@BigMaintainStartDate{0},@BigMaintainEndDate{0},@EntryAmount{0},@ExitAmount{0},@StructureType{0},@TunnelDirection{0},@CqType{0},@CrosSriver{0},@Opattribute{0},@TunnelLength{0},@TunnelWidth{0},@TunnelPureWidth{0},@TunnelShape{0},@CqThick{0},@CqStrength{0},@DesignSpeed{0},@DesignLoading{0},@DesignShaft{0},@DesignFlowing{0},@OwnerUnit{0},@DesignUnit{0},@ContructUnit{0},@OperationUnit{0},@NewContractStartDate{0},@NewContractEndDate{0},now(),@DesignBi{0},@DesignDi{0},@DesignPm{0},@DesignCo{0},@DesignVi{0},@DesignMCIScore{0},0,TunnelType{0},DesignEntranceBI{0},DesignExitBI{0},DesignBaseBI{0})", i));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@BuildStartDate" + i, model.BuildStartDate));
                    param.Add(DbHelper.CreateParameter("@BuildEndDate" + i, model.BuildEndDate));
                    param.Add(DbHelper.CreateParameter("@CommitDate" + i, model.CommitDate));
                    param.Add(DbHelper.CreateParameter("@OpstartDate" + i, model.OpstartDate));
                    param.Add(DbHelper.CreateParameter("@BigMaintainStartDate" + i, model.BigMaintainStartDate));
                    param.Add(DbHelper.CreateParameter("@BigMaintainEndDate" + i, model.BigMaintainEndDate));
                    param.Add(DbHelper.CreateParameter("@EntryAmount" + i, model.EntryAmount));
                    param.Add(DbHelper.CreateParameter("@ExitAmount" + i, model.ExitAmount));
                    param.Add(DbHelper.CreateParameter("@StructureType" + i, model.StructureType));
                    param.Add(DbHelper.CreateParameter("@TunnelDirection" + i, model.TunnelDirection));
                    param.Add(DbHelper.CreateParameter("@CqType" + i, model.CqType));
                    param.Add(DbHelper.CreateParameter("@CrosSriver" + i, model.CrosSriver));
                    param.Add(DbHelper.CreateParameter("@Opattribute" + i, model.Opattribute));
                    param.Add(DbHelper.CreateParameter("@TunnelLength" + i, model.TunnelLength));
                    param.Add(DbHelper.CreateParameter("@TunnelWidth" + i, model.TunnelWidth));
                    param.Add(DbHelper.CreateParameter("@TunnelPureWidth" + i, model.TunnelPureWidth));
                    param.Add(DbHelper.CreateParameter("@TunnelShape" + i, model.TunnelShape));
                    param.Add(DbHelper.CreateParameter("@CqThick" + i, model.CqThick));
                    param.Add(DbHelper.CreateParameter("@CqStrength" + i, model.CqStrength));
                    param.Add(DbHelper.CreateParameter("@DesignSpeed" + i, model.DesignSpeed));
                    param.Add(DbHelper.CreateParameter("@DesignLoading" + i, model.DesignLoading));
                    param.Add(DbHelper.CreateParameter("@DesignShaft" + i, model.DesignShaft));
                    param.Add(DbHelper.CreateParameter("@DesignFlowing" + i, model.DesignFlowing));
                    param.Add(DbHelper.CreateParameter("@OwnerUnit" + i, model.OwnerUnit));
                    param.Add(DbHelper.CreateParameter("@DesignUnit" + i, model.DesignUnit));
                    param.Add(DbHelper.CreateParameter("@ContructUnit" + i, model.ContructUnit));
                    param.Add(DbHelper.CreateParameter("@OperationUnit" + i, model.OperationUnit));
                    param.Add(DbHelper.CreateParameter("@NewContractStartDate" + i, model.NewContractStartDate));
                    param.Add(DbHelper.CreateParameter("@NewContractEndDate" + i, model.NewContractEndDate));
                    param.Add(DbHelper.CreateParameter("@DesignBi" + i, model.DesignBi));
                    param.Add(DbHelper.CreateParameter("@DesignDi" + i, model.DesignDi));
                    param.Add(DbHelper.CreateParameter("@DesignPm" + i, model.DesignPm));
                    param.Add(DbHelper.CreateParameter("@DesignCo" + i, model.DesignCo));
                    param.Add(DbHelper.CreateParameter("@DesignVi" + i, model.DesignVi));
                    param.Add(DbHelper.CreateParameter("@DesignMCIScore" + i, model.DesignMCIScore));

                    param.Add(DbHelper.CreateParameter("@TunnelType" + i, model.TunnelType));
                    param.Add(DbHelper.CreateParameter("@DesignEntranceBI" + i, model.DesignEntranceBI));
                    param.Add(DbHelper.CreateParameter("@DesignExitBI" + i, model.DesignExitBI));
                    param.Add(DbHelper.CreateParameter("@DesignBaseBI" + i, model.DesignBaseBI));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 隧道线路基本业务信息Web
        public IList<ModelOpLineinfoQuery> GetModelOpLineinfoList(ModelOpLineinfoQuery model, out int count)
        {
            string sql = "select* from tb_model_op_lineinfo where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_lineinfo where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpLineinfoQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpLineinfo(int id)
        {
            string sql = "UPDATE tb_model_op_lineinfo SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpLineinfo(string task_no)
        {
            string sql = "UPDATE tb_model_op_lineinfo SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpLineinfo(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_lineinfo SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpLineinfo(ModelOpLineinfoQuery model)
        {
            string sql = "INSERT INTO tb_model_op_lineinfo(LineName,LineCode,LineLength,project_code,ProjectName,task_no,Memo,DataPushDate,delete_flag,StructureType,StructureTypeLength) VALUES(@LineName,@LineCode,@LineLength,@project_code,@ProjectName,@task_no,@Memo,now(),0,@StructureType,@StructureTypeLength)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineName", model.LineName));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LineLength", model.LineLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@ProjectName", model.ProjectName));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));

                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@StructureTypeLength", model.StructureTypeLength));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpLineinfoList(List<ModelOpLineinfoQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_lineinfo(LineName,LineCode,LineLength,project_code,ProjectName,task_no,Memo,DataPushDate,delete_flag,StructureType,StructureTypeLength) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@LineName{0},@LineCode{0},@LineLength{0},@project_code{0},@ProjectName{0},@task_no{0},@Memo{0},now(),0,@StructureType{0},@StructureTypeLength{0})", i));
                    param.Add(DbHelper.CreateParameter("@LineName" + i, model.LineName));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@LineLength" + i, model.LineLength));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@ProjectName" + i, model.ProjectName));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@Memo" + i, model.Memo));
                    param.Add(DbHelper.CreateParameter("@StructureType" + i, model.StructureType));
                    param.Add(DbHelper.CreateParameter("@StructureTypeLength" + i, model.StructureTypeLength));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 隧道车道基本业务信息Web
        public IList<ModelOpLaneinfoQuery> GetModelOpLaneinfoList(ModelOpLaneinfoQuery model, out int count)
        {
            string sql = "select* from tb_model_op_laneinfo where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0 limit @page, @count";
            string count_sql = "select count(1) from tb_model_op_laneinfo where task_no = @task_no AND project_code = @project_code  AND delete_flag = 0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelOpLaneinfoQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelOpLaneinfo(int id)
        {
            string sql = "UPDATE tb_model_op_laneinfo SET delete_flag = 1 WHERE id = @id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelOpLaneinfo(string task_no)
        {
            string sql = "UPDATE tb_model_op_laneinfo SET delete_flag = 1 WHERE task_no = @task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelOpLaneinfo(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_op_laneinfo SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpLaneinfo(ModelOpLaneinfoQuery model)
        {
            string sql = "INSERT INTO tb_model_op_laneinfo(LineCode,LaneCode,LaneWidth,LaneLength,project_code,ProjectName,task_no,Memo,DataPushDate,delete_flag) VALUES(@LineCode,@LaneCode,@LaneWidth,@LaneLength,@project_code,@ProjectName,@task_no,@Memo,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@LaneCode", model.LaneCode));
                param.Add(DbHelper.CreateParameter("@LaneWidth", model.LaneWidth));
                param.Add(DbHelper.CreateParameter("@LaneLength", model.LaneLength));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@ProjectName", model.ProjectName));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelOpLaneinfoList(List<ModelOpLaneinfoQuery> list)
        {
            string sql = "INSERT INTO tb_model_op_laneinfo(LineCode,LaneCode,LaneWidth,LaneLength,project_code,ProjectName,task_no,Memo,DataPushDate,delete_flag) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@LineCode{0},@LaneCode{0},@LaneWidth{0},@LaneLength{0},@project_code{0},@ProjectName{0},@task_no{0},@Memo{0},now(),0)", i));
                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@LaneCode" + i, model.LaneCode));
                    param.Add(DbHelper.CreateParameter("@LaneWidth" + i, model.LaneWidth));
                    param.Add(DbHelper.CreateParameter("@LaneLength" + i, model.LaneLength));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@ProjectName" + i, model.ProjectName));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    param.Add(DbHelper.CreateParameter("@Memo" + i, model.Memo));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 运营服务评价接口

        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpBridgeBasicInfo(ModelOpBridgeBasicInfo model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_bridge_basicinfo(
                                project_code
                                ,build_start_date
                                ,build_end_date
                                ,completion_date
                                ,operation_start_date
                                ,daily_design_traffic_lower_value
                                ,daily_design_traffic_upper_value
                                ,bridge_length
                                ,datapushdate
                                ) VALUES(
                                @project_code
                                ,@build_start_date
                                ,@build_end_date
                                ,@completion_date
                                ,@operation_start_date
                                ,@daily_design_traffic_lower_value
                                ,@daily_design_traffic_upper_value
                                ,@bridge_length
                                ,now()
                                )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@build_start_date", model.build_start_date));
                param.Add(DbHelper.CreateParameter("@build_end_date", model.build_end_date));
                param.Add(DbHelper.CreateParameter("@completion_date", model.completion_date));
                param.Add(DbHelper.CreateParameter("@operation_start_date", model.operation_start_date));
                param.Add(DbHelper.CreateParameter("@daily_design_traffic_lower_value", model.daily_design_traffic_lower_value));
                param.Add(DbHelper.CreateParameter("@daily_design_traffic_upper_value", model.daily_design_traffic_upper_value));
                param.Add(DbHelper.CreateParameter("@bridge_length", model.bridge_length));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpBridgeBasicInfo(ModelOpBridgeBasicInfo model)
        {
            string sql = "SELECT id FROM tb_model_op_bridge_bridge_basicinfo WHERE project_code=@project_code and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }  
        public bool UpdateModelOpBridgeBasicInfo(ModelOpBridgeBasicInfo model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_bridge_basicinfo SET 
                                  build_start_date=@build_start_date
                                , build_end_date=@build_end_date
                                , completion_date=@completion_date
                                , operation_start_date=@operation_start_date
                                , daily_design_traffic_lower_value=@daily_design_traffic_lower_value
                                , daily_design_traffic_upper_value=@daily_design_traffic_upper_value
                                , bridge_length=@bridge_length
                                , datapushdate=now()
                                WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@build_start_date", model.build_start_date));
                param.Add(DbHelper.CreateParameter("@build_end_date", model.build_end_date));
                param.Add(DbHelper.CreateParameter("@completion_date", model.completion_date));
                param.Add(DbHelper.CreateParameter("@operation_start_date", model.operation_start_date));
                param.Add(DbHelper.CreateParameter("@daily_design_traffic_lower_value", model.daily_design_traffic_lower_value));
                param.Add(DbHelper.CreateParameter("@daily_design_traffic_upper_value", model.daily_design_traffic_upper_value));
                param.Add(DbHelper.CreateParameter("@bridge_length", model.bridge_length));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpTrafficDriveSpeed(ModelOpTrafficDriveSpeed model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_traffic_drivespeed(
                                project_code
                                ,task_no
                                ,route_no
                                ,monitor_date
                                ,monitor_hour
                                ,running_speed
                                ,datapushdate
                                ) VALUES(
                                @project_code
                                ,@task_no
                                ,@route_no
                                ,@monitor_date
                                ,@monitor_hour
                                ,@running_speed
                                ,now()
                                )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@route_no", model.route_no));
                param.Add(DbHelper.CreateParameter("@monitor_date", model.monitor_date));
                param.Add(DbHelper.CreateParameter("@monitor_hour", model.monitor_hour));
                param.Add(DbHelper.CreateParameter("@running_speed", model.running_speed));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpTrafficDriveSpeed(ModelOpTrafficDriveSpeed model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_traffic_drivespeed WHERE 
                            project_code=@project_code 
                            and task_no=@task_no 
                            and route_no=@route_no 
                            and monitor_date=@monitor_date 
                            and monitor_hour=@monitor_hour 
                            and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@route_no", model.route_no));
                param.Add(DbHelper.CreateParameter("@monitor_date", model.monitor_date));
                param.Add(DbHelper.CreateParameter("@monitor_hour", model.monitor_hour));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpTrafficDriveSpeed(ModelOpTrafficDriveSpeed model, string id)
        {
            string sql = "UPDATE tb_model_op_bridge_traffic_drivespeed SET `running_speed`=@running_speed,`datapushdate`=now() WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@running_speed", model.running_speed));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpTrafficFlow(ModelOpTrafficFlow model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_traffic_flow(
                                project_code
                                ,task_no
                                ,route_no
                                ,monitor_date
                                ,monitor_hour
                                ,traffic_flow
                                ,datapushdate
                                ) VALUES(
                                @project_code
                                ,@task_no
                                ,@route_no
                                ,@monitor_date
                                ,@monitor_hour
                                ,@traffic_flow
                                ,now()
                                )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@route_no", model.route_no));
                param.Add(DbHelper.CreateParameter("@monitor_date", model.monitor_date));
                param.Add(DbHelper.CreateParameter("@monitor_hour", model.monitor_hour));
                param.Add(DbHelper.CreateParameter("@traffic_flow", model.traffic_flow));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpTrafficFlow(ModelOpTrafficFlow model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_traffic_flow WHERE 
project_code=@project_code 
and task_no=@task_no 
and route_no=@route_no 
and monitor_date=@monitor_date 
and monitor_hour=@monitor_hour 
and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@route_no", model.route_no));
                param.Add(DbHelper.CreateParameter("@monitor_date", model.monitor_date));
                param.Add(DbHelper.CreateParameter("@monitor_hour", model.monitor_hour));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpTrafficFlow(ModelOpTrafficFlow model, string id)
        {
            string sql = "UPDATE tb_model_op_bridge_traffic_flow SET `traffic_flow`=@traffic_flow,`datapushdate`=now() WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@traffic_flow",model.traffic_flow));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpTrafficFenceInfluence(ModelOpTrafficFenceInfluence model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_traffic_fence_influence(
                                project_code
                                ,task_no
                                ,route_no
                                ,monitor_date
                                ,fence_work_start_time
                                ,fence_work_end_time
                                ,traffick1_value
                                ,traffick2_value
                                ,traffick3_value
                                ,traffick4_value
                                ,traffick5_value
                                ,traffick6_value
                                ,traffick7_value
                                ,datapushdate
                                ) VALUES(
                                @project_code
                                ,@task_no
                                ,@route_no
                                ,@monitor_date
                                ,@fence_work_start_time
                                ,@fence_work_end_time
                                ,@traffick1_value
                                ,@traffick2_value
                                ,@traffick3_value
                                ,@traffick4_value
                                ,@traffick5_value
                                ,@traffick6_value
                                ,@traffick7_value
                                ,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@route_no", model.route_no));
                param.Add(DbHelper.CreateParameter("@monitor_date", model.monitor_date));
                param.Add(DbHelper.CreateParameter("@fence_work_start_time", model.fence_work_start_time));
                param.Add(DbHelper.CreateParameter("@fence_work_end_time", model.fence_work_end_time));
                param.Add(DbHelper.CreateParameter("@traffick1_value", model.traffick1_value));
                param.Add(DbHelper.CreateParameter("@traffick2_value", model.traffick2_value));
                param.Add(DbHelper.CreateParameter("@traffick3_value", model.traffick3_value));
                param.Add(DbHelper.CreateParameter("@traffick4_value", model.traffick4_value));
                param.Add(DbHelper.CreateParameter("@traffick5_value", model.traffick5_value));
                param.Add(DbHelper.CreateParameter("@traffick6_value", model.traffick6_value));
                param.Add(DbHelper.CreateParameter("@traffick7_value", model.traffick7_value));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpTrafficFenceInfluence(ModelOpTrafficFenceInfluence model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_traffic_fence_influence WHERE 
                                project_code=@project_code 
                                and task_no=@task_no 
                                and route_no=@route_no 
                                and monitor_date=@monitor_date 
                                and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@route_no", model.route_no));
                param.Add(DbHelper.CreateParameter("@monitor_date", model.monitor_date));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpTrafficFenceInfluence(ModelOpTrafficFenceInfluence model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_traffic_fence_influence SET 
                                fence_work_start_time=@fence_work_start_time
                                ,fence_work_end_time=@fence_work_end_time
                                ,traffick1_value=@traffick1_value
                                ,traffick2_value=@traffick2_value
                                ,traffick3_value=@traffick3_value
                                ,traffick4_value=@traffick4_value
                                ,traffick5_value=@traffick5_value
                                ,traffick6_value=@traffick6_value
                                ,traffick7_value=@traffick7_value
                                ,datapushdate=now() WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@fence_work_start_time", model.fence_work_start_time));
                param.Add(DbHelper.CreateParameter("@fence_work_end_time", model.fence_work_end_time));
                param.Add(DbHelper.CreateParameter("@traffick1_value", model.traffick1_value));
                param.Add(DbHelper.CreateParameter("@traffick2_value", model.traffick2_value));
                param.Add(DbHelper.CreateParameter("@traffick3_value", model.traffick3_value));
                param.Add(DbHelper.CreateParameter("@traffick4_value", model.traffick4_value));
                param.Add(DbHelper.CreateParameter("@traffick5_value", model.traffick5_value));
                param.Add(DbHelper.CreateParameter("@traffick6_value", model.traffick6_value));
                param.Add(DbHelper.CreateParameter("@traffick7_value", model.traffick7_value));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpTrafficAccident(ModelOpTrafficAccident model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_traffic_accident(
                                project_code
                                ,task_no
                                ,monitor_year
                                ,monitor_month
                                ,major_traffic_accident
                                ,normal_traffic_accident
                                ,datapushdate
                                ) VALUES(
                                @project_code
                                ,@task_no
                                ,@monitor_year
                                ,@monitor_month
                                ,@major_traffic_accident
                                ,@normal_traffic_accident
                                ,now()
                                )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                param.Add(DbHelper.CreateParameter("@major_traffic_accident", model.major_traffic_accident));
                param.Add(DbHelper.CreateParameter("@normal_traffic_accident", model.normal_traffic_accident));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpTrafficAccident(ModelOpTrafficAccident model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_traffic_accident WHERE 
                                project_code=@project_code 
                                and task_no=@task_no 
                                and monitor_year=@monitor_year 
                                and monitor_month=@monitor_month 
                                and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpTrafficAccident(ModelOpTrafficAccident model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_traffic_accident SET 
                                major_traffic_accident=@major_traffic_accident
                                ,normal_traffic_accident=@normal_traffic_accident
                                ,datapushdate=now() WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@major_traffic_accident", model.major_traffic_accident));
                param.Add(DbHelper.CreateParameter("@normal_traffic_accident", model.normal_traffic_accident));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpDeviceMaterialComplete(ModelOpDeviceMaterialComplete model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_device_material_complete(
                                    project_code
                                    ,task_no
                                    ,monitor_date
                                    ,actual_material
                                    ,agreed_material
                                ,datapushdate
                                    ) VALUES(
                                    @project_code
                                    ,@task_no
                                    ,@monitor_date
                                    ,@actual_material
                                    ,@agreed_material
                                ,now()
                                    )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_date", model.monitor_date));
                param.Add(DbHelper.CreateParameter("@actual_material", model.actual_material));
                param.Add(DbHelper.CreateParameter("@agreed_material", model.agreed_material));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpDeviceMaterialComplete(ModelOpDeviceMaterialComplete model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_device_material_complete WHERE 
                                project_code=@project_code 
                                and monitor_date=@monitor_date 
                                and task_no=@task_no 
                                and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_date", model.monitor_date));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpDeviceMaterialComplete(ModelOpDeviceMaterialComplete model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_device_material_complete SET  
                                actual_material=@actual_material
                                ,agreed_material=@agreed_material
                                ,datapushdate=now() WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@actual_material", model.actual_material));
                param.Add(DbHelper.CreateParameter("@agreed_material", model.agreed_material));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpEmergencyResponse(ModelOpEmergencyResponse model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_emergency_response(
                            project_code
                            ,task_no
                            ,route_no
                            ,monitor_year
                            ,monitor_month
                            ,rescue_start_time
                            ,rescue_end_time
                                ,datapushdate
                            ) VALUES(
                            @project_code
                            ,@task_no
                            ,@route_no
                            ,@monitor_year
                            ,@monitor_month
                            ,@rescue_start_time
                            ,@rescue_end_time
                                ,now()
                            )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@route_no", model.route_no));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                param.Add(DbHelper.CreateParameter("@rescue_start_time", model.rescue_start_time));
                param.Add(DbHelper.CreateParameter("@rescue_end_time", model.rescue_end_time));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpEmergencyResponse(ModelOpEmergencyResponse model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_emergency_response WHERE 
                            project_code=@project_code 
                            and task_no=@task_no
                            and route_no=@route_no
                            and monitor_year=@monitor_year
                            and monitor_month=@monitor_month
                            and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@route_no", model.route_no));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpEmergencyResponse(ModelOpEmergencyResponse model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_emergency_response SET 
                            `rescue_start_time`=@rescue_start_time,
                            `rescue_end_time`=@rescue_end_time, 
                            datapushdate=now()
                            WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@rescue_start_time", model.rescue_start_time));
                param.Add(DbHelper.CreateParameter("@rescue_end_time", model.rescue_end_time));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpComplaintResponse(ModelOpComplaintResponse model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_complaint_response(
                                    project_code
                                    ,task_no
                                    ,monitor_year
                                    ,monitor_month
                                    ,complaint_acceptance_time
                                    ,complaint_finish_time
                                ,datapushdate
                                    ) VALUES(
                                    @project_code
                                    ,@task_no
                                    ,@monitor_year
                                    ,@monitor_month
                                    ,@complaint_acceptance_time
                                    ,@complaint_finish_time
                                ,now()
                                    )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                param.Add(DbHelper.CreateParameter("@complaint_acceptance_time", model.complaint_acceptance_time));
                param.Add(DbHelper.CreateParameter("@complaint_finish_time", model.complaint_finish_time));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpComplaintResponse(ModelOpComplaintResponse model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_complaint_response WHERE 
                                project_code=@project_code 
                                and monitor_year=@monitor_year 
                                and monitor_month=@monitor_month 
                                and task_no=@task_no 
                                and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpComplaintResponse(ModelOpComplaintResponse model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_complaint_response SET 
`complaint_acceptance_time`=@complaint_acceptance_time,
`complaint_finish_time`=@complaint_finish_time,
datapushdate=now()
WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@complaint_acceptance_time", model.complaint_acceptance_time));
                param.Add(DbHelper.CreateParameter("@complaint_finish_time", model.complaint_finish_time));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpValidComplaint(ModelOpValidComplaint model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_valid_complaint(
                                project_code
                                ,task_no
                                ,monitor_year
                                ,monitor_month
                                ,real_complaint_number
                                ,datapushdate
                                ) VALUES(
                                @project_code
                                ,@task_no
                                ,@monitor_year
                                ,@monitor_month
                                ,@real_complaint_number
                                ,now()
                                )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                param.Add(DbHelper.CreateParameter("@real_complaint_number", model.real_complaint_number));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpValidComplaint(ModelOpValidComplaint model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_valid_complaint WHERE 
                                project_code=@project_code 
                                and task_no=@task_no
                                and monitor_year=@monitor_year
                                and monitor_month=@monitor_month
                                and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpValidComplaint(ModelOpValidComplaint model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_valid_complaint SET 
`real_complaint_number`=@real_complaint_number,
`datapushdate`=now()
WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@real_complaint_number", model.real_complaint_number));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpReleaseInfoAccuracy(ModelOpReleaseInfoAccuracy model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_release_info_accuracy(
                                project_code
                                ,task_no
                                ,monitor_year
                                ,monitor_month
                                ,accurate_traffic_information_number
                                ,traffic_information_total_number
                                ,datapushdate
                                ) VALUES(
                                @project_code
                                ,@task_no
                                ,@monitor_year
                                ,@monitor_month
                                ,@accurate_traffic_information_number
                                ,@traffic_information_total_number
                                ,now()
                                )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                param.Add(DbHelper.CreateParameter("@accurate_traffic_information_number", model.accurate_traffic_information_number));
                param.Add(DbHelper.CreateParameter("@traffic_information_total_number", model.traffic_information_total_number));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpReleaseInfoAccuracy(ModelOpReleaseInfoAccuracy model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_release_info_accuracy WHERE 
                                project_code=@project_code 
                                and task_no=@task_no
                                and monitor_year=@monitor_year
                                and monitor_month=@monitor_month
                                and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpReleaseInfoAccuracy(ModelOpReleaseInfoAccuracy model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_release_info_accuracy SET 
`accurate_traffic_information_number`=@accurate_traffic_information_number,
`traffic_information_total_number`=@traffic_information_total_number,
`datapushdate`=now()
WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@accurate_traffic_information_number", model.accurate_traffic_information_number));
                param.Add(DbHelper.CreateParameter("@traffic_information_total_number", model.traffic_information_total_number));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpReleaseInfoTimeliness(ModelOpReleaseInfoTimeliness model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_release_info_timeliness(
                                project_code
                                ,task_no
                                ,monitor_year
                                ,monitor_month
                                ,msg_timely_num
                                ,msg_total_num
                                ,datapushdate
                                ) VALUES(
                                @project_code
                                ,@task_no
                                ,@monitor_year
                                ,@monitor_month
                                ,@msg_timely_num
                                ,@msg_total_num
                                ,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                param.Add(DbHelper.CreateParameter("@msg_timely_num", model.msg_timely_num));
                param.Add(DbHelper.CreateParameter("@msg_total_num", model.msg_total_num));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpReleaseInfoTimeliness(ModelOpReleaseInfoTimeliness model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_release_info_timeliness WHERE 
                                project_code=@project_code 
                                and task_no=@task_no 
                                and monitor_year=@monitor_year 
                                and monitor_month=@monitor_month 
                                and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpReleaseInfoTimeliness(ModelOpReleaseInfoTimeliness model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_release_info_timeliness SET 
                            `msg_timely_num`=@msg_timely_num,
                            `msg_total_num`=@msg_total_num,
                            `datapushdate`=now()
                            WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@msg_timely_num", model.msg_timely_num));
                param.Add(DbHelper.CreateParameter("@msg_total_num", model.msg_total_num));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// <summary>
        ///
        /// </summary>
        public bool AddModelOpValidComplaintHandle(ModelOpValidComplaintHandle model)
        {
            string sql = @"INSERT INTO tb_model_op_bridge_valid_complaint_handle(
                            project_code
                            ,task_no
                            ,monitor_year
                            ,monitor_month
                            ,effective_complaint_success_number
                            ,effective_complaint_number
                                ,datapushdate
                            ) VALUES(
                            @project_code
                            ,@task_no
                            ,@monitor_year
                            ,@monitor_month
                            ,@effective_complaint_success_number
                            ,@effective_complaint_number
                            ,now()
                            )";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                param.Add(DbHelper.CreateParameter("@effective_complaint_success_number", model.effective_complaint_success_number));
                param.Add(DbHelper.CreateParameter("@effective_complaint_number", model.effective_complaint_number));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        public string CheckModelOpValidComplaintHandle(ModelOpValidComplaintHandle model)
        {
            string sql = @"SELECT id FROM tb_model_op_bridge_valid_complaint_handle WHERE 
                                project_code=@project_code
                                and task_no=@task_no
                                and monitor_year=@monitor_year
                                and monitor_month=@monitor_month
                                and delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.taskNo));
                param.Add(DbHelper.CreateParameter("@monitor_year", model.monitor_year));
                param.Add(DbHelper.CreateParameter("@monitor_month", model.monitor_month));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public bool UpdateModelOpValidComplaintHandle(ModelOpValidComplaintHandle model, string id)
        {
            string sql = @"UPDATE tb_model_op_bridge_valid_complaint_handle SET 
                            `effective_complaint_success_number`=@effective_complaint_success_number,
                            `effective_complaint_number`=@effective_complaint_number,
                            datapushdate=now()
                            WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@effective_complaint_success_number", model.effective_complaint_success_number));
                param.Add(DbHelper.CreateParameter("@effective_complaint_number", model.effective_complaint_number));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        /// summary>
        /// 8.15查询结果
        /// </summary>
        /// <param name="task_no"></param>
        /// <returns></returns>
        public ModelOpBridgeResultTsi GetModelOpBridgeResultTSI(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_bridge_result_tsi WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpBridgeResultTsi>(sql, CommandType.Text, param.ToArray());
            }
        }
        public ModelOpBridgeResultSsi GetModelOpBridgeResultSSI(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_bridge_result_ssi WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpBridgeResultSsi>(sql, CommandType.Text, param.ToArray());
            }
        }
        public ModelOpBridgeResultEsi GetModelOpBridgeResultESI(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_bridge_result_esi WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpBridgeResultEsi>(sql, CommandType.Text, param.ToArray());
            }
        }
        public ModelOpBridgeResultUsi GetModelOpBridgeResultUSI(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_bridge_result_usi WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpBridgeResultUsi>(sql, CommandType.Text, param.ToArray());
            }
        }
        public ModelOpBridgeResultMidEvaluation GetModelOpBridgeResultMID(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_bridge_result_mid_evaluation WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpBridgeResultMidEvaluation>(sql, CommandType.Text, param.ToArray());
            }
        }
        public ModelOpBridgeResultAllEvaluation GetModelOpBridgeResultAllEVA(string task_no)
        {
            string sql = "SELECT * FROM tb_model_op_bridge_result_all_evaluation WHERE task_no=@task_no limit 0,1";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderObject<ModelOpBridgeResultAllEvaluation>(sql, CommandType.Text, param.ToArray());
            }
        }

        #endregion

        #region 新增v2接口
        #region 运营服务评价指标权重信息表

        public List<T> GetModel<T>(string find1, string find2, string tablename)
        {
            string sql = "SELECT * FROM " + tablename + " WHERE 1=1 ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                if (tablename == "tb_model_op_weight" || tablename == "tb_model_table_op_criteria")
                {
                    sql += " and IndexName=@IndexName and ParentIndex=@ParentIndex";
                    param.Add(DbHelper.CreateParameter("@IndexName", find1));
                    param.Add(DbHelper.CreateParameter("@ParentIndex", find2));
                }
                else if (tablename == "tb_model_op_data_clean" || tablename == "tb_model_op_data_effluent" || tablename == "tb_model_op_data_eri")
                {
                    sql += " and task_no=@task_no ";
                    param.Add(DbHelper.CreateParameter("@task_no", find1));
                }
                //return DbHelper.ExecuteReaderObject<List<T>>(sql, CommandType.Text, param.ToArray());
                return DataTableToDataList<T>(DbHelper.ExecuteDataTable(sql, param.ToArray()));
            }
        }

        public List<T> DataTableToDataList<T>(DataTable dt)
        {
            var list = new List<T>();
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            foreach (DataRow item in dt.Rows)
            {
                T s = Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info != null)
                    {
                        try
                        {
                            if (!Convert.IsDBNull(item[i]))
                            {
                                object v = null;
                                if (info.PropertyType.ToString().Contains("System.Nullable"))
                                {
                                    v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(info.PropertyType));
                                }
                                else
                                {
                                    v = Convert.ChangeType(item[i], info.PropertyType);
                                }
                                info.SetValue(s, v, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelWeightinfo(ModelOpevaWeightInfo model)
        {
            string sql = "SELECT ID FROM tb_model_op_weight WHERE IndexName=@IndexName AND ParentIndex=@ParentIndex";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@IndexName", model.IndexName));
                param.Add(DbHelper.CreateParameter("@ParentIndex", model.ParentIndex));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_op_weight
        /// </summary>
        public bool AddModelWeightinfo(ModelOpevaWeightInfo model)
        {
            string sql = "INSERT INTO tb_model_op_weight(IndexName,ParentIndex,Weight) VALUES(@IndexName,@ParentIndex,@Weight)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@IndexName", model.IndexName));
                param.Add(DbHelper.CreateParameter("@ParentIndex", model.ParentIndex));
                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_weight
        /// </summary>
        public bool UpdateModelWeightinfo(ModelOpevaWeightInfo model)
        {
            string sql = "UPDATE tb_model_op_weight SET IndexName=@IndexName,ParentIndex=@ParentIndex,Weight=@Weight WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@IndexName", model.IndexName));
                param.Add(DbHelper.CreateParameter("@ParentIndex", model.ParentIndex));
                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 评价等级与分值对应关系表
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckCriteriaInfo(ModelOpCriteria model)
        {
            string sql = "SELECT ID FROM tb_model_table_op_criteria WHERE IndexName=@IndexName AND ParentIndex=@ParentIndex";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@IndexName", model.IndexName));
                param.Add(DbHelper.CreateParameter("@ParentIndex", model.ParentIndex));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_table_op_criteria
        /// </summary>
        public bool AddModelOpCriteria(ModelOpCriteria model)
        {
            string sql = "INSERT INTO tb_model_table_op_criteria(IndexName,ParentIndex,rate,description,rate_mark,lower_value,up_value) VALUES(@IndexName,@ParentIndex,@rate,@description,@rate_mark,@lower_value,@up_value)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@IndexName", model.IndexName));
                param.Add(DbHelper.CreateParameter("@ParentIndex", model.ParentIndex));
                param.Add(DbHelper.CreateParameter("@rate", model.Rate));
                param.Add(DbHelper.CreateParameter("@description", model.Description));
                param.Add(DbHelper.CreateParameter("@rate_mark", model.RateMark));
                param.Add(DbHelper.CreateParameter("@lower_value", model.LowerValue));
                param.Add(DbHelper.CreateParameter("@up_value", model.UpValue));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_table_op_criteria
        /// </summary>
        public bool UpdateModelOpCriteria(ModelOpCriteria model)
        {
            string sql = @"UPDATE tb_model_table_op_criteria SET IndexName=@IndexName,ParentIndex=@ParentIndex, 
                            rate = @rate,description=@description,rate_mark=@rate_mark,lower_value=@lower_value,up_value=@up_value 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@IndexName", model.IndexName));
                param.Add(DbHelper.CreateParameter("@ParentIndex", model.ParentIndex));
                param.Add(DbHelper.CreateParameter("@rate", model.Rate));
                param.Add(DbHelper.CreateParameter("@description", model.Description));
                param.Add(DbHelper.CreateParameter("@rate_mark", model.RateMark));
                param.Add(DbHelper.CreateParameter("@lower_value", model.LowerValue));
                param.Add(DbHelper.CreateParameter("@up_value", model.UpValue));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的保洁效果信息表
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDataClean(ModelOpDataClean model)
        {
            string sql = "SELECT ID FROM tb_model_op_data_clean WHERE task_no=@task_no AND project_code=@project_code";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_op_data_clean
        /// </summary>
        public bool AddModelOpDataClean(ModelOpDataClean model)
        {
            string sql = "INSERT INTO tb_model_op_data_clean(CheckIndex,CheckDate,unqualified,project_code,task_no) VALUES(@CheckIndex,@CheckDate,@unqualified,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@CheckIndex", model.CheckIndex));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@unqualified", model.Unqualified));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_data_clean
        /// </summary>
        public bool UpdateModelOpDataClean(ModelOpDataClean model)
        {
            string sql = @"UPDATE tb_model_op_data_clean SET CheckIndex=@CheckIndex,CheckDate=@CheckDate ,
                            unqualified = @unqualified,project_code=@project_code,task_no=@task_no 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@CheckIndex", model.CheckIndex));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@unqualified", model.Unqualified));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的废水排放合格率信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDataEffluent(ModelOpDataEffluent model)
        {
            string sql = "SELECT ID FROM tb_model_op_data_effluent WHERE task_no=@task_no AND project_code=@project_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_op_data_effluent
        /// </summary>
        public bool AddModelOpDataEffluent(ModelOpDataEffluent model)
        {
            string sql = "INSERT INTO tb_model_op_data_effluent(CheckDaTe,totalamount,phNum,suspendNum,project_code,task_no) VALUES(@CheckDate,@totalamount,@phNum,@suspendNum,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@totalamount", model.Totalamount));
                param.Add(DbHelper.CreateParameter("@phNum", model.PhNum));
                param.Add(DbHelper.CreateParameter("@suspendNum", model.SuspendNum));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_data_effluent
        /// </summary>
        public bool UpdateModelOpDataEffluent(ModelOpDataEffluent model)
        {
            string sql = @"UPDATE tb_model_op_data_effluent SET CheckDate=@CheckDate,totalamount=@totalamount ,
                            phNum = @phNum,suspendNum = @suspendNum,project_code=@project_code,task_no=@task_no 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@totalamount", model.Totalamount));
                param.Add(DbHelper.CreateParameter("@phNum", model.PhNum));
                param.Add(DbHelper.CreateParameter("@suspendNum", model.SuspendNum));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的应急响应及时率信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDataEri(ModelOpDataEri model)
        {
            string sql = "SELECT ID FROM tb_model_op_data_eri WHERE task_no=@task_no AND project_code=@project_code  and Year=@Year and Month=@Month";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@Year", model.Year));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_op_data_eri
        /// </summary>
        public bool AddModelOpDataEri(ModelOpDataEri model)
        {
            string sql = "INSERT INTO tb_model_op_data_eri(Year,Month,N1,N,project_code,task_no) VALUES(@Year,@Month,@N1,@N,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Year", model.Year));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@N1", model.N1));
                param.Add(DbHelper.CreateParameter("@N", model.N));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_data_eri
        /// </summary>
        public bool UpdateModelOpDataEri(ModelOpDataEri model)
        {
            string sql = @"UPDATE tb_model_op_data_eri SET Year=@Year,Month=@Month ,
                            N1 = @N1,N = @N,project_code=@project_code,task_no=@task_no 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@Year", model.Year));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@N1", model.N1));
                param.Add(DbHelper.CreateParameter("@N", model.N));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的节能环保信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDataEs(ModelOpDataEs model)
        {
            string sql = "SELECT ID FROM tb_model_op_data_es WHERE task_no=@task_no AND project_code=@project_code  and CheckDate=@CheckDate ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_op_data_es
        /// </summary>
        public bool AddModelOpDataEs(ModelOpDataEs model)
        {
            string sql = "INSERT INTO tb_model_op_data_es(CheckDate,ES,Memo,project_code,task_no) VALUES(@CheckDate,@ES,@Memo,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@ES", model.ES));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_data_es
        /// </summary>
        public bool UpdateModelOpDataEs(ModelOpDataEs model)
        {
            string sql = @"UPDATE tb_model_op_data_es SET CheckDate=@CheckDate,ES=@ES ,
                            Memo = @Memo,project_code=@project_code,task_no=@task_no 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@ES", model.ES));
                param.Add(DbHelper.CreateParameter("@Memo", model.Memo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的高峰期烟雾浓度信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDataK(ModelOpDataK model)
        {
            string sql = "SELECT ID FROM tb_model_op_data_k WHERE task_no=@task_no AND project_code=@project_code  and CheckDate=@CheckDate and Code=@Code";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_op_data_es
        /// </summary>
        public bool AddModelOpDataK(ModelOpDataK model)
        {
            string sql = "INSERT INTO tb_model_op_data_k(CheckDate,Code,station,Value,project_code,task_no) VALUES(@CheckDate,@Code,@station,@Value,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@station", model.Station));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_op_data_es
        /// </summary>
        public bool UpdateModelOpDataK(ModelOpDataK model)
        {
            string sql = @"UPDATE tb_model_op_data_k SET CheckDate=@CheckDate,Code=@Code ,
                            station = @station,Value=@Value,project_code=@project_code,task_no=@task_no 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@station", model.Station));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的标线光度性能信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDataNBI(ModelOpDataNBI model)
        {
            string sql = "SELECT ID FROM tb_model_op_data_nbi WHERE task_no=@task_no AND project_code=@project_code  and monitordate=@monitordate and Code=@Code";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@monitordate", model.Monitordate));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpDataNBI(ModelOpDataNBI model)
        {
            string sql = "INSERT INTO tb_model_op_data_nbi(monitordate,Code,station,Value,color,project_code,task_no) VALUES(@monitordate,@Code,@station,@Value,@color,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@monitordate", model.Monitordate));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@station", model.Station));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@color", model.Color));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public bool UpdateModelOpDataNBI(ModelOpDataNBI model)
        {
            string sql = @"UPDATE tb_model_op_data_nbi SET monitordate=@monitordate,Code=@Code ,
                            station = @station,Value=@Value,color=@color,project_code=@project_code,task_no=@task_no 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@monitordate", model.Monitordate));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@station", model.Station));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@color", model.Color));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的安全生产事故信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDataSafety(ModelOpDataSafety model)
        {
            string sql = "SELECT ID FROM tb_model_op_data_safety WHERE task_no=@task_no AND project_code=@project_code  and Year=@Year and Month=@Month and LineCode=@LineCode ;";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@Year", model.Year));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpDataSafety(ModelOpDataSafety model)
        {
            string sql = "INSERT INTO tb_model_op_data_safety(LineCode,Year,Month,AccidentType,SeriousInjury,Dead,project_code,task_no) VALUES(@LineCode,@Year,@Month,@AccidentType,@SeriousInjury,@Dead,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Year", model.Year));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@AccidentType", model.AccidentType));
                param.Add(DbHelper.CreateParameter("@SeriousInjury", model.SeriousInjury));
                param.Add(DbHelper.CreateParameter("@Dead", model.Dead));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public bool UpdateModelOpDataSafety(ModelOpDataSafety model)
        {
            string sql = @"UPDATE tb_model_op_data_safety SET LineCode=@LineCode,Year=@Year ,
                            Month = @Month,AccidentType=@AccidentType,SeriousInjury=@SeriousInjury,Dead=@Dead,project_code=@project_code,task_no=@task_no 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@Year", model.Year));
                param.Add(DbHelper.CreateParameter("@Month", model.Month));
                param.Add(DbHelper.CreateParameter("@AccidentType", model.AccidentType));
                param.Add(DbHelper.CreateParameter("@SeriousInjury", model.SeriousInjury));
                param.Add(DbHelper.CreateParameter("@Dead", model.Dead));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的高峰期平均行驶速度信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDataSpeed(ModelOpDataSpeed model)
        {
            string sql = "SELECT ID FROM tb_model_op_data_speed WHERE task_no=@task_no AND project_code=@project_code  and MonitorDate=@MonitorDate and Code=@Code";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpDataSpeed(ModelOpDataSpeed model)
        {
            string sql = "INSERT INTO tb_model_op_data_speed(Code,Length,PassingTime,Speed,MonitorDate,project_code,task_no) VALUES(@Code,@Length,@PassingTime,@Speed,@MonitorDate,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Length", model.Length));
                param.Add(DbHelper.CreateParameter("@PassingTime", model.PassingTime));
                param.Add(DbHelper.CreateParameter("@Speed", model.Speed));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public bool UpdateModelOpDataSpeed(ModelOpDataSpeed model)
        {
            string sql = @"UPDATE tb_model_op_data_speed SET Code=@Code,Length=@Length ,
                            PassingTime = @PassingTime,Speed=@Speed,MonitorDate=@MonitorDate,project_code=@project_code,task_no=@task_no 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Length", model.Length));
                param.Add(DbHelper.CreateParameter("@PassingTime", model.PassingTime));
                param.Add(DbHelper.CreateParameter("@Speed", model.Speed));
                param.Add(DbHelper.CreateParameter("@MonitorDate", model.MonitorDate));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的通行影响率信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpDataTraff(ModelOpDataTraff model)
        {
            string sql = "SELECT ID FROM tb_model_op_data_trafficinfluence WHERE task_no=@task_no AND project_code=@project_code  and start_time=@start_time and end_time=@end_time and LineCode=@LineCode";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@start_time", model.StartTime));
                param.Add(DbHelper.CreateParameter("@end_time", model.EndTime));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpDataTraff(ModelOpDataTraff model)
        {
            string sql = "INSERT INTO tb_model_op_data_trafficinfluence(Code,LineCode,start_time,end_time,CloseDuration,project_code,task_no) VALUES(@Code,@LineCode,@start_time,@end_time,@CloseDuration,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@start_time", model.StartTime));
                param.Add(DbHelper.CreateParameter("@end_time", model.EndTime));
                param.Add(DbHelper.CreateParameter("@CloseDuration", model.CloseDuration));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public bool UpdateModelOpDataTraff(ModelOpDataTraff model)
        {
            string sql = @"UPDATE tb_model_op_data_trafficinfluence SET Code=@Code,LineCode=@LineCode ,
                            start_time = @start_time,end_time=@end_time,CloseDuration=@CloseDuration,project_code=@project_code,task_no=@task_no 
                            WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@start_time", model.StartTime));
                param.Add(DbHelper.CreateParameter("@end_time", model.EndTime));
                param.Add(DbHelper.CreateParameter("@CloseDuration", model.CloseDuration));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 新增待评价项目的照明状况信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelOpBidataQuery(ModelOpBidataQuery2 model)
        {
            string sql = "SELECT ID FROM tb_model_op_bidata WHERE task_no=@task_no AND project_code=@project_code  and monitoryear=@monitoryear and linecode=@linecode  ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@monitoryear", model.monitoryear));
                param.Add(DbHelper.CreateParameter("@linecode", model.linecode));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpBidataQuery(ModelOpBidataQuery2 model)
        {
            string sql = "INSERT INTO tb_model_op_bidata(linecode,position,mileage,deviceno,monitoryear,project_code,task_no,monitormonth,monitordata,datapushdate,uniformdata) VALUES(@linecode,@position,@mileage,@deviceno,@monitoryear,@project_code,@task_no,@monitormonth,@monitordata,@datapushdate,@uniformdata)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@linecode", model.linecode));
                param.Add(DbHelper.CreateParameter("@position", model.position));
                param.Add(DbHelper.CreateParameter("@mileage", model.mileage));
                param.Add(DbHelper.CreateParameter("@deviceno", model.deviceno));
                param.Add(DbHelper.CreateParameter("@monitoryear", model.monitoryear));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@monitormonth", model.monitormonth));
                param.Add(DbHelper.CreateParameter("@monitordata", model.monitordata));
                param.Add(DbHelper.CreateParameter("@datapushdate", model.datapushdate));
                param.Add(DbHelper.CreateParameter("@uniformdata", model.uniformdata));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public bool UpdateModelOpBidataQuery(ModelOpBidataQuery2 model,string id)
        {
            string sql = @"UPDATE `tb_model_op_bidata` SET `project_code` = @project_code, `task_no` =@task_no, `linecode` = @linecode, `position` = @position, `mileage` = @mileage, `deviceno` = @deviceno, `monitoryear` = @monitoryear, `monitormonth` = @monitormonth, `monitordata` = @monitordata, `datapushdate` = @datapushdate,  `uniformdata` = @uniformdata WHERE `ID` = @ID;";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", id));
                param.Add(DbHelper.CreateParameter("@linecode", model.linecode));
                param.Add(DbHelper.CreateParameter("@position", model.position));
                param.Add(DbHelper.CreateParameter("@mileage", model.mileage));
                param.Add(DbHelper.CreateParameter("@deviceno", model.deviceno));
                param.Add(DbHelper.CreateParameter("@monitoryear", model.monitoryear));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@monitormonth", model.monitormonth));
                param.Add(DbHelper.CreateParameter("@monitordata", model.monitordata));
                param.Add(DbHelper.CreateParameter("@datapushdate", model.datapushdate));
                param.Add(DbHelper.CreateParameter("@uniformdata", model.uniformdata));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 待评价项目的牵引排堵及时率信息
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckOpTeidata2(ModelOpTeidata2 model)
        {
            string sql = "SELECT ID FROM tb_model_op_teidata WHERE task_no=@task_no AND project_code=@project_code  and monitordate=@monitordate and linecode=@linecode  ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@monitordate", model.monitordate));
                param.Add(DbHelper.CreateParameter("@linecode", model.linecode));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool AddModelOpTeidata2(ModelOpTeidata2 model)
        {
            string sql = "INSERT INTO `tb_model_op_teidata`( `project_code`, `task_no`, `linecode`, `monitordate`, `M1amount`, `M2amount`, `totalinday`, `datapushdate`) VALUES(@project_code,@task_no,@linecode,@monitordate,@M1amount,@M2amount,@totalinday,NOW())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@linecode", model.linecode));
                param.Add(DbHelper.CreateParameter("@monitordate", model.monitordate));
                param.Add(DbHelper.CreateParameter("@M1amount", model.M1amount));
                param.Add(DbHelper.CreateParameter("@M2amount", model.M2amount));
                param.Add(DbHelper.CreateParameter("@totalinday", model.totalinday));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        public bool UpdateModelOpTeidata2(ModelOpTeidata2 model, string id)
        {
            string sql = @"UPDATE `tb_model_op_teidata` SET `project_code` = @project_code, `task_no` = @task_no, `linecode` = @linecode, `monitordate` = @monitordate, `M1amount` = @M1amount, `M2amount` = @M2amount, `totalinday` = @totalinday, `datapushdate` = NOW()  WHERE `ID` = @ID;";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", id));
                param.Add(DbHelper.CreateParameter("@linecode", model.linecode));
                param.Add(DbHelper.CreateParameter("@monitordate", model.monitordate));
                param.Add(DbHelper.CreateParameter("@M1amount", model.M1amount));
                param.Add(DbHelper.CreateParameter("@M2amount", model.M2amount));
                param.Add(DbHelper.CreateParameter("@totalinday", model.totalinday));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 删除模型信息
        public bool DeleteModel(string id , string tbname)
        {
            string sql = $@"Delete FROM { tbname }  WHERE ID=@ID";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion
        #endregion
    }
}