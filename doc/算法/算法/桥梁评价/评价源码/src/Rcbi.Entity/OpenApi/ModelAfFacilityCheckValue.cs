using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 附属子设施检查评分明细
    /// </summary>
    public class ModelAfFacilityCheckValue
    {

        /// <summary>
        /// 设施名称
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// 设施编码
        /// </summary>
        [Required(ErrorMessage = "设施编码为必输")]
        public string FacilityName_Code { get; set; }

        /// <summary>
        /// 技术状况值
        /// </summary>
        [Range(1, 5, ErrorMessage = "技术状况值有效值范围[1-5]")]
        public int CheckMarkValue { get; set; }

        /// <summary>
        /// 检查技术状况描述
        /// </summary>
        public string CheckDesp { get; set; }

        /// <summary>
        /// 检查附件(如图片）
        /// </summary>
        public string CheckPic { get; set; }

        /// <summary>
        /// 检查人
        /// </summary>
        public string CheckPerson { get; set; }

        /// <summary>
        /// 检查日期
        /// </summary>
        [Required(ErrorMessage = "检查日期为必须")]
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string CheckMemo { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必须")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Required(ErrorMessage = "任务编号为必须")]

        public string TaskNo { get; set; }


        /// <summary>
        /// 起始里程 V2
        /// </summary>
        public string start_mileage { get; set; }
        /// <summary>
        /// 开始里程  V2
        /// </summary>
        public string end_mileage { get; set; }
    }

    /// <summary>
    /// 附属子设施检查评分明细
    /// </summary>
    public class ModelAfFacilityCheckValue2
    {

        /// <summary>
        /// 设施名称
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// 设施编码
        /// </summary>
        [Required(ErrorMessage = "设施编码为必输")]
        public string FacilityName_Code { get; set; }

        /// <summary>
        /// 技术状况值
        /// </summary>
        public int CheckMarkValue { get; set; }

        /// <summary>
        /// 检查技术状况描述
        /// </summary>
        public string CheckDesp { get; set; }

        /// <summary>
        /// 检查附件(如图片）
        /// </summary>
        public string CheckPic { get; set; }

        /// <summary>
        /// 检查人
        /// </summary>
        public string CheckPerson { get; set; }

        /// <summary>
        /// 检查日期
        /// </summary>
        [Required(ErrorMessage = "检查日期为必须")]
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string CheckMemo { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required(ErrorMessage = "项目编号为必须")]
        public string Project_Code { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        [Required(ErrorMessage = "任务编号为必须")]

        public string TaskNo { get; set; }


        /// <summary>
        /// 起始里程 V2
        /// </summary>
        public string start_mileage { get; set; }
        /// <summary>
        /// 开始里程  V2
        /// </summary>
        public string end_mileage { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>

        public bool delete_flag { get; set; }
    }
}
