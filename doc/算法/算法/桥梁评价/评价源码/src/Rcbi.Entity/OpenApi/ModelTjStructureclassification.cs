using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelTjStructureclassification
    {

        /// <summary>
        /// �ṹ����
        /// </summary>
        public string StructureAtt { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        public string StructureType { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string ComponentType { get; set; }

        /// <summary>
        /// ������Ҫ��
        /// </summary>
        public string Component_importance { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        public string Project_Code { get; set; }

        /// <summary>
        /// Ȩ��V2
        /// </summary>
        public decimal? Weight { get; set; }
        /// <summary>
        /// ������V2
        /// </summary>
        public string  Defect { get; set; }
    }
}