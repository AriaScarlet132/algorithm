using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelMesCriteriaMidsystem
    {
        public int Id { get; set; }

        /// <summary>
        /// �����ϵͳ����
        /// </summary>
        [Column("name_Midsystem")]
        public string NameMidsystem { get; set; }

        /// <summary>
        /// �����ϵͳ����
        /// </summary>
        [Column("code_Midsystem")]
        public string CodeMidsystem { get; set; }

        /// <summary>
        /// �����ϵͳ����״��ָ��
        /// </summary>
        [Column("CI_Midsystem")]
        public string CIMidsystem { get; set; }

        /// <summary>
        /// I�����ֵ
        /// </summary>
        [Column("Mid_I_Top")]
        public int MidITop { get; set; }

        /// <summary>
        /// I����Сֵ
        /// </summary>
        [Column("Mid_I_Bottom")]
        public int MidIBottom { get; set; }

        /// <summary>
        /// II�����ֵ
        /// </summary>
        [Column("Mid_II_Top")]
        public int MidIITop { get; set; }

        /// <summary>
        /// II����Сֵ
        /// </summary>
        [Column("Mid_II_Bottom")]
        public int MidIIBottom { get; set; }

        /// <summary>
        /// III�����ֵ
        /// </summary>
        [Column("Mid_III_Top")]
        public int MidIIITop { get; set; }

        /// <summary>
        /// III����Сֵ
        /// </summary>
        [Column("Mid_III_Bottom")]
        public int MidIIIBottom { get; set; }

        /// <summary>
        /// IV�����ֵ
        /// </summary>
        [Column("Mid_IV_Top")]
        public int MidIVTop { get; set; }

        /// <summary>
        /// IV����Сֵ
        /// </summary>
        [Column("Mid_IV_Bottom")]
        public int MidIVBottom { get; set; }

        /// <summary>
        /// V�����ֵ
        /// </summary>
        [Column("Mid_V_Top")]
        public int MidVTop { get; set; }

        /// <summary>
        /// V����Сֵ
        /// </summary>
        [Column("Mid_V_Bottom")]
        public int MidVBottom { get; set; }
        /// <summary>
        /// �豸����
        /// </summary>
        public string facility_type { get; set; }
    }
}