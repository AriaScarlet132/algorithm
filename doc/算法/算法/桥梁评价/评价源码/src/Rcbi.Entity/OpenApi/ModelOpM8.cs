using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    class ModelOpM8
    {
    }
    /// <summary>
    /// 桥梁基本信息
    /// </summary>
    public class ModelOpBridgeBasicInfo
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }
        public DateTime? build_start_date { get; set; }
        public DateTime? build_end_date { get; set; }
        public DateTime? completion_date { get; set; }
        public DateTime? operation_start_date { get; set; }
        public int? daily_design_traffic_lower_value { get; set; }
        public int? daily_design_traffic_upper_value { get; set; }
        public decimal? bridge_length { get; set; }
    }

    public class ModelOpTrafficDriveSpeed
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "线路号为必输")]
        public string route_no { get; set; }
        [Required(ErrorMessage = "观测日期为必输")]
        public DateTime monitor_date { get; set; }
        [Required(ErrorMessage = "观测小时为必输")]
        public int monitor_hour { get; set; }
        public double? running_speed { get; set; }




    }
    public class ModelOpTrafficFlow
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "线路号为必输")]
        public string route_no { get; set; }
        [Required(ErrorMessage = "观测日期为必输")]
        public DateTime monitor_date { get; set; }
        [Required(ErrorMessage = "观测小时为必输")]
        public int monitor_hour { get; set; }
        public int? traffic_flow { get; set; }


    }
    public class ModelOpTrafficFenceInfluence
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "线路号为必输")]
        public string route_no { get; set; }
        [Required(ErrorMessage = "观测日期为必输")]
        public DateTime monitor_date { get; set; }
        public DateTime? fence_work_start_time { get; set; }
        public DateTime? fence_work_end_time { get; set; }
        public int? traffick1_value { get; set; }
        public int? traffick2_value { get; set; }
        public int? traffick3_value { get; set; }
        public int? traffick4_value { get; set; }
        public int? traffick5_value { get; set; }
        public int? traffick6_value { get; set; }
        public int? traffick7_value { get; set; }


    }
    public class ModelOpTrafficAccident
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "年份为必输")]
        public int monitor_year { get; set; }
        [Required(ErrorMessage = "月份为必输")]
        public int monitor_month { get; set; }
        public int? major_traffic_accident { get; set; }
        public int? normal_traffic_accident { get; set; }

    }
    public class ModelOpDeviceMaterialComplete
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "观测日期为必输")]
        public DateTime monitor_date { get; set; }
        [Required(ErrorMessage = "物资实际量为必输")]
        public int actual_material { get; set; }
        [Required(ErrorMessage = "物资约定量为必输")]
        public int agreed_material { get; set; }


    }
    public class ModelOpEmergencyResponse
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "线路号为必输")]
        public string route_no { get; set; }
        [Required(ErrorMessage = "年份为必输")]
        public int monitor_year { get; set; }
        [Required(ErrorMessage = "月份为必输")]
        public int monitor_month { get; set; }
        public DateTime? rescue_start_time { get; set; }
        public DateTime? rescue_end_time { get; set; }
    }
    public class ModelOpComplaintResponse
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "年份为必输")]
        public int monitor_year { get; set; }
        [Required(ErrorMessage = "月份为必输")]
        public int monitor_month { get; set; }
        public DateTime? complaint_acceptance_time { get; set; }
        public DateTime? complaint_finish_time { get; set; }


    }
    public class ModelOpValidComplaint
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "年份为必输")]
        public int monitor_year { get; set; }
        [Required(ErrorMessage = "月份为必输")]
        public int monitor_month { get; set; }
        public int? real_complaint_number { get; set; }


    }
    public class ModelOpReleaseInfoAccuracy
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "年份为必输")]
        public int monitor_year { get; set; }
        [Required(ErrorMessage = "月份为必输")]
        public int monitor_month { get; set; }
        public int? accurate_traffic_information_number { get; set; }
        public int? traffic_information_total_number { get; set; }


    }
    public class ModelOpReleaseInfoTimeliness
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "年份为必输")]
        public int monitor_year { get; set; }
        [Required(ErrorMessage = "月份为必输")]
        public int monitor_month { get; set; }
        public int? msg_timely_num { get; set; }
        public int? msg_total_num { get; set; }


    }
    public class ModelOpValidComplaintHandle
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }

        [Required(ErrorMessage = "任务号为必输")]
        public string taskNo { get; set; }
        [Required(ErrorMessage = "年份为必输")]
        public int monitor_year { get; set; }
        [Required(ErrorMessage = "月份为必输")]
        public int monitor_month { get; set; }
        public int? effective_complaint_success_number { get; set; }
        public int? effective_complaint_number { get; set; }

    }

    public class ModelOpBridgeResultAllEvaluation
    {
        public int ID { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal fwci_value { get; set; }
        public int fwci_level { get; set; }
        public DateTime create_date { get; set; }

    }
    public class ModelOpBridgeResultEsi
    {
        public int ID { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal epi_value { get; set; }
        public string epi_value_per
        {
            get
            {
                return (epi_value * 100) + "%";
            }
        }
        public int epi_mark { get; set; }
        public string epi_grade_desp { get; set; }
        public int epi_grade { get; set; }
        public decimal rti_value { get; set; }
        public int rti_mark { get; set; }
        public string rti_grade_desp { get; set; }
        public int rti_grade { get; set; }
        public DateTime create_date { get; set; }

        /// <summary>
        /// EPI权重
        /// </summary>
        public decimal? epi_weight { get; set; }
        /// <summary>
        /// RTI权重
        /// </summary>
        public decimal? rti_weight { get; set; }

    }
    public class ModelOpBridgeResultMidEvaluation
    {
        public int ID { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal tsi_value { get; set; }
        public decimal tsi_level { get; set; }
        public decimal ssi_value { get; set; }
        public decimal ssi_level { get; set; }
        public decimal esi_value { get; set; }
        public decimal esi_level { get; set; }
        public decimal usi_value { get; set; }
        public decimal usi_level { get; set; }
        public DateTime create_date { get; set; }

        /// <summary>
        /// tsi权重
        /// </summary>
        public decimal? tsi_weight { get; set; }
        /// <summary>
        /// ssi权重
        /// </summary>
        public decimal? ssi_weight { get; set; }
        /// <summary>
        /// esi权重
        /// </summary>
        public decimal? esi_weight { get; set; }
        /// <summary>
        /// usi权重
        /// </summary>
        public decimal? usi_weight { get; set; }
    }
    public class ModelOpBridgeResultSsi
    {
        public int ID { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal aai_value { get; set; }
        public int aai_mark { get; set; }
        public string aai_grade_desp { get; set; }
        public int aai_grade { get; set; }
        public decimal tir_value { get; set; }
        public int tir_mark { get; set; }
        public string tir_grade_desp { get; set; }
        public int tir_grade { get; set; }
        public DateTime create_date { get; set; }

        /// <summary>
        /// AAI权重
        /// </summary>
        public decimal? aai_weight { get; set; }
        /// <summary>
        /// TIR权重
        /// </summary>
        public decimal? tir_weight { get; set; }
    }
    public class ModelOpBridgeResultTsi
    {
        public int ID { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal dsi_value { get; set; }
        public int dsi_mark { get; set; }
        public string dsi_grade_desp { get; set; }
        public int dsi_grade { get; set; }
        public decimal dti_value { get; set; }
        public string dti_value_per
        {
            get
            {
                return (dti_value * 100) + "%";
            }
        }
        public int dti_mark { get; set; }
        public string dti_grade_desp { get; set; }
        public int dti_grade { get; set; }
        public decimal api_value { get; set; }
        public int api_mark { get; set; }
        public string api_grade_desp { get; set; }
        public int api_grade { get; set; }
        public DateTime create_date { get; set; }

        /// <summary>
        /// DSI权重
        /// </summary>
        public decimal? dsi_weight { get; set; }
        /// <summary>
        /// DTI权重
        /// </summary>
        public decimal? dti_weight { get; set; }
        /// <summary>
        /// API权重
        /// </summary>
        public decimal? api_weight { get; set; }

    }
    public class ModelOpBridgeResultUsi
    {
        public string ID { get; set; }
        public string project_code { get; set; }
        public string taskNo { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal xti_value { get; set; }
        public int xti_mark { get; set; }
        public string xti_grade_desp { get; set; }
        public int xti_grade { get; set; }
        public decimal tti_value { get; set; }
        public int tti_mark { get; set; }
        public string tti_grade_desp { get; set; }
        public int tti_grade { get; set; }
        public decimal iai_value { get; set; }
        public string iai_value_per
        {
            get
            {
                return (iai_value * 100) + "%";
            }
        }
        public int iai_mark { get; set; }
        public string iai_grade_desp { get; set; }
        public int iai_grade { get; set; }
        public decimal iri_value { get; set; }
        public string iri_value_per
        {
            get
            {
                return (iri_value * 100) + "%";
            }
        }
        public int iri_mark { get; set; }
        public string iri_grade_desp { get; set; }
        public int iri_grade { get; set; }
        public decimal eci_value { get; set; }
        public string eci_value_per
        {
            get
            {
                return (eci_value * 100) + "%";
            }
        }
        public int eci_mark { get; set; }
        public string eci_grade_desp { get; set; }
        public int eci_grade { get; set; }
        public DateTime create_date { get; set; }

        /// <summary>
        /// xti权重
        /// </summary>
        public decimal? xti_weight { get; set; }
        /// <summary>
        /// tti权重
        /// </summary>
        public decimal? tti_weight { get; set; }
        /// <summary>
        /// iai权重
        /// </summary>
        public decimal? iai_weight { get; set; }
        /// <summary>
        /// iri权重
        /// </summary>
        public decimal? iri_weight { get; set; }

        /// <summary>
        /// eci权重
        /// </summary>
        public decimal? eci_weight { get; set; }
    }

    /// <summary>
    /// 获取运营服务评价结果
    /// </summary>
    public class ModelOpBridgeInfos
    {
        public ModelOpBridgeResultTsi tsi_result { get; set; }
        public ModelOpBridgeResultSsi ssi_result { get; set; }
        public ModelOpBridgeResultEsi esi_result { get; set; }
        public ModelOpBridgeResultUsi usi_result { get; set; }
        public ModelOpBridgeResultMidEvaluation mid_evaluation_result { get; set; }
        public ModelOpBridgeResultAllEvaluation all_evaluation_result { get; set; }
    }
}
