using System;
using Rcbi.Entity.Query;
using System.Text;

namespace Rcbi.Entity.Domain
{
    /// <summary>
    /// ��ҵ����������Ϣ��MIIҵ����Ϣ
    /// </summary>
    public class ModelOpMiidataQuery : LayuiQuery
    {
        public int ID { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ProjecName { get; set; }

        public string project_code { get; set; }

        public string task_no { get; set; }

        /// <summary>
        /// �ĵ�����
        /// </summary>
        public string DocCode { get; set; }

        /// <summary>
        /// ���۹淶�е�Ӧ�ύ�ĵ�����
        /// </summary>
        public string DocName_Spec { get; set; }

        /// <summary>
        /// ��˾��������ʵ������
        /// </summary>
        public string DocName_Company { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public string DocYear { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public int DocComplete { get; set; }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime DataPushDate { get; set; }


        public override CommonQuery ToCommonQuery()
        {
                 throw new NotImplementedException();
        }
    }
}