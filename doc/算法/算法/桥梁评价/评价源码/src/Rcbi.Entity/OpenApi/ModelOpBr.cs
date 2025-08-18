using System;
using System.Collections.Generic;
using System.Text;
using Rcbi.Core.Attributes;

namespace Rcbi.Entity.OpenApi
{
    class ModelOpBr
    {
    }
    [Table("tb_bridge_assessment_facilitylist")]
    public class TbBridgeAssessmentFacilitylist
    {
        public int id { get; set; }
        public string task_no { get; set; }
        public string project_code { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
    }

    /// <summary>
    /// 获取力学性能评价结果
    /// </summary>
    public class Bridgetjeva_ModelTjLxxnInfos
    {
        public List<xlssl_results> xlssl_results { get; set; }
        public List<jcwy_results> jcwy_results { get; set; }
        public List<tdwy_results> tdwy_results { get; set; }
        public List<zlxx_results> zlxx_results { get; set; }
        public List<jgyl_results> jgyl_results { get; set; }
        public List<jgpl_results> jgpl_results { get; set; }

        public List<sszz_results> sszz_results { get; set; }
        public List<zzwy_results> zzwy_results { get; set; }

    }
    [Table("tb_bridge_lxxn_xlssl_output")]
    public class xlssl_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }

    }

    [Table("tb_bridge_lxxn_jhbw_jcwy_output")]
    public class jcwy_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }

    }
    [Table("tb_bridge_lxxn_jhbw_tdwy_output")]
    public class tdwy_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }

    }
    [Table("tb_bridge_lxxn_jhbw_zlxx_output")]
    public class zlxx_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }

    }

    [Table("tb_bridge_lxxn_jgyl_output")]
    public class jgyl_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }

    }

    [Table("tb_bridge_lxxn_jgpl_output")]
    public class jgpl_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    [Table("tb_bridge_lxxn_sszz_output")]
    public class sszz_results {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float? points { get; set; }
        public float? grade { get; set; }
    }
    [Table("tb_bridge_lxxn_zzwy_output")]
    public class zzwy_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float? points { get; set; }
        public float? grade { get; set; }
    }

    /// <summary>
    /// 获取土建结构总体评价结果
    /// </summary>
    public class Bridgetjeva_ModelTjInfos
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string parent_code { get; set; }
        public string parent_name { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public float weight { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }

    }

    /// <summary>
    /// 获取运营环境评价结果
    /// </summary>
    public class Bridgetjeva_ModelTjYyhjInfos
    {
        public List<jtl_results> jtl_results { get; set; }
        public List<fs_results> fs_results { get; set; }
        public List<qmzjd_results> qmzjd_results { get; set; }
        public List<czczfx_results> czczfx_results { get; set; }
        public List<wd_results> wd_results { get; set; }
    }
    public class jtl_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class fs_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }

        public float? grade { get; set; }
    }
    public class qmzjd_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class czczfx_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class wd_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    /// <summary>
    /// 获取表观状况评价结果
    /// </summary>
    public class Bridgetjeva_ModelTjBgzkInfos
    {
        public List<xlsxt_results> xlsxt_results { get; set; }
        public List<st_results> st_results { get; set; }
        public List<zl_results> zl_results { get; set; }
        public List<qd_results> qd_results { get; set; }
        public List<qt_results> qt_results { get; set; }
        public List<jcct_results> jcct_results { get; set; }
        public List<qmpz_results> qmpz_results { get; set; }
        public List<sszz_results> sszz_results { get; set; }
        public List<rxd_results> rxd_results { get; set; }
        public List<zz_results> zz_results { get; set; }
        public List<znq_results> znq_results { get; set; }

    }
    /// <summary>
    /// tb_bridge_bgzk_xlsxt_output
    /// </summary>
    public class xlsxt_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string xls_code { get; set; }
        public string xls_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float xlsst_points { get; set; }
        public float xlsht_points { get; set; }
        public float mgxt_points { get; set; }
        public float jzxt_points { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
        public float? xlsst_grade { get; set; }
        public float? xlsht_grade { get; set; }
        public float? mgxt_grade { get; set; }
        public float? jzxt_grade { get; set; }
    }
    public class st_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class zl_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class qd_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class qt_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class jcct_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class qmpz_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    //public class sszz_results
    //{
    //    public int id { get; set; }
    //    public string project_code { get; set; }
    //    public string taskNo { get; set; }
    //    public string facility_code { get; set; }
    //    public string facility_name { get; set; }
    //    public DateTime? datapushdate { get; set; }
    //    public float points { get; set; }
    //    public float? grade { get; set; }
    //}
    public class rxd_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class zz_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }
    public class znq_results
    {
        public int id { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float points { get; set; }
        public float? grade { get; set; }
    }

    #region 20230720新增接口
     public class BridgetaddDqjcData
    {
        public List<tb_bridge_dqjc_zlxx_checkvalue> zlxx_checkvalue { get; set; }
        public List<tb_bridge_dqjc_jcwy_checkvalue> jcwy_checkvalue { get; set; }
        public List<tb_bridge_dqjc_tdwy_checkvalue> tdwy_checkvalue { get; set; }
        public List<tb_bridge_dqjc_xlssl_checkvalue> xlssl_checkvalue { get; set; }
        public List<tb_bridge_dqjc_jgpl_checkvalue> jgpl_checkvalue { get; set; }
    }
    #endregion

    /// <summary>
    /// 力学性能添加
    /// </summary>
    public class BridgetaddLxxnData
    {
        public List<xlssl_checkvalue> xlssl_checkvalue { get; set; }
        public List<jcwy_checkvalue> jcwy_checkvalue { get; set; }
        public List<tdwy_checkvalue> tdwy_checkvalue { get; set; }
        public List<zlxx_checkvalue> zlxx_checkvalue { get; set; }
        public List<jgyl_checkvalue> jgyl_checkvalue { get; set; }
        public List<jgpl_checkvalue> jgpl_checkvalue { get; set; }

        public List<tb_bridge_lxxn_sszz_checkvalue> sszz_checkvalue { get; set; }
        public List<tb_bridge_lxxn_zzwy_checkvalue> zzwy_checkvalue { get; set; }
    }

    public class xlssl_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string xls_code { get; set; }
        public string xls_name { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }

    }
    public class jcwy_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class tdwy_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class zlxx_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class jgyl_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class jgpl_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }

    /// <summary>
    /// 运营环境添加
    /// </summary>
    public class BridgetaddYyhjData
    {
        public List<jtl_checkvalue> jtl_checkvalue { get; set; }
        public List<wd_checkvalue> wd_checkvalue { get; set; }
        public List<fs_checkvalue> fs_checkvalue { get; set; }
    }
    public class jtl_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class wd_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class fs_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }

    #region 分析数据桥面系
    /// <summary>
    /// 分析数据桥面系
    /// </summary>
    public class BridgetaddQmxData
    {
        /// <summary>
        /// 桥面铺装系统检查状况信息
        /// </summary>
        public List<qmpz_checkvalue> qmpz_checkvalue { get; set; }
        // <summary>
        /// 伸缩装置检查状况信息
        /// </summary>
        public List<sszz_checkvalue> sszz_checkvalue { get; set; }
        // <summary>
        /// 人行道检查状况信息
        /// </summary>
        public List<rxd_checkvalue> rxd_checkvalue { get; set; }
    }

    public class qmpz_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class sszz_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class rxd_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    #endregion

    #region  20230720 新需求
    public class tb_bridge_lxxn_sszz_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public string disease { get; set; }
    }

    public class tb_bridge_lxxn_sszz_output
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public float? points { get; set; }
        public float? grade { get; set; }

    }

    public class tb_bridge_lxxn_zzwy_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public string disease { get; set; }
    }

    public class tb_bridge_lxxn_zzwy_output
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime datapushdate { get; set; }
        public float? points { get; set; }
        public float? grade { get; set; }
    }
     

    public class tb_bridge_dqjc_zlxx_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string measure_point_direction { get; set; }
        public string measure_point_name { get; set; }
        public float? measure_point_dist { get; set; }
        public DateTime? datapushdate { get; set; }
        public string disease { get; set; }

    }
    public class tb_bridge_dqjc_jcwy_checkvalue
    {
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string measure_point_name { get; set; }
        public float? measure_point_height { get; set; }
        public string disease { get; set; }
        public DateTime? datapushdate { get; set; }

    }

    public class tb_bridge_dqjc_tdwy_checkvalue {
       public string project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string direction { get; set; }
        public string disease { get; set; }
        public DateTime datapushdate { get; set; }
    }
    public class tb_bridge_dqjc_xlssl_checkvalue
    {
       public string  project_code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public DateTime? datapushdate { get; set; }
        public string disease { get; set; }
    }
    public class tb_bridge_dqjc_jgpl_checkvalue
    {
       public string project_code { get; set; }
        public string taskNo { get; set; }
        public DateTime? datapushdate { get; set; }
        public string disease { get; set; }

    }
    #endregion

    #region 【分析数据】主梁系统
    /// <summary>
    /// 主梁节段检查状况信息
    /// </summary>
    public class BridgetaddZlData
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    #endregion

    #region 【分析数据】支座及限位装置
    /// <summary>
    /// 分析数据支座及限位装置
    /// </summary>
    public class BridgetaddZzxtData
    {
        /// <summary>
        /// 支座检查状况信息
        /// </summary>
        public List<zz_checkvalue> zz_checkvalue { get; set; }
        // <summary>
        /// 主梁阻尼器检查状况信息
        /// </summary>
        public List<znq_checkvalue> znq_checkvalue { get; set; }
    }
    public class zz_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class znq_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    #endregion

    #region 【分析数据】下部结构
    public class BridgetaddXbjgData
    {
        /// <summary>
        /// 桥墩系统检查状况信息
        /// </summary>
        public List<qd_checkvalue> qd_checkvalue { get; set; }
        // <summary>
        /// 桥台系统检查状况信息
        /// </summary>
        public List<qt_checkvalue> qt_checkvalue { get; set; }
        // <summary>
        /// 基础承台系统检查
        /// </summary>
        public List<jcct_checkvalue> jcct_checkvalue { get; set; }
    }

    public class qd_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class qt_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class jcct_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    #endregion

    #region 【分析数据】索塔系统
    /// <summary>
    /// 索塔节段检查状况信息
    /// </summary>
    public class BridgetaddStData
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    #endregion

    #region 斜拉索系统
    /// <summary>
    /// 斜拉索系统
    /// </summary>
    public class BridgetaddXlsData
    {
        /// <summary>
        /// 斜拉索索体检查状况信息
        /// </summary>
        public List<xls_checkvalue> xls_checkvalue { get; set; }
        // <summary>
        /// 斜拉索护套检查状况信息
        /// </summary>
        public List<xlsht_checkvalue> xlsht_checkvalue { get; set; }
        // <summary>
        /// 斜拉索锚固系统检查状况信息
        /// </summary>
        public List<mgxt_checkvalue> mgxt_checkvalue { get; set; }
        // <summary>
        /// 斜拉索减振系统检查状况信息
        /// </summary>
        public List<jzxt_checkvalue> jzxt_checkvalue { get; set; }
    }

    public class xls_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string xls_code { get; set; }
        public string xls_name { get; set; }
        public string disease { get; set; }
    }
    public class xlsht_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string xls_code { get; set; }
        public string xls_name { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class mgxt_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string xls_code { get; set; }
        public string xls_name { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    public class jzxt_checkvalue
    {
        public string project_Code { get; set; }
        public string taskNo { get; set; }
        public string xls_code { get; set; }
        public string xls_name { get; set; }
        public string facility_code { get; set; }
        public string facility_name { get; set; }
        public string disease { get; set; }
    }
    #endregion

    #region 斜拉桥评价接
    public class OverallEvaluation
    {
        public string[] tjzq_taskno { get; set; }
        //public string tjzq_taskno { get; set; }
        public string[] tjyq_taskno { get; set; }
        public string jd_taskno { get; set; }
        public string af_taskno { get; set; }
        public string os_taskno { get; set; }
        public string facility_type { get; set; }
        public string project_code { get; set; }
    }

    public class tb_model_overall_eval
    {
        public string project_code { get; set; }
        public string facility_type { get; set; }
        public string status { get; set; }
        public string main_taskno { get; set; }
        public string[] tjzq_taskno { get; set; }
        //public string tjzq_taskno { get; set; }
        public string[] tjyq_taskno { get; set; }
        public string jd_taskno { get; set; }
        public string af_taskno { get; set; }
        public string os_taskno { get; set; }
    }

    public class tb_model_overall_eval2
    {
        public decimal? total_mark { get; set; }
        public string total_grade { get; set; }
        public decimal? tj_mark { get; set; }
        public decimal? jd_mark { get; set; }
        public decimal? af_mark { get; set; }
        public decimal? os_mark { get; set; }
        public string tj_grade { get; set; }
        public string jd_grade { get; set; }
        public string af_grade { get; set; }
        public string os_grade { get; set; }
    }
    #endregion
}
