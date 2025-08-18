using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 路面结果
    /// </summary>
    public class ModelRoadInfos
    {
        /// <summary>
        /// 隧道整体路面评价结果
        /// </summary>
        public ModelRoadResultAll ModelRoadResultAll { get; set; }
        /// <summary>
        /// 线路
        /// </summary>
        public List<ModelRoadLineInfos> ModelRoadLineInfos { get; set; }
    }

    /// <summary>
    /// 线路信息
    /// </summary>
    public class ModelRoadLineInfos
    {
        /// <summary>
        /// 隧道线路级路面评价结果
        /// </summary>
        public ModelRoadResultLine ModelRoadResultLine { get; set; }
        /// <summary>
        /// 车道信息
        /// </summary>
        public List<ModelRoadLaneInfos> ModelRoadLaneInfos { get; set; }
    }

    /// <summary>
    /// 车道信息
    /// </summary>
    public class ModelRoadLaneInfos
    {
        /// <summary>
        /// 隧道车道级路面评价结果
        /// </summary>
        public ModelRoadResultLane ModelRoadResultLane { get; set; }

        /// <summary>
        /// 桩数据
        /// </summary>
        public ModelRoadResultSectionInfos ModelRoadResultSectionInfos { get; set; }
    }

    /// <summary>
    /// 单元信息
    /// </summary>
    public class ModelRoadResultSectionInfos
    {
        /// <summary>
        /// 隧道单元级路面评价结果
        /// </summary>
        public List<ModelRoadResultSection> ModelRoadResultSections { get; set; }
      
    }


}
