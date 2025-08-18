using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class ModelTjDataSedimentation
    {
        /// <summary>
        /// ��ʼ����
        /// </summary>
        [Required(ErrorMessage = "��ʼ����Ϊ����")]
        public DateTime? Start_Date { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required(ErrorMessage = "��������Ϊ����")]
        public DateTime End_Date { get; set; }

        /// <summary>
        /// ׮��
        /// </summary>
        [Required(ErrorMessage = "׮��Ϊ����")]
        public string Station { get; set; }

        /// <summary>
        /// ���-R
        /// </summary>
        public string Code_R { get; set; }

        /// <summary>
        /// ��ʼֵ-R
        /// </summary>
        public string Value_R { get; set; }

        /// <summary>
        /// ���-L
        /// </summary>
        public string Code_L { get; set; }

        /// <summary>
        /// ��ʼֵ-L
        /// </summary>
        public string Value_L { get; set; }

        /// <summary>
        /// ��Ŀ���
        /// </summary>
        [Required(ErrorMessage = "��Ŀ���Ϊ����")]
        public string Project_Code { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Required(ErrorMessage = "������Ϊ����")]
        public string TaskNo { get; set; }


        public string Code { get; set; }
        public decimal? Value { get; set; }
        public decimal? Sedimentation { get; set; }
    }
}