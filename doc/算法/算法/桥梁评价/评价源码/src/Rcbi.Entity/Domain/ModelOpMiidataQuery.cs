using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// 内业档案资料信息化MII业务信息
    /// </summary>
    public class ModelOpMiidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// 文档编码
        /// </summary>
        public string DocCode { get; set; }

        /// <summary>
        /// 评价规范中的应提交文档名称
        /// </summary>
        public string DocName_Spec { get; set; }

        /// <summary>
        /// 公司档案资料实际名称
        /// </summary>
        public string DocName_Company { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string DocYear { get; set; }

        /// <summary>
        /// 完成情况
        /// </summary>
        public int DocComplete { get; set; }

        /// <summary>
        /// 数据推送时间
        /// </summary>
        public DateTime DataPushDate { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}