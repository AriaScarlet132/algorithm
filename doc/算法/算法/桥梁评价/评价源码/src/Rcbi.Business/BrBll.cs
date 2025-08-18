using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Rcbi.AspNetCore.Helper;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Enums;
using Rcbi.Entity.OpenApi;
using Rcbi.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace Rcbi.Business
{
    public class BrBll     
    {
        BrRepository brRepository = new BrRepository();
        public OpenApiResult<bool> AddFacilitylist(List<TbBridgeAssessmentFacilitylist> models)
        {
            foreach (var item in models)
            {
                string id = brRepository.CheckModelBrTrafficDriveSpeed(item);
                if (!string.IsNullOrEmpty(id))
                {
                    brRepository.UpdateModelBrTrafficDriveSpeed(item, id);
                }
                else
                {
                    brRepository.AddModelBrTrafficDriveSpeed(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<Bridgetjeva_ModelTjBgzkInfos> GetModelTjBgzkInfos(string task_no)
        {
            Bridgetjeva_ModelTjBgzkInfos m = new Bridgetjeva_ModelTjBgzkInfos();
            m.xlsxt_results = brRepository.GetListModelByTableNameAndTaskno<xlsxt_results>(task_no, "tb_bridge_bgzk_xlsxt_output");
            m.st_results = brRepository.GetListModelByTableNameAndTaskno<st_results>(task_no, "tb_bridge_bgzk_stxt_st_output");
            m.zl_results = brRepository.GetListModelByTableNameAndTaskno<zl_results>(task_no, "tb_bridge_bgzk_zlxt_zl_output");
            m.qd_results = brRepository.GetListModelByTableNameAndTaskno<qd_results>(task_no, "tb_bridge_bgzk_xbjg_qd_output");
            m.qt_results = brRepository.GetListModelByTableNameAndTaskno<qt_results>(task_no, "tb_bridge_bgzk_xbjg_qt_output");
            m.jcct_results = brRepository.GetListModelByTableNameAndTaskno<jcct_results>(task_no, "tb_bridge_bgzk_xbjg_jcct_output");
            m.qmpz_results = brRepository.GetListModelByTableNameAndTaskno<qmpz_results>(task_no, "tb_bridge_bgzk_qmx_qmpz_output");
            m.sszz_results = brRepository.GetListModelByTableNameAndTaskno<sszz_results>(task_no, "tb_bridge_bgzk_qmx_sszz_output");
            m.rxd_results = brRepository.GetListModelByTableNameAndTaskno<rxd_results>(task_no, "tb_bridge_bgzk_qmx_rxd_output");
            m.zz_results = brRepository.GetListModelByTableNameAndTaskno<zz_results>(task_no, "tb_bridge_bgzk_zzxt_zz_output");
            m.znq_results = brRepository.GetListModelByTableNameAndTaskno<znq_results>(task_no, "tb_bridge_bgzk_zzxt_znq_output");
            return new OpenApiResult<Bridgetjeva_ModelTjBgzkInfos>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<Bridgetjeva_ModelTjYyhjInfos> GetModelTjYyhjInfos(string task_no)
        {
            Bridgetjeva_ModelTjYyhjInfos m = new Bridgetjeva_ModelTjYyhjInfos();
            m.jtl_results = brRepository.GetListModelByTableNameAndTaskno<jtl_results>(task_no, "tb_bridge_yyhj_jtl_output");
            m.fs_results = brRepository.GetListModelByTableNameAndTaskno<fs_results>(task_no, "tb_bridge_yyhj_fs_output");
            m.qmzjd_results = brRepository.GetListModelByTableNameAndTaskno<qmzjd_results>(task_no, "tb_bridge_yyhj_qmzjd_output");
            m.czczfx_results = brRepository.GetListModelByTableNameAndTaskno<czczfx_results>(task_no, "tb_bridge_yyhj_czczfx_output");
            m.wd_results = brRepository.GetListModelByTableNameAndTaskno<wd_results>(task_no, "tb_bridge_yyhj_wd_output");
            return new OpenApiResult<Bridgetjeva_ModelTjYyhjInfos>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        public OpenApiResult<List<Bridgetjeva_ModelTjInfos>> GetModelTjInfos(string task_no)
        {
            List<Bridgetjeva_ModelTjInfos> m = brRepository.GetListModelByTableNameAndTaskno<Bridgetjeva_ModelTjInfos>(task_no, "tb_bridge_assessment_output");
            return new OpenApiResult<List<Bridgetjeva_ModelTjInfos>>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<Bridgetjeva_ModelTjLxxnInfos> GetModelTjLxxnInfos(string task_no)
        {
            Bridgetjeva_ModelTjLxxnInfos m = new Bridgetjeva_ModelTjLxxnInfos();
            m.xlssl_results = brRepository.GetListModelByTableNameAndTaskno<xlssl_results>(task_no, "tb_bridge_lxxn_xlssl_output");
            m.jcwy_results = brRepository.GetListModelByTableNameAndTaskno<jcwy_results>(task_no, "tb_bridge_lxxn_jhbw_jcwy_output");
            m.tdwy_results = brRepository.GetListModelByTableNameAndTaskno<tdwy_results>(task_no, "tb_bridge_lxxn_jhbw_tdwy_output");
            m.zlxx_results = brRepository.GetListModelByTableNameAndTaskno<zlxx_results>(task_no, "tb_bridge_lxxn_jhbw_zlxx_output");
            m.jgyl_results = brRepository.GetListModelByTableNameAndTaskno<jgyl_results>(task_no, "tb_bridge_lxxn_jgyl_output");
            m.jgpl_results = brRepository.GetListModelByTableNameAndTaskno<jgpl_results>(task_no, "tb_bridge_lxxn_jgpl_output");

            m.sszz_results = brRepository.GetListModelByTableNameAndTaskno<sszz_results>(task_no, "tb_bridge_lxxn_sszz_output");
            m.zzwy_results = brRepository.GetListModelByTableNameAndTaskno<zzwy_results>(task_no, "tb_bridge_lxxn_zzwy_output");
            return new OpenApiResult<Bridgetjeva_ModelTjLxxnInfos>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddLxxnData(BridgetaddLxxnData models)
        {
            add_xlssl_checkvalue(models.xlssl_checkvalue);
            add_jcwy_checkvalue(models.jcwy_checkvalue);
            add_tdwy_checkvalue(models.tdwy_checkvalue);
            add_zlxx_checkvalue(models.zlxx_checkvalue);
            add_jgyl_checkvalue(models.jgyl_checkvalue);
            add_jgpl_checkvalue(models.jgpl_checkvalue);
            //20230720
            add_lxxn_sszz_checkvalue(models.sszz_checkvalue);
            add_lxxn_zzwy_checkvalue(models.zzwy_checkvalue);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #region    20230720
        public OpenApiResult<bool> AddDqjcData(BridgetaddDqjcData models)
        {
            add_dqjc_zlxx_checkvalue(models.zlxx_checkvalue);
            add_dqjc_jcwy_checkvalue(models.jcwy_checkvalue);
            add_dqjc_tdwy_checkvalue(models.tdwy_checkvalue);
            add_dqjc_xlssl_checkvalue(models.xlssl_checkvalue);
            add_dqjc_jgpl_checkvalue(models.jgpl_checkvalue);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public void add_dqjc_zlxx_checkvalue(List<tb_bridge_dqjc_zlxx_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_dqjc_zlxx_checkvalue(item);
            }
        }
        public void add_dqjc_jcwy_checkvalue(List<tb_bridge_dqjc_jcwy_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_dqjc_jcwy_checkvalue(item);
            }
        }
        public void add_dqjc_tdwy_checkvalue(List<tb_bridge_dqjc_tdwy_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_dqjc_tdwy_checkvalue(item);
            }
        }
        public void add_dqjc_xlssl_checkvalue(List<tb_bridge_dqjc_xlssl_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_dqjc_xlssl_checkvalue(item);
            }
        }
        public void add_dqjc_jgpl_checkvalue(List<tb_bridge_dqjc_jgpl_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_dqjc_jgpl_checkvalue(item);
            }
        }
        #endregion

        public void add_xlssl_checkvalue(List<xlssl_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_xlssl_checkvalue(item);
            }
        }
        public void add_jcwy_checkvalue(List<jcwy_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_jcwy_checkvalue(item);
            }
        }
        public void add_tdwy_checkvalue(List<tdwy_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_tdwy_checkvalue(item);
            }
        }
        public void add_zlxx_checkvalue(List<zlxx_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_zlxx_checkvalue(item);
            }
        }
        public void add_jgyl_checkvalue(List<jgyl_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_jgyl_checkvalue(item);
            }
        }
        public void add_jgpl_checkvalue(List<jgpl_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_jgpl_checkvalue(item);
            }
        } 
        /// <summary>
        /// 20230720
        /// </summary>
        /// <param name="models"></param>
        public void add_lxxn_sszz_checkvalue(List<tb_bridge_lxxn_sszz_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.lxxn_sszz_checkvalue(item);
            }
        }
        public void add_lxxn_zzwy_checkvalue(List<tb_bridge_lxxn_zzwy_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.lxxn_zzwy_checkvalue(item);
            }
        } 

        public OpenApiResult<bool> AddYyhjData(BridgetaddYyhjData models)
        {
            add_jtl_checkvalue(models.jtl_checkvalue);
            add_wd_checkvalue(models.wd_checkvalue);
            add_fs_checkvalue(models.fs_checkvalue);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public void add_jtl_checkvalue(List<jtl_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_jtl_checkvalue(item);
            }
        }
        public void add_wd_checkvalue(List<wd_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_wd_checkvalue(item);
            }
        }
        public void add_fs_checkvalue(List<fs_checkvalue> models)
        {
            foreach (var item in models)
            {
                brRepository.add_fs_checkvalue(item);
            }
        }


        #region 土建结构评价接口/输入-表观状况

        #region 【分析数据】桥面系
        /// <summary>
        /// 添加桥面信息模型
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> addQmxData(BridgetaddQmxData models)
        {
            add_qmpz_checkvalue(models.qmpz_checkvalue);
            add_rxd_checkvalue(models.rxd_checkvalue);
            add_sszz_checkvalue(models.sszz_checkvalue);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public void add_qmpz_checkvalue(List<qmpz_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_qmpz_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_qmpz_checkvalue(item, ID);
                }
                else {
                    brRepository.add_qmpz_checkvalue(item);
                }
                
            }
        }
        public void add_rxd_checkvalue(List<rxd_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_rxd_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_rxd_checkvalue(item, ID);
                }
                else
                {
                    brRepository.add_rxd_checkvalue(item);
                }
            }
        }
        public void add_sszz_checkvalue(List<sszz_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_sszz_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_sszz_checkvalue(item,ID);
                }
                else
                {
                    brRepository.add_sszz_checkvalue(item);
                }
            }
        }
        #endregion

        #region【分析数据】主梁系统
        public OpenApiResult<bool>  addZlData(List<BridgetaddZlData> models) {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_ZlData(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.UpdateZlData(item,ID);
                }
                else {
                    brRepository.addZlData(item);
                }
               
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 【分析数据】支座及限位装置
        /// <summary>
        /// 添加支座及限位装置信息模型
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> addZzxtData(BridgetaddZzxtData models)
        {
            add_zz_checkvalue(models.zz_checkvalue);
            add_znq_checkvalue(models.znq_checkvalue);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public void add_zz_checkvalue(List<zz_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_zz_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_zz_checkvalue(item, ID);
                }
                else
                {
                    brRepository.add_zz_checkvalue(item);
                }
            }
        }
        public void add_znq_checkvalue(List<znq_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_znq_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_znq_checkvalue(item,ID);
                }
                else {
                    brRepository.add_znq_checkvalue(item);
                }
            }
        }
        #endregion

        #region 【分析数据】下部结构
        /// <summary>
        /// 添加下部结构信息模型
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> addXbjgData(BridgetaddXbjgData models)
        {
            add_qd_checkvalue(models.qd_checkvalue);
            add_qt_checkvalue(models.qt_checkvalue);
            add_jcct_checkvalue(models.jcct_checkvalue);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public void add_qd_checkvalue(List<qd_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_qd_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_qd_checkvalue(item,ID);
                }
                else {
                    brRepository.add_qd_checkvalue(item);
                }
            }
        }
        public void add_qt_checkvalue(List<qt_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_qt_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_qt_checkvalue(item, ID);
                }
                else
                {
                    brRepository.add_qt_checkvalue(item);
                }
            }
        }
        public void add_jcct_checkvalue(List<jcct_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_jcct_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_jcct_checkvalue(item, ID);
                }
                else
                {
                    brRepository.add_jcct_checkvalue(item);
                }   
            }
        }
        #endregion

        #region【分析数据】索塔系统
        public OpenApiResult<bool> addStData(List<BridgetaddStData> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_StData(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.UpdateStData(item,ID);
                }
                else
                {
                    brRepository.addStData(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 【分析数据】斜拉索系统
        /// <summary>
        /// 添加斜拉索信息模型
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> addXlsData(BridgetaddXlsData models)
        {
            add_xls_checkvalue(models.xls_checkvalue);
            add_xlsht_checkvalue(models.xlsht_checkvalue);
            add_mgxt_checkvalue(models.mgxt_checkvalue);
            add_jzxt_checkvalue(models.jzxt_checkvalue);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public void add_xls_checkvalue(List<xls_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_xls_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_xls_checkvalue(item,ID);
                }
                else {
                    brRepository.add_xls_checkvalue(item);
                }
            }
        }
        public void add_xlsht_checkvalue(List<xlsht_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_xlsht_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_xlsht_checkvalue(item, ID);
                }
                else {
                    brRepository.add_xlsht_checkvalue(item);
                }
            }
        }
        public void add_mgxt_checkvalue(List<mgxt_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_mgxt_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_mgxt_checkvalue(item, ID);
                }
                else
                {
                    brRepository.add_mgxt_checkvalue(item);
                }
            }
        }
        public void add_jzxt_checkvalue(List<jzxt_checkvalue> models)
        {
            foreach (var item in models)
            {
                //判断数据是否重复,重复就修改数据，否则添加
                string ID = brRepository.Seach_jzxt_checkvalue(item);
                if (!string.IsNullOrEmpty(ID))
                {
                    brRepository.Update_jzxt_checkvalue(item, ID);
                }
                else
                {
                    brRepository.add_jzxt_checkvalue(item);
                }
            }
        }
        #endregion
        #endregion

        #region 斜拉桥评价接口对接
        #region 添加总体评价任务
        /// <summary>
        /// 创建添加总体评价任务
        /// </summary>
        /// <returns></returns>
        public OpenApiResult<string> CreateOverallEvaluationTask(OverallEvaluation model)
        {
            DateTime dtNow = DateTime.Now;
            string main_taskno = model.project_code + "-" + dtNow.ToString("yyyyMMddHHmmss");
            //List<tb_model_overall_eval> table = new List<tb_model_overall_eval>();
            tb_model_overall_eval table = new tb_model_overall_eval();

            //foreach (var item in model.tjyq_taskno)
            //{
            //    tb_model_overall_eval _table = new tb_model_overall_eval
            //    {
            //        project_code = model.project_code,
            //        facility_type = model.facility_type,
            //        status = "Start",
            //        main_taskno = main_taskno,
            //        tjzq_taskno = model.tjzq_taskno,
            //        jd_taskno = model.jd_taskno,
            //        af_taskno = model.af_taskno,
            //        os_taskno = model.os_taskno,
            //        tjyq_taskno = item
            //    };
            //    table.Add(_table);
            //}
            //Addtb_model_overall_eval(table);
            //string ret = IispBll.CreateTask(table);

            tb_model_overall_eval _table = new tb_model_overall_eval
            {
                project_code = model.project_code,
                facility_type = model.facility_type,
                status = "Start",
                main_taskno = main_taskno,
                tjzq_taskno = model.tjzq_taskno,
                jd_taskno = model.jd_taskno,
                af_taskno = model.af_taskno,
                os_taskno = model.os_taskno,
                tjyq_taskno = model.tjyq_taskno
            };
            Addtb_model_overall_eval(_table);
            return new OpenApiResult<string>
            {
                Data = main_taskno,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        //public void Addtb_model_overall_eval(List<tb_model_overall_eval> models)
        //{
        //    if (models == null)
        //    {
        //        throw new ArgumentNullException("model");
        //    }
        //    foreach (var item in models)
        //    {

        //        brRepository.Addtb_model_overall_eval(item);
        //    }

        //}

        public void Addtb_model_overall_eval(tb_model_overall_eval models)
        {
            if (models == null)
            {
                throw new ArgumentNullException("model");
            }
            brRepository.Addtb_model_overall_eval(models);

        }
        #endregion

        #region  获取总体评价结果
        /// <summary>
        /// 获取总体评价结果
        /// </summary>
        /// <param name="task_no"></param>
        /// <returns></returns>
        public OpenApiResult<List<tb_model_overall_eval2>> getOverallEvaluationResult(string task_no)
        {
            //判断该任务是否已经完成
            string error_msg = brRepository.Seach_tb_model_overall_evalStatus(task_no);
            //string error_msg = "";
            if (string.IsNullOrEmpty(error_msg))
            {
                List<tb_model_overall_eval2> m = brRepository.getOverallEvaluationResult<tb_model_overall_eval2>(task_no, "tb_model_overall_eval");
                return new OpenApiResult<List<tb_model_overall_eval2>>
                {
                    Data = m,
                    Status = (int)OpenApiResultStatus.SUCCESS,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
                };
            }
            else {
                return new OpenApiResult<List<tb_model_overall_eval2>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.SUCCESS,
                    Message = error_msg
                };
            }
            
        }
        #endregion
        #endregion

    }
}
