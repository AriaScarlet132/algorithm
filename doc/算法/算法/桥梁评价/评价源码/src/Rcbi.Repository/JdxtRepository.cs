using Rcbi.Entity.Domain;
using Rcbi.Entity.OpenApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text; 

namespace Rcbi.Repository
{
    public class JdxtRepository
    {
        /// <summary>
        /// 更新任务号
        /// </summary>
        public bool UpdateTaskNo(string task_no, DateTime start, DateTime end, string project_code)
        {
            string sql = @"UPDATE tb_model_mes_data_operation SET task_no=@task_no WHERE beginning_Operation>=@start AND ending_Operation<=@end AND project_code=@project_code;
                           UPDATE tb_model_mes_data_failure SET task_no = @task_no WHERE beginning_Failure>= @start AND ending_Failure<= @end AND project_code=@project_code; ";
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


        #region tb_model_mes_devicetype_imp
        /// <summary>
        /// 数据重复验证tb_model_mes_devicetype_imp
        /// </summary>
        public string RepeatCheckModelMesDevicetypeImp(ModelMesDevicetypeImp model)
        {
            string sql = "SELECT id FROM tb_model_mes_devicetype_imp WHERE MesSystemCode=@MesSystemCode AND typeCode_Equipment=@typeCode_Equipment AND Project_Code=@Project_Code and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MesSystemCode", model.MesSystemCode));
                param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_mes_devicetype_imp
        /// </summary>
        public bool AddModelMesDevicetypeImp(ModelMesDevicetypeImp model)
        {
            string sql = "INSERT INTO tb_model_mes_devicetype_imp(MesSystemCode,typeName_Equipment,typeCode_Equipment,unit,Explanation,importance_Equipment,project_code,datapushdate,delete_flag) VALUES(@MesSystemCode,@typeName_Equipment,@typeCode_Equipment,@unit,@Explanation,@importance_Equipment,@project_code,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MesSystemCode", model.MesSystemCode));
                param.Add(DbHelper.CreateParameter("@typeName_Equipment", model.TypeNameEquipment));
                param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
                param.Add(DbHelper.CreateParameter("@unit", model.Unit));
                param.Add(DbHelper.CreateParameter("@Explanation", model.Explanation));
                param.Add(DbHelper.CreateParameter("@importance_Equipment", model.ImportanceEquipment));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_mes_devicetype_imp
        /// </summary>
        public bool UpdateModelMesDevicetypeImp(ModelMesDevicetypeImp model, string id)
        {
            string sql = "UPDATE tb_model_mes_devicetype_imp SET MesSystemCode=@MesSystemCode,typeName_Equipment=@typeName_Equipment,typeCode_Equipment=@typeCode_Equipment,unit=@unit,Explanation=@Explanation,importance_Equipment=@importance_Equipment,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MesSystemCode", model.MesSystemCode));
                param.Add(DbHelper.CreateParameter("@typeName_Equipment", model.TypeNameEquipment));
                param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
                param.Add(DbHelper.CreateParameter("@unit", model.Unit));
                param.Add(DbHelper.CreateParameter("@Explanation", model.Explanation));
                param.Add(DbHelper.CreateParameter("@importance_Equipment", model.ImportanceEquipment));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id",id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region  RepeatCheckModelMesParameterMesystem
        /// <summary>
        /// 数据重复验证 
        /// </summary>
        public string RepeatCheckModelMesParameterMesystem(ModelMesParameterMesystem model)
        {
            string sql = "SELECT id FROM tb_model_mes_parameter_mesystem WHERE code_Midsystem=@code_Midsystem and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@MesSystemCode", model.code_Midsystem));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增RepeatCheckModelMesParameterMesystem
        /// </summary>
        public bool AddModelMesParameterMesystem(ModelMesParameterMesystem model)
        {
            string sql = "INSERT INTO tb_model_mes_parameter_mesystem(code_Midsystem,Subsystem,parameter,MES_I,MES_II,MES_III,MES_IV,MES_V,facility_type) VALUES(@code_Midsystem,@Subsystem,@parameter,@MES_I,@MES_II,@MES_III,@MES_IV,@MES_V,@facility_type)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@code_Midsystem", model.code_Midsystem));
                param.Add(DbHelper.CreateParameter("@Subsystem", model.Subsystem));
                param.Add(DbHelper.CreateParameter("@parameter", model.parameter));
                param.Add(DbHelper.CreateParameter("@MES_I", model.MES_I));
                param.Add(DbHelper.CreateParameter("@MES_II", model.MES_II));
                param.Add(DbHelper.CreateParameter("@MES_III", model.MES_III));
                param.Add(DbHelper.CreateParameter("@MES_IV", model.MES_IV));
                param.Add(DbHelper.CreateParameter("@MES_V", model.MES_V));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新RepeatCheckModelMesParameterMesystem
        /// </summary>
        public bool UpdateModelMesParameterMesystem(ModelMesParameterMesystem model, int id)
        {
            string sql = "UPDATE tb_model_mes_parameter_mesystem SET code_Midsystem=@code_Midsystem,Subsystem=@Subsystem,parameter=@parameter,MES_I=@MES_I,MES_II=@MES_II,MES_III=@MES_III,MES_IV=@MES_IV,MES_V=@MES_V,facility_type=@facility_type WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@code_Midsystem", model.code_Midsystem));
                param.Add(DbHelper.CreateParameter("@Subsystem", model.Subsystem));
                param.Add(DbHelper.CreateParameter("@parameter", model.parameter));
                param.Add(DbHelper.CreateParameter("@MES_I", model.MES_I));
                param.Add(DbHelper.CreateParameter("@MES_II", model.MES_II));
                param.Add(DbHelper.CreateParameter("@MES_III", model.MES_III));
                param.Add(DbHelper.CreateParameter("@MES_IV", model.MES_IV));
                param.Add(DbHelper.CreateParameter("@MES_V", model.MES_V));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion
        #region  RepeatCheckModelMesCriteria
        /// <summary>
        /// 数据重复验证 
        /// </summary>
        public string RepeatCheckModelMesCriteria(ModelMesCriteria model)
        {
            string sql = "SELECT id FROM tb_model_mes_Criteria WHERE code_Midsystem=@code_Midsystem and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                //param.Add(DbHelper.CreateParameter("@ ", model. ));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增RepeatCheckModelMesParameterMesystem
        /// </summary>
        public bool AddModelMesCriteria(ModelMesCriteria model)
        {
            string sql = "INSERT INTO tb_model_mes_Criteria(mes_system_code,mes_system_name,Level,low_value,up_value) VALUES(@mes_system_code,@mes_system_name,@Level,@low_value,@up_value)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@mes_system_code", model.mes_system_code));
                param.Add(DbHelper.CreateParameter("@mes_system_name", model.mes_system_name));
                param.Add(DbHelper.CreateParameter("@Level", model.Level));
                param.Add(DbHelper.CreateParameter("@low_value", model.low_value));
                param.Add(DbHelper.CreateParameter("@up_value", model.up_value));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新RepeatCheckModelMesParameterMesystem
        /// </summary>
        public bool UpdateModelMesCriteria(ModelMesCriteria model, int id)
        {
            string sql = "UPDATE tb_model_mes_Criteria SET mes_system_code=@mes_system_code,mes_system_name=@mes_system_name,Level=@Level,low_value=@low_value,up_value=@up_value WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@mes_system_code", model.mes_system_code));
                param.Add(DbHelper.CreateParameter("@mes_system_name", model.mes_system_name));
                param.Add(DbHelper.CreateParameter("@Level", model.Level));
                param.Add(DbHelper.CreateParameter("@low_value", model.low_value));
                param.Add(DbHelper.CreateParameter("@up_value", model.up_value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion


        #region tb_model_mes_equipmentlist
        /// <summary>
        /// 数据重复验证tb_model_mes_equipmentlist
        /// </summary>
        public string RepeatCheckModelMesEquipmentlist(ModelMesEquipmentlist model)
        {
            string sql = "SELECT id FROM tb_model_mes_equipmentlist WHERE Project_Code=@ProjectCode AND Equipment_Code=@Equipment_Code and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                // param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
                param.Add(DbHelper.CreateParameter("@ProjectCode", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_mes_equipmentlist
        /// </summary>
        public bool AddModelMesEquipmentlist(ModelMesEquipmentlist model)
        {
            string sql = "INSERT INTO tb_model_mes_equipmentlist(typeCode_Equipment,typeName_Equipment,Equipment_Name,Equipment_Code,project_code,datapushdate,delete_flag) VALUES(@typeCode_Equipment,@typeName_Equipment,@Equipment_Name,@Equipment_Code,@project_code,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
                param.Add(DbHelper.CreateParameter("@typeName_Equipment", model.TypeNameEquipment));
                param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_mes_equipmentlist
        /// </summary>
        public bool UpdateModelMesEquipmentlist(ModelMesEquipmentlist model, string id)
        {
            string sql = "UPDATE tb_model_mes_equipmentlist SET typeCode_Equipment=@typeCode_Equipment,typeName_Equipment=@typeName_Equipment,Equipment_Name=@Equipment_Name,Equipment_Code=@Equipment_Code,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
                param.Add(DbHelper.CreateParameter("@typeName_Equipment", model.TypeNameEquipment));
                param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id",id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_mes_equipmentlistsummary
        /// <summary>
        /// 数据重复验证tb_model_mes_equipmentlistsummary
        /// </summary>
        public string RepeatCheckModelMesEquipmentlistsummary(ModelMesEquipmentlistsummary model)
        {
            string sql = "SELECT id FROM tb_model_mes_equipmentlistsummary WHERE typeCode_Equipment=@typeCode_Equipment AND Equipment_Count=@Equipment_Count AND Project_Code=@Project_Code and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Equipment_Count", model.EquipmentCount));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_mes_equipmentlistsummary
        /// </summary>
        public bool AddModelMesEquipmentlistsummary(ModelMesEquipmentlistsummary model)
        {
            string sql = "INSERT INTO tb_model_mes_equipmentlistsummary(typeCode_Equipment,typeName_Equipment,Equipment_Count,project_code,datapushdate,delete_flag) VALUES(@typeCode_Equipment,@typeName_Equipment,@Equipment_Count,@project_code,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
                param.Add(DbHelper.CreateParameter("@typeName_Equipment", model.TypeNameEquipment));
                param.Add(DbHelper.CreateParameter("@Equipment_Count", model.EquipmentCount));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_mes_equipmentlistsummary
        /// </summary>
        public bool UpdateModelMesEquipmentlistsummary(ModelMesEquipmentlistsummary model, string id)
        {
            string sql = "UPDATE tb_model_mes_equipmentlistsummary SET typeCode_Equipment=@typeCode_Equipment,typeName_Equipment=@typeName_Equipment,Equipment_Count=@Equipment_Count,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
                param.Add(DbHelper.CreateParameter("@typeName_Equipment", model.TypeNameEquipment));
                param.Add(DbHelper.CreateParameter("@Equipment_Count", model.EquipmentCount));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id",id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelMesDataOperation(int id)
        {
            string sql = "UPDATE tb_model_mes_data_operation SET delete_flag=1 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_mes_data_operation
        /// <summary>
        /// 数据重复验证tb_model_mes_data_operation
        /// </summary>
        public string RepeatCheckModelMesDataOperation(ModelMesDataOperation model)
        {
            string sql = "SELECT id FROM tb_model_mes_data_operation WHERE Equipment_Code=@Equipment_Code AND  project_code=@project_code and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_mes_data_operation
        /// </summary>
        public bool AddModelMesDataOperation(ModelMesDataOperation model)
        {
            string sql = "INSERT INTO tb_model_mes_data_operation(Equipment_Name,Equipment_Code,beginning_Operation,ending_Operation,total_Operation,project_code,task_no,datapushdate,delete_flag) VALUES(@Equipment_Name,@Equipment_Code,@beginning_Operation,@ending_Operation,@total_Operation,@project_code,@task_no,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@beginning_Operation", model.BeginningOperation));
                param.Add(DbHelper.CreateParameter("@ending_Operation", model.EndingOperation));
                param.Add(DbHelper.CreateParameter("@total_Operation", model.TotalOperation));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_mes_data_operation
        /// </summary>
        public bool UpdateModelMesDataOperation(ModelMesDataOperation model, string id)
        {
            string sql = "UPDATE tb_model_mes_data_operation SET Equipment_Name=@Equipment_Name,Equipment_Code=@Equipment_Code,beginning_Operation=@beginning_Operation,ending_Operation=@ending_Operation,total_Operation=@total_Operation,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@beginning_Operation", model.BeginningOperation));
                param.Add(DbHelper.CreateParameter("@ending_Operation", model.EndingOperation));
                param.Add(DbHelper.CreateParameter("@total_Operation", model.TotalOperation));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id",id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_mes_data_failure
        /// <summary>
        /// 数据重复验证tb_model_mes_data_failure
        /// </summary>
        public string RepeatCheckModelMesDataFailure(ModelMesDataFailure model)
        {
            string sql = "SELECT id FROM tb_model_mes_data_failure WHERE Equipment_Code=@Equipment_Code AND project_code=@project_code and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_mes_data_failure
        /// </summary>
        public bool AddModelMesDataFailure(ModelMesDataFailure model)
        {
            string sql = "INSERT INTO tb_model_mes_data_failure(Equipment_Name,Equipment_Code,beginning_Failure,ending_Failure,total_Failure,project_code,task_no,datapushdate,delete_flag) VALUES(@Equipment_Name,@Equipment_Code,@beginning_Failure,@ending_Failure,@total_Failure,@project_code,@task_no,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@beginning_Failure", model.BeginningFailure));
                param.Add(DbHelper.CreateParameter("@ending_Failure", model.EndingFailure));
                param.Add(DbHelper.CreateParameter("@total_Failure", model.TotalFailure));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_mes_data_failure
        /// </summary>
        public bool UpdateModelMesDataFailure(ModelMesDataFailure model, string id)
        {
            string sql = "UPDATE tb_model_mes_data_failure SET Equipment_Name=@Equipment_Name,Equipment_Code=@Equipment_Code,beginning_Failure=@beginning_Failure,ending_Failure=@ending_Failure,total_Failure=@total_Failure,project_code=@project_code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@beginning_Failure", model.BeginningFailure));
                param.Add(DbHelper.CreateParameter("@ending_Failure", model.EndingFailure));
                param.Add(DbHelper.CreateParameter("@total_Failure", model.TotalFailure));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id",id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        /// <summary>
        /// 查询tb_model_mes_result_equipment
        /// </summary>
        public IList<ModelMesResultEquipment> GetModelMesResultEquipment(string task_no)
        {
            string sql = "SELECT * FROM tb_model_mes_result_equipment WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelMesResultEquipment>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_mes_result_mesystem
        /// </summary>
        public IList<ModelMesResultMesystem> GetModelMesResultMesystem(string task_no)
        {
            string sql = "SELECT * FROM tb_model_mes_result_mesystem WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelMesResultMesystem>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_mes_result_midsystem
        /// </summary>
        public IList<ModelMesResultMidsystem> GetModelMesResultMidsystem(string task_no)
        {
            string sql = "SELECT * FROM tb_model_mes_result_midsystem WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelMesResultMidsystem>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_mes_result_subsystem
        /// </summary>
        public IList<ModelMesResultSubsystem> GetModelMesResultSubsystem(string task_no)
        {
            string sql = "SELECT * FROM tb_model_mes_result_subsystem WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelMesResultSubsystem>(sql, CommandType.Text, param.ToArray());
            }
        }

        #region 2020年12月1日

        public IList<ModelMesDataOperationList> GetModelJdevaList(ModelMesDataOperationQuery model, out int count)
        {
            string sql = "select * from tb_model_mes_data_operation where task_no=@task_no  AND delete_flag=0 limit @page,@count";
            string count_sql = "select count(1) from tb_model_mes_data_operation where  task_no=@task_no  AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                       DbHelper.CreateParameter("@task_no", model.task_no)));
                return DbHelper.ExecuteReaderList<ModelMesDataOperationList>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool AddModelMesDataOperationForm(ModelMesDataOperationList model)
        {

            string sql = "INSERT INTO tb_model_mes_data_operation(Equipment_Name,Equipment_Code,beginning_Operation,ending_Operation,total_Operation,project_code,task_no,datapushdate) VALUES(@Equipment_Name,@Equipment_Code,@beginning_Operation,@ending_Operation,@total_Operation,@project_code,@task_no,@datapushdate)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@beginning_Operation", model.BeginningOperation));
                param.Add(DbHelper.CreateParameter("@ending_Operation", model.EndingOperation));
                param.Add(DbHelper.CreateParameter("@total_Operation", model.TotalOperation));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@datapushdate", model.Datapushdate));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        public bool InsertModelMesDataOperationList(List<ModelMesDataOperationList> list)
        {
            string sql = " INSERT INTO tb_model_mes_data_operation(Equipment_Name,Equipment_Code,beginning_Operation,ending_Operation,total_Operation,project_code,task_no,datapushdate) VALUES ";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;

            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@Equipment_Name{0},@Equipment_Code{0},@beginning_Operation{0},@ending_Operation{0},@total_Operation{0},@project_code{0},@task_no{0},@datapushdate{0})", i));
                    param.Add(DbHelper.CreateParameter("@Equipment_Name" + i, model.EquipmentName));
                    param.Add(DbHelper.CreateParameter("@Equipment_Code" + i, model.EquipmentCode));
                    param.Add(DbHelper.CreateParameter("@beginning_Operation" + i, model.BeginningOperation));
                    param.Add(DbHelper.CreateParameter("@ending_Operation" + i, model.EndingOperation));
                    param.Add(DbHelper.CreateParameter("@total_Operation" + i, model.TotalOperation));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.ProjectCode));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.TaskNo));
                    param.Add(DbHelper.CreateParameter("@datapushdate" + i, model.Datapushdate));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelMesDataOperationByTaskNo(string task_no)
        {
            string sql = "UPDATE tb_model_mes_data_operation SET delete_flag=1 WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        #region 新步骤 MesDataFailure


        public IList<ModelMesDataFailureList> GetModelMesDataFailureList(ModelMesDataFailureQuery model, out int count)
        {
            string sql = "select * from tb_model_mes_data_failure where task_no=@task_no  AND delete_flag=0 limit @page,@count";
            string count_sql = "select count(1) from tb_model_mes_data_failure where  task_no=@task_no  AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                       DbHelper.CreateParameter("@task_no", model.task_no)));
                return DbHelper.ExecuteReaderList<ModelMesDataFailureList>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool AddModelMesDataFailureForm(ModelMesDataFailureList model)
        {

            string sql = "INSERT INTO tb_model_mes_data_failure(Equipment_Name,Equipment_Code,beginning_Failure,ending_Failure,total_Failure,project_code,task_no,datapushdate) VALUES(@Equipment_Name,@Equipment_Code,@beginning_Failure,@ending_Failure,@total_Failure,@project_code,@task_no,@datapushdate)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
                param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
                param.Add(DbHelper.CreateParameter("@beginning_Failure", model.BeginningFailure));
                param.Add(DbHelper.CreateParameter("@ending_Failure", model.EndingFailure));
                param.Add(DbHelper.CreateParameter("@total_Failure", model.TotalFailure));
                param.Add(DbHelper.CreateParameter("@project_code", model.ProjectCode));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@datapushdate", model.Datapushdate));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        public bool InsertModelMesDataFailureList(List<ModelMesDataFailureList> list)
        {
            string sql = " INSERT INTO tb_model_mes_data_failure(Equipment_Name,Equipment_Code,beginning_Failure,ending_Failure,total_Failure,project_code,task_no,datapushdate) VALUES ";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;

            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@Equipment_Name{0},@Equipment_Code{0},@beginning_Failure{0},@ending_Failure{0},@total_Failure{0},@project_code{0},@task_no{0},@datapushdate{0})", i));
                    param.Add(DbHelper.CreateParameter("@Equipment_Name" + i, model.EquipmentName));
                    param.Add(DbHelper.CreateParameter("@Equipment_Code" + i, model.EquipmentCode));
                    param.Add(DbHelper.CreateParameter("@beginning_Failure" + i, model.BeginningFailure));
                    param.Add(DbHelper.CreateParameter("@ending_Failure" + i, model.EndingFailure));
                    param.Add(DbHelper.CreateParameter("@total_Failure" + i, model.TotalFailure));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.ProjectCode));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.TaskNo));
                    param.Add(DbHelper.CreateParameter("@datapushdate" + i, model.Datapushdate));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelMesDataFailureByTaskNo(string task_no)
        {
            string sql = "UPDATE tb_model_mes_data_failure SET delete_flag=1 WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelMesDataFailure(int id)
        {
            string sql = "UPDATE tb_model_mes_data_failure SET delete_flag=1 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        #endregion

        public IList<ModelMesEquipmentlist> GetModelMesEquipmentListByProjectCode(string projectCode)
        {
            string sql = "SELECT * FROM tb_model_mes_equipmentlist WHERE Project_Code=@projectCode AND delete_flag=0";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@projectCode", projectCode)); 
                return DbHelper.ExecuteReaderList<ModelMesEquipmentlist>(sql,CommandType.Text, param.ToArray());
            }
        }
        #endregion


        #region tb_model_mes_criteria_mesystem
        ///// <summary>
        ///// 数据重复验证tb_model_mes_criteria_mesystem
        ///// </summary>
        //public string RepeatCheckMesCriteriaMesystem(ModelMesCriteriaMesystem model)
        //{
        //    string sql = "SELECT id FROM tb_model_mes_criteria_mesystem WHERE Project_Code=@ProjectCode AND Equipment_Code=@Equipment_Code and (delete_flag is null or delete_flag=0)";
        //    List<DbParameter> param = new List<DbParameter>();
        //    using (var DbHelper = DBManager.CoreHelper)
        //    {
        //        // param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
        //        param.Add(DbHelper.CreateParameter("@ProjectCode", model.Project_Code));
        //        param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
        //        return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
        //    }
        //}

        /// <summary>
        /// 新增tb_model_mes_criteria_mesystem
        /// </summary>
        public bool AddMesCriteriaMesystem(ModelMesCriteriaMesystem model)
        {
            string sql = "INSERT INTO tb_model_mes_criteria_mesystem(CI_MESystem,MES_I_Top,MES_I_Bottom,MES_II_Top,MES_II_Bottom,MES_III_Top,MES_III_Bottom,MES_IV_Top,MES_IV_Bottom,MES_V_Top,MES_V_Bottom,facility_type) VALUES(@CI_MESystem,@MES_I_Top,@MES_I_Bottom,@MES_II_Top,@MES_II_Bottom,@MES_III_Top,@MES_III_Bottom,@MES_IV_Top,@MES_IV_Bottom,@MES_V_Top,@MES_V_Bottom,@facility_type)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@CI_MESystem", model.CIMESystem));
                param.Add(DbHelper.CreateParameter("@MES_I_Top", model.MESITop));
                param.Add(DbHelper.CreateParameter("@MES_I_Bottom", model.MESIBottom));
                param.Add(DbHelper.CreateParameter("@MES_II_Top", model.MESIITop));
                param.Add(DbHelper.CreateParameter("@MES_II_Bottom", model.MESIIBottom));

                param.Add(DbHelper.CreateParameter("@MES_III_Top", model.MESIIITop));
                param.Add(DbHelper.CreateParameter("@MES_III_Bottom", model.MESIIIBottom));
                param.Add(DbHelper.CreateParameter("@MES_IV_Top", model.MESIVTop));
                param.Add(DbHelper.CreateParameter("@MES_IV_Bottom", model.MESIVBottom));
                param.Add(DbHelper.CreateParameter("@MES_V_Top", model.MESVTop));
                param.Add(DbHelper.CreateParameter("@MES_V_Bottom", model.MESVBottom));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        ///// <summary>
        ///// 更新tb_model_mes_criteria_mesystem
        ///// </summary>
        //public bool AddMesCriteriaMesystem(ModelMesCriteriaMesystem model, string id)
        //{
        //    string sql = "UPDATE tb_model_mes_equipmentlist SET typeCode_Equipment=@typeCode_Equipment,typeName_Equipment=@typeName_Equipment,Equipment_Name=@Equipment_Name,Equipment_Code=@Equipment_Code,project_code=@project_code WHERE id=@id";
        //    List<DbParameter> param = new List<DbParameter>();
        //    using (var DbHelper = DBManager.CoreHelper)
        //    {
        //        param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
        //        param.Add(DbHelper.CreateParameter("@typeName_Equipment", model.TypeNameEquipment));
        //        param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
        //        param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
        //        param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
        //        param.Add(DbHelper.CreateParameter("@id", id));
        //        return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
        //    }
        //}

        #endregion

        #region tb_model_mes_criteria_midsystem
        ///// <summary>
        ///// 数据重复验证tb_model_mes_criteria_mesystem
        ///// </summary>
        //public string RepeatCheckMesCriteriaMesystem(ModelMesCriteriaMesystem model)
        //{
        //    string sql = "SELECT id FROM tb_model_mes_criteria_mesystem WHERE Project_Code=@ProjectCode AND Equipment_Code=@Equipment_Code and (delete_flag is null or delete_flag=0)";
        //    List<DbParameter> param = new List<DbParameter>();
        //    using (var DbHelper = DBManager.CoreHelper)
        //    {
        //        // param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
        //        param.Add(DbHelper.CreateParameter("@ProjectCode", model.Project_Code));
        //        param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
        //        return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
        //    }
        //}

        /// <summary>
        /// 新增
        /// </summary>
        public bool addMesCriteriaMidsystem(ModelMesCriteriaMidsystem model)
        {
            string sql = "INSERT INTO tb_model_mes_criteria_midsystem(CI_Midsystem,Mid_I_Top,Mid_I_Bottom,Mid_II_Top,Mid_II_Bottom,Mid_III_Top,Mid_III_Bottom,Mid_IV_Top,Mid_IV_Bottom,Mid_V_Top,Mid_V_Bottom,facility_type,name_Midsystem,code_Midsystem) VALUES(@CI_Midsystem,@Mid_I_Top,@Mid_I_Bottom,@Mid_II_Top,@Mid_II_Bottom,@Mid_III_Top,@Mid_III_Bottom,@Mid_IV_Top,@Mid_IV_Bottom,@Mid_V_Top,@Mid_V_Bottom,@facility_type,@name_Midsystem,@code_Midsystem)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@CI_Midsystem", model.CIMidsystem));
                param.Add(DbHelper.CreateParameter("@Mid_I_Top", model.MidITop));
                param.Add(DbHelper.CreateParameter("@Mid_I_Bottom", model.MidIBottom));
                param.Add(DbHelper.CreateParameter("@Mid_II_Top", model.MidIITop));
                param.Add(DbHelper.CreateParameter("@Mid_II_Bottom", model.MidIIBottom));

                param.Add(DbHelper.CreateParameter("@Mid_III_Top", model.MidIIITop));
                param.Add(DbHelper.CreateParameter("@Mid_III_Bottom", model.MidIIIBottom));
                param.Add(DbHelper.CreateParameter("@Mid_IV_Top", model.MidIVTop));
                param.Add(DbHelper.CreateParameter("@Mid_IV_Bottom", model.MidIVBottom));
                param.Add(DbHelper.CreateParameter("@Mid_V_Top", model.MidVTop));
                param.Add(DbHelper.CreateParameter("@Mid_V_Bottom", model.MidVBottom));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                param.Add(DbHelper.CreateParameter("@name_Midsystem", model.NameMidsystem));
                param.Add(DbHelper.CreateParameter("@code_Midsystem", model.CodeMidsystem));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        ///// <summary>
        ///// 更新tb_model_mes_criteria_mesystem
        ///// </summary>
        //public bool AddMesCriteriaMesystem(ModelMesCriteriaMesystem model, string id)
        //{
        //    string sql = "UPDATE tb_model_mes_equipmentlist SET typeCode_Equipment=@typeCode_Equipment,typeName_Equipment=@typeName_Equipment,Equipment_Name=@Equipment_Name,Equipment_Code=@Equipment_Code,project_code=@project_code WHERE id=@id";
        //    List<DbParameter> param = new List<DbParameter>();
        //    using (var DbHelper = DBManager.CoreHelper)
        //    {
        //        param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
        //        param.Add(DbHelper.CreateParameter("@typeName_Equipment", model.TypeNameEquipment));
        //        param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
        //        param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
        //        param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
        //        param.Add(DbHelper.CreateParameter("@id", id));
        //        return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
        //    }
        //}

        #endregion

        #region tb_model_mes_systemtype_weights
        ///// <summary>
        ///// 数据重复验证tb_model_mes_criteria_mesystem
        ///// </summary>
        //public string RepeatCheckMesCriteriaMesystem(ModelMesCriteriaMesystem model)
        //{
        //    string sql = "SELECT id FROM tb_model_mes_criteria_mesystem WHERE Project_Code=@ProjectCode AND Equipment_Code=@Equipment_Code and (delete_flag is null or delete_flag=0)";
        //    List<DbParameter> param = new List<DbParameter>();
        //    using (var DbHelper = DBManager.CoreHelper)
        //    {
        //        // param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
        //        param.Add(DbHelper.CreateParameter("@ProjectCode", model.Project_Code));
        //        param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
        //        return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
        //    }
        //}

        /// <summary>
        /// 新增
        /// </summary>
        public bool addMesSystemtypeWeights(ModelMesSystemtypeWeights model)
        {
            string sql = "INSERT INTO ModelMesSystemtypeWeights(CODE,SystemName,weights_system,ParentSystem,LevelName,facility_type) VALUES(@CODE,@SystemName,@weights_system,@ParentSystem,@LevelName,@facility_type)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@CODE", model.CODE));
                param.Add(DbHelper.CreateParameter("@SystemName", model.SystemName));
                param.Add(DbHelper.CreateParameter("@weights_system", model.WeightsSystem));
                param.Add(DbHelper.CreateParameter("@ParentSystem", model.ParentSystem));
                param.Add(DbHelper.CreateParameter("@LevelName", model.LevelName));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        ///// <summary>
        ///// 更新tb_model_mes_criteria_mesystem
        ///// </summary>
        //public bool AddMesCriteriaMesystem(ModelMesCriteriaMesystem model, string id)
        //{
        //    string sql = "UPDATE tb_model_mes_equipmentlist SET typeCode_Equipment=@typeCode_Equipment,typeName_Equipment=@typeName_Equipment,Equipment_Name=@Equipment_Name,Equipment_Code=@Equipment_Code,project_code=@project_code WHERE id=@id";
        //    List<DbParameter> param = new List<DbParameter>();
        //    using (var DbHelper = DBManager.CoreHelper)
        //    {
        //        param.Add(DbHelper.CreateParameter("@typeCode_Equipment", model.TypeCodeEquipment));
        //        param.Add(DbHelper.CreateParameter("@typeName_Equipment", model.TypeNameEquipment));
        //        param.Add(DbHelper.CreateParameter("@Equipment_Name", model.EquipmentName));
        //        param.Add(DbHelper.CreateParameter("@Equipment_Code", model.EquipmentCode));
        //        param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
        //        param.Add(DbHelper.CreateParameter("@id", id));
        //        return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
        //    }
        //}

        #endregion
    }
}