using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 附属设施清单
    /// </summary>
    public class ModelAfFacilitylist
    {
        /// <summary>
        /// 子设施类别
        /// </summary>
        public string FacilityCategory_Name { get; set; }
        /// <summary>
        /// 子设施类别编码
        /// </summary>
        [Required(ErrorMessage = "子设施类别编码为必输")]
        public string FacilityCategory_Code { get; set; }
        /// <summary>
        /// 设施名称
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// 设施编码
        /// </summary>
        [Required(ErrorMessage = "设施编码为必输")]
        public string FacilityCode { get; set; }
        /// <summary>
        /// 检查日期
        /// </summary>
        [Required(ErrorMessage = "检查日期为必输")]
        public DateTime CheckDate { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string Project_Code { get; set; }



        /// <summary>
        /// 子设施编码 V2
        /// </summary>
        public string FacilitySubCategoryCode { get; set; }
        /// <summary>
        /// 线路编号 V2
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 开始里程 V2
        /// </summary>
        public string start_mileage { get; set; }

        /// <summary>
        /// 结束里程 V2
        /// </summary>
        public string end_mileage { get; set; }

        /// <summary>
        /// 启用时间 V2
        /// </summary>
        public DateTime? activedate { get; set; }
    }

    /// <summary>
    /// 附属设施清单
    /// </summary>
    public class ModelAfFacilitylist2
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 子设施类别
        /// </summary>
        public string FacilityCategory_Name { get; set; }
        /// <summary>
        /// 子设施类别编码
        /// </summary>
        [Required(ErrorMessage = "子设施类别编码为必输")]
        public string FacilityCategory_Code { get; set; }
        /// <summary>
        /// 设施名称
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// 设施编码
        /// </summary>
        [Required(ErrorMessage = "设施编码为必输")]
        public string FacilityCode { get; set; }
        /// <summary>
        /// 检查日期
        /// </summary>
        [Required(ErrorMessage = "检查日期为必输")]
        public DateTime CheckDate { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必输")]
        public string project_code { get; set; }



        /// <summary>
        /// 子设施编码 V2
        /// </summary>
        public string FacilitySubCategoryCode { get; set; }
        /// <summary>
        /// 线路编号 V2
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 开始里程 V2
        /// </summary>
        public string start_mileage { get; set; }

        /// <summary>
        /// 结束里程 V2
        /// </summary>
        public string end_mileage { get; set; }

        /// <summary>
        /// 启用时间 V2
        /// </summary>
        public DateTime? activedate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? datapushdate { get; set; }

        /// <summary>
        /// 结束里程 V2
        /// </summary>
        public bool delete_flag { get; set; }
    }
}
