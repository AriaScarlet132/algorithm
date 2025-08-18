using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.iisp.Business.ModelMsgEntity
{
    /// <summary>
    /// 每个模型的执行状态
    /// </summary>
    public enum ModelRunState
    {
        //模型失效，表示该模型不可用
        Disable = 1,
        //模型有效，表示该模型可用
        Enable = 2,
        //模型停止，未激活
        Stop = 3,
        //模型计算错误结束
        Error = 4,
        //模型计算中
        Run = 5,
        //模型启动中
        Start = 6,
        //模型计算结束
        Success = 7
    }
}
