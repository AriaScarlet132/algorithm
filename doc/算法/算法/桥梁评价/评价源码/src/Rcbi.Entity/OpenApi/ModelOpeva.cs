using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 运营服务评价指标权重信息表
    /// </summary>
    public class ModelOpevaWeightInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 指数名称
        /// </summary>
        [Required(ErrorMessage = "指数名称为必输")]
        [Column("IndexName")]
        public string IndexName { get; set; }

        /// <summary>
        /// 指数权重
        /// </summary>
        [Required(ErrorMessage = "指数权重为必输")]
        [Column("Weight")]
        public decimal? Weight { get; set; }

        /// <summary>
        /// 父指数
        /// </summary>
        [Required(ErrorMessage = "父指数为必输")]
        [Column("ParentIndex")]
        public string ParentIndex { get; set; }

    }

    /// <summary>
    /// 评价等级与分值对应关系表
    /// </summary>
    public class ModelOpCriteria
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 指标名称
        /// </summary>
        [Required(ErrorMessage = "指标名称为必输")]
        [Column("IndexName")]
        public string IndexName { get; set; }

        /// <summary>
        /// 等级值
        /// </summary>
        [Required(ErrorMessage = "等级值为必输")]
        [Column("rate")]
        public int Rate { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required(ErrorMessage = "描述为必输")]
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [Required(ErrorMessage = "分数为必输")]
        [Column("rate_mark")]
        public int RateMark { get; set; }

        /// <summary>
        /// 指标值下限
        /// </summary>
        [Required(ErrorMessage = "指标值下限为必输")]
        [Column("lower_value")]
        public decimal? LowerValue { get; set; }

        /// <summary>
        /// 指标值上限
        /// </summary>
        [Required(ErrorMessage = "指标值上限为必输")]
        [Column("up_value")]
        public decimal? UpValue { get; set; }

        /// <summary>
        /// 父级指标
        /// </summary>
        [Required(ErrorMessage = "父级指标为必输")]
        [Column("ParentIndex")]
        public string ParentIndex { get; set; }

    }

    /// <summary>
    /// 待评价项目的保洁效果信息
    /// </summary>
    public class ModelOpDataClean
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 第i次监测
        /// </summary>
        [Required(ErrorMessage = "第i次监测为必输")]
        [Column("CheckIndex")]
        public string CheckIndex { get; set; }

        /// <summary>
        /// 检测日期
        /// </summary>
        [Required(ErrorMessage = "检测日期为必输")]
        [Column("CheckDate")]
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 不合格处数
        /// </summary>
        [Required(ErrorMessage = "不合格处数为必输")]
        [Column("unqualified")]
        public int Unqualified { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目号为必输")]
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Required(ErrorMessage = "任务号为必输")]
        [Column("task_no")]
        public string TaskNo { get; set; }
    }

    /// <summary>
    /// 待评价项目的废水排放合格率信息
    /// </summary>
    public class ModelOpDataEffluent
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 废水池总数目
        /// </summary>
        [Required(ErrorMessage = "废水池总数目为必输")]
        [Column("totalamount")]
        public int Totalamount { get; set; }

        /// <summary>
        /// ph值不合格废水池数目
        /// </summary>
        [Required(ErrorMessage = "ph值不合格废水池数目为必输")]
        [Column("phNum")]
        public int PhNum { get; set; }

        /// <summary>
        /// 悬浮物不合格废水池数目
        /// </summary>
        [Required(ErrorMessage = "悬浮物不合格废水池数目为必输")]
        [Column("suspendNum")]
        public int SuspendNum { get; set; }

        /// <summary>
        /// 检测日期
        /// </summary>
        [Required(ErrorMessage = "检测日期为必输")]
        [Column("CheckDaTe")]
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目号为必输")]
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Required(ErrorMessage = "任务号为必输")]
        [Column("task_no")]
        public string TaskNo { get; set; }
    }

    /// <summary>
    /// 待评价项目的应急响应及时率信息
    /// </summary>
    public class ModelOpDataEri
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        [Required(ErrorMessage = "年为必输")]
        [Column("Year")]
        public int Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        [Required(ErrorMessage = "月为必输")]
        [Column("Month")]
        public int Month { get; set; }

        /// <summary>
        /// 及时启动应急预案次数v2
        /// </summary>
        [Required(ErrorMessage = "及时启动应急预案次数v2为必输")]
        [Column("N1")]
        public int N1 { get; set; }

        /// <summary>
        /// 应急预案启动次数v2
        /// </summary>
        [Required(ErrorMessage = "应急预案启动次数v2为必输")]
        [Column("N")]
        public int N { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目号为必输")]
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Required(ErrorMessage = "任务号为必输")]
        [Column("task_no")]
        public string TaskNo { get; set; }
    }


    /// <summary>
    /// 待评价项目的节能环保信息
    /// </summary>
    public class ModelOpDataEs
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 评价日期
        /// </summary>
        [Required(ErrorMessage = "评价日期为必输")]
        [Column("CheckDate")]
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 节能环保措施数量
        /// </summary>
        [Required(ErrorMessage = "节能环保措施数量为必输")]
        [Column("ES")]
        public int ES { get; set; }

        /// <summary>
        /// 评价描述
        /// </summary>
        [Required(ErrorMessage = "评价描述为必输")]
        [Column("Memo")]
        public int Memo { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目号为必输")]
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Required(ErrorMessage = "任务号为必输")]
        [Column("task_no")]
        public string TaskNo { get; set; }
    }

    /// <summary>
    /// 待评价项目的高峰期烟雾浓度信息
    /// </summary>
    public class ModelOpDataK
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 监测日期
        /// </summary>
        [Required(ErrorMessage = "监测日期为必输")]
        [Column("CheckDate")]
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 设备编号 
        /// </summary>
        [Required(ErrorMessage = "设备编号为必输")]
        [Column("Code")]
        public string Code { get; set; }

        /// <summary>
        /// 里程号
        /// </summary>
        [Column("station")]
        public string Station { get; set; }

        /// <summary>
        /// 监测值(10-3/m)
        /// </summary>
        [Required(ErrorMessage = "监测值(10-3/m)为必输")]
        [Column("Value")]
        public decimal? Value { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目号为必输")]
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Required(ErrorMessage = "任务号为必输")]
        [Column("task_no")]
        public string TaskNo { get; set; }
    }

    /// <summary>
    /// 待评价项目的标线光度性能信息
    /// </summary>
    public class ModelOpDataNBI
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 监测日期
        /// </summary>
        [Required(ErrorMessage = "监测日期为必输")]
        [Column("monitordate")]
        public DateTime? Monitordate { get; set; }

        /// <summary>
        /// 测点编号 
        /// </summary>
        [Required(ErrorMessage = "测点编号为必输")]
        [Column("Code")]
        public string Code { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [Required(ErrorMessage = "位置为必输")]
        [Column("station")]
        public int Station { get; set; }

        /// <summary>
        /// 逆反射系数(mcd∙m^(-2)∙lx^(-1)）
        /// </summary>
        [Required(ErrorMessage = "逆反射系数(mcd∙m^(-2)∙lx^(-1))为必输")]
        [Column("Value")]
        public decimal? Value { get; set; }

        /// <summary>
        /// 标线颜色
        /// </summary>
        [Required(ErrorMessage = "标线颜色为必输")]
        [Column("color")]
        public int Color { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目号为必输")]
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Required(ErrorMessage = "任务号为必输")]
        [Column("task_no")]
        public string TaskNo { get; set; }
    }

    /// <summary>
    /// 待评价项目的安全生产事故信息
    /// </summary>
    public class ModelOpDataSafety
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        [Required(ErrorMessage = "年为必输")]
        [Column("Year")]
        public int Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        [Required(ErrorMessage = "月为必输")]
        [Column("Month")]
        public int Month { get; set; }

        /// <summary>
        /// 线路编码 
        /// </summary>
        [Required(ErrorMessage = "线路编码为必输")]
        [Column("LineCode")]
        public string LineCode { get; set; }

        /// <summary>
        /// 事故类型
        /// </summary>
        [Required(ErrorMessage = "事故类型为必输")]
        [Column("AccidentType")]
        public string AccidentType { get; set; }

        /// <summary>
        /// 重伤人数
        /// </summary>
        [Required(ErrorMessage = "重伤人数为必输")]
        [Column("SeriousInjury")]
        public int SeriousInjury { get; set; }

        /// <summary>
        /// 死亡人数
        /// </summary>
        [Required(ErrorMessage = "死亡人数为必输")]
        [Column("Dead")]
        public int Dead { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目号为必输")]
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Required(ErrorMessage = "任务号为必输")]
        [Column("task_no")]
        public string TaskNo { get; set; }
    }

    /// <summary>
    /// 待评价项目的高峰期平均行驶速度信息
    /// </summary>
    public class ModelOpDataSpeed
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 观测路段长度(km)
        /// </summary>
        [Required(ErrorMessage = "观测路段长度(km)为必输")]
        [Column("Length")]
        public decimal? Length { get; set; }

        /// <summary>
        /// 观测车通过该路段的行程时间(h)
        /// </summary>
        [Required(ErrorMessage = "观测车通过该路段的行程时间(h)为必输")]
        [Column("PassingTime")]
        public decimal? PassingTime { get; set; }

        /// <summary>
        /// 观察序号 
        /// </summary>
        [Required(ErrorMessage = "观察序号为必输")]
        [Column("Code")]
        public string Code { get; set; }

        /// <summary>
        /// 速度(km/h)
        /// </summary>
        [Required(ErrorMessage = "速度(km/h)为必输")]
        [Column("Speed")]
        public decimal? Speed { get; set; }

        /// <summary>
        /// 监测日期
        /// </summary>
        [Required(ErrorMessage = "监测日期为必输")]
        [Column("MonitorDate")]
        public DateTime? MonitorDate { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目号为必输")]
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Required(ErrorMessage = "任务号为必输")]
        [Column("task_no")]
        public string TaskNo { get; set; }
    }

    /// <summary>
    /// 待评价项目的通行影响率信息
    /// </summary>
    public class ModelOpDataTraff
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 封闭开始时间
        /// </summary>
        [Required(ErrorMessage = "封闭开始时间为必输")]
        [Column("start_time")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束开始时间
        /// </summary>
        [Required(ErrorMessage = "封闭结束时间为必输")]
        [Column("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 封闭时长（小时） 
        /// </summary>
        [Required(ErrorMessage = "封闭时长（小时）为必输")]
        [Column("CloseDuration")]
        public double? CloseDuration { get; set; }

        /// <summary>
        /// 养护作业序号 
        /// </summary>
        [Column("Code")]
        public string Code { get; set; }

        /// <summary>
        /// 线路编号 
        /// </summary>
        [Required(ErrorMessage = "线路编号为必输")]
        [Column("LineCode")]
        public string LineCode { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目号为必输")]
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Required(ErrorMessage = "任务号为必输")]
        [Column("task_no")]
        public string TaskNo { get; set; }
    }

    /// <summary>
    /// 运营服务子指标评价结果
    /// </summary>
    public class ModelOpResultIndexevaluation
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Column("start_date")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 服务指标名称
        /// </summary>
        [Column("service")]
        public string Service { get; set; }

        /// <summary>
        /// 子指标 
        /// </summary>
        [Column("indexs")]
        public string Indexs { get; set; }

        /// <summary>
        /// 分值 
        /// </summary>
        [Column("value")]
        public decimal? Value { get; set; }

        /// <summary>
        /// 得分 
        /// </summary>
        [Column("score")]
        public decimal? Score { get; set; }

        /// <summary>
        /// 等级 
        /// </summary>
        [Column("level")]
        public decimal? Level { get; set; }

        /// <summary>
        /// 等级描述 
        /// </summary>
        [Column("level_description")]
        public string LevelDescription { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_date")]
        public DateTime? CreateDate { get; set; }
    }

    /// <summary>
    /// 运营服务分类项目评价结果
    /// </summary>
    public class ModelOpResultMidevaluation
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("ID")]
        public string ID { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Column("start_date")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 服务指标名称
        /// </summary>
        [Column("service")]
        public string Service { get; set; }

        /// <summary>
        /// 得分 
        /// </summary>
        [Column("score")]
        public decimal? Score { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Column("project_code")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_date")]
        public DateTime? CreateDate { get; set; }
    }

    /// <summary>
    /// 附属设施类别及权重
    /// </summary>
    public class Modelbridgetypeweight
    {
        /// <summary>
        /// 设施类型名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 设施类型编码
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 设施类型权重
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// 父设施类别
        /// </summary>
        public string ParentType { get; set; }
        /// <summary>
        /// 设施类型重要度
        /// </summary>
        public string Importance { get; set; }
        /// <summary>
        /// 设施类型层级
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string facility_type { get; set; }
    }

    /// <summary>
    /// 附属设施病害描述
    /// </summary>
    public class Modelbridgefacilitymarkspec
    {

        /// <summary>
        /// 子设施类别
        /// </summary>
        public string FacilityCategory_Name { get; set; }
        /// <summary>
        /// 子设施类别编码
        /// </summary>
        public string FacilityCategory_Code { get; set; }
        /// <summary>
        /// 状况值
        /// </summary>
        public int FacilityMark { get; set; }
        /// <summary>
        /// 技术状况描述
        /// </summary>
        public string FacilityStatusDesp { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string facility_type { get; set; }
    }

    public class ModelOpBidataQuery2
    {

        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }
        public string linecode { get; set; }
        public string position { get; set; }
        public string mileage { get; set; }
        public string deviceno { get; set; }
        public string monitoryear { get; set; }
        public string monitormonth { get; set; }
        public decimal monitordata { get; set; }
        public decimal uniformdata { get; set; }
        public DateTime datapushdate { get; set; }
    }

    /// <summary>
    /// 待评价项目的牵引排堵及时率信息
    /// </summary>
    public class ModelOpTeidata2
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public string project_code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public string task_no { get; set; }

        /// <summary>
        /// 线路号
        /// </summary>
        public string linecode { get; set; }

        /// <summary>
        /// 观测日期
        /// </summary>
        public DateTime monitordate { get; set; }

        /// <summary>
        /// m1次数
        /// </summary>
        [Required(ErrorMessage = "m1次数（（事故通知时间-牵引车启动时间）<=2分钟）为必输")]
        public int M1amount { get; set; }

        /// <summary>
        /// m2次数
        /// </summary>
        [Required(ErrorMessage = "m2次数（（牵引车启动时间-牵引车到达牵引地点时间）<=20分钟）为必输")]
        public int M2amount { get; set; }

        /// <summary>
        /// 当日牵引总次数
        /// </summary>
        public int totalinday { get; set; }

        ///// <summary>
        ///// 数据推送时间
        ///// </summary>
        //[Required(ErrorMessage = "数据推送时间为必输")]
        //public DateTime DataPushDate { get; set; }
    }
}
