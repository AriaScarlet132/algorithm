using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class ModelTjLine
    {

        /// <summary>
        /// ��·��
        /// </summary>
        public string Line_name { get; set; }

        /// <summary>
        /// ��·��
        /// </summary>
        [Required(ErrorMessage = "��·��Ϊ����")]
        public string Line_no { get; set; }

        /// <summary>
        /// ��·��
        /// </summary>
        [Required(ErrorMessage = "��·��Ϊ����")]
        public decimal Line_l { get; set; }

        /// <summary>
        /// ��Ŀ����
        /// </summary>
        [Required(ErrorMessage = "��Ŀ����Ϊ����")]
        public string Project_Code { get; set; }
    }
}