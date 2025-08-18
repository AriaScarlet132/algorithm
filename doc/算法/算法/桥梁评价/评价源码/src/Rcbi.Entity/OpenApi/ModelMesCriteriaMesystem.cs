using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelMesCriteriaMesystem
    {
        public int Id { get; set; }

        /// <summary>
        /// 机电系统技术状况指数
        /// </summary>
        [Column("CI_MESystem")]
        public string CIMESystem { get; set; }

        /// <summary>
        /// I级最大值
        /// </summary>
        [Column("MES_I_Top")]
        public int MESITop { get; set; }

        /// <summary>
        /// I级最小值
        /// </summary>
        [Column("MES_I_Bottom")]
        public int MESIBottom { get; set; }

        /// <summary>
        /// II级最大值
        /// </summary>
        [Column("MES_II_Top")]
        public int MESIITop { get; set; }

        /// <summary>
        /// II级最小值
        /// </summary>
        [Column("MES_II_Bottom")]
        public int MESIIBottom { get; set; }

        /// <summary>
        /// III级最大值
        /// </summary>
        [Column("MES_III_Top")]
        public int MESIIITop { get; set; }

        /// <summary>
        /// III级最小值
        /// </summary>
        [Column("MES_III_Bottom")]
        public int MESIIIBottom { get; set; }

        /// <summary>
        /// IV级最大值
        /// </summary>
        [Column("MES_IV_Top")]
        public int MESIVTop { get; set; }

        /// <summary>
        /// IV级最小值
        /// </summary>
        [Column("MES_IV_Bottom")]
        public int MESIVBottom { get; set; }

        /// <summary>
        /// V级最大值
        /// </summary>
        [Column("MES_V_Top")]
        public int MESVTop { get; set; }

        /// <summary>
        /// V级最小值
        /// </summary>
        [Column("MES_V_Bottom")]
        public int MESVBottom { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string facility_type { get; set; }
    }
}