using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ��������Ŀ���豸�����۽��
    /// </summary>
    public class ModelMesResultEquipment
    {
        /// <summary>
        /// ��ʼ����
        /// </summary>
        [Column("start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Column("end")]
        public DateTime End { get; set; }

        /// <summary>
        /// �豸����
        /// </summary>
        [Column("TypeName_Equipment")]
        public string TypeNameEquipment { get; set; }

        /// <summary>
        /// �豸���ͱ���
        /// </summary>
        [Column("TypeCode_Equipment")]
        public string TypeCodeEquipment { get; set; }

        /// <summary>
        /// �豸������Ҫ��
        /// </summary>
        [Column("importance_Equipment")]
        public string ImportanceEquipment { get; set; }

        /// <summary>
        /// �豸�����
        /// </summary>
        [Column("integrityrate_Equipment")]
        public string IntegrityrateEquipment { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Column("project_code")]
        public string Project_Code { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("task_no")]
        public string TaskNo { get; set; }

    }
}