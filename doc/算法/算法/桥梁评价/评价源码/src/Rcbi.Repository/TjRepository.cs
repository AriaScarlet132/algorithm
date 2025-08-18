using Rcbi.Entity.Domain;
using Rcbi.Entity.OpenApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Rcbi.Repository
{
    public class TjRepository
    {

        /// <summary>
        /// 更新任务号
        /// </summary>
        public bool UpdateTaskNo(string task_no, DateTime start, DateTime end, string Project_Code)
        {
            string sql = @"UPDATE tb_model_tj_data_defects SET task_no=@task_no WHERE Date>=@start AND Date<=@end AND Project_Code=@Project_Code;
                           UPDATE tb_model_tj_data_deformation SET task_no=@task_no WHERE Date>=@start AND Date<=@end AND Project_Code=@Project_Code;
                           UPDATE tb_model_tj_data_sedimentation SET task_no=@task_no WHERE Start_Date>=@start AND End_Date<=@end AND Project_Code=@Project_Code;";
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


        #region tb_model_tj_data_defects
        /// <summary>
        /// 数据重复验证tb_model_tj_data_defects
        /// </summary>
        public string RepeatCheckModelTjDataDefects(ModelTjDataDefects model)
        {
            string sql = "SELECT id FROM tb_model_tj_data_defects WHERE Date=@Date AND Line=@Line AND Project_Code=@Project_Code AND RingNumber=@RingNumber AND StructureSection=@StructureSection and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Date", model.Date));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@RingNumber", model.RingNumber));
                param.Add(DbHelper.CreateParameter("@StructureSection", model.StructureSection));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_data_defects
        /// </summary>
        public bool AddModelTjDataDefects(ModelTjDataDefects model)
        {
            string sql = "INSERT INTO tb_model_tj_data_defects(Date,Line,StructureSection,ManagementUnit,StructureAtt,StructureType,ComponentType,Mileage,Defect,DefectType,DefectSeverity,DefectDescription,RingNumber,Project_Code,task_no,datapushdate,delete_flag,LineCode,SectionName,SectionCode) VALUES(@Date,@Line,@StructureSection,@ManagementUnit,@StructureAtt,@StructureType,@ComponentType,@Mileage,@Defect,@DefectType,@DefectSeverity,@DefectDescription,@RingNumber,@Project_Code,@task_no,now(),0,@LineCode,@SectionName,@SectionCode)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Date", model.Date));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@StructureSection", model.StructureSection));
                param.Add(DbHelper.CreateParameter("@ManagementUnit", model.ManagementUnit));
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@Defect", model.Defect));
                param.Add(DbHelper.CreateParameter("@DefectType", model.DefectType));
                param.Add(DbHelper.CreateParameter("@DefectSeverity", model.DefectSeverity));
                param.Add(DbHelper.CreateParameter("@DefectDescription", model.DefectDescription));
                param.Add(DbHelper.CreateParameter("@RingNumber", model.RingNumber));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@SectionName", model.SectionName));
                param.Add(DbHelper.CreateParameter("@SectionCode", model.SectionCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_data_defects
        /// </summary>
        public bool UpdateModelTjDataDefects(ModelTjDataDefects model, string id)
        {
            string sql = "UPDATE tb_model_tj_data_defects SET Date=@Date,Line=@Line,StructureSection=@StructureSection,ManagementUnit=@ManagementUnit,StructureAtt=@StructureAtt,StructureType=@StructureType,ComponentType=@ComponentType,Mileage=@Mileage,Defect=@Defect,DefectType=@DefectType,DefectSeverity=@DefectSeverity,DefectDescription=@DefectDescription,RingNumber=@RingNumber,Project_Code=@Project_Code,LineCode=@LineCode,SectionName=@SectionName,SectionCode=@SectionCode WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Date", model.Date));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@StructureSection", model.StructureSection));
                param.Add(DbHelper.CreateParameter("@ManagementUnit", model.ManagementUnit));
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@Defect", model.Defect));
                param.Add(DbHelper.CreateParameter("@DefectType", model.DefectType));
                param.Add(DbHelper.CreateParameter("@DefectSeverity", model.DefectSeverity));
                param.Add(DbHelper.CreateParameter("@DefectDescription", model.DefectDescription));
                param.Add(DbHelper.CreateParameter("@RingNumber", model.RingNumber));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));

                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@SectionName", model.SectionName));
                param.Add(DbHelper.CreateParameter("@SectionCode", model.SectionCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_tj_data_deformation
        /// <summary>
        /// 数据重复验证tb_model_tj_data_deformation
        /// </summary>
        public string RepeatCheckModelTjDataDeformation(ModelTjDataDeformation model)
        {
            string sql = "SELECT id FROM tb_model_tj_data_deformation WHERE Date=@Date AND Project_Code=@Project_Code AND Code=@Code AND Station=@Station and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Date", model.Date));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Station", model.Station));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_data_deformation
        /// </summary>
        public bool AddModelTjDataDeformation(ModelTjDataDeformation model)
        {
            string sql = "INSERT INTO tb_model_tj_data_deformation(Date,Code,Station,ValueName,ValueCode,DeformationValue,Project_Code,task_no,datapushdate,delete_flag,Value) VALUES(@Date,@Code,@Station,@ValueName,@ValueCode,@DeformationValue,@Project_Code,@task_no,now(),0,@Value)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Date", model.Date));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Station", model.Station));
                param.Add(DbHelper.CreateParameter("@ValueName", model.ValueName));
                param.Add(DbHelper.CreateParameter("@ValueCode", model.ValueCode));
                param.Add(DbHelper.CreateParameter("@DeformationValue", model.DeformationValue));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));

                //param.Add(DbHelper.CreateParameter("@deformationValue", model.deformationValue));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_data_deformation
        /// </summary>
        public bool UpdateModelTjDataDeformation(ModelTjDataDeformation model, string id)
        {
            string sql = "UPDATE tb_model_tj_data_deformation SET Date=@Date,Code=@Code,Station=@Station,ValueName=@ValueName,ValueCode=@ValueCode,DeformationValue=@DeformationValue,Project_Code=@Project_Code,Value=@Value WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Date", model.Date));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Station", model.Station));
                param.Add(DbHelper.CreateParameter("@ValueName", model.ValueName));
                param.Add(DbHelper.CreateParameter("@ValueCode", model.ValueCode));
                param.Add(DbHelper.CreateParameter("@DeformationValue", model.DeformationValue));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@id", id));

                //param.Add(DbHelper.CreateParameter("@deformationValue", model.deformationValue));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_tj_data_diffsedimentation v2

        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelTjDataDiffsedimentation(ModelTjDataDiffsedimentation model)
        {
            string sql = "SELECT ID FROM tb_model_tj_data_diffsedimentation WHERE task_no=@task_no AND project_code=@project_code and LineCode=@LineCode  and section_code=@section_code ;";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }


        /// <summary>
        /// 新增 tb_model_tj_data_diffsedimentation v2  待评价项目的收敛变形差异信息表
        /// </summary>
        public bool AddModelTjDataDiffsedimentation(ModelTjDataDiffsedimentation model)
        {
            string sql = "INSERT INTO tb_model_tj_data_diffsedimentation(LineCode,StructureType,section_code,start_mileage,end_mileage,Value,date,project_code,task_no) VALUES(@LineCode,@StructureType,@section_code,@start_mileage,@end_mileage,@Value,@date,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_data_diffsedimentation v2  待评价项目的收敛变形差异信息表
        /// </summary>
        public bool UpdateModelTjDataDiffsedimentation(ModelTjDataDiffsedimentation model, int id)
        {
            string sql = "UPDATE tb_model_tj_data_diffsedimentation SET LineCode=@LineCode,StructureType=@StructureType,section_code=@section_code,start_mileage=@start_mileage,end_mileage=@end_mileage,Value=@Value,date=@date,project_code=@project_code,task_no=@task_no WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@id", id));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion



        #region tb_model_tj_data_diffsedimentation v2
        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelTjDataLeakage(ModelTjDataLeakage model)
        {
            string sql = "SELECT ID FROM tb_model_tj_data_leakage WHERE task_no=@task_no AND project_code=@project_code and LineCode=@LineCode  and section_code=@section_code ;";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增 tb_model_tj_data_diffsedimentation v2  待评价项目的平均渗水量记录信息表
        /// </summary>
        public bool AddModelTjDataLeakage(ModelTjDataLeakage model)
        {
            string sql = "INSERT INTO tb_model_tj_data_leakage(LineCode,StructureType,section_code,start_mileage,end_mileage,Value,date,project_code,task_no) VALUES(@LineCode,@StructureType,@section_code,@start_mileage,@end_mileage,@Value,@date,@project_code,@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_data_diffsedimentation v2  待评价项目的平均渗水量记录信息表
        /// </summary>
        public bool UpdateModelTjDataLeakage(ModelTjDataLeakage model, int id)
        {
            string sql = "UPDATE tb_model_tj_data_leakage SET LineCode=@LineCode,StructureType=@StructureType,section_code=@section_code,start_mileage=@start_mileage,end_mileage=@end_mileage,Value=@Value,date=@date,project_code=@project_code,task_no=@task_no WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@date", model.date));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@id", id));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion


        #region tb_model_tj_data_sedimentation
        /// <summary>
        /// 数据重复验证tb_model_tj_data_sedimentation
        /// </summary>
        public string RepeatCheckModelTjDataSedimentation(ModelTjDataSedimentation model)
        {
            string sql = "SELECT id FROM tb_model_tj_data_sedimentation WHERE Station=@Station AND Project_Code=@Project_Code AND Start_Date=@Start_Date AND End_Date=@End_Date and (delete_flag is null or delete_flag=0) and task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Station", model.Station));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Start_Date", model.Start_Date));
                param.Add(DbHelper.CreateParameter("@End_Date", model.End_Date));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_data_sedimentation
        /// </summary>
        public bool AddModelTjDataSedimentation(ModelTjDataSedimentation model)
        {
            string sql = "INSERT INTO tb_model_tj_data_sedimentation(Start_Date,End_Date,Station,Code_R,Value_R,Code_L,Value_L,Project_Code,task_no,datapushdate,delete_flag,Code,Value,Sedimentation) VALUES(@Start_Date,@End_Date,@Station,@Code_R,@Value_R,@Code_L,@Value_L,@Project_Code,@task_no,now(),0,@Code,@Value,@Sedimentation)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Start_Date", model.Start_Date));
                param.Add(DbHelper.CreateParameter("@End_Date", model.End_Date));
                param.Add(DbHelper.CreateParameter("@Station", model.Station));
                param.Add(DbHelper.CreateParameter("@Code_R", model.Code_R));
                param.Add(DbHelper.CreateParameter("@Value_R", model.Value_R));
                param.Add(DbHelper.CreateParameter("@Code_L", model.Code_L));
                param.Add(DbHelper.CreateParameter("@Value_L", model.Value_L));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", model.TaskNo));

                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@Sedimentation", model.Sedimentation));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_data_sedimentation
        /// </summary>
        public bool UpdateModelTjDataSedimentation(ModelTjDataSedimentation model, string id)
        {
            string sql = "UPDATE tb_model_tj_data_sedimentation SET Start_Date=@Start_Date,End_Date=@End_Date,Station=@Station,Code_R=@Code_R,Value_R=@Value_R,Code_L=@Code_L,Value_L=@Value_L,Project_Code=@Project_Code,Code=@Code,Value=@Value,Sedimentation=@Sedimentation WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Start_Date", model.Start_Date));
                param.Add(DbHelper.CreateParameter("@End_Date", model.End_Date));
                param.Add(DbHelper.CreateParameter("@Station", model.Station));
                param.Add(DbHelper.CreateParameter("@Code_R", model.Code_R));
                param.Add(DbHelper.CreateParameter("@Value_R", model.Value_R));
                param.Add(DbHelper.CreateParameter("@Code_L", model.Code_L));
                param.Add(DbHelper.CreateParameter("@Value_L", model.Value_L));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));

                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@Sedimentation", model.Sedimentation));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_tj_data_segmentring
        /// <summary>
        /// 数据重复验证tb_model_tj_data_segmentring
        /// </summary>
        public string RepeatCheckModelTjDataSegmentring(ModelTjDataSegmentring model)
        {
            //string sql = "SELECT id FROM tb_model_tj_data_segmentring WHERE Line=@Line AND Code=@Code AND Project_Code=@Project_Code and (delete_flag is null or delete_flag=0)";
            string sql = "SELECT id FROM tb_model_tj_data_segmentring WHERE Line=@Line AND Code=@Code AND Project_Code=@Project_Code and (delete_flag is null or delete_flag=0) and section=@section";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@section", model.Section));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_data_segmentring
        /// </summary>
        public bool AddModelTjDataSegmentring(ModelTjDataSegmentring model)
        {
            string sql = "INSERT INTO tb_model_tj_data_segmentring(Line,Code,Name,RingNumber,Start_Mileage,End_Mileage,Section,Project_Code,datapushdate,delete_flag) VALUES(@Line,@Code,@Name,@RingNumber,@Start_Mileage,@End_Mileage,@Section,@Project_Code,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Name", model.Name));
                param.Add(DbHelper.CreateParameter("@RingNumber", model.RingNumber));
                param.Add(DbHelper.CreateParameter("@Start_Mileage", model.Start_Mileage));
                param.Add(DbHelper.CreateParameter("@End_Mileage", model.End_Mileage));
                param.Add(DbHelper.CreateParameter("@Section", model.Section));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_data_segmentring
        /// </summary>
        public bool UpdateModelTjDataSegmentring(ModelTjDataSegmentring model, string id)
        {
            string sql = "UPDATE tb_model_tj_data_segmentring SET Line=@Line,Code=@Code,Name=@Name,RingNumber=@RingNumber,Start_Mileage=@Start_Mileage,End_Mileage=@End_Mileage,Section=@Section,Project_Code=@Project_Code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Name", model.Name));
                param.Add(DbHelper.CreateParameter("@RingNumber", model.RingNumber));
                param.Add(DbHelper.CreateParameter("@Start_Mileage", model.Start_Mileage));
                param.Add(DbHelper.CreateParameter("@End_Mileage", model.End_Mileage));
                param.Add(DbHelper.CreateParameter("@Section", model.Section));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_tj_data_structurefacility
        /// <summary>
        /// 数据重复验证tb_model_tj_data_structurefacility
        /// </summary>
        public string RepeatCheckModelTjDataStructurefacility(ModelTjDataStructurefacility model)
        {
            string sql = "SELECT id FROM tb_model_tj_data_structurefacility WHERE Code=@Code AND Project_Code=@Project_Code AND Line=@Line and (delete_flag is null or delete_flag=0) and Code_Section=@Code_Section";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@Code_Section", model.Code_Section));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_data_structurefacility
        /// </summary>
        public bool AddModelTjDataStructurefacility(ModelTjDataStructurefacility model)
        {
            string sql = "INSERT INTO tb_model_tj_data_structurefacility(Code,Name,ManagementUnit,Line,StructureAtt,StructureType,ComponentType,Start_Mileage,End_Mileage,Code_Section,Project_Code,datapushdate,delete_flag,LineCode,SectionName,SectionCode,ComponentCode) VALUES(@Code,@Name,@ManagementUnit,@Line,@StructureAtt,@StructureType,@ComponentType,@Start_Mileage,@End_Mileage,@Code_Section,@Project_Code,now(),0,@LineCode,@SectionName,@SectionCode,@ComponentCode)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Name", model.Name));
                param.Add(DbHelper.CreateParameter("@ManagementUnit", model.ManagementUnit));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Start_Mileage", model.Start_Mileage));
                param.Add(DbHelper.CreateParameter("@End_Mileage", model.End_Mileage));
                param.Add(DbHelper.CreateParameter("@Code_Section", model.Code_Section));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));

                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@SectionName", model.SectionName));
                param.Add(DbHelper.CreateParameter("@SectionCode", model.SectionCode));
                param.Add(DbHelper.CreateParameter("@ComponentCode", model.ComponentCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_data_structurefacility
        /// </summary>
        public bool UpdateModelTjDataStructurefacility(ModelTjDataStructurefacility model, string id)
        {
            string sql = "UPDATE tb_model_tj_data_structurefacility SET Code=@Code,Name=@Name,ManagementUnit=@ManagementUnit,Line=@Line,StructureAtt=@StructureAtt,StructureType=@StructureType,ComponentType=@ComponentType,Start_Mileage=@Start_Mileage,End_Mileage=@End_Mileage,Code_Section=@Code_Section,Project_Code=@Project_Code,LineCode=@LineCode,SectionName=@SectionName,SectionCode=@SectionCode,ComponentCode=@ComponentCode  WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Name", model.Name));
                param.Add(DbHelper.CreateParameter("@ManagementUnit", model.ManagementUnit));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Start_Mileage", model.Start_Mileage));
                param.Add(DbHelper.CreateParameter("@End_Mileage", model.End_Mileage));
                param.Add(DbHelper.CreateParameter("@Code_Section", model.Code_Section));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));

                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@SectionName", model.SectionName));
                param.Add(DbHelper.CreateParameter("@SectionCode", model.SectionCode));
                param.Add(DbHelper.CreateParameter("@ComponentCode", model.ComponentCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_tj_line
        /// <summary>
        /// 数据重复验证tb_model_tj_line
        /// </summary>
        public string RepeatCheckModelTjLine(ModelTjLine model)
        {
            string sql = "SELECT id FROM tb_model_tj_line WHERE Line_no=@Line_no AND Project_Code=@Project_Code and (delete_flag is null or delete_flag=0) and line_l=@line_l";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Line_no", model.Line_no));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@line_l", model.Line_l));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_line
        /// </summary>
        public bool AddModelTjLine(ModelTjLine model)
        {
            string sql = "INSERT INTO tb_model_tj_line(Line_name,Line_no,Line_l,Project_Code,datapushdate,delete_flag) VALUES(@Line_name,@Line_no,@Line_l,@Project_Code,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Line_name", model.Line_name));
                param.Add(DbHelper.CreateParameter("@Line_no", model.Line_no));
                param.Add(DbHelper.CreateParameter("@Line_l", model.Line_l));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_line
        /// </summary>
        public bool UpdateModelTjLine(ModelTjLine model, string id)
        {
            string sql = "UPDATE tb_model_tj_line SET Line_name=@Line_name,Line_no=@Line_no,Line_l=@Line_l,Project_Code=@Project_Code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Line_name", model.Line_name));
                param.Add(DbHelper.CreateParameter("@Line_no", model.Line_no));
                param.Add(DbHelper.CreateParameter("@Line_l", model.Line_l));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_tj_structureclassification
        /// <summary>
        /// 数据重复验证tb_model_tj_structureclassification
        /// </summary>
        public string RepeatCheckModelTjStructureclassification(ModelTjStructureclassification model)
        {
            string sql = "SELECT id FROM tb_model_tj_structureclassification WHERE Project_Code=@Project_Code AND StructureType=@StructureType AND ComponentType=@ComponentType";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_structureclassification
        /// </summary>
        public bool AddModelTjStructureclassification(ModelTjStructureclassification model)
        {
            string sql = "INSERT INTO tb_model_tj_structureclassification(StructureAtt,StructureType,ComponentType,Component_importance,Project_Code,Weight,Defect) VALUES(@StructureAtt,@StructureType,@ComponentType,@Component_importance,@Project_Code,@Weight,@Defect)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Component_importance", model.Component_importance));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));

                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));
                param.Add(DbHelper.CreateParameter("@Defect", model.Defect));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_structureclassification
        /// </summary>
        public bool UpdateModelTjStructureclassification(ModelTjStructureclassification model, string id)
        {
            string sql = "UPDATE tb_model_tj_structureclassification SET StructureAtt=@StructureAtt,StructureType=@StructureType,ComponentType=@ComponentType,Component_importance=@Component_importance,Project_Code=@Project_Code,Weight=@Weight,Defect=@Defect WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Component_importance", model.Component_importance));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));

                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));
                param.Add(DbHelper.CreateParameter("@Defect", model.Defect));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        /// <summary>
        /// 新增tb_model_tj_structureclassification
        /// </summary>
        public bool AddModelTjStructuretypeweights(ModelTjStructuretypeweights model)
        {
            string sql = "INSERT INTO tb_model_tj_structuretypeweights(ConstructionMethod,StructureType,Weight) VALUES(@ConstructionMethod,@StructureType,@Weight)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ConstructionMethod", model.ConstructionMethod));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_structureclassification
        /// </summary>
        public bool UpdateModelTjStructuretypeweights(ModelTjStructuretypeweights model, int id)
        {
            string sql = "UPDATE tb_model_tj_structuretypeweights SET ConstructionMethod=@ConstructionMethod,StructureType=@StructureType,Weight=@Weight WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ConstructionMethod", model.ConstructionMethod));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@Weight", model.Weight));
                param.Add(DbHelper.CreateParameter("@id", model.ID));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region tb_model_tj_tunnelsection
        /// <summary>
        /// 数据重复验证tb_model_tj_tunnelsection
        /// </summary>
        public string RepeatCheckModelTjTunnelsection(ModelTjTunnelsection model)
        {
            string sql = "SELECT id FROM tb_model_tj_tunnelsection WHERE Line=@Line AND StructureSection=@StructureSection AND Project_Code=@Project_Code and (delete_flag is null or delete_flag=0) and code_section=@code_section";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@StructureSection", model.StructureSection));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@code_section", model.Code_Section));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_tunnelsection
        /// </summary>
        public bool AddModelTjTunnelsection(ModelTjTunnelsection model)
        {
            string sql = "INSERT INTO tb_model_tj_tunnelsection(ManagementUnit,StructureSection,Line,StructureAtt,StructureType,Code_Section,Start_mileage,End_mileage,Project_Code,datapushdate,delete_flag) VALUES(@ManagementUnit,@StructureSection,@Line,@StructureAtt,@StructureType,@Code_Section,@Start_mileage,@End_mileage,@Project_Code,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ManagementUnit", model.ManagementUnit));
                param.Add(DbHelper.CreateParameter("@StructureSection", model.StructureSection));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@Code_Section", model.Code_Section));
                param.Add(DbHelper.CreateParameter("@Start_mileage", model.Start_mileage));
                param.Add(DbHelper.CreateParameter("@End_mileage", model.End_mileage));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_tunnelsection
        /// </summary>
        public bool UpdateModelTjTunnelsection(ModelTjTunnelsection model, string id)
        {
            string sql = "UPDATE tb_model_tj_tunnelsection SET ManagementUnit=@ManagementUnit,StructureSection=@StructureSection,Line=@Line,StructureAtt=@StructureAtt,StructureType=@StructureType,Code_Section=@Code_Section,Start_mileage=@Start_mileage,End_mileage=@End_mileage,Project_Code=@Project_Code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ManagementUnit", model.ManagementUnit));
                param.Add(DbHelper.CreateParameter("@StructureSection", model.StructureSection));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@Code_Section", model.Code_Section));
                param.Add(DbHelper.CreateParameter("@Start_mileage", model.Start_mileage));
                param.Add(DbHelper.CreateParameter("@End_mileage", model.End_mileage));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_tj_tunnelstructuretype
        /// <summary>
        /// 数据重复验证tb_model_tj_tunnelstructuretype
        /// </summary>
        public string RepeatCheckModelTjTunnelstructuretype(ModelTjTunnelstructuretype model)
        {
            string sql = "SELECT id FROM tb_model_tj_tunnelstructuretype WHERE Line=@Line AND Code_line=@Code_line AND Project_Code=@Project_Code and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@Code_line", model.Code_line));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_tunnelstructuretype
        /// </summary>
        public bool AddModelTjTunnelstructuretype(ModelTjTunnelstructuretype model)
        {
            string sql = "INSERT INTO tb_model_tj_tunnelstructuretype(Line,Code_line,StructureAtt,Code_StructureAtt,StructureType,Code_StructureType,Project_Code,datapushdate,delete_flag) VALUES(@Line,@Code_line,@StructureAtt,@Code_StructureAtt,@StructureType,@Code_StructureType,@Project_Code,now(),0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@Code_line", model.Code_line));
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@Code_StructureAtt", model.Code_StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@Code_StructureType", model.Code_StructureType));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_tunnelstructuretype
        /// </summary>
        public bool UpdateModelTjTunnelstructuretype(ModelTjTunnelstructuretype model, string id)
        {
            string sql = "UPDATE tb_model_tj_tunnelstructuretype SET Line=@Line,Code_line=@Code_line,StructureAtt=@StructureAtt,Code_StructureAtt=@Code_StructureAtt,StructureType=@StructureType,Code_StructureType=@Code_StructureType,Project_Code=@Project_Code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@Code_line", model.Code_line));
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@Code_StructureAtt", model.Code_StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@Code_StructureType", model.Code_StructureType));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region tb_model_tj_weights
        /// <summary>
        /// 数据重复验证tb_model_tj_weights
        /// </summary>
        public string RepeatCheckModelTjWeights(ModelTjWeights model)
        {
            string sql = "SELECT id FROM tb_model_tj_weights WHERE StructureType=@StructureType AND ComponentType=@ComponentType AND Defect=@Defect AND Project_Code=@Project_Code";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Defect", model.Defect));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        /// <summary>
        /// 新增tb_model_tj_weights
        /// </summary>
        public bool AddModelTjWeights(ModelTjWeights model)
        {
            string sql = "INSERT INTO tb_model_tj_weights(StructureAtt,Weight_Att,StructureType,Weight_Type,ComponentType,Weight_Com,Defect,Weight_Def,Defect_importance,Project_Code) VALUES(@StructureAtt,@Weight_Att,@StructureType,@Weight_Type,@ComponentType,@Weight_Com,@Defect,@Weight_Def,@Defect_importance,@Project_Code)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@Weight_Att", model.Weight_Att));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@Weight_Type", model.Weight_Type));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Weight_Com", model.Weight_Com));
                param.Add(DbHelper.CreateParameter("@Defect", model.Defect));
                param.Add(DbHelper.CreateParameter("@Weight_Def", model.Weight_Def));
                param.Add(DbHelper.CreateParameter("@Defect_importance", model.Defect_importance));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 更新tb_model_tj_weights
        /// </summary>
        public bool UpdateModelTjWeights(ModelTjWeights model, string id)
        {
            string sql = "UPDATE tb_model_tj_weights SET StructureAtt=@StructureAtt,Weight_Att=@Weight_Att,StructureType=@StructureType,Weight_Type=@Weight_Type,ComponentType=@ComponentType,Weight_Com=@Weight_Com,Defect=@Defect,Weight_Def=@Weight_Def,Defect_importance=@Defect_importance,Project_Code=@Project_Code WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@Weight_Att", model.Weight_Att));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@Weight_Type", model.Weight_Type));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Weight_Com", model.Weight_Com));
                param.Add(DbHelper.CreateParameter("@Defect", model.Defect));
                param.Add(DbHelper.CreateParameter("@Weight_Def", model.Weight_Def));
                param.Add(DbHelper.CreateParameter("@Defect_importance", model.Defect_importance));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion


       
    
        /// <summary>
        /// 查询tb_model_tj_result_component
        /// </summary>
        public IList<ModelTjResultComponent> GetModelTjResultComponent(string task_no)
        {
            string sql = "SELECT * FROM tb_model_tj_result_component WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelTjResultComponent>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_tj_result_componentdeduction
        /// </summary>
        public IList<ModelTjResultComponentdeduction> GetModelTjResultComponentdeduction(string task_no)
        {
            string sql = "SELECT * FROM tb_model_tj_result_componentdeduction WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelTjResultComponentdeduction>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_tj_result_componenttype
        /// </summary>
        public IList<ModelTjResultComponenttype> GetModelTjResultComponenttype(string task_no)
        {
            string sql = "SELECT * FROM tb_model_tj_result_componenttype WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelTjResultComponenttype>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_tj_result_modelcalculationdata
        /// </summary>
        public IList<ModelTjResultModelcalculationdata> GetModelTjResultModelcalculationdata(string task_no)
        {
            string sql = "SELECT * FROM tb_model_tj_result_modelcalculationdata WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelTjResultModelcalculationdata>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_tj_result_tunnel
        /// </summary>
        public IList<ModelTjResultTunnel> GetModelTjResultTunnel(string task_no)
        {
            string sql = "SELECT * FROM tb_model_tj_result_tunnel WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelTjResultTunnel>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_tj_result_tunnelline
        /// </summary>
        public IList<ModelTjResultTunnelline> GetModelTjResultTunnelline(string task_no)
        {
            string sql = "SELECT * FROM tb_model_tj_result_tunnelline WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelTjResultTunnelline>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_tj_result_tunnelsection
        /// </summary>
        public IList<ModelTjResultTunnelsection> GetModelTjResultTunnelsection(string task_no)
        {
            string sql = "SELECT * FROM tb_model_tj_result_tunnelsection WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelTjResultTunnelsection>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_tj_result_tunnelstructureatt
        /// </summary>
        public IList<ModelTjResultTunnelstructureatt> GetModelTjResultTunnelstructureatt(string task_no)
        {
            string sql = "SELECT * FROM tb_model_tj_result_tunnelstructureatt WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelTjResultTunnelstructureatt>(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询tb_model_tj_result_tunnelstructuretype
        /// </summary>
        public IList<ModelTjResultTunnelstructuretype> GetModelTjResultTunnelstructuretype(string task_no)
        {
            string sql = "SELECT * FROM tb_model_tj_result_tunnelstructuretype WHERE task_no=@task_no and (delete_flag is null or delete_flag=0)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return DbHelper.ExecuteReaderList<ModelTjResultTunnelstructuretype>(sql, CommandType.Text, param.ToArray());
            }
        }

        #region 项目的结构缺陷信息Web
        public IList<ModelTjDataDefectsQuery> GetModelTjDefectsList(ModelTjDataDefectsQuery model, out int count)
        {
            string sql = "select * from tb_model_tj_data_defects where task_no=@task_no AND project_code=@project_code  AND delete_flag=0 limit @page,@count";
            string count_sql = "select count(1) from tb_model_tj_data_defects where  task_no=@task_no AND project_code=@project_code  AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                       DbHelper.CreateParameter("@task_no", model.task_no),
                       DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelTjDataDefectsQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool AddModelTjDefects(ModelTjDataDefectsQuery model)
        {
            string sql = "INSERT INTO tb_model_tj_data_defects(Date,Line,StructureSection,ManagementUnit,StructureAtt,StructureType,ComponentType,Mileage,Defect,DefectType,DefectSeverity,DefectDescription,RingNumber,Project_Code,task_no,delete_flag,datapushdate,LineCode,SectionName,SectionCode) VALUES(@Date,@Line,@StructureSection,@ManagementUnit,@StructureAtt,@StructureType,@ComponentType,@Mileage,@Defect,@DefectType,@DefectSeverity,@DefectDescription,@RingNumber,@Project_Code,@task_no,0, now(),@LineCode,@SectionName,@SectionCode)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Date", model.Date));
                param.Add(DbHelper.CreateParameter("@Line", model.Line));
                param.Add(DbHelper.CreateParameter("@StructureSection", model.StructureSection));
                param.Add(DbHelper.CreateParameter("@ManagementUnit", model.ManagementUnit));
                param.Add(DbHelper.CreateParameter("@StructureAtt", model.StructureAtt));
                param.Add(DbHelper.CreateParameter("@StructureType", model.StructureType));
                param.Add(DbHelper.CreateParameter("@ComponentType", model.ComponentType));
                param.Add(DbHelper.CreateParameter("@Mileage", model.Mileage));
                param.Add(DbHelper.CreateParameter("@Defect", model.Defect));
                param.Add(DbHelper.CreateParameter("@DefectType", model.DefectType));
                param.Add(DbHelper.CreateParameter("@DefectSeverity", model.DefectSeverity));
                param.Add(DbHelper.CreateParameter("@DefectDescription", model.DefectDescription));
                param.Add(DbHelper.CreateParameter("@RingNumber", model.RingNumber));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));

                param.Add(DbHelper.CreateParameter("@LineCode", model.LineCode));
                param.Add(DbHelper.CreateParameter("@SectionName", model.SectionName));
                param.Add(DbHelper.CreateParameter("@SectionCode", model.SectionCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelTjDefects(int id)
        {
            string sql = "UPDATE tb_model_tj_data_defects SET delete_flag=1 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        public bool DeleteModelTjDefects(string task_no)
        {
            string sql = "UPDATE tb_model_tj_data_defects SET delete_flag=1 WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelTjDefectsList(List<ModelTjDataDefectsQuery> list)
        {
            string sql = "INSERT INTO tb_model_tj_data_defects(Date,Line,StructureSection,ManagementUnit,StructureAtt,StructureType,ComponentType,Mileage,Defect,DefectType,DefectSeverity,DefectDescription,RingNumber,Project_Code,task_no,delete_flag,datapushdate,LineCode,SectionName,SectionCode) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@Date{0},@Line{0},@StructureSection{0},@ManagementUnit{0},@StructureAtt{0},@StructureType{0},@ComponentType{0},@Mileage{0},@Defect{0},@DefectType{0},@DefectSeverity{0},@DefectDescription{0},@RingNumber{0},@Project_Code{0},@task_no{0},0,now(),@LineCode{0},@SectionName{0},@SectionCode{0})", i));
                    param.Add(DbHelper.CreateParameter("@Date" + i, model.Date));
                    param.Add(DbHelper.CreateParameter("@Line" + i, model.Line));
                    param.Add(DbHelper.CreateParameter("@StructureSection" + i, model.StructureSection));
                    param.Add(DbHelper.CreateParameter("@ManagementUnit" + i, model.ManagementUnit));
                    param.Add(DbHelper.CreateParameter("@StructureAtt" + i, model.StructureAtt));
                    param.Add(DbHelper.CreateParameter("@StructureType" + i, model.StructureType));
                    param.Add(DbHelper.CreateParameter("@ComponentType" + i, model.ComponentType));
                    param.Add(DbHelper.CreateParameter("@Mileage" + i, model.Mileage));
                    param.Add(DbHelper.CreateParameter("@Defect" + i, model.Defect));
                    param.Add(DbHelper.CreateParameter("@DefectType" + i, model.DefectType));
                    param.Add(DbHelper.CreateParameter("@DefectSeverity" + i, model.DefectSeverity));
                    param.Add(DbHelper.CreateParameter("@DefectDescription" + i, model.DefectDescription));
                    param.Add(DbHelper.CreateParameter("@RingNumber" + i, model.RingNumber));
                    param.Add(DbHelper.CreateParameter("@Project_Code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));

                    param.Add(DbHelper.CreateParameter("@LineCode" + i, model.LineCode));
                    param.Add(DbHelper.CreateParameter("@SectionName" + i, model.SectionName));
                    param.Add(DbHelper.CreateParameter("@SectionCode" + i, model.SectionCode));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool UpdateModelTjDefects(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_tj_data_defects SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion


        #region 项目的收敛变形信息Web
        public IList<ModelTjDataDeformationQuery> GetModelTjDeformationList(ModelTjDataDeformationQuery model, out int count)
        {
            string sql = "select * from tb_model_tj_data_deformation where task_no=@task_no AND project_code=@project_code  AND delete_flag=0 limit @page,@count";
            string count_sql = "select count(1) from tb_model_tj_data_deformation where  task_no=@task_no AND project_code=@project_code  AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                       DbHelper.CreateParameter("@task_no", model.task_no),
                       DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelTjDataDeformationQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool UpdateModelTjDeformation(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_tj_data_deformation SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelTjDeformation(int id)
        {
            string sql = "UPDATE tb_model_tj_data_deformation SET delete_flag=1 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        public bool DeleteModelTjDeformation(string task_no)
        {
            string sql = "UPDATE tb_model_tj_data_deformation SET delete_flag=1 WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        public bool AddModelTjDeformation(ModelTjDataDeformationQuery model)
        {
            string sql = "INSERT INTO tb_model_tj_data_deformation(Date,Code,Station,ValueName,ValueCode,DeformationValue,Project_Code,task_no,delete_flag,datapushdate) VALUES(@Date,@Code,@Station,@ValueName,@ValueCode,@DeformationValue,@Project_Code,@task_no,0, now())";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Date", model.date));
                param.Add(DbHelper.CreateParameter("@Code", model.code));
                param.Add(DbHelper.CreateParameter("@Station", model.station));
                param.Add(DbHelper.CreateParameter("@ValueName", model.valueName));
                param.Add(DbHelper.CreateParameter("@ValueCode", model.valueCode));
                param.Add(DbHelper.CreateParameter("@DeformationValue", model.deformationValue));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelTjDeformationList(List<ModelTjDataDeformationQuery> list)
        {
            string sql = "INSERT INTO tb_model_tj_data_deformation(Date,Code,Station,ValueName,ValueCode,DeformationValue,Project_Code,task_no,delete_flag,datapushdate) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@Date{0},@Code{0},@Station{0},@ValueName{0},@ValueCode{0},@DeformationValue{0},@Project_Code{0},@task_no{0},0, now())", i));
                    param.Add(DbHelper.CreateParameter("@Date"+i, model.date));
                    param.Add(DbHelper.CreateParameter("@Code" + i, model.code));
                    param.Add(DbHelper.CreateParameter("@Station" + i, model.station));
                    param.Add(DbHelper.CreateParameter("@ValueName" + i, model.valueName));
                    param.Add(DbHelper.CreateParameter("@ValueCode" + i, model.valueCode));
                    param.Add(DbHelper.CreateParameter("@DeformationValue" + i, model.deformationValue));
                    param.Add(DbHelper.CreateParameter("@Project_Code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion

        #region 项目的收敛变形信息Web
        public IList<ModelTjDataSedimentationQuery> GetModelTjSedimentationList(ModelTjDataSedimentationQuery model, out int count)
        {
            string sql = "select * from tb_model_tj_data_sedimentation where task_no=@task_no AND project_code=@project_code  AND delete_flag=0 limit @page,@count";
            string count_sql = "select count(1) from tb_model_tj_data_Sedimentation where  task_no=@task_no AND project_code=@project_code  AND delete_flag=0";
            using (var DbHelper = DBManager.CoreHelper)
            {
                count = Convert.ToInt32(DbHelper.ExecuteScalar(count_sql, CommandType.Text,
                       DbHelper.CreateParameter("@task_no", model.task_no),
                       DbHelper.CreateParameter("@project_code", model.project_code)));
                return DbHelper.ExecuteReaderList<ModelTjDataSedimentationQuery>(sql, CommandType.Text,
                    DbHelper.CreateParameter("@task_no", model.task_no),
                    DbHelper.CreateParameter("@project_code", model.project_code),
                    DbHelper.CreateParameter("@page", (model.Page - 1) * model.Limit),
                    DbHelper.CreateParameter("@count", model.Limit));
            }
        }

        public bool UpdateModelTjSedimentation(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_tj_data_sedimentation SET {0}=@{0} WHERE id=@id", field);
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@" + field, value));
                param.Add(DbHelper.CreateParameter("@id", id));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool DeleteModelTjSedimentation(int id)
        {
            string sql = "UPDATE tb_model_tj_data_sedimentation SET delete_flag=1 WHERE id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        public bool DeleteModelTjSedimentation(string task_no)
        {
            string sql = "UPDATE tb_model_tj_data_sedimentation SET delete_flag=1 WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));

                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }


        public bool AddModelTjSedimentation(ModelTjDataSedimentationQuery model)
        {
            string sql = "INSERT INTO tb_model_tj_data_sedimentation(Start_Date,End_Date,Station,Code_R,Value_R,Code_L,Value_L,Project_Code,task_no,delete_flag,datapushdate,Code,Value,Sedimentation) VALUES(@Start_Date,@End_Date,@Station,@Code_R,@Value_R,@Code_L,@Value_L,@Project_Code,@task_no,0, now(),@Code,@Value,@Sedimentation)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@Start_Date", model.start_date));
                param.Add(DbHelper.CreateParameter("@End_Date", model.end_date));
                param.Add(DbHelper.CreateParameter("@Station", model.station));
                param.Add(DbHelper.CreateParameter("@Code_R", model.Code_R));
                param.Add(DbHelper.CreateParameter("@Value_R", model.Value_R));
                param.Add(DbHelper.CreateParameter("@Code_L", model.Code_L));
                param.Add(DbHelper.CreateParameter("@Value_L", model.Value_L));
                param.Add(DbHelper.CreateParameter("@Project_Code", model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));

                param.Add(DbHelper.CreateParameter("@Code", model.Code));
                param.Add(DbHelper.CreateParameter("@Value", model.Value));
                param.Add(DbHelper.CreateParameter("@Sedimentation", model.Sedimentation));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public bool AddModelTjSedimentationList(List<ModelTjDataSedimentationQuery> list)
        {
            string sql = "INSERT INTO tb_model_tj_data_sedimentation(Start_Date,End_Date,Station,Code_R,Value_R,Code_L,Value_L,Project_Code,task_no,delete_flag,datapushdate,Code,Value,Sedimentation) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;
            using (var DbHelper = DBManager.CoreHelper)
            {
                foreach (var model in list)
                {
                    values.Add(string.Format("(@Start_Date{0},@End_Date{0},@Station{0},@Code_R{0},@Value_R{0},@Code_L{0},@Value_L{0},@Project_Code{0},@task_no{0},0, now(),@Code{0},@Value{0},@Sedimentation{0})", i));
                    param.Add(DbHelper.CreateParameter("@Start_Date"+i, model.start_date));
                    param.Add(DbHelper.CreateParameter("@End_Date" + i, model.end_date));
                    param.Add(DbHelper.CreateParameter("@Station" + i, model.station));
                    param.Add(DbHelper.CreateParameter("@Code_R" + i, model.Code_R));
                    param.Add(DbHelper.CreateParameter("@Value_R" + i, model.Value_R));
                    param.Add(DbHelper.CreateParameter("@Code_L" + i, model.Code_L));
                    param.Add(DbHelper.CreateParameter("@Value_L" + i, model.Value_L));
                    param.Add(DbHelper.CreateParameter("@Project_Code" + i, model.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no" + i, model.task_no));

                    param.Add(DbHelper.CreateParameter("@Code" + i, model.Code));
                    param.Add(DbHelper.CreateParameter("@Value" + i, model.Value));
                    param.Add(DbHelper.CreateParameter("@Sedimentation" + i, model.Sedimentation));
                    i++;
                }
                return DbHelper.ExecuteNonQuery(sql + string.Join(",", values), CommandType.Text, param.ToArray()) > 0;
            }
        }
        #endregion


        #region 待评价项目的路面平整度信息

        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelRoadDataCheckvalue(ModelRoadDataCheckvalue model)
        {
            string sql = "SELECT ID FROM tb_model_road_data_checkvalue WHERE task_no=@task_no AND project_code=@project_code and line_no=@line_no and lane_no=@lane_no and section_code=@section_code ;";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
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
                param.Add(DbHelper.CreateParameter("@ID", model.ID));
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
        public bool InsertModelRoadDataCheckvalue(ModelRoadDataCheckvalue model)
        {
            string sql = " INSERT INTO tb_model_road_data_checkvalue(date,line_no,lane_no,section_code,start_mileage,end_mileage,iri,sfc,pci,project_code,task_no) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;

            using (var DbHelper = DBManager.CoreHelper)
            {
                sql +="(@date,@line_no,@lane_no,@section_code,@start_mileage,@end_mileage,@iri,@sfc,@pci,@project_code,@task_no)";
                param.Add(DbHelper.CreateParameter("@date" , model.date));
                param.Add(DbHelper.CreateParameter("@line_no" , model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no" , model.lane_no));
                param.Add(DbHelper.CreateParameter("@section_code" , model.section_code));
                param.Add(DbHelper.CreateParameter("@start_mileage" , model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage" , model.end_mileage));
                param.Add(DbHelper.CreateParameter("@iri" , model.iri));
                param.Add(DbHelper.CreateParameter("@sfc" , model.sfc));
                param.Add(DbHelper.CreateParameter("@pci" , model.pci));
                param.Add(DbHelper.CreateParameter("@project_code" , model.project_code));
                param.Add(DbHelper.CreateParameter("@task_no" , model.task_no));
                return DbHelper.ExecuteNonQuery(sql , CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion

        #region 待评价项目的损坏类型信息

        /// <summary>
        /// 数据重复验证
        /// </summary>
        //public string RepeatCheckModelRoadDamageType(ModelRoadDamageType model)
        //{
        //    string sql = "SELECT ID FROM tb_model_road_damagetype WHERE task_no=@task_no AND project_code=@project_code and line_no=@line_no and lane_no=@lane_no and section_code=@section_code ;";
        //    List<DbParameter> param = new List<DbParameter>();
        //    using (var DbHelper = DBManager.CoreHelper)
        //    {
        //        param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
        //        param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
        //        param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
        //        param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
        //        param.Add(DbHelper.CreateParameter("@section_code", model.section_code));

        //        return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
        //    }
        //}


        /// <summary>
        /// 修改
        /// </summary>
        //public bool UpdateModelRoadDamageType(ModelRoadDamageType model, int id)
        //{
        //    string sql = "UPDATE tb_model_road_data_checkvalue SET date=@date,line_no=@line_no,lane_no=@lane_no,section_code=@section_code,start_mileage=@start_mileage,end_mileage=@end_mileage,iri=@iri,sfc=@sfc,pci=@pci,project_code=@project_code,task_no=@task_no  WHERE id=@id";
        //    List<DbParameter> param = new List<DbParameter>();
        //    using (var DbHelper = DBManager.CoreHelper)
        //    {
        //        param.Add(DbHelper.CreateParameter("@ID", model.ID));
        //        param.Add(DbHelper.CreateParameter("@date", model.date));
        //        param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
        //        param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
        //        param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
        //        param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
        //        param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
        //        param.Add(DbHelper.CreateParameter("@iri", model.iri));
        //        param.Add(DbHelper.CreateParameter("@sfc", model.sfc));
        //        param.Add(DbHelper.CreateParameter("@pci", model.pci));
        //        param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
        //        param.Add(DbHelper.CreateParameter("@task_no", model.task_no));
        //        return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
        //    }
        //}

        /// <summary>
        /// 新增
        /// </summary>
        public bool InsertModelRoadDamageType(ModelRoadDamageType model)
        {
            string sql = " INSERT INTO tb_model_road_damagetype(`DefectTypeName`, `DefectTypeCode`, `ParentDefectType`, `ParentDefectCode`) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;

            using (var DbHelper = DBManager.CoreHelper)
            {
                sql += "(@DefectTypeName,@DefectTypeCode,@ParentDefectType,@ParentDefectCode)";
                param.Add(DbHelper.CreateParameter("@DefectTypeName", model.DefectTypeName));
                param.Add(DbHelper.CreateParameter("@DefectTypeCode", model.DefectTypeCode));
                param.Add(DbHelper.CreateParameter("@ParentDefectType", model.ParentDefectType));
                param.Add(DbHelper.CreateParameter("@ParentDefectCode", model.ParentDefectCode));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion


        #region 待评价项目的损坏类型信息

        /// <summary>
        /// 数据重复验证
        /// </summary>
        public string RepeatCheckModelRoadCheckUnitInfo(ModelRoadCheckUnitInfo model)
        {
            string sql = "SELECT ID FROM tb_model_road_checkunitinfo WHERE line_no=@line_no AND project_code=@project_code and lane_no=@lane_no  and section_code=@section_code ;";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));

                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        public bool UpdateModelRoadCheckUnitInfo(ModelRoadCheckUnitInfo model, string id)
        {
            string sql = "UPDATE tb_model_road_checkunitinfo SET line_no=@line_no,lane_no=@lane_no,section_code=@section_code,start_mileage=@start_mileage,end_mileage=@end_mileage,project_code=@project_code  WHERE ID=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@ID", id));
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        public bool InsertModelRoadCheckUnitInfo(ModelRoadCheckUnitInfo model)
        {
            string sql = " INSERT INTO tb_model_road_checkunitinfo(`line_no`, `lane_no`, `start_mileage`, `end_mileage`, `project_code`, `datapushdate`,  `section_code`) VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            int i = 0;

            using (var DbHelper = DBManager.CoreHelper)
            {
                sql += "(@line_no,@lane_no,@start_mileage,@end_mileage,@project_code,NOW(),@section_code)";
                param.Add(DbHelper.CreateParameter("@line_no", model.line_no));
                param.Add(DbHelper.CreateParameter("@lane_no", model.lane_no));
                param.Add(DbHelper.CreateParameter("@start_mileage", model.start_mileage));
                param.Add(DbHelper.CreateParameter("@end_mileage", model.end_mileage));
                param.Add(DbHelper.CreateParameter("@project_code", model.Project_Code));
                param.Add(DbHelper.CreateParameter("@section_code", model.section_code));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        #endregion
    }
}