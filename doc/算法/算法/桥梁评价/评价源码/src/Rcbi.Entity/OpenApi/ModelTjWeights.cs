using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    public class ModelTjWeights
    {

        /// <summary>
        /// �ṹ����
        /// </summary>
        public string StructureAtt { get; set; }

        /// <summary>
        /// Ȩ��
        /// </summary>
        public decimal Weight_Att { get; set; }

        /// <summary>
        /// �ṹ���
        /// </summary>
        public string StructureType { get; set; }

        /// <summary>
        /// Ȩ��
        /// </summary>
        public decimal Weight_Type { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string ComponentType { get; set; }

        /// <summary>
        /// ��������Ȩ��
        /// </summary>
        public decimal Weight_Com { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string Defect { get; set; }

        /// <summary>
        /// ������Ȩ��
        /// </summary>
        public decimal Weight_Def { get; set; }

        /// <summary>
        /// ������Ҫ�̶�
        /// </summary>
        public string Defect_importance { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        public string Project_Code { get; set; }
    }
}