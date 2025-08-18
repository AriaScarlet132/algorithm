using Microsoft.AspNetCore.Mvc;
using Rcbi.AspNetCore.Helper;
using Rcbi.Business;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Enums;
using Rcbi.Entity.OpenApi;
using Rcbi.Framework.Controllers;
using Rcbi.IdentityServer.Interfaces.Services;
using Rcbi.iisp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rcbi.Api.Controllers.OpenApi
{
    /// <summary>
    ///  运营服务评估模型   V2
    /// </summary>
    [Route("v2/openApi/opeva")]
    public class OpevaV2Controller : BaseApiController
    {
        OpBll opBll = new OpBll();
        private IUserService userService;
        public OpevaV2Controller(IUserService userService)
        {
            this.userService = userService;
        }
        #region 查询
        /// <summary>
        /// 获取运营服务信息
        /// </summary>
        /// <param name="task_no">任务编号</param>
        [HttpGet("getModelOpInfos")]
        public OpenApiResult<ModelOpInfos> GetModelOpInfos(string task_no)
        {
            try
            {
                if (string.IsNullOrEmpty(task_no))
                {
                    return new OpenApiResult<ModelOpInfos>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<ModelOpInfos> result = opBll.GetModelOpInfos(task_no);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<ModelOpInfos>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region 基础数据
        ///// <summary>
        ///// 新增用户服务指标评价等级【基础数据】
        ///// </summary>
        //[HttpPost("addOpCsiCriteria")]
        //public OpenApiResult<bool> AddOpCsiCriteria([FromBody] List<ModelOpCsiCriteria> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpCsiCriteria(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        ///// <summary>
        ///// 新增内业管理服务指标评价等级【基础数据】
        ///// </summary>
        //[HttpPost("addOpMsiCriteria")]
        //public OpenApiResult<bool> AddOpMsiCriteria([FromBody] List<ModelOpMsiCriteria> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpMsiCriteria(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        ///// <summary>
        ///// 新增FWCI指数评价等级【基础数据】
        ///// </summary>
        //[HttpPost("addOpFwciCriteria")]
        //public OpenApiResult<bool> AddOpFwciCriteria([FromBody] List<ModelOpFwciCriteria> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpFwciCriteria(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        ///// <summary>
        ///// 新增安全服务指标评价等级【基础数据】
        ///// </summary>
        //[HttpPost("addOpSsiCriteria")]
        //public OpenApiResult<bool> AddOpSsiCriteria([FromBody] List<ModelOpSsiCriteria> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpSsiCriteria(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        ///// <summary>
        ///// 新增交通服务指标评价等级【基础数据】
        ///// </summary>
        //[HttpPost("addOpTsiCriteria")]
        //public OpenApiResult<bool> AddOpTsiCriteria([FromBody] List<ModelOpTsiCriteria> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpTsiCriteria(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}
        /// <summary>
        /// 新增隧道基础信息【基础数据】
        /// </summary>
        [HttpPost("addOpTunnelbasicinfo")]
        public OpenApiResult<bool> AddOpTunnelbasicinfo([FromBody] List<ModelOpTunnelbasicinfo> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpTunnelbasicinfo(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        #endregion


        #region 分析数据

        /// <summary>
        /// 新增CO一氧化碳指数业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpCodata")]
        public OpenApiResult<bool> AddOpCodata([FromBody] List<ModelOpCodata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpCodata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增交牵引排堵TEI业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpTeidata")]
        public OpenApiResult<bool> AddOpTeidata([FromBody] List<ModelOpTeidata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpTeidata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增交通流量DTI线路业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpDtidata")]
        public OpenApiResult<bool> AddOpDtidata([FromBody] List<ModelOpDtidata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDtidata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增交通畅通率DFR业务信息【分析数据】
        /// </summary>
        //[HttpPost("addOpDfrdata")]
        //public OpenApiResult<bool> AddOpDfrdata([FromBody] List<ModelOpDfrdata> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpDfrdata(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增交通路面荷载LR业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpLrdata")]
        public OpenApiResult<bool> AddOpLrdata([FromBody] List<ModelOpLrdata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpLrdata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增亮度或照度BI业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpBidata")]
        public OpenApiResult<bool> AddOpBidata([FromBody] List<ModelOpBidata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpBidata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增内业成本绩效MCI业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpMcidata")]
        public OpenApiResult<bool> AddOpMcidata([FromBody] List<ModelOpMcidata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpMcidata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增内业报编制MBI业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpMbidata")]
        public OpenApiResult<bool> AddOpMbidata([FromBody] List<ModelOpMbidata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpMbidata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增内业档案资料信息化MII业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpMiidata")]
        public OpenApiResult<bool> AddOpMiidata([FromBody] List<ModelOpMiidata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpMiidata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增内业管理制度MSSI业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpMssidata")]
        public OpenApiResult<bool> AddOpMssidata([FromBody] List<ModelOpMssidata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpMssidata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增可吸入颗粒物浓度PM2.5业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpPmdata")]
        public OpenApiResult<bool> AddOpPmdata([FromBody] List<ModelOpPmdata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpPmdata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        ///  新增噪音DI业务信息【分析数据】
        /// </summary>
        //[HttpPost("addOpDidata")]
        //public OpenApiResult<bool> AddOpDidata([FromBody] List<ModelOpDidata> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpDidata(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        ///新增安全事故率RV业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpRvdata")]
        public OpenApiResult<bool> AddOpRvdata([FromBody] List<ModelOpRvdata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpRvdata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增用户满意度UCVI业务信息【分析数据】
        /// </summary>
        [HttpPost("addOpUcvidata")]
        public OpenApiResult<bool> AddOpUcvidata([FromBody] List<ModelOpUcvidata> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpUcvidata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 新增用户舒适度UCI业务信息【分析数据】
        /// </summary>
        //[HttpPost("addOpUcidata")]
        //public OpenApiResult<bool> AddOpUcidata([FromBody] List<ModelOpUcidata> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpUcidata(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增能见度VI业务信息【分析数据】
        /// </summary>
        //[HttpPost("addOpVidata")]
        //public OpenApiResult<bool> AddOpVidata([FromBody] List<ModelOpVidata> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpVidata(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增行驶速率DSI业务信息【分析数据】
        /// </summary>
        //[HttpPost("addOpDsidata")]
        //public OpenApiResult<bool> AddOpDsidata([FromBody] List<ModelOpDsidata> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpDsidata(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        ///// <summary>
        ///// 新增隧道交通流量业务信息【分析数据】
        ///// </summary>
        //[HttpPost("addOpTunneltrafficinfo")]
        //public OpenApiResult<bool> AddOpTunneltrafficinfo([FromBody] List<ModelOpTunneltrafficinfo> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpTunneltrafficinfo(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        ///// <summary>
        ///// 新增隧道线路基本业务信息【分析数据】
        ///// </summary>
        //[HttpPost("addOpLineinfo")]
        //public OpenApiResult<bool> AddOpLineinfo([FromBody] List<ModelOpLineinfo> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpLineinfo(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        ///// <summary>
        ///// 新增隧道车道基本业务信息【分析数据】
        ///// </summary>
        //[HttpPost("addOpLaneinfo")]
        //public OpenApiResult<bool> AddOpLaneinfo([FromBody] List<ModelOpLaneinfo> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpLaneinfo(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        #endregion

        #region  创建任务
        /// <summary>
        /// 创建路面性能评估任务
        /// </summary>
        /// <param name="model">路面性能评估模型</param>
        /// <returns></returns>
        [HttpPost("createTask")]
        public OpenApiResult<string> CreateTask(ModelResultMainRequest model)
        {
            try
            {
                if (model == null)
                {
                    new OpenApiResult<string>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }

                OpenApiResult<string> result = opBll.CreateTask(model);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<string>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }


        /// <summary>
        /// 开启路面性能评估任务
        /// </summary>
        /// <param name="task_no">任务编号</param>
        /// <returns></returns>
        [HttpPost("startTask")]
        public OpenApiResult<bool> StartTask(string task_no)
        {
            try
            {
                if (string.IsNullOrEmpty(task_no))
                {
                    return new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<TbModelResultMain> result = opBll.StartTask(task_no, CurrentUser.Id);
                if (result.Status != (int)OpenApiResultStatus.SUCCESS)
                {
                    return new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = result.Status,
                        Message = result.Message
                    };
                }
                CreateIispTask.Send(result.Data,"V2");
                return new OpenApiResult<bool>
                {
                    Data = true,
                    Status = result.Status,
                    Message = result.Message
                };
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = true,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region 8.运营服务评价接口

        /// <summary>
        /// 8.2.新增桥梁基本信息（基础数据）
        /// </summary>
        [HttpPost("addBridgeBasicInfo")]
        public OpenApiResult<bool> AddBridgeBasicInfo([FromBody] List<ModelOpBridgeBasicInfo> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpBridgeBasicInfo(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.3.新增车辆行车速度数据(待分析数据)
        /// </summary>
        [HttpPost("addTrafficDriveSpeed")]
        public OpenApiResult<bool> AddTrafficDriveSpeed([FromBody] List<ModelOpTrafficDriveSpeed> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpTrafficDriveSpeed(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.4.新增交通车流量数据(待分析数据)
        /// </summary>
        [HttpPost("addTrafficFlow")]
        public OpenApiResult<bool> AddTrafficFlow([FromBody] List<ModelOpTrafficFlow> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpTrafficFlow(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.5.新增交通封闭期车流量(待分析数据)
        /// </summary>
        [HttpPost("addTrafficFenceInfluence")]
        public OpenApiResult<bool> AddTrafficFenceInfluence([FromBody] List<ModelOpTrafficFenceInfluence> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpTrafficFenceInfluence(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.6.新增交通事故信息(待分析数据)
        /// </summary>
        [HttpPost("addTrafficAccident")]
        public OpenApiResult<bool> AddTrafficAccident([FromBody] List<ModelOpTrafficAccident> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpTrafficAccident(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.7.新增应急设备和材料完备性信息(待分析数据)
        /// </summary>
        [HttpPost("addDeviceMaterialComplete")]
        public OpenApiResult<bool> AddDeviceMaterialComplete([FromBody] List<ModelOpDeviceMaterialComplete> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDeviceMaterialComplete(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.8.新增救援响应信息(待分析数据)
        /// </summary>
        [HttpPost("addEmergencyResponse")]
        public OpenApiResult<bool> AddEmergencyResponse([FromBody] List<ModelOpEmergencyResponse> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpEmergencyResponse(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.9.新增用户投诉及时响应信息(待分析数据)
        /// </summary>
        [HttpPost("addComplaintResponse")]
        public OpenApiResult<bool> AddComplaintResponse([FromBody] List<ModelOpComplaintResponse> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpComplaintResponse(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.10.新增用户有责投诉和有效投诉（无责投诉）次数信息(待分析数据)
        /// </summary>
        [HttpPost("addValidComplaint")]
        public OpenApiResult<bool> AddValidComplaint([FromBody] List<ModelOpValidComplaint> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpValidComplaint(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.11.新增交通信息发布准确次数数据(待分析数据)
        /// </summary>
        [HttpPost("addReleaseInfoAccuracy")]
        public OpenApiResult<bool> AddReleaseInfoAccuracy([FromBody] List<ModelOpReleaseInfoAccuracy> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpReleaseInfoAccuracy(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        /// <summary>
        /// 8.12.新增交通信息发布及时次数数据(待分析数据)
        /// </summary>
        [HttpPost("addReleaseInfoTimeliness")]
        public OpenApiResult<bool> AddReleaseInfoTimeliness([FromBody] List<ModelOpReleaseInfoTimeliness> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpReleaseInfoTimeliness(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }


        /// <summary>
        ///  8.13.新增有责投诉和有效投诉（无责投诉）完成数据(待分析数据)
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("addValidComplaintHandle")]
        public OpenApiResult<bool> AddValidComplaintHandle([FromBody] List<ModelOpValidComplaintHandle> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpValidComplaintHandle(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        ///  8.15.获取运营服务评价结果
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpGet("getBridgeModelOpResults")]
        public OpenApiResult<ModelOpBridgeInfos> GetBridgeModelOpResults(string task_no)
        {
            try
            {
                if (string.IsNullOrEmpty(task_no))
                {
                    return new OpenApiResult<ModelOpBridgeInfos>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<ModelOpBridgeInfos> result = opBll.GetBridgeModelOpResults(task_no);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<ModelOpBridgeInfos>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region 新增v2数据接口
        #region 基础数据

        #region 运营服务评价指标权重信息表

        ///// <summary>
        ///// 获取运营服务评价指标权重信息
        ///// </summary>
        ///// <param name="IndexName">权重名称</param>
        ///// <param name="ParentIndex">父指数</param>
        //[HttpGet("getWeightinfo")]
        //public OpenApiResult<List<ModelOpevaWeightInfo>> GetWeightinfo(string IndexName,string ParentIndex)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(IndexName) && string.IsNullOrEmpty(ParentIndex))
        //        {
        //            return new OpenApiResult<List<ModelOpevaWeightInfo>>
        //            {
        //                Data = null,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<List<ModelOpevaWeightInfo>> result = opBll.GetWeightinfo(IndexName, ParentIndex);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<List<ModelOpevaWeightInfo>>
        //        {
        //            Data = null,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增运营服务评价指标权重信息表【基础数据】 v2
        /// </summary>
        [HttpPost("addWeightinfo")]
        public OpenApiResult<bool> AddWeightinfo([FromBody] List<ModelOpevaWeightInfo> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelWeightinfo(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        ///// <summary>
        ///// 更新运营服务评价指标权重信息表【基础数据】
        ///// </summary>
        //[HttpPost("updateModelWeightinfo")]
        //public OpenApiResult<bool> UpdateModelWeightinfo([FromBody] List<ModelOpevaWeightInfo> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelWeightinfo(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 删除运营服务评价指标权重信息表【基础数据】 v2
        /// </summary>
        [HttpPost("deleteModelWeightinfo")]
        public OpenApiResult<bool> DeleteModelWeightinfo([FromBody] List<ModelOpevaWeightInfo> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelWeightinfo(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  评价等级与分值对应关系表

        /// <summary>
        /// 评价等级与分值对应关系表
        /// </summary>
        /// <param name="IndexName">指标名称</param>
        /// <param name="ParentIndex">指标名称</param>
        //[HttpGet("getModelOpCriteria")]
        //public OpenApiResult<List<ModelOpCriteria>> GetModelOpCriteria(string IndexName, string ParentIndex)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(IndexName) && string.IsNullOrEmpty(ParentIndex))
        //        {
        //            return new OpenApiResult<List<ModelOpCriteria>>
        //            {
        //                Data = null,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<List<ModelOpCriteria>> result = opBll.GetModelOpCriteria(IndexName, ParentIndex);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<List<ModelOpCriteria>>
        //        {
        //            Data = null,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增评价等级与分值对应关系表【基础数据】 v2
        /// </summary>
        [HttpPost("addModelOpCriteria")]
        public OpenApiResult<bool> AddCriteriaInfo([FromBody] List<ModelOpCriteria> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddCriteriaInfo(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        ///// <summary>
        ///// 更新评价等级与分值对应关系表【基础数据】
        ///// </summary>
        //[HttpPost("updateModelOpCriteria")]
        //public OpenApiResult<bool> UpdateModelOpCriteria([FromBody] List<ModelOpCriteria> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddCriteriaInfo(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 删除评价等级与分值对应关系表【基础数据】 v2
        /// </summary>
        [HttpPost("deleteModelOpCriteria")]
        public OpenApiResult<bool> DeleteModelOpCriteria([FromBody] List<ModelOpCriteria> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpCriteria(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的保洁效果信息表

        /// <summary>
        /// 待评价项目的保洁效果信息表
        /// </summary>
        /// <param name="task_no">任务号</param>
        //[HttpGet("getModelOpDataClean")]
        //public OpenApiResult<List<ModelOpDataClean>> GetModelOpDataClean(string task_no)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(task_no) )
        //        {
        //            return new OpenApiResult<List<ModelOpDataClean>>
        //            {
        //                Data = null,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<List<ModelOpDataClean>> result = opBll.GetModelOpDataClean(task_no);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<List<ModelOpDataClean>>
        //        {
        //            Data = null,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}


        /// <summary>
        /// 新增待评价项目的保洁效果信息表【基础数据】v2
        /// </summary>
        [HttpPost("addModelOpDataClean")]
        public OpenApiResult<bool> AddModelOpDataClean([FromBody] List<ModelOpDataClean> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDataClean(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 更新待评价项目的保洁效果信息表【基础数据】
        /// </summary>
        //[HttpPost("updateModelOpDataClean")]
        //public OpenApiResult<bool> UpdateModelOpDataClean([FromBody] List<ModelOpDataClean> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpDataClean(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 删除待评价项目的保洁效果信息表【基础数据】v2
        /// </summary>
        [HttpPost("deleteModelOpDataClean")]
        public OpenApiResult<bool> DeleteModelOpDataClean([FromBody] List<ModelOpDataClean> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpDataClean(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的废水排放合格率信息
        ///// <summary>
        ///// 待评价项目的保洁效果信息表
        ///// </summary>
        ///// <param name="task_no">任务号</param>
        //[HttpGet("getModelOpDataEffluent")]
        //public OpenApiResult<List<ModelOpDataEffluent>> GetModelOpDataEffluent(string task_no)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(task_no))
        //        {
        //            return new OpenApiResult<List<ModelOpDataEffluent>>
        //            {
        //                Data = null,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<List<ModelOpDataEffluent>> result = opBll.GetModelOpDataEffluent(task_no);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<List<ModelOpDataEffluent>>
        //        {
        //            Data = null,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增待评价项目的废水排放合格率信息【基础数据】v2
        /// </summary>
        [HttpPost("addModelOpDataEffluent")]
        public OpenApiResult<bool> AddModelOpDataEffluent([FromBody] List<ModelOpDataEffluent> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDataEffluent(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        ///// <summary>
        ///// 更新待评价项目的废水排放合格率信息【基础数据】v2
        ///// </summary>
        //[HttpPost("updateModelOpDataEffluent")]
        //public OpenApiResult<bool> UpdateModelOpDataEffluent([FromBody] List<ModelOpDataEffluent> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpDataEffluent(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 删除待评价项目的废水排放合格率信息【基础数据】v2
        /// </summary>
        [HttpPost("deleteModelOpDataEffluent")]
        public OpenApiResult<bool> DeleteModelOpDataEffluent([FromBody] List<ModelOpDataEffluent> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpDataEffluent(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的应急响应及时率信息
        ///// <summary>
        ///// 待评价项目的应急响应及时率信息
        ///// </summary>
        ///// <param name="task_no">任务号</param>
        //[HttpGet("getModelOpDataEri")]
        //public OpenApiResult<List<ModelOpDataEri>> GetModelOpDataEri(string task_no)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(task_no))
        //        {
        //            return new OpenApiResult<List<ModelOpDataEri>>
        //            {
        //                Data = null,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<List<ModelOpDataEri>> result = opBll.GetModelOpDataEri(task_no);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<List<ModelOpDataEri>>
        //        {
        //            Data = null,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增待评价项目的应急响应及时率信息【基础数据】v2
        /// </summary>
        [HttpPost("addModelOpDataEri")]
        public OpenApiResult<bool> AddModelOpDataEri([FromBody] List<ModelOpDataEri> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDataEri(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        ///// <summary>
        ///// 更新待评价项目的应急响应及时率信息【基础数据】
        ///// </summary>
        //[HttpPost("updateModelOpDataEri")]
        //public OpenApiResult<bool> UpdateModelOpDataEri([FromBody] List<ModelOpDataEri> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpDataEri(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 删除待评价项目的应急响应及时率信息【基础数据】v2
        /// </summary>
        [HttpPost("deleteModelOpDataEri")]
        public OpenApiResult<bool> DeleteModelOpDataEri([FromBody] List<ModelOpDataEri> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpDataEri(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的节能环保信息
        /// <summary>
        /// 待评价项目的节能环保信息
        /// </summary>
        /// <param name="task_no">任务号</param>
        //[HttpGet("getModelOpDataEs")]
        //public OpenApiResult<List<ModelOpDataEs>> GetModelOpDataEs(string task_no)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(task_no))
        //        {
        //            return new OpenApiResult<List<ModelOpDataEs>>
        //            {
        //                Data = null,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<List<ModelOpDataEs>> result = opBll.GetModelOpDataEs(task_no);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<List<ModelOpDataEs>>
        //        {
        //            Data = null,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增待评价项目的节能环保信息【基础数据】v2
        /// </summary>
        [HttpPost("addModelOpDataEs")]
        public OpenApiResult<bool> AddModelOpDataEs([FromBody] List<ModelOpDataEs> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDataEs(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 更新待评价项目的节能环保信息【基础数据】
        /// </summary>
        //[HttpPost("updateModelOpDataEs")]
        //public OpenApiResult<bool> UpdateModelOpDataEs([FromBody] List<ModelOpDataEs> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.AddModelOpDataEs(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 删除待评价项目的节能环保信息【基础数据】v2
        /// </summary>
        [HttpPost("deleteModelOpDataEs")]
        public OpenApiResult<bool> DeleteModelOpDataEs([FromBody] List<ModelOpDataEs> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpDataEs(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的高峰期烟雾浓度信息
        /// <summary>
        /// 待评价项目的高峰期烟雾浓度信息
        /// </summary>
        /// <param name="task_no">任务号</param>
        //[HttpGet("getModelOpDataEs")]
        //public OpenApiResult<List<ModelOpDataEs>> GetModelOpDataEs(string task_no)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(task_no))
        //        {
        //            return new OpenApiResult<List<ModelOpDataEs>>
        //            {
        //                Data = null,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<List<ModelOpDataEs>> result = opBll.GetModelOpDataEs(task_no);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<List<ModelOpDataEs>>
        //        {
        //            Data = null,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增待评价项目的高峰期烟雾浓度信息【基础数据】v2
        /// </summary>
        [HttpPost("addModelOpDataK")]
        public OpenApiResult<bool> AddModelOpDataK([FromBody] List<ModelOpDataK> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDataK(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        /// <summary>
        /// 更新待评价项目的高峰期烟雾浓度信息【基础数据】
        /// </summary>
        //[HttpPost("updateModelOpDataK")]
        //public OpenApiResult<bool> UpdateModelOpDataK([FromBody] List<ModelOpDataK> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.UpdateModelOpDataK(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 删除待评价项目的高峰期烟雾浓度信息【基础数据】v2
        /// </summary>
        [HttpPost("deleteModelOpDataK")]
        public OpenApiResult<bool> DeleteModelOpDataK([FromBody] List<ModelOpDataK> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpDataK(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的标线光度性能信息
        /// <summary>
        /// 待评价项目的标线光度性能信息
        /// </summary>
        /// <param name="task_no">任务号</param>
        //[HttpGet("getModelOpDataEs")]
        //public OpenApiResult<List<ModelOpDataEs>> GetModelOpDataEs(string task_no)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(task_no))
        //        {
        //            return new OpenApiResult<List<ModelOpDataEs>>
        //            {
        //                Data = null,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<List<ModelOpDataEs>> result = opBll.GetModelOpDataEs(task_no);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<List<ModelOpDataEs>>
        //        {
        //            Data = null,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增待评价项目的标线光度性能信息【基础数据】v2
        /// </summary>
        [HttpPost("addModelOpDataNBI")]
        public OpenApiResult<bool> AddModelOpDataNBI([FromBody] List<ModelOpDataNBI> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDataNBI(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }

        ///// <summary>
        ///// 更新待评价项目的标线光度性能信息【基础数据】
        ///// </summary>
        //[HttpPost("updateModelOpDataNBI")]
        //public OpenApiResult<bool> UpdateModelOpDataNBI([FromBody] List<ModelOpDataNBI> models)
        //{
        //    try
        //    {
        //        if (models == null && models.Count <= 0)
        //        {
        //            new OpenApiResult<bool>
        //            {
        //                Data = false,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<bool> result = opBll.UpdateModelOpDataNBI(models);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<bool>
        //        {
        //            Data = false,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 删除待评价项目的标线光度性能信息【基础数据】v2
        /// </summary>
        [HttpPost("deleteModelOpDataNBI")]
        public OpenApiResult<bool> DeleteModelOpDataNBI([FromBody] List<ModelOpDataNBI> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpDataNBI(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的安全生产事故信息

        /// <summary>
        /// 待评价项目的安全生产事故信息
        /// </summary>
        /// <param name="task_no">任务号</param>
        //[HttpGet("getModelOpDataEs")]
        //public OpenApiResult<List<ModelOpDataEs>> GetModelOpDataEs(string task_no)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(task_no))
        //        {
        //            return new OpenApiResult<List<ModelOpDataEs>>
        //            {
        //                Data = null,
        //                Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
        //                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
        //            };
        //        }
        //        OpenApiResult<List<ModelOpDataEs>> result = opBll.GetModelOpDataEs(task_no);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OpenApiResult<List<ModelOpDataEs>>
        //        {
        //            Data = null,
        //            Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
        //            Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
        //        };
        //    }
        //}

        /// <summary>
        /// 新增待评价项目的安全生产事故信息【基础数据】v2
        /// </summary>
        [HttpPost("addModelOpDataSafety")]
        public OpenApiResult<bool> AddModelOpDataSafety([FromBody] List<ModelOpDataSafety> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDataSafety(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }


        /// <summary>
        /// 删除待评价项目的安全生产事故信息【基础数据】v2
        /// </summary>
        [HttpPost("deleteModelOpDataSafety")]
        public OpenApiResult<bool> DeleteModelOpDataSafety([FromBody] List<ModelOpDataSafety> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpDataSafety(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的高峰期平均行驶速度信息

        /// <summary>
        /// 新增待评价项目的高峰期平均行驶速度信息【基础数据】v2
        /// </summary>
        [HttpPost("addModelOpDataSpeed")]
        public OpenApiResult<bool> AddModelOpDataSpeed([FromBody] List<ModelOpDataSpeed> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDataSpeed(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }


        /// <summary>
        /// 删除待评价项目的安全生产事故信息【基础数据】v2
        /// </summary>
        [HttpPost("deleteModelOpDataSpeed")]
        public OpenApiResult<bool> DeleteModelOpDataSpeed([FromBody] List<ModelOpDataSpeed> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpDataSpeed(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的通行影响率信息

        /// <summary>
        /// 新增待评价项目的通行影响率信息【基础数据】v2
        /// </summary>
        [HttpPost("addModelOpDataTraff")]
        public OpenApiResult<bool> AddModelOpDataTraff([FromBody] List<ModelOpDataTraff> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpDataTraff(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }


        /// <summary>
        /// 删除待评价项目的通行影响率信息【基础数据】v2
        /// </summary>
        [HttpPost("deleteModelOpDataTraff")]
        public OpenApiResult<bool> DeleteModelOpDataTraff([FromBody] List<ModelOpDataTraff> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.DeleteModelOpDataTraff(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的照明状况信息

        /// <summary>
        /// 新增待评价项目的照明状况信息【基础数据】v2
        /// </summary>
        [HttpPost("AddModelOpBidataQuery")]
        public OpenApiResult<bool> AddModelOpBidataQuery([FromBody] List<ModelOpBidataQuery2> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpBidata(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  待评价项目的照明状况信息

        /// <summary>
        /// 待评价项目的牵引排堵及时率信息【基础数据】v2
        /// </summary>
        [HttpPost("AddModelOpTeidata2")]
        public OpenApiResult<bool> AddModelOpTeidata2([FromBody] List<ModelOpTeidata2> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpTeidata2(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  车道线路基本业务信息

        /// <summary>
        /// 车道线路基本业务信息【基础数据】v2
        /// </summary>
        [HttpPost("AddModelOpLaneinfo")]
        public OpenApiResult<bool> AddModelOpLaneinfo([FromBody] List<ModelOpLaneinfo> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpLaneinfo(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region  新增隧道线路基本业务信息

        /// <summary>
        /// 新增隧道线路基本业务信息【基础数据】v2
        /// </summary>
        [HttpPost("AddModelOpLineinfo")]
        public OpenApiResult<bool> AddModelOpLineinfo([FromBody] List<ModelOpLineinfo> models)
        {
            try
            {
                if (models == null && models.Count <= 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = opBll.AddModelOpLineinfo(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion
        #endregion

        #endregion
    }
}
