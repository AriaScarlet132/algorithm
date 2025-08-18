using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// �����·����ҵ����Ϣ
    /// </summary>
    public class ModelOpLineinfoQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// ��·����
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// ��·��
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// ��·����
        /// </summary>
        public decimal LineLength { get; set; }

        public string project_code { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ProjectName { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime DataPushDate { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }

        /// <summary>
        /// �ṹ����  V2
        /// </summary>
        public string StructureType { get; set; }
        /// <summary>
        /// �ṹ���γ���   V2
        /// </summary>
        public int? StructureTypeLength { get; set; }
    }
}