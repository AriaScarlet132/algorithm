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
    public class BrRepository
    {
        public string CheckModelBrTrafficDriveSpeed(TbBridgeAssessmentFacilitylist item)
        {
            string sql = @"SELECT id FROM tb_bridge_assessment_facilitylist WHERE 
                            project_code=@project_code 
                            and facility_code=@facility_code
                            and delete_flag=0
                            and task_no=@task_no
                            ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", item.project_code));
                param.Add(DbHelper.CreateParameter("@facility_code", item.facility_code));
                param.Add(DbHelper.CreateParameter("@task_no", item.task_no));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }

        public void UpdateModelBrTrafficDriveSpeed(TbBridgeAssessmentFacilitylist item, string id)
        {
            string sql = @"update tb_bridge_assessment_facilitylist set facility_name=@facility_name,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@facility_name", item.facility_name));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        public bool AddModelBrTrafficDriveSpeed(TbBridgeAssessmentFacilitylist item)
        {
            string sql = "INSERT INTO tb_bridge_assessment_facilitylist(project_code,facility_code,facility_name,datapushdate,task_no) VALUES(@project_code,@facility_code,@facility_name,now(),@task_no)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", item.project_code));
                param.Add(DbHelper.CreateParameter("@facility_code", item.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", item.facility_name));
                param.Add(DbHelper.CreateParameter("@task_no", item.task_no));
                return DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray()) > 0;
            }
        }

        public List<T> GetListModelByTableNameAndTaskno<T>(string task_no, string tablename)
        {
            string sql = "SELECT * FROM " + tablename + " WHERE task_no=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
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


        public string CheckModelBrCommon1(string tableName, string project_code, string task_no, string xls_code, string facility_code)
        {
            string sql = @"SELECT id FROM " + tableName + @" WHERE 
                            project_code=@project_code 
                            and task_no=@task_no
                            and xls_code=@xls_code
                            and facility_code=@facility_code
                            "; //and delete_flag = 0
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", project_code));
                param.Add(DbHelper.CreateParameter("@facility_code", facility_code));
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                param.Add(DbHelper.CreateParameter("@xls_code", xls_code));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public void UpdateModelBrCommon1(string id, string tableName, string xls_name, string facility_name, string disease)
        {
            string sql = @"update " + tableName + @" set datapushdate=now(),xls_name=@xls_name,facility_name=@facility_name ,disease=@disease where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@facility_name", facility_name));
                param.Add(DbHelper.CreateParameter("@xls_name", xls_name));
                param.Add(DbHelper.CreateParameter("@disease", disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        public string CheckModelBrCommon2(string tableName, string project_code, string task_no, string facility_code)
        {
            string sql = @"SELECT id FROM " + tableName + @" WHERE 
                            project_code=@project_code 
                            and task_no=@task_no
                            and facility_code=@facility_code
                            ";//and delete_flag=0
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", project_code));
                param.Add(DbHelper.CreateParameter("@facility_code", facility_code));
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public void UpdateModelBrCommon2(string id, string tableName, string facility_name, string disease)
        {
            string sql = @"update " + tableName + @" set datapushdate=now(),facility_name=@facility_name ,disease=@disease where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@facility_name", facility_name));
                param.Add(DbHelper.CreateParameter("@disease", disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        #region 230720
        public string CheckModelBrCommon_1(string tableName, string project_code, string task_no, string measure_point_direction,string measure_point_name)
        {
            string sql = @"SELECT id FROM " + tableName + @" WHERE 
                            project_code=@project_code 
                            and task_no=@task_no
                            and measure_point_direction=@measure_point_direction
                            and measure_point_name=@measure_point_name
                            ";//and delete_flag=0
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", project_code));
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                param.Add(DbHelper.CreateParameter("@measure_point_direction", measure_point_direction));
                param.Add(DbHelper.CreateParameter("@measure_point_name", measure_point_name));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public void UpdateModelBrCommon_1(string id, string tableName, float? measure_point_dist, string disease)
        {
            string sql = @"update " + tableName + @" set datapushdate=now(),measure_point_dist=@measure_point_dist ,disease=@disease where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@measure_point_dist", measure_point_dist));
                param.Add(DbHelper.CreateParameter("@disease", disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        public string CheckModelBrCommon_2(string tableName, string project_code, string task_no, string facility_code, string facility_name, string measure_point_name)
        {
            string sql = @"SELECT id FROM " + tableName + @" WHERE 
                            project_code=@project_code 
                            and task_no=@task_no
                            and facility_code=@facility_code
                            and facility_name=@facility_name
                            and measure_point_name=@measure_point_name
                            ";//and delete_flag=0
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", project_code));
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                param.Add(DbHelper.CreateParameter("@facility_code", facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", facility_name));
                param.Add(DbHelper.CreateParameter("@measure_point_name", measure_point_name));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public void UpdateModelBrCommon_2(string id, string tableName, float? measure_point_height, string disease)
        {
            string sql = @"update " + tableName + @" set datapushdate=now(),measure_point_height=@measure_point_height ,disease=@disease where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@measure_point_height", measure_point_height));
                param.Add(DbHelper.CreateParameter("@disease", disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        public string CheckModelBrCommon_3(string tableName, string project_code, string task_no, string facility_code, string facility_name, string direction)
        {
            string sql = @"SELECT id FROM " + tableName + @" WHERE 
                            project_code=@project_code 
                            and task_no=@task_no
                            and facility_code=@facility_code
                            and facility_name=@facility_name
                            and direction=@direction
                            ";//and delete_flag=0
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", project_code));
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                param.Add(DbHelper.CreateParameter("@facility_code", facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", facility_name));
                param.Add(DbHelper.CreateParameter("@direction", direction));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public void UpdateModelBrCommon_3(string id, string tableName, string disease)
        {
            string sql = @"update " + tableName + @" set datapushdate=now(),disease=@disease where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@id", id));
                param.Add(DbHelper.CreateParameter("@disease", disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        //UpdateModelBrCommon_4  同上
        //UpdateModelBrCommon_5  同上
        

        public string CheckModelBrCommon_4(string tableName, string project_code, string task_no, string facility_code, string facility_name)
        {
            string sql = @"SELECT id FROM " + tableName + @" WHERE 
                            project_code=@project_code 
                            and task_no=@task_no
                            and facility_code=@facility_code
                            and facility_name=@facility_name
                            ";//and delete_flag=0
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", project_code));
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                param.Add(DbHelper.CreateParameter("@facility_code", facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", facility_name));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        public string CheckModelBrCommon_5(string tableName, string project_code, string task_no)
        {
            string sql = @"SELECT id FROM " + tableName + @" WHERE 
                            project_code=@project_code 
                            and task_no=@task_no
                            ";//and delete_flag=0
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", project_code));
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                return Convert.ToString(DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()));
            }
        }
        #endregion
        /// <summary>
        ///   
        /// </summary>
        /// <param name="models"></param>
        public void add_xlssl_checkvalue(xlssl_checkvalue models)
        {
            string id = CheckModelBrCommon1("tb_bridge_lxxn_xlssl_checkvalue", models.project_code, models.taskNo, models.xls_code, models.facility_code);
            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_lxxn_xlssl_checkvalue(project_code,task_no,xls_code,xls_name,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@xls_code,@xls_name,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                    param.Add(DbHelper.CreateParameter("@xls_name", models.xls_name));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon1(id, "tb_bridge_lxxn_xlssl_checkvalue", models.xls_name, models.facility_name, models.disease);
            }

        }

        public void add_jcwy_checkvalue(jcwy_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_lxxn_jhbw_jcwy_checkvalue", models.project_code, models.taskNo, models.facility_code);
            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_lxxn_jhbw_jcwy_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_lxxn_jhbw_jcwy_checkvalue", models.facility_name, models.disease);
            }
        }

        public void add_tdwy_checkvalue(tdwy_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_lxxn_jhbw_tdwy_checkvalue", models.project_code, models.taskNo, models.facility_code);
            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_lxxn_jhbw_tdwy_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_lxxn_jhbw_tdwy_checkvalue", models.facility_name, models.disease);
            }
        }

        public void add_zlxx_checkvalue(zlxx_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_lxxn_jhbw_zlxx_checkvalue", models.project_code, models.taskNo, models.facility_code);
            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_lxxn_jhbw_zlxx_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_lxxn_jhbw_zlxx_checkvalue", models.facility_name, models.disease);
            }
        }

        public void add_jgyl_checkvalue(jgyl_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_lxxn_jgyl_checkvalue", models.project_code, models.taskNo, models.facility_code);
            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_lxxn_jgyl_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_lxxn_jgyl_checkvalue", models.facility_name, models.disease);
            }
        }

        public void add_jgpl_checkvalue(jgpl_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_lxxn_jgpl_checkvalue", models.project_code, models.taskNo, models.facility_code);
            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_lxxn_jgpl_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_lxxn_jgpl_checkvalue", models.facility_name, models.disease);
            }
        }
        #region 20230720
        /// <summary>
        /// 20230720
        /// </summary>
        /// <param name="models"></param>
        public void lxxn_sszz_checkvalue(tb_bridge_lxxn_sszz_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_lxxn_sszz_checkvalue", models.project_code, models.taskNo, models.facility_code);

            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_lxxn_sszz_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_lxxn_sszz_checkvalue", models.facility_name, models.disease);
            }
        }
        public void lxxn_zzwy_checkvalue(tb_bridge_lxxn_zzwy_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_lxxn_zzwy_checkvalue", models.project_code, models.taskNo, models.facility_code);

            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_lxxn_zzwy_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_lxxn_zzwy_checkvalue", models.facility_name, models.disease);
            }
        }

        /// <summary>
        /// 1
        /// </summary>
        /// <param name="models"></param>
        public void add_dqjc_zlxx_checkvalue(tb_bridge_dqjc_zlxx_checkvalue models)
        {
            string id = CheckModelBrCommon_1("tb_bridge_dqjc_zlxx_checkvalue", models.project_code, models.taskNo, models.measure_point_direction, models.measure_point_name);

            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_dqjc_zlxx_checkvalue(project_code,task_no,measure_point_direction,measure_point_name,measure_point_dist,datapushdate,disease) VALUES(@project_code,@task_no,@measure_point_direction,@measure_point_name,@measure_point_dist,now(),@disease)";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@measure_point_direction", models.measure_point_direction));
                    param.Add(DbHelper.CreateParameter("@measure_point_name", models.measure_point_name));
                    param.Add(DbHelper.CreateParameter("@measure_point_dist", models.measure_point_dist));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon_1(id, "tb_bridge_dqjc_zlxx_checkvalue", models.measure_point_dist, models.disease);
            }
        }
        /// <summary>
        /// 2
        /// </summary>
        /// <param name="models"></param>
        public void add_dqjc_jcwy_checkvalue(tb_bridge_dqjc_jcwy_checkvalue models)
        {
            string id = CheckModelBrCommon_2("tb_bridge_dqjc_jcwy_checkvalue", models.project_code, models.taskNo, models.facility_code, models.facility_name, models.measure_point_name);

            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_dqjc_jcwy_checkvalue(project_code,task_no,facility_code,facility_name,measure_point_name,measure_point_height,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@measure_point_name,@measure_point_height,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@measure_point_name", models.measure_point_name));
                    param.Add(DbHelper.CreateParameter("@measure_point_height", models.measure_point_height));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon_2(id, "tb_bridge_dqjc_jcwy_checkvalue", models.measure_point_height, models.disease);
            }
        }  
        /// <summary>
           /// 3
           /// </summary>
           /// <param name="models"></param>
        public void add_dqjc_tdwy_checkvalue(tb_bridge_dqjc_tdwy_checkvalue models)
        {
            string id = CheckModelBrCommon_3("tb_bridge_dqjc_tdwy_checkvalue", models.project_code, models.taskNo, models.facility_code, models.facility_name, models.direction);

            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_dqjc_tdwy_checkvalue(project_code,task_no,facility_code,facility_name,direction,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@direction,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@direction", models.direction));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon_3(id, "tb_bridge_dqjc_tdwy_checkvalue", models.disease);
            }
        }
        /// <summary>
        /// 4
        /// </summary>
        /// <param name="models"></param>
        public void add_dqjc_xlssl_checkvalue(tb_bridge_dqjc_xlssl_checkvalue models)
        {
            string id = CheckModelBrCommon_4("tb_bridge_dqjc_xlssl_checkvalue", models.project_code, models.taskNo, models.facility_code, models.facility_name);

            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_dqjc_xlssl_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@facility_code,@facility_name,now(),@disease)";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon_3(id, "tb_bridge_dqjc_xlssl_checkvalue",  models.disease);
            }
        }
        /// <summary>
        /// 5
        /// </summary>
        /// <param name="models"></param>
        public void add_dqjc_jgpl_checkvalue(tb_bridge_dqjc_jgpl_checkvalue models)
        {
            string id = CheckModelBrCommon_5("tb_bridge_dqjc_jgpl_checkvalue", models.project_code, models.taskNo);

            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_dqjc_jgpl_checkvalue(project_code,task_no,datapushdate,disease) VALUES(@project_code,@task_no,now(),@disease)";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon_3(id, "tb_bridge_dqjc_jgpl_checkvalue",models.disease);
            }
        }
        #endregion

        public void add_fs_checkvalue(fs_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_yyhj_fs_checkvalue", models.project_code, models.taskNo, models.facility_code);
            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_yyhj_fs_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_yyhj_fs_checkvalue", models.facility_name, models.disease);
            }
        }

        public void add_wd_checkvalue(wd_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_yyhj_wd_checkvalue", models.project_code, models.taskNo, models.facility_code);
            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_yyhj_wd_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_yyhj_wd_checkvalue", models.facility_name, models.disease);
            }
        }

        public void add_jtl_checkvalue(jtl_checkvalue models)
        {
            string id = CheckModelBrCommon2("tb_bridge_yyhj_jtl_checkvalue", models.project_code, models.taskNo, models.facility_code);
            if (string.IsNullOrEmpty(id))
            {
                string sql = "INSERT INTO tb_bridge_yyhj_jtl_checkvalue(project_code,task_no,facility_code,facility_name,disease,datapushdate) VALUES(@project_code,@task_no,@facility_code,@facility_name,@disease,now())";
                List<DbParameter> param = new List<DbParameter>();
                using (var DbHelper = DBManager.CoreHelper)
                {
                    param.Add(DbHelper.CreateParameter("@project_code", models.project_code));
                    param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                    param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                    param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                    param.Add(DbHelper.CreateParameter("@disease", models.disease));
                    DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
                }
            }
            else
            {
                UpdateModelBrCommon2(id, "tb_bridge_yyhj_jtl_checkvalue", models.facility_name, models.disease);
            }
        }



        #region  【分析数据】桥面系

        /// <summary>
        /// 查询桥面铺装系统检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_qmpz_checkvalue(qmpz_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_qmx_qmpz_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code  ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 添加桥面铺装系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_qmpz_checkvalue(qmpz_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_qmx_qmpz_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改桥面铺装系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_qmpz_checkvalue(qmpz_checkvalue models,string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_qmx_qmpz_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询人行道检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_rxd_checkvalue(rxd_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_qmx_rxd_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 添加人行道检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_rxd_checkvalue(rxd_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_qmx_rxd_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改人行道检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_rxd_checkvalue(rxd_checkvalue models,string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_qmx_rxd_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询伸缩装置检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_sszz_checkvalue(sszz_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_qmx_sszz_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 添加伸缩装置检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_sszz_checkvalue(sszz_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_qmx_sszz_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改伸缩装置检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_sszz_checkvalue(sszz_checkvalue models,string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_qmx_sszz_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        #endregion

        #region {分析数据}主梁系统

        /// <summary>
        /// 查询主梁系统是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_ZlData(BridgetaddZlData models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_zlxt_zl_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        public void addZlData(BridgetaddZlData models)
        {
            string sql = @"INSERT INTO tb_bridge_bgzk_zlxt_zl_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES (@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改主梁系统状况信息
        /// </summary>
        /// <param name="models"></param>
        public void UpdateZlData(BridgetaddZlData models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_zlxt_zl_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        #endregion

        #region  【分析数据】支座及限位装置
        /// <summary>
        /// 查询支座检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_zz_checkvalue(zz_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_zzxt_zz_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 添加支座检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_zz_checkvalue(zz_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_zzxt_zz_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改支座检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_zz_checkvalue(zz_checkvalue models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_zzxt_zz_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询主梁阻尼器检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_znq_checkvalue(znq_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_zzxt_znq_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 添加主梁阻尼器检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_znq_checkvalue(znq_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_zzxt_znq_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改主梁阻尼器检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_znq_checkvalue(znq_checkvalue models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_zzxt_znq_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        #endregion

        #region [分析数据]下部结构
        /// <summary>
        /// 查询桥墩系统检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_qd_checkvalue(qd_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_xbjg_qd_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 桥墩系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_qd_checkvalue(qd_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_xbjg_qd_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改桥墩系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_qd_checkvalue(qd_checkvalue models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_xbjg_qd_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询桥台系统检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_qt_checkvalue(qt_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_xbjg_qt_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 桥台系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_qt_checkvalue(qt_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_xbjg_qt_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改桥台系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_qt_checkvalue(qt_checkvalue models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_xbjg_qt_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询基础承台系统检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_jcct_checkvalue(jcct_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_xbjg_jcct_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 基础承台系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_jcct_checkvalue(jcct_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_xbjg_jcct_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改基础承台系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_jcct_checkvalue(jcct_checkvalue models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_xbjg_jcct_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        #endregion

        #region {分析数据}索塔系统
        /// <summary>
        /// 查询索塔系统是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_StData(BridgetaddStData models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_stxt_st_checkvalue WHERE project_code=@project_code and task_no=@task_no and facility_code=@facility_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        public void addStData(BridgetaddStData models)
        {
            string sql = @"INSERT INTO tb_bridge_bgzk_stxt_st_checkvalue(project_code,task_no,facility_code,facility_name,datapushdate,disease) VALUES (@project_code,@task_no,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改基础承台系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void UpdateStData(BridgetaddStData models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_stxt_st_checkvalue SET project_code = @project_code ,task_no=@task_no,facility_code=@facility_code, facility_name=@facility_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        #endregion

        #region  【分析数据】斜拉索系统
        /// <summary>
        /// 查询斜拉索索体检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_xls_checkvalue(xls_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_xlsxt_xls_checkvalue WHERE project_code=@project_code and task_no=@task_no and xls_code=@xls_code ";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 添加斜拉索索体检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_xls_checkvalue(xls_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_xlsxt_xls_checkvalue(project_code,task_no,xls_code,xls_name,datapushdate,disease) VALUES(@project_code,@task_no,@xls_code,@xls_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@xls_name", models.xls_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改斜拉索索体检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_xls_checkvalue(xls_checkvalue models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_xlsxt_xls_checkvalue SET project_code = @project_code ,task_no=@task_no,xls_code=@xls_code, xls_name=@xls_name,disease=@disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@xls_name", models.xls_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }


        /// <summary>
        /// 查询斜拉索护套检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_xlsht_checkvalue(xlsht_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_xlsxt_xlsht_checkvalue WHERE project_code=@project_code and task_no=@task_no and xls_code=@xls_code and facility_code=@facility_code";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 添加斜拉索护套检查状况信息
        /// </summary>
        /// <param nam  e="models"></param>
        public void add_xlsht_checkvalue(xlsht_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_xlsxt_xlsht_checkvalue(project_code,task_no,xls_code,xls_name,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@xls_code,@xls_name,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@xls_name", models.xls_name));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改斜拉索护套检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_xlsht_checkvalue(xlsht_checkvalue models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_xlsxt_xlsht_checkvalue SET project_code = @project_code ,task_no = @task_no,xls_code = @xls_code,xls_name = @xls_name,facility_code = @facility_code,facility_name= @facility_name,disease = @disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@xls_name", models.xls_name));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询斜拉索锚固系统检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_mgxt_checkvalue(mgxt_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_xlsxt_mgxt_checkvalue WHERE project_code=@project_code and task_no=@task_no and xls_code=@xls_code and facility_code=@facility_code";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 斜拉索锚固系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_mgxt_checkvalue(mgxt_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_xlsxt_mgxt_checkvalue(project_code,task_no,xls_code,xls_name,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@xls_code,@xls_name,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@xls_name", models.xls_name));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改斜拉索锚固系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_mgxt_checkvalue(mgxt_checkvalue models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_xlsxt_mgxt_checkvalue SET project_code = @project_code ,task_no = @task_no,xls_code = @xls_code,xls_name = @xls_name,facility_code = @facility_code,facility_name= @facility_name,disease = @disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@xls_name", models.xls_name));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询斜拉索减振系统检查状况信息是否有相同数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_jzxt_checkvalue(jzxt_checkvalue models)
        {
            string sql = "SELECT id from tb_bridge_bgzk_xlsxt_jzxt_checkvalue WHERE project_code=@project_code and task_no=@task_no and xls_code=@xls_code and facility_code=@facility_code";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        /// <summary>
        /// 斜拉索减振系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void add_jzxt_checkvalue(jzxt_checkvalue models)
        {
            string sql = "INSERT INTO tb_bridge_bgzk_xlsxt_jzxt_checkvalue(project_code,task_no,xls_code,xls_name,facility_code,facility_name,datapushdate,disease) VALUES(@project_code,@task_no,@xls_code,@xls_name,@facility_code,@facility_name,NOW(),@disease)";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@xls_name", models.xls_name));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 修改斜拉索减振系统检查状况信息
        /// </summary>
        /// <param name="models"></param>
        public void Update_jzxt_checkvalue(jzxt_checkvalue models, string ID)
        {
            string sql = "UPDATE tb_bridge_bgzk_xlsxt_jzxt_checkvalue SET project_code = @project_code ,task_no = @task_no,xls_code = @xls_code,xls_name = @xls_name,facility_code = @facility_code,facility_name= @facility_name,disease = @disease,datapushdate=now() where id=@id";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", models.project_Code));
                param.Add(DbHelper.CreateParameter("@task_no", models.taskNo));
                param.Add(DbHelper.CreateParameter("@xls_code", models.xls_code));
                param.Add(DbHelper.CreateParameter("@xls_name", models.xls_name));
                param.Add(DbHelper.CreateParameter("@facility_code", models.facility_code));
                param.Add(DbHelper.CreateParameter("@facility_name", models.facility_name));
                param.Add(DbHelper.CreateParameter("@disease", models.disease));
                param.Add(DbHelper.CreateParameter("@id", ID));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }
        #endregion

        #region 斜拉桥评价接口

        /// <summary>
        /// 总体评价任务
        /// </summary>
        /// <param name="model"></param>
        public void Addtb_model_overall_eval(tb_model_overall_eval model)
        {
            string sql = @"INSERT INTO tb_model_overall_eval(project_code,facility_type,status,main_taskno,tjzq_taskno,tjyq_taskno,jd_taskno,af_taskno,os_taskno,last_update,error_msg)VALUES (@project_code, @facility_type, @status,@main_taskno, @tjzq_taskno, @tjyq_taskno, @jd_taskno, @af_taskno,@os_taskno,Now(),'请确认数据状态为Success,请等待状态更新再进行获取!' );";
            string tjyq_taskno = "[";
            for (int i = 0; i < model.tjyq_taskno.Length; i++)
            {
                 tjyq_taskno += "\""+ model.tjyq_taskno[i] + "\"";
                if (i!= model.tjyq_taskno.Length - 1)
                {
                    tjyq_taskno += ",";
                }
            }
            tjyq_taskno += "]";

            string tjzq_taskno = "[";
            for (int i = 0; i < model.tjzq_taskno.Length; i++)
            {
                tjzq_taskno += "\"" + model.tjzq_taskno[i] + "\"";
                if (i != model.tjzq_taskno.Length - 1)
                {
                    tjzq_taskno += ",";
                }
            }
            tjzq_taskno += "]";

            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@project_code", model.project_code));
                param.Add(DbHelper.CreateParameter("@facility_type", model.facility_type));
                param.Add(DbHelper.CreateParameter("@status", model.status));
                param.Add(DbHelper.CreateParameter("@main_taskno", model.main_taskno));
                param.Add(DbHelper.CreateParameter("@tjzq_taskno", tjzq_taskno));
                param.Add(DbHelper.CreateParameter("@tjyq_taskno", tjyq_taskno));
                param.Add(DbHelper.CreateParameter("@jd_taskno", model.jd_taskno));
                param.Add(DbHelper.CreateParameter("@af_taskno", model.af_taskno));
                param.Add(DbHelper.CreateParameter("@os_taskno", model.os_taskno));
                DbHelper.ExecuteNonQuery(sql, CommandType.Text, param.ToArray());
            }
        }

        /// <summary>
        /// 查询总体评价结果状态
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public string Seach_tb_model_overall_evalStatus(string task_no)
        {
            string sql = "SELECT error_msg from tb_model_overall_eval WHERE main_taskno=@task_no and  status != 'Success';";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                if (DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()) == null)
                    return "";
                else
                    return DbHelper.ExecuteScalar(sql, CommandType.Text, param.ToArray()).ToString();
            }
        }

        public List<T> getOverallEvaluationResult<T>(string task_no, string tablename)
        {
            string sql = "SELECT * FROM " + tablename + " WHERE main_taskno=@task_no";
            List<DbParameter> param = new List<DbParameter>();
            using (var DbHelper = DBManager.CoreHelper)
            {
                param.Add(DbHelper.CreateParameter("@task_no", task_no));
                //return DbHelper.ExecuteReaderObject<List<T>>(sql, CommandType.Text, param.ToArray());
                return DataTableToDataList<T>(DbHelper.ExecuteDataTable(sql, param.ToArray()));
            }
        }
        #endregion
    }
}
