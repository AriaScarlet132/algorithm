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
    /// 土建结构评估模型  V2
    /// </summary>
    [Route("v2/openApi/tjeva")]
    public class TjevaV2Controller : BaseApiController
    {
        TjBll tjBll = new TjBll();
        RoadBll roadBll = new RoadBll();
        private IUserService userService;
        public TjevaV2Controller(IUserService userService)
        {
            this.userService = userService;
        }

        #region 查询
        /// <summary>
        /// 获取土建结构信息
        /// </summary>
        /// <param name="task_no">任务编号</param>
        [HttpGet("getModelTjInfos")]
        public OpenApiResult<ModelTjInfos> GetModelAfInfos(string task_no)
        {
            try
            {
                if (string.IsNullOrEmpty(task_no))
                {
                    return new OpenApiResult<ModelTjInfos>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<ModelTjInfos> result = tjBll.GetModelTjInfos(task_no);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<ModelTjInfos>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region 基础数据

        /// <summary>
        /// 新增项目车道信息【基础数据】
        /// </summary>
        //[HttpPost("addTjLine")]
        //public OpenApiResult<bool> AddTjLine([FromBody] List<ModelTjLine> models)
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
        //        OpenApiResult<bool> result = tjBll.AddModelTjLine(models);
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
        /// 新增项目设施单元结构信息【基础数据】
        /// </summary>
        //[HttpPost("addTjTunnelsection")]
        //public OpenApiResult<bool> AddTjTunnelsection([FromBody] List<ModelTjTunnelsection> models)
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
        //        OpenApiResult<bool> result = tjBll.AddModelTjTunnelsection(models);
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
        /// 新增项目结构类别信息【基础数据】
        /// </summary>
        //[HttpPost("addTjTunnelstructuretype")]
        //public OpenApiResult<bool> AddTjTunnelstructuretype([FromBody] List<ModelTjTunnelstructuretype> models)
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
        //        OpenApiResult<bool> result = tjBll.AddModelTjTunnelstructuretype(models);
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
        /// 新增项目评价单元信息【基础数据】
        /// </summary>
        [HttpPost("addTjDataStructurefacility")]
        public OpenApiResult<bool> AddTjDataStructurefacility([FromBody] List<ModelTjDataStructurefacility> models)
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
                OpenApiResult<bool> result = tjBll.AddModelTjDataStructurefacility(models);
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
        /// 新增项目环号信息【基础数据】
        /// </summary>
        //[HttpPost("addTjDataSegmentring")]
        //public OpenApiResult<bool> AddTjDataSegmentring([FromBody] List<ModelTjDataSegmentring> models)
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
        //        OpenApiResult<bool> result = tjBll.AddModelTjDataSegmentring(models);
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
        /// 待评价项目的损坏类型信息【基础数据】
        /// </summary>
        [HttpPost("addTjModelRoadDamageType")]
        public OpenApiResult<bool> AddTjModelRoadDamageType([FromBody] List<ModelRoadDamageType> models)
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
                OpenApiResult<bool> result = tjBll.InsertModelRoadDamageType(models);
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
        /// 待评价项目的检测信息【基础数据】
        /// </summary>
        [HttpPost("addTjModelRoadCheckUnitInfo")]
        public OpenApiResult<bool> AddTjModelRoadCheckUnitInfo([FromBody] List<ModelRoadCheckUnitInfo> models)
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
                OpenApiResult<bool> result = tjBll.InsertModelRoadCheckUnitInfo(models);
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
        /// 土建分类表【基础数据】
        /// </summary>
        [HttpPost("addTjModelTjStructureclassification")]
        public OpenApiResult<bool> AddTjModelTjStructureclassification([FromBody] List<ModelTjStructureclassification> models)
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
                OpenApiResult<bool> result = tjBll.AddModelTjStructureclassification(models);
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
        /// 新增项目结构缺陷信息【分析数据】
        /// </summary>
        [HttpPost("addTjDataDefects")]
        public OpenApiResult<bool> AddTjDataDefects([FromBody] List<ModelTjDataDefects> models)
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
                OpenApiResult<bool> result = tjBll.AddModelTjDataDefects(models);
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
        /// 新增项目收敛变形信息【分析数据】
        /// </summary>
        [HttpPost("addTjDataDeformation")]
        public OpenApiResult<bool> AddTjDataDeformation([FromBody] List<ModelTjDataDeformation> models)
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
                OpenApiResult<bool> result = tjBll.AddModelTjDataDeformation(models);
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
        /// 待评价项目的收敛变形差异信息表【分析数据】 v2
        /// </summary>
        [HttpPost("addTjDataDiffsedimentation")]
        public OpenApiResult<bool> AddTjDataDiffsedimentation([FromBody] List<ModelTjDataDiffsedimentation> models)
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
                OpenApiResult<bool> result = tjBll.AddModelTjDataDiffsedimentation(models);
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
        /// 待评价项目的平均渗水量记录信息表【分析数据】 v2
        /// </summary>
        [HttpPost("addTjDataLeakage")]
        public OpenApiResult<bool> AddTjDataLeakage([FromBody] List<ModelTjDataLeakage> models)
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
                OpenApiResult<bool> result = tjBll.AddModelTjDataLeakage(models);
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
        /// 待评价项目的路面平整度信息 v2
        /// </summary>
        [HttpPost("addTjDataModelRoadDataCheckvalue")]
        public OpenApiResult<bool> AddTjDataModelRoadDataCheckvalue([FromBody] List<ModelRoadDataCheckvalue> models)
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
                OpenApiResult<bool> result = tjBll.AddTjDataModelRoadDataCheckvalue(models);
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
        /// 土建设施评价指标权重信息表 v2
        /// </summary>
        [HttpPost("addModelTjStructuretypeweights")]
        public OpenApiResult<bool> AddModelTjStructuretypeweights([FromBody] List<ModelTjStructuretypeweights> models)
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
                OpenApiResult<bool> result = tjBll.AddModelTjStructuretypeweights(models);
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
        /// 新增项目沉降信息【分析数据】
        /// </summary>
        [HttpPost("addTjDataSedimentation")]
        public OpenApiResult<bool> AddTjDataSedimentation([FromBody] List<ModelTjDataSedimentation> models)
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
                OpenApiResult<bool> result = tjBll.AddModelTjDataSedimentation(models);
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

        #region 原路面性能接口

        #region 查询
        /// <summary>
        /// 获取路面性能信息
        /// </summary>
        /// <param name="task_no">任务编号</param>
        [HttpGet("getModelRoadInfos")]
        public OpenApiResult<ModelRoadInfos> GetModelRoadInfos(string task_no)
        {
            try
            {
                if (string.IsNullOrEmpty(task_no))
                {
                    return new OpenApiResult<ModelRoadInfos>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<ModelRoadInfos> result = roadBll.GetModelRoadInfos(task_no);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<ModelRoadInfos>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion

        #region 基础数据

        /// <summary>
        /// 新增车道基本信息【基础数据】
        /// </summary>
        /// <param name="model">车道基本信息</param>
        [HttpPost("addLmLaneInfo")]
        public OpenApiResult<bool> AddLmLaneInfo([FromBody] List<ModelRoadLaneInfo> models)
        {
            try
            {
                if (models == null || models.Count == 0)
                {
                    return new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = roadBll.AddModelRoadLaneInfo(models.ToList());
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
        /// 新增线路基本信息【基础数据】
        /// </summary>
        /// <param name="model">线路基本信息</param>
        [HttpPost("addLmLineInfo")]
        public OpenApiResult<bool> AddLmLineInfo([FromBody] List<ModelRoadLineInfo> models)
        {
            try
            {
                if (models == null || models.Count == 0)
                {
                    return new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = roadBll.AddModelRoadLineInfo(models);
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
        /// 新增路面检测单信息【基础数据】
        /// </summary>
        /// <param name="model">路面检测单信息</param>
        [HttpPost("addLmCheckUnitInfo")]
        public OpenApiResult<bool> AddLmCheckUnitInfo([FromBody] List<ModelRoadCheckUnitInfo> models)
        {
            try
            {
                if (models == null || models.Count == 0)
                {
                    return new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = roadBll.AddModelRoadCheckUnitInfo(models);
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
        /// 新增监测指标数据【分析数据】
        /// </summary>
        /// <param name="model">监测指标数据</param>
        [HttpPost("addLmIRI")]
        public OpenApiResult<bool> AddLmIRI([FromBody] List<ModelRoadIRI> models)
        {
            try
            {
                if (models == null || models.Count == 0)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = roadBll.AddModelRoadIRI(models);
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
        /// 新增路面病害数据【分析数据】
        /// </summary>
        /// <param name="model">路面病害数据</param>
        [HttpPost("addLmDamage")]
        public OpenApiResult<bool> AddLmDamage([FromBody] List<ModelRoadDamage> models)
        {
            try
            {
                if (models == null || models.Count == 0)
                {
                    return new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = roadBll.AddModelRoadDamage(models);
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

        #region 创建任务

        /// <summary>
        /// 创建附属设施评估任务
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

                OpenApiResult<string> result = tjBll.CreateTask(model);
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
        /// 开启附属设施评估任务
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
                OpenApiResult<TbModelResultMain> result = tjBll.StartTask(task_no, CurrentUser.Id);
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
    }
}
