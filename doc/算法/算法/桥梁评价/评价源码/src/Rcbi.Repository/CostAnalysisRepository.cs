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

namespace Rcbi.Repository
{
    public class CostAnalysisRepository : BaseRepository<ModelFINMaterialPrice>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PriceYear"></param>
        /// <returns></returns>
        public DataTable GetModelFINMaterialPrice(CostAnalysisQuery query, out int total)
        {
            var sql = @"select 
                        ID,
                        MaterialID,
                        MaterialName,
                        MaterialUnit,
                        CostType,
                        MaterialPrice,
                        PriceYear
                        from tb_model_FIN_MaterialPrice 
                        where PriceYear=@PriceYear
                        ORDER BY ID DESC
                        {0} 
                    ";
            var querySql = string.Format(sql,
                  string.Format(" limit {0}, {1}", (query.Page - 1) * query.Limit, query.Limit)
               );
            total = ConvertHelper.ToInt32(this.ExecuteDataTable("select count(1) as total from  tb_model_FIN_MaterialPrice  where PriceYear = @PriceYear   ",
                this.DbHelper.CreateParameter("@PriceYear", query.year)).Rows[0]["total"]);
            // total = 0;
            return this.ExecuteDataTable(querySql,
                       this.DbHelper.CreateParameter("@PriceYear", query.year));
        }


        /// <summary>
        /// 插入ModelFINConMain表
        /// </summary>
        /// <param name="tunnelCode"></param>
        /// <returns></returns>
        public bool InsertModelFINConMain(ModelFINConMain model)
        {

            var sql = @"
                        insert into tb_model_FIN_Con_Main
	                            (
                                ConfigID,
                                TaskModel,
                                ProjectID,
                                ConfigDate,
                                SpecYear,
                                PriceYear
                                )
                            VALUES(
                                @ConfigID,
                                @TaskModel,
                                @ProjectID,
                                @ConfigDate,
                                @SpecYear,
                                @PriceYear);
                 ";
            this.ExecuteNonQuery(sql, DbHelper.CreateParameter("@ConfigID", model.ConfigID)
                , DbHelper.CreateParameter("@TaskModel", model.TaskModel)
                , DbHelper.CreateParameter("@ProjectID", model.ProjectID)
                , DbHelper.CreateParameter("@ConfigDate", model.ConfigDate)
                , DbHelper.CreateParameter("@SpecYear", model.SpecYear)
                 , DbHelper.CreateParameter("@PriceYear", model.PriceYear));
            return true;
        }

        public bool UpdateModelFINConMain(ModelFINConMain model)
        {
            var sql = @"UPDATE  tb_model_FIN_Con_Main 
                        SET TaskModel=@TaskModel,
                        ProjectID=@ProjectID,
                        ConfigDate=@ConfigDate,
                        SpecYear=@SpecYear,
                        PriceYear=@PriceYear 
                        WHERE ConfigID=@ConfigID;";
            this.ExecuteNonQuery(sql, DbHelper.CreateParameter("@ConfigID", model.ConfigID)
                , DbHelper.CreateParameter("@TaskModel", model.TaskModel)
                , DbHelper.CreateParameter("@ProjectID", model.ProjectID)
                , DbHelper.CreateParameter("@ConfigDate", model.ConfigDate)
                , DbHelper.CreateParameter("@SpecYear", model.SpecYear)
                 , DbHelper.CreateParameter("@PriceYear", model.PriceYear));



            return true;
        }

        public bool DeleteModelFINConProjectCountBatch(string ConfigID)
        {
            string sql = @"DELETE FROM tb_model_FIN_Con_ProjectCount WHERE ConfigID=@ConfigID";
            return this.ExecuteNonQuery(sql,
              this.DbHelper.CreateParameter("@ConfigID", ConfigID)) > 0;
        }

        public bool DeleteModelFINConProjectUnitCountBatch(string ConfigID)
        {
            string sql = @"DELETE FROM tb_model_FIN_Con_ProjectUnitCount WHERE ConfigID=@ConfigID";
            return this.ExecuteNonQuery(sql,
              this.DbHelper.CreateParameter("@ConfigID", ConfigID)) > 0;
        }
        public bool DeleteModelFINConIndiscountBatch(string ConfigID)
        {
            string sql = @"DELETE FROM tb_model_FIN_Con_Indiscount WHERE ConfigID=@ConfigID";
            return this.ExecuteNonQuery(sql,
              this.DbHelper.CreateParameter("@ConfigID", ConfigID)) > 0;
        }
        public bool DeleteModelFINConFeeDiscountBatch(string ConfigID)
        {
            string sql = @"DELETE FROM tb_model_FIN_Con_FeeDiscount WHERE ConfigID=@ConfigID";
            return this.ExecuteNonQuery(sql,
              this.DbHelper.CreateParameter("@ConfigID", ConfigID)) > 0;
        }

