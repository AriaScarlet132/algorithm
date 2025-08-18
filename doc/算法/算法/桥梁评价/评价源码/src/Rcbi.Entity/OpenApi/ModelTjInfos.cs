using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Entity.OpenApi
{
    /// <summary>
    /// 土建结果
    /// </summary>
    public class ModelTjInfos
    {
        //待评价项目的结构类别级评价结果
        public List<ModelTjResultTunnelstructuretype> ModelTjResultTunnelstructuretypes { get; set; }
        //待评价项目的结构属性级评价结果
        public List<ModelTjResultTunnelstructureatt> ModelTjResultTunnelstructureatts { get; set; }
        //待评价项目的评价单元级评价结果
        public List<ModelTjResultTunnelsection> ModelTjResultTunnelsections { get; set; }

        //待评价项目的线路级评价结果
        public List<ModelTjResultTunnelline> ModelTjResultTunnellines { get; set; }

        //待评价项目的土建结构评价结果
        public List<ModelTjResultTunnel> ModelTjResultTunnels { get; set; }
        /// <summary>
        /// 待评价项目的构件类别得分计算信息
        /// </summary>
        public List<ModelTjResultComponenttype> ModelTjResultComponenttypes { get; set; }
    }
   

}
