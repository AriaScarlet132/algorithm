using Rcbi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ����ϵͳ�豸�嵥��Ϣ
    /// </summary>
    public class ModelMesEquipmentlist
    {
        /// <summary>
        /// �豸���ͱ���
        /// </summary>
        [Column("typeCode_Equipment")]
        public string TypeCodeEquipment { get; set; }

        /// <summary>
        /// �豸��������
        /// </summary>
        [Column("typeName_Equipment")]
        public string TypeNameEquipment { get; set; }

        /// <summary>
        /// �豸����
        /// </summary>
        [Column("Equipment_Name")]
        public string EquipmentName { get; set; }

        /// <summary>
        /// �豸����
        /// </summary>
        [Column("Equipment_Code")]
        public string EquipmentCode { get; set; }

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