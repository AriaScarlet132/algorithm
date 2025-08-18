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
        /// ����ϵͳ����״��ָ��
        /// </summary>
        [Column("CI_MESystem")]
        public string CIMESystem { get; set; }

        /// <summary>
        /// I�����ֵ
        /// </summary>
        [Column("MES_I_Top")]
        public int MESITop { get; set; }

        /// <summary>
        /// I����Сֵ
        /// </summary>
        [Column("MES_I_Bottom")]
        public int MESIBottom { get; set; }

        /// <summary>
        /// II�����ֵ
        /// </summary>
        [Column("MES_II_Top")]
        public int MESIITop { get; set; }

        /// <summary>
        /// II����Сֵ
        /// </summary>
        [Column("MES_II_Bottom")]
        public int MESIIBottom { get; set; }

        /// <summary>
        /// III�����ֵ
        /// </summary>
        [Column("MES_III_Top")]
        public int MESIIITop { get; set; }

        /// <summary>
        /// III����Сֵ
        /// </summary>
        [Column("MES_III_Bottom")]
        public int MESIIIBottom { get; set; }

        /// <summary>
        /// IV�����ֵ
        /// </summary>
        [Column("MES_IV_Top")]
        public int MESIVTop { get; set; }

        /// <summary>
        /// IV����Сֵ
        /// </summary>
        [Column("MES_IV_Bottom")]
        public int MESIVBottom { get; set; }

        /// <summary>
        /// V�����ֵ
        /// </summary>
        [Column("MES_V_Top")]
        public int MESVTop { get; set; }

        /// <summary>
        /// V����Сֵ
        /// </summary>
        [Column("MES_V_Bottom")]
        public int MESVBottom { get; set; }
        /// <summary>
        /// �豸����
        /// </summary>
        public string facility_type { get; set; }
    }
}