        /// <summary>
        /// 批量插入ModelFINConProjectCount
        /// </summary>
        /// <param name="tunnelCode"></param>
        /// <param name="segmentSerials"></param>
        /// <param name="currentUserName"></param>
        /// <returns></returns>
        public long InsertModelFINConProjectCountBatch(List<ModelFINConProjectCount> model, string ConfigID)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("SectionUnitID", typeof(string)));
            table.Columns.Add(new DataColumn("InputMaitainItemWork", typeof(float)));
            table.Columns.Add(new DataColumn("TransformedMaitainItemWork", typeof(decimal)));
            table.Columns.Add(new DataColumn("ConfigID", typeof(string)));
            DataRow row = null;
            int i = 1;
            foreach (var da in model)
            {
                row = table.NewRow();
                row["SectionUnitID"] = da.SectionUnitID;
                row["InputMaitainItemWork"] = da.InputMaitainItemWork;
                row["TransformedMaitainItemWork"] = da.TransformedMaitainItemWork;
                row["ConfigID"] = ConfigID;

                table.Rows.Add(row);
                i++;
            }
            return this.BatchInsert(table, "tb_model_FIN_Con_ProjectCount");
        }



        /// <summary>
        /// 批量插入ModelFINConProjectUnitCount
        /// </summary>
        /// <param name="tunnelCode"></param>
        /// <param name="segmentSerials"></param>
        /// <param name="currentUserName"></param>
        /// <returns></returns>
        public long InsertModelFINConProjectUnitCountBatch(List<ModelFINConProjectUnitCount> model, string ConfigID)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("SectionUnitID", typeof(string)));
            table.Columns.Add(new DataColumn("MaintainItemID", typeof(string)));
            table.Columns.Add(new DataColumn("MaitainItemWorkAmount", typeof(decimal)));
            table.Columns.Add(new DataColumn("ConfigID", typeof(string)));
            DataRow row = null;
            int i = 1;
            foreach (var da in model)
            {
                row = table.NewRow();
                row["SectionUnitID"] = da.SectionUnitID;
                row["MaintainItemID"] = da.MaintainItemID;
                row["MaitainItemWorkAmount"] = da.MaitainItemWorkAmount;
                row["ConfigID"] = ConfigID;
                table.Rows.Add(row);
                i++;
            }
            return this.BatchInsert(table, "tb_model_FIN_Con_ProjectUnitCount");
        }


        /// <summary>
        /// 批量插入MdelFINConIndiscount
        /// </summary>
        /// <param name="tunnelCode"></param>
        /// <param name="segmentSerials"></param>
        /// <param name="currentUserName"></param>
        /// <returns></returns>
        public long InsertMdelFINConIndiscountBatch(List<MdelFINConIndiscount> model, string ConfigID)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("FeeItemName", typeof(string)));
            table.Columns.Add(new DataColumn("Ratio", typeof(decimal)));
            table.Columns.Add(new DataColumn("ConfigID", typeof(string)));
            DataRow row = null;
            int i = 1;
            foreach (var da in model)
            {
                row = table.NewRow();
                row["FeeItemName"] = da.FeeItemName;
                row["Ratio"] = da.Ratio;
                row["ConfigID"] = ConfigID;
                table.Rows.Add(row);
                i++;
            }
            return this.BatchInsert(table, "tb_model_FIN_Con_Indiscount");
        }

        /// <summary>
        /// 批量插入ModelFINConFeeDiscount
        /// </summary>
        /// <param name="tunnelCode"></param>
        /// <param name="segmentSerials"></param>
        /// <param name="currentUserName"></param>
        /// <returns></returns>
        public long InsertModelFINConFeeDiscountBatch(List<ModelFINConFeeDiscount> model, string ConfigID)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn("ItemName", typeof(string)));
            table.Columns.Add(new DataColumn("Ratio", typeof(decimal)));
            table.Columns.Add(new DataColumn("ConfigID", typeof(string)));
            DataRow row = null;
            int i = 1;
            foreach (var da in model)
            {
                row = table.NewRow();
                row["ItemName"] = da.ItemName;
                row["Ratio"] = da.Ratio;
                row["ConfigID"] = ConfigID;
                table.Rows.Add(row);
                i++;
            }
            return this.BatchInsert(table, "tb_model_FIN_Con_FeeDiscount");
        }

        public bool UpdateSubmitStatus(string id)
        {
            string sql = @"UPDATE tb_model_result_main  
                                SET is_submit=@is_submit
                                WHERE id=@id;";
            return this.ExecuteNonQuery(sql,
              this.DbHelper.CreateParameter("@is_submit", 1),
              this.DbHelper.CreateParameter("@id", id)) > 0;
        }

        public IList<ModelFINConFeeDiscount> GetInsertModelFINConFeeDiscountBatchs(string conifgId)
        {
            string sql = "select * from tb_model_FIN_Con_FeeDiscount where ConfigID=@ConfigID";
            var DbHelper = DBManager.CoreHelper;
            return DbHelper.ExecuteReaderList<ModelFINConFeeDiscount>(sql, CommandType.Text, DbHelper.CreateParameter("@ConfigID", conifgId));
        }

        public IList<MdelFINConIndiscount> GetMdelFINConIndiscountBatch(string conifgId)
        {
            string sql = "select * from tb_model_FIN_Con_Indiscount where ConfigID=@ConfigID";
            var DbHelper = DBManager.CoreHelper;
            return DbHelper.ExecuteReaderList<MdelFINConIndiscount>(sql, CommandType.Text, DbHelper.CreateParameter("@ConfigID", conifgId));
        }

        public IList<ModelFINConProjectUnitCount> GetModelFINConProjectUnitCountBatch(string conifgId)
        {
            string sql = "select * from tb_model_FIN_Con_ProjectUnitCount where ConfigID=@ConfigID";
            var DbHelper = DBManager.CoreHelper;
            return DbHelper.ExecuteReaderList<ModelFINConProjectUnitCount>(sql, CommandType.Text, DbHelper.CreateParameter("@ConfigID", conifgId));
        }

        public IList<ModelFINConProjectCount> GetModelFINConProjectCountBatch(string conifgId)
        {
            string sql = "select * from tb_model_FIN_Con_ProjectCount where ConfigID=@ConfigID";
            var DbHelper = DBManager.CoreHelper;
            return DbHelper.ExecuteReaderList<ModelFINConProjectCount>(sql, CommandType.Text, DbHelper.CreateParameter("@ConfigID", conifgId));
        }

        public ModelFINConMain GetModelFINConMain(string conifgId)
        {
            string sql = "select * from tb_model_FIN_Con_Main where ConfigID=@ConfigID";
            var DbHelper = DBManager.CoreHelper;
            return DbHelper.ExecuteReaderObject<ModelFINConMain>(sql, CommandType.Text, DbHelper.CreateParameter("@ConfigID", conifgId));
        }

        public bool DeleteModelFINMaterialPrice(int id)
        {
            string sql = @"DELETE FROM tb_model_FIN_MaterialPrice WHERE id=@id";
            return this.ExecuteNonQuery(sql,
              this.DbHelper.CreateParameter("@id", id)) > 0;
        }

        public bool AddModelFINMaterialPrice(List<ModelFINMaterialPrice> list)
        {
            string sql = @"INSERT INTO tb_model_fin_materialprice ( MaterialID, MaterialName, MaterialUnit, CostType, MaterialPrice, PriceYear )VALUES";
            List<string> values = new List<string>();
            List<DbParameter> param = new List<DbParameter>();
            for (int i = 0; i < list.Count; i++)
            {
                values.Add(string.Format("(@MaterialID{0},@MaterialName{0},@MaterialUnit{0},@CostType{0},@MaterialPrice{0},@PriceYear{0})", i));
                param.Add(DbHelper.CreateParameter("@MaterialID" + i, list[i].MaterialID));
                param.Add(DbHelper.CreateParameter("@MaterialName" + i, list[i].MaterialName));
                param.Add(DbHelper.CreateParameter("@MaterialUnit" + i, list[i].MaterialUnit));
                param.Add(DbHelper.CreateParameter("@CostType" + i, list[i].CostType));
                param.Add(DbHelper.CreateParameter("@MaterialPrice" + i, list[i].MaterialPrice));
                param.Add(DbHelper.CreateParameter("@PriceYear" + i, list[i].PriceYear));
            }
            return this.ExecuteNonQuery(sql + string.Join(",", values), param.ToArray()) > 0;
        }

        public bool UpdateModelFINMaterialPrice(int id, string field, string value)
        {
            string sql = string.Format("UPDATE tb_model_fin_materialprice SET {0}=@{0} WHERE ID=@ID ", field);
            return this.ExecuteNonQuery(sql, DbHelper.CreateParameter("@" + field, value),
                DbHelper.CreateParameter("@ID", id)) > 0;
        }
    }
}
