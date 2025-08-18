using System;
using System.Collections.Generic;
using Rcbi.Core.Attributes;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelMesSystemtypeWeights
    {
        public int Id { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("CODE")]
        public string CODE { get; set; }

        /// <summary>
        /// ϵͳ����
        /// </summary>
        [Column("SystemName")]
        public string SystemName { get; set; }

        /// <summary>
        /// ��ϵͳռ�����Ȩ��
        /// </summary>
        [Column("weights_system")]
        public string WeightsSystem { get; set; }

        /// <summary>
        /// ����ϵͳ
        /// </summary>
        [Column("ParentSystem")]
        public string ParentSystem { get; set; }

        /// <summary>
        /// ϵͳ�㼶
        /// </summary>
        [Column("LevelName")]
        public string LevelName { get; set; }

        /// <summary>
        /// �豸����
        /// </summary>
        public string facility_type { get; set; }
    }
}