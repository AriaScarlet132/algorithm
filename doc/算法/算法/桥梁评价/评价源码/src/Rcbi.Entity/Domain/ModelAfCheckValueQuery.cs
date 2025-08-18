using Rcbi.Entity.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.Domain
{
  public  class ModelAfCheckValueQuery : LayuiQuery
    {
        public int ID { get; set; }
        public string task_no { get; set; }
        public string project_code { get; set; }
        /// <summary>
        /// 设施名称
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// 设施编码
        /// </summary>
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
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string CheckMemo { get; set; }

        public override CommonQuery ToCommonQuery()
        {
            throw new NotImplementedException();
        }
    }
}
