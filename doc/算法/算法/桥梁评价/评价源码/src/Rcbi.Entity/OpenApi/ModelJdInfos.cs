using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 机电结果
    /// </summary>
    public class ModelJdInfos
    {
        /// <summary>
        /// 待评价项目的机电系统总体评价结果
        /// </summary>
        public ModelMesResultMesystem ModelMesResultMesystems { get; set; }
        /// <summary>
        /// 待评价项目的设备级评价结果
        /// </summary>
        public List<ModelMesResultEquipment> ModelMesResultEquipments { get; set; }
        /// <summary>
        /// 待评价项目的分系统级评价结果
        /// </summary>
        public List<ModelMesResultMidsystem> ModelMesResultMidsystems { get; set; }
        /// <summary>
        ///  待评价项目的子系统级评价结果
        /// </summary>
        public List<ModelMesResultSubsystem> ModelMesResultSubsystems { get; set; }
    }
}
