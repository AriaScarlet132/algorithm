using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// �ṹ�����Ϣ
    /// </summary>
    public class ModelTjTunnelstructuretype
    {


        /// <summary>
        /// �����·
        /// </summary>
        [Required(ErrorMessage = "�����·Ϊ����")]
        public string Line { get; set; }

        /// <summary>
        /// ��·����
        /// </summary>
        [Required(ErrorMessage = "��·����Ϊ����")]
        public string Code_line { get; set; }

        /// <summary>
        /// �ṹ����
        /// </summary>
        [Required(ErrorMessage = "�ṹ����Ϊ����")]
        public string StructureAtt { get; set; }

        /// <summary>
        /// �ṹ���Ա���
        /// </summary>
        [Required(ErrorMessage = "�ṹ���Ա���Ϊ����")]
        public string Code_StructureAtt { get; set; }

        /// <summary>
        /// �ṹ���
        /// </summary>
        [Required(ErrorMessage = "�ṹ���Ϊ����")]
        public string StructureType { get; set; }

        /// <summary>
        /// �ṹ������
        /// </summary>
        [Required(ErrorMessage = "�ṹ������Ϊ����")]
        public string Code_StructureType { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Required(ErrorMessage = "��Ŀ���Ϊ����")]
        public string Project_Code { get; set; }
    }
}