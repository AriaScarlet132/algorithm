using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    class ModelV2
    {
    }

    /// <summary>
    /// 附属设施线路评价结果表 v2
    /// </summary>
    public class ModelAFResultLine
    {
        /// <summary>
        ///  
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 线路编码
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }
        /// <summary>
        /// 得分
        /// </summary>
        public int? Value { get; set; }
        /// <summary>
        /// 任务号
        /// </summary>
        public string task_no { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string project_code { get; set; }
        /// <summary>
        /// 数据创建时间
        /// </summary>
        public string create_date { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public bool delete_flag { get; set; }
    }


    public class ModelMesParameterMesystem
    {
        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string code_Midsystem { get; set; }
        /// <summary>
        /// 子系统名称
        /// </summary>
        public string Subsystem { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public string parameter { get; set; }
        /// <summary>
        /// I级参数值
        /// </summary>
        public float? MES_I { get; set; }
        /// <summary>
        /// II级参数值
        /// </summary>
        public float? MES_II { get; set; }
        /// <summary>
        /// III级参数值
        /// </summary>
        public float? MES_III { get; set; }
        /// <summary>
        /// IV级参数值
        /// </summary>
        public float? MES_IV { get; set; }
        /// <summary>
        /// V级参数值
        /// </summary>
        public float? MES_V { get; set; }
        /// <summary>
        /// 设施类型
        /// </summary>
        public string facility_type { get; set; }
    }

    /// <summary>
    /// 评价等级与分值对应关系表V2
    /// </summary>
    public class ModelMesCriteria
    {
        public string id { get; set; }
        /// <summary>
        /// 系统编码
        /// </summary>
        public string mes_system_code { get; set; }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string mes_system_name { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 等级最小值
        /// </summary>
        public decimal? low_value { get; set; }
        /// <summary>
        /// 等级最大值
        /// </summary>
        public decimal? up_value { get; set; }
    }

    public class ModelRoadDataCheckvalue
    {
        public string ID { get; set; }
        public DateTime? date { get; set; }
        public string line_no { get; set; }
        public string lane_no { get; set; }
        public string section_code { get; set; }
        public string start_mileage { get; set; }
        public string end_mileage { get; set; }
        public decimal? iri { get; set; }
        public decimal? sfc { get; set; }
        public decimal? pci { get; set; }
        public string project_code { get; set; }
        public string task_no { get; set; }
    }

    /// <summary>
    /// 土建分类表  v2
    /// </summary>
    public class ModelTjStructuretypeweights
    {
        public string ID { get; set; }
        /// <summary>
        /// 施工方法 
        /// </summary>
        public string ConstructionMethod { get; set; }
        /// <summary>
        /// 结构类别
        /// </summary>
        public string StructureType { get; set; }
        /// <summary>
        /// 权重
        /// </summary>
        public decimal? Weight { get; set; }
    }

    /// <summary>
    /// 待评价项目的收敛变形差异信息表 v2
    /// </summary>
    public class ModelTjDataDiffsedimentation
    {
        public string ID { get; set; }
        /// <summary>
        /// 线路编码
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 结构类别
        /// </summary>
        public string StructureType { get; set; }
        /// <summary>
        /// 评价单元编号
        /// </summary>
        public string section_code { get; set; }
        /// <summary>
        /// 开始里程
        /// </summary>
        public string start_mileage { get; set; }
        /// <summary>
        /// 结束里程
        /// </summary>
        public string end_mileage { get; set; }
        /// <summary>
        /// 差异沉降
        /// </summary>
        public decimal? Value { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 项目号
        /// </summary>
        public string project_code { get; set; }
        /// <summary>
        /// 任务号
        /// </summary>
        public string task_no { get; set; }
    }

    /// <summary>
    /// 待评价项目的平均渗水量记录信息表 v2
    /// </summary>
    public class ModelTjDataLeakage
    {
        public string ID { get; set; }
        /// <summary>
        /// 线路编码
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 结构类别
        /// </summary>
        public string StructureType { get; set; }
        /// <summary>
        /// 评价单元编号
        /// </summary>
        public string section_code { get; set; }
        /// <summary>
        /// 开始里程
        /// </summary>
        public string start_mileage { get; set; }
        /// <summary>
        /// 结束里程
        /// </summary>
        public string end_mileage { get; set; }
        /// <summary>
        /// 平均渗漏水量
        /// </summary>
        public decimal? Value { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 项目号
        /// </summary>
        public string project_code { get; set; }
        /// <summary>
        /// 任务号
        /// </summary>
        public string task_no { get; set; }
    }
}
