using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ����ϵͳ�豸��������Ҫ����Ϣ
    /// </summary>
    public class ModelMesDevicetypeImp
    {
        /// <summary>
        /// ������ϵͳ����
        /// </summary>
        [Column("MesSystemCode")]
        public string MesSystemCode { get; set; }

        /// <summary>
        /// �豸��������
        /// </summary>
        [Column("typeName_Equipment")]
        public string TypeNameEquipment { get; set; }

        /// <summary>
        /// �豸���ͱ���
        /// </summary>
        [Column("typeCode_Equipment")]
        public string TypeCodeEquipment { get; set; }

        /// <summary>
        /// ��λ
        /// </summary>
        [Column("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// ����˵��
        /// </summary>
        [Column("Explanation")]
        public string Explanation { get; set; }

        /// <summary>
        /// �豸������Ҫ��
        /// </summary>
        [Column("importance_Equipment")]
        public string ImportanceEquipment { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Column("project_code")]
        public string Project_Code { get; set; }

        ///// <summary>
        ///// ��������ʱ��
        ///// </summary>
        //[Column("datapushdate")]
        //public DateTime Datapushdate { get; set; }

    }
}