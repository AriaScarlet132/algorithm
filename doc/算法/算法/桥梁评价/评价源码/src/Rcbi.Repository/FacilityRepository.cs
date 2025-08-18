using Rcbi.Entity.Domain;
using Rcbi.Entity.OpenApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Rcbi.Repository
{
    public class FacilityRepository
    {
        /// <summary>
        /// 更新任务号
        /// </summary>
        public bool UpdateTaskNo(string task_no, DateTime start, DateTime end,string Project_Code)
        {
            string sql = @"UPDATE tb_model_af_facilitycheck_value SET task_no=@task_no WHERE CheckDate>=@start AND CheckDate<=@end AND Project_Code=@Project_Code;
                          ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                param.Add(DbHelper.CreateParameter("@start", start));
                param.Add(DbHelper.CreateParameter("@end", end));
                param.Add(DbHelper.CreateParameter("@Project_Code", Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckCheckValues(ModelAfFacilityCheckValue model)
        {
            string sql = "SELECT id FROM tb_model_af_facilitycheck_value WHERE CheckDate=@CheckDate AND Project_Code=@Project_Code AND FacilityName_Code=@FacilityName_Code and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@FacilityName_Code", model.FacilityName_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增附属子设施检查评分明细
        /// </summary>
        public bool AddCheckValues(ModelAfFacilityCheckValue model)
        {
            string sql = "INSERT INTO tb_model_af_facilitycheck_value(FacilityName,FacilityName_Code,CheckMarkValue,CheckDesp,CheckPic,CheckPerson,CheckDate,CheckMemo,Project_Code,task_no,datapushdate,delete_flag,start_mileage,end_mileage) VALUES(@FacilityName,@FacilityName_Code,@CheckMarkValue,@CheckDesp,@CheckPic,@CheckPerson,@CheckDate,@CheckMemo,@Project_Code,@task_no,now(),0,@start_mileage,@end_mileage)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityName", model.FacilityName));
                param.Add(DbHelper.CreateParameter("@FacilityName_Code", model.FacilityName_Code));
                param.Add(DbHelper.CreateParameter("@CheckMarkValue", model.CheckMarkValue));
                param.Add(DbHelper.CreateParameter("@CheckDesp", model.CheckDesp));
                param.Add(DbHelper.CreateParameter("@CheckPic", model.CheckPic));
                param.Add(DbHelper.CreateParameter("@CheckPerson", model.CheckPerson));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@CheckMemo", model.CheckMemo));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新附属子设施检查评分明细
        /// </summary>
        public bool UpdateCheckValues(ModelAfFacilityCheckValue model, string id)
        {
            string sql = "UPDATE tb_model_af_facilitycheck_value SET FacilityName=@FacilityName,FacilityName_Code=@FacilityName_Code,CheckMarkValue=@CheckMarkValue,CheckDesp=@CheckDesp,CheckPic=@CheckPic,CheckPerson=@CheckPerson,CheckDate=@CheckDate,CheckMemo=@CheckMemo,Project_Code=@Project_Code,start_mileage=@start_mileage,end_mileage=@end_mileage WHERE id=@id";

            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityName", model.FacilityName));
                param.Add(DbHelper.CreateParameter("@FacilityName_Code", model.FacilityName_Code));
                param.Add(DbHelper.CreateParameter("@CheckMarkValue", model.CheckMarkValue));
                param.Add(DbHelper.CreateParameter("@CheckDesp", model.CheckDesp));
                param.Add(DbHelper.CreateParameter("@CheckPic", model.CheckPic));
                param.Add(DbHelper.CreateParameter("@CheckPerson", model.CheckPerson));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@CheckMemo", model.CheckMemo));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckList(ModelAfFacilitylist model)
        {
            string sql = "SELECT id FROM tb_model_AF_FacilityList WHERE Project_Code=@Project_Code AND FacilityCode=@FacilityCode and (delete_flag is null or delete_flag=0)"; // CheckDate=@CheckDate AND
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
               // param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@FacilityCode", model.FacilityCode));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }


        /// <summary>
        /// 新增附属设施清单
        /// </summary>
        public bool AddList(ModelAfFacilitylist model)
        {
            string sql = "INSERT INTO tb_model_AF_FacilityList(FacilityCategory_Name,FacilityCategory_Code,FacilityName,FacilityCode,Project_Code,CheckDate,datapushdate,delete_flag,FacilitySubCategoryCode,LineCode,start_mileage,end_mileage,activedate) VALUES(@FacilityCategory_Name,@FacilityCategory_Code,@FacilityName,@FacilityCode,@Project_Code,@CheckDate,now(),0,@FacilitySubCategoryCode,@LineCode,@start_mileage,@end_mileage,@activedate)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@FacilityName", model.FacilityName));
                param.Add(DbHelper.CreateParameter("@FacilityCode", model.FacilityCode));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                //v2
                param.Add(DbHelper.CreateParameter("@FacilitySubCategoryCode", model.FacilitySubCategoryCode));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@activedate", model.activedate));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新附属设施清单
        /// </summary>
        public bool UpdateList(ModelAfFacilitylist model, string id)
        {
            string sql = "UPDATE tb_model_AF_FacilityList SET FacilityCategory_Name=@FacilityCategory_Name,FacilityCategory_Code=@FacilityCategory_Code,FacilityName=@FacilityName,FacilityCode=@FacilityCode,Project_Code=@Project_Code,CheckDate=@CheckDate ,FacilitySubCategoryCode=@FacilitySubCategoryCode,LineCode=@LineCode,start_mileage=@start_mileage,end_mileage=@end_mileage,activedate=@activedate WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@FacilityName", model.FacilityName));
                param.Add(DbHelper.CreateParameter("@FacilityCode", model.FacilityCode));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@id", id));

                //v2
                param.Add(DbHelper.CreateParameter("@FacilitySubCategoryCode", model.FacilitySubCategoryCode));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@activedate", model.activedate));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }





        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckMarkSpec(ModelAFFacilityMarkSpec model)
        {
            string sql = "SELECT id FROM tb_model_AF_FacilityMarkSpec WHERE Project_Code=@Project_Code AND FacilityCategory_Code=@FacilityCategory_Code AND facility_type=@facility_type";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }


        /// <summary>
        /// 新增附属设施清单
        /// </summary>
        public bool AddMarkSpec(ModelAFFacilityMarkSpec model)
        {
            string sql = "INSERT INTO tb_model_AF_FacilityMarkSpec(Project_Code,FacilityCategory_Name,FacilityCategory_Code,FacilityMark,FacilityStatusDesp,facility_type) VALUES(@Project_Code,@FacilityCategory_Name,@FacilityCategory_Code,@FacilityMark,@FacilityStatusDesp,@facility_type)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@FacilityMark", model.FacilityMark));
                param.Add(DbHelper.CreateParameter("@FacilityStatusDesp", model.FacilityStatusDesp));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新附属设施清单
        /// </summary>
        public bool UpdateMarkSpec(ModelAFFacilityMarkSpec model, string id)
        {
            string sql = "UPDATE tb_model_AF_FacilityMarkSpec SET Project_Code=@Project_Code,FacilityCategory_Name=@FacilityCategory_Name,FacilityCategory_Code=@FacilityCategory_Code,FacilityMark=@FacilityMark,FacilityStatusDesp=@FacilityStatusDesp  WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@FacilityMark", model.FacilityMark));
                param.Add(DbHelper.CreateParameter("@FacilityStatusDesp", model.FacilityStatusDesp));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckNum(ModelAFFacilityNum model)
        {
            string sql = "SELECT id FROM tb_model_AF_FacilityNum WHERE Project_Code=@Project_Code AND FacilityCategory_Code=@FacilityCategory_Code";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }


        /// <summary>
        /// 新增附属设施清单
        /// </summary>
        public bool AddNum(ModelAFFacilityNum model)
        {
            string sql = "INSERT INTO tb_model_AF_FacilityNum(FacilityCategory_Name,FacilityCategory_Code,Number,Project_Code) VALUES(@FacilityCategory_Name,@FacilityCategory_Code,@Number,@Project_Code)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@Number", model.Number));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新附属设施清单
        /// </summary>
        public bool UpdateNum(ModelAFFacilityNum model, string id)
        {
            string sql = "UPDATE tb_model_AF_FacilityNum SET FacilityCategory_Name=@FacilityCategory_Name,FacilityCategory_Code=@FacilityCategory_Code,Number=@Number,Project_Code=@Project_Code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@Number", model.Number));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckTypeWeight(ModelAFTypeWeight model)
        {
            string sql = "SELECT id FROM tb_model_AF_Type_weight WHERE Project_Code=@Project_Code AND TypeCode=@TypeCode AND facility_type=@facility_type";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@TypeCode", model.TypeCode));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }


        /// <summary>
        /// 新增附属设施清单
        /// </summary>
        public bool AddTypeWeight(ModelAFTypeWeight model)
        {
            string sql = "INSERT INTO tb_model_AF_Type_weight(TypeName,TypeCode,Weight,ParentType,Importance,Level,Project_Code,facility_type) VALUES(@TypeName,@TypeCode,@Weight,@ParentType,@Importance,@Level,@Project_Code,@facility_type)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@TypeName", model.TypeName));
                param.Add(DbHelper.CreateParameter("@TypeCode", model.TypeCode));
                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));
                param.Add(DbHelper.CreateParameter("@ParentType", model.ParentType));
                param.Add(DbHelper.CreateParameter("@Importance", model.Importance));
                param.Add(DbHelper.CreateParameter("@Level", model.Level));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新附属设施清单
        /// </summary>
        public bool UpdateTypeWeight(ModelAFTypeWeight model, string id)
        {
            string sql = "UPDATE tb_model_AF_Type_weight SET TypeName=@TypeName,TypeCode=@TypeCode,Weight=@Weight,ParentType=@ParentType,Importance=@Importance,Level=@Level,Project_Code=@Project_Code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@TypeName", model.TypeName));
                param.Add(DbHelper.CreateParameter("@TypeCode", model.TypeCode));
                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));
                param.Add(DbHelper.CreateParameter("@ParentType", model.ParentType));
                param.Add(DbHelper.CreateParameter("@Importance", model.Importance));
                param.Add(DbHelper.CreateParameter("@Level", model.Level));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckBridgeTypeWeight(Modelbridgetypeweight model)
        {
            string sql = "SELECT id FROM tb_model_bridge_af_type_weight_2 WHERE  TypeCode=@TypeCode AND facility_type=@facility_type AND Level=@Level";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@TypeCode", model.TypeCode));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                param.Add(DbHelper.CreateParameter("@Level", model.Level));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }


        /// <summary>
        /// 新增附属设施清单
        /// </summary>
        public bool AddTypeWeight(Modelbridgetypeweight model)
        {
            string sql = "INSERT INTO tb_model_bridge_af_type_weight_2(TypeName,TypeCode,Weight,ParentType,Importance,Level,facility_type) VALUES(@TypeName,@TypeCode,@Weight,@ParentType,@Importance,@Level,@facility_type)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@TypeName", model.TypeName));
                param.Add(DbHelper.CreateParameter("@TypeCode", model.TypeCode));
                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));
                param.Add(DbHelper.CreateParameter("@ParentType", model.ParentType));
                param.Add(DbHelper.CreateParameter("@Importance", model.Importance));
                param.Add(DbHelper.CreateParameter("@Level", model.Level));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新附属设施清单
        /// </summary>
        public bool UpdateTypeWeight(Modelbridgetypeweight model, string id)
        {
            string sql = "UPDATE tb_model_bridge_af_type_weight_2 SET TypeName=@TypeName,TypeCode=@TypeCode,Weight=@Weight,ParentType=@ParentType,Importance=@Importance,Level=@Level,facility_type=@facility_type WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@TypeName", model.TypeName));
                param.Add(DbHelper.CreateParameter("@TypeCode", model.TypeCode));
                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));
                param.Add(DbHelper.CreateParameter("@ParentType", model.ParentType));
                param.Add(DbHelper.CreateParameter("@Importance", model.Importance));
                param.Add(DbHelper.CreateParameter("@Level", model.Level));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        /// <summary>
        /// 附属设施总体评价结果
        /// </summary>
        public ModelAFResult GetModelAFResult(string task_no)
        {
            string sql = "select * from tb_model_af_result where task_no=@task_no and (delete_flag is null or delete_flag=0) limit 0,1"; 
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderObject<ModelAFResult>(sql,
                    CommandType.Text, DbHelper.CreateParameter("@task_no", task_no));
            }
        }

        /// <summary>
        /// 附属分设施评价结果
        /// </summary>
        public IList<ModelAFResultType> GetModelAFResultTypes(string task_no)
        {
            string sql = "select * from tb_model_af_result_type where task_no=@task_no and (delete_flag is null or delete_flag=0)";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelAFResultType>(sql,
                    CommandType.Text, DbHelper.CreateParameter("@task_no", task_no));
            }
        }
        /// <summary>
        ///  附属设施线路评价结果表 v2
        /// </summary>
        public IList<ModelAFResultLine> GetModelAFResultLine(string task_no)
        {
            string sql = "select * from tb_model_af_result_line where task_no=@task_no and (delete_flag is null or delete_flag=0)";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelAFResultLine>(sql,
                    CommandType.Text, DbHelper.CreateParameter("@task_no", task_no));
            }
        }

        /// <summary>
        /// 附属子设施评价结果
        /// </summary>
        public IList<ModelAFResultCategory> GetModelAFResultCategorys(string task_no)
        {
            string sql = "select * from tb_model_af_result_category where task_no=@task_no and (delete_flag is null or delete_flag=0)";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelAFResultCategory>(sql,
                    CommandType.Text, DbHelper.CreateParameter("@task_no", task_no));
            }
        }


        #region 附属子设施检查评分明细Web 
        public IList<ModelAfCheckValueQuery> GetModelAfCheckValueList(ModelAfCheckValueQuery model, out int count)
        {
            string sql = "select * from tb_model_af_facilitycheck_value where task_no=@task_no AND project_code=@project_code  AND delete_flag=0 limit @page,@count";
            string count_sql = "select count(1) from tb_model_af_facilitycheck_value where  task_no=@task_no AND project_code=@project_code  AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                       DbHelper.CreateParameter("@task_no", model.task_no),
                       DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelAfCheckValueQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool DeleteModelAfCheckValue(int id)
        {
            string sql = "UPDATE tb_model_af_facilitycheck_value SET delete_flag=1 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        public bool DeleteModelAfCheckValue(string task_no)
        {
            string sql = "UPDATE tb_model_af_facilitycheck_value SET delete_flag=1 WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelAfCheckValue(ModelAfCheckValueQuery model)
        {
            string sql = "INSERT INTO tb_model_af_facilitycheck_value(FacilityName,FacilityName_Code,CheckMarkValue,CheckDesp,CheckPic,CheckPerson,CheckDate,CheckMemo,Project_Code,task_no,delete_flag,datapushdate) VALUES(@FacilityName,@FacilityName_Code,@CheckMarkValue,@CheckDesp,@CheckPic,@CheckPerson,@CheckDate,@CheckMemo,@project_code,@task_no,0,now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityName", model.FacilityName));
                param.Add(DbHelper.CreateParameter("@FacilityName_Code", model.FacilityName_Code));
                param.Add(DbHelper.CreateParameter("@CheckMarkValue", model.CheckMarkValue));
                param.Add(DbHelper.CreateParameter("@CheckDesp", model.CheckDesp));
                param.Add(DbHelper.CreateParameter("@CheckPic", model.CheckPic));
                param.Add(DbHelper.CreateParameter("@CheckPerson", model.CheckPerson));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@CheckMemo", model.CheckMemo));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelAfCheckValueList(List<ModelAfCheckValueQuery> list)
        {
            string sql = "INSERT INTO tb_model_af_facilitycheck_value(FacilityName,FacilityName_Code,CheckMarkValue,CheckDesp,CheckPic,CheckPerson,CheckDate,CheckMemo,Project_Code,task_no,delete_flag,datapushdate) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@FacilityName{0},@FacilityName_Code{0},@CheckMarkValue{0},@CheckDesp{0},@CheckPic{0},@CheckPerson{0},@CheckDate{0},@CheckMemo{0},@project_code{0},@task_no{0},0,now())", i));
                    param.Add(DbHelper.CreateParameter("@FacilityName"+i, model.FacilityName));
                    param.Add(DbHelper.CreateParameter("@FacilityName_Code" + i, model.FacilityName_Code));
                    param.Add(DbHelper.CreateParameter("@CheckMarkValue" + i, model.CheckMarkValue));
                    param.Add(DbHelper.CreateParameter("@CheckDesp" + i, model.CheckDesp));
                    param.Add(DbHelper.CreateParameter("@CheckPic" + i, model.CheckPic));
                    param.Add(DbHelper.CreateParameter("@CheckPerson" + i, model.CheckPerson));
                    param.Add(DbHelper.CreateParameter("@CheckDate" + i, model.CheckDate));
                    param.Add(DbHelper.CreateParameter("@CheckMemo" + i, model.CheckMemo));
                    param.Add(DbHelper.CreateParameter("@project_code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelAfCheckValue(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_af_facilitycheck_value SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 附属分设施评价结果
        /// </summary>
        public IList<ModelAfFacilitylist> GetModelAfFacilityList(string project_code)
        {
            string sql = "select * from tb_model_AF_FacilityList where project_code=@Project_Code and (delete_flag is null or delete_flag=0)";
            using (var DbHelper = DBManager.CoreHelper)
            {
                return DbHelper.ExecuteReaderList<ModelAfFacilitylist>(sql,
                    CommandType.Text, DbHelper.CreateParameter("@Project_Code", project_code));
            }
        }
        #endregion


        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckList(ModelAfFacilitylist2 model)
        {
            string sql = "SELECT id FROM tb_model_bridge_af_facilitylist_2 WHERE Project_Code=@Project_Code AND FacilityCode=@FacilityCode and (delete_flag is null or delete_flag=0)"; // CheckDate=@CheckDate AND
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                // param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.project_code));
                param.Add(DbHelper.CreateParameter("@FacilityCode", model.FacilityCode));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增附属设施清单
        /// </summary>
        public bool AddList(ModelAfFacilitylist2 model)
        {
            string sql = "INSERT INTO tb_model_bridge_af_facilitylist_2(FacilityCategory_Name,FacilityCategory_Code,FacilityName,FacilityCode,Project_Code,CheckDate,datapushdate,delete_flag,FacilitySubCategoryCode,LineCode,start_mileage,end_mileage,activedate) VALUES(@FacilityCategory_Name,@FacilityCategory_Code,@FacilityName,@FacilityCode,@Project_Code,@CheckDate,now(),0,@FacilitySubCategoryCode,@LineCode,@start_mileage,@end_mileage,@activedate)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@FacilityName", model.FacilityName));
                param.Add(DbHelper.CreateParameter("@FacilityCode", model.FacilityCode));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.project_code));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                //v2
                param.Add(DbHelper.CreateParameter("@FacilitySubCategoryCode", model.FacilitySubCategoryCode));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@activedate", model.activedate));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新附属设施清单
        /// </summary>
        public bool UpdateList(ModelAfFacilitylist2 model, string id)
        {
            string sql = "UPDATE tb_model_bridge_af_facilitylist_2 SET FacilityCategory_Name=@FacilityCategory_Name,FacilityCategory_Code=@FacilityCategory_Code,FacilityName=@FacilityName,FacilityCode=@FacilityCode,Project_Code=@Project_Code,CheckDate=@CheckDate ,FacilitySubCategoryCode=@FacilitySubCategoryCode,LineCode=@LineCode,start_mileage=@start_mileage,end_mileage=@end_mileage,activedate=@activedate,delete_flag=@delete_flag WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@FacilityName", model.FacilityName));
                param.Add(DbHelper.CreateParameter("@FacilityCode", model.FacilityCode));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.project_code));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@id", id));

                //v2
                param.Add(DbHelper.CreateParameter("@FacilitySubCategoryCode", model.FacilitySubCategoryCode));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@activedate", model.activedate));
                param.Add(DbHelper.CreateParameter("@delete_flag", model.delete_flag==true?1:0));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckCheckValues(ModelAfFacilityCheckValue2 model)
        {
            string sql = "SELECT id FROM tb_model_bridge_af_facilitycheck_value_2 WHERE CheckDate=@CheckDate AND Project_Code=@Project_Code AND FacilityName_Code=@FacilityName_Code and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@FacilityName_Code", model.FacilityName_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增附属子设施检查评分明细
        /// </summary>
        public bool AddCheckValues(ModelAfFacilityCheckValue2 model)
        {
            string sql = "INSERT INTO tb_model_bridge_af_facilitycheck_value_2(FacilityName,FacilityName_Code,CheckMarkValue,CheckDesp,CheckPic,CheckPerson,CheckDate,CheckMemo,Project_Code,task_no,datapushdate,delete_flag,start_mileage,end_mileage) VALUES(@FacilityName,@FacilityName_Code,@CheckMarkValue,@CheckDesp,@CheckPic,@CheckPerson,@CheckDate,@CheckMemo,@Project_Code,@task_no,now(),0,@start_mileage,@end_mileage)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityName", model.FacilityName));
                param.Add(DbHelper.CreateParameter("@FacilityName_Code", model.FacilityName_Code));
                param.Add(DbHelper.CreateParameter("@CheckMarkValue", model.CheckMarkValue));
                param.Add(DbHelper.CreateParameter("@CheckDesp", model.CheckDesp));
                param.Add(DbHelper.CreateParameter("@CheckPic", model.CheckPic));
                param.Add(DbHelper.CreateParameter("@CheckPerson", model.CheckPerson));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@CheckMemo", model.CheckMemo));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新附属子设施检查评分明细
        /// </summary>
        public bool UpdateCheckValues(ModelAfFacilityCheckValue2 model, string id)
        {
            string sql = "UPDATE tb_model_bridge_af_facilitycheck_value_2 SET FacilityName=@FacilityName,FacilityName_Code=@FacilityName_Code,CheckMarkValue=@CheckMarkValue,CheckDesp=@CheckDesp,CheckPic=@CheckPic,CheckPerson=@CheckPerson,CheckDate=@CheckDate,CheckMemo=@CheckMemo,Project_Code=@Project_Code,start_mileage=@start_mileage,end_mileage=@end_mileage,delete_flag=@delete_flag WHERE id=@id";

            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityName", model.FacilityName));
                param.Add(DbHelper.CreateParameter("@FacilityName_Code", model.FacilityName_Code));
                param.Add(DbHelper.CreateParameter("@CheckMarkValue", model.CheckMarkValue));
                param.Add(DbHelper.CreateParameter("@CheckDesp", model.CheckDesp));
                param.Add(DbHelper.CreateParameter("@CheckPic", model.CheckPic));
                param.Add(DbHelper.CreateParameter("@CheckPerson", model.CheckPerson));
                param.Add(DbHelper.CreateParameter("@CheckDate", model.CheckDate));
                param.Add(DbHelper.CreateParameter("@CheckMemo", model.CheckMemo));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@delete_flag", model.delete_flag==true?1:0));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 数据重复验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RepeatCheckbridgeMarkSpec(Modelbridgefacilitymarkspec model)
        {
            string sql = "SELECT id FROM tb_model_bridge_af_facilitymarkspec_2 WHERE  FacilityCategory_Code=@FacilityCategory_Code AND facility_type=@facility_type and FacilityMark=@FacilityMark";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                param.Add(DbHelper.CreateParameter("@FacilityMark", model.FacilityMark));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }


        /// <summary>
        /// 新增附属设施清单
        /// </summary>
        public bool AddMarkSpec(Modelbridgefacilitymarkspec model)
        {
            string sql = "INSERT INTO tb_model_bridge_af_facilitymarkspec_2(FacilityCategory_Name,FacilityCategory_Code,FacilityMark,FacilityStatusDesp,facility_type) VALUES(@FacilityCategory_Name,@FacilityCategory_Code,@FacilityMark,@FacilityStatusDesp,@facility_type)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@FacilityMark", model.FacilityMark));
                param.Add(DbHelper.CreateParameter("@FacilityStatusDesp", model.FacilityStatusDesp));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新附属设施清单
        /// </summary>
        public bool UpdateMarkSpec(Modelbridgefacilitymarkspec model, string id)
        {
            string sql = "UPDATE tb_model_bridge_af_facilitymarkspec_2 SET FacilityCategory_Name=@FacilityCategory_Name,FacilityCategory_Code=@FacilityCategory_Code,FacilityMark=@FacilityMark,FacilityStatusDesp=@FacilityStatusDesp  WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Name", model.FacilityCategory_Name));
                param.Add(DbHelper.CreateParameter("@FacilityCategory_Code", model.FacilityCategory_Code));
                param.Add(DbHelper.CreateParameter("@FacilityMark", model.FacilityMark));
                param.Add(DbHelper.CreateParameter("@FacilityStatusDesp", model.FacilityStatusDesp));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
    }
}
