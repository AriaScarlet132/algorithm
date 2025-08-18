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
    /// 附属设施评估模型 V2
    /// </summary>
    [Route("v2/openApi/afeva")]
    public class AfevaV2Controller : BaseApiController
    {
        FacilityBll facilityBll = new FacilityBll();
        private IUserService userService;
        public AfevaV2Controller(IUserService userService)
        {
            this.userService = userService;
        }
        #region 查询
        /// <summary>
        /// 获取附属设施信息V2
        /// </summary>
        /// <param name="task_no">任务编号</param>
        [HttpGet("getModelAfInfos")]
        public OpenApiResult<ModelAfInfos> GetModelAfInfos(string task_no)
        {
            try
            {
                if (string.IsNullOrEmpty(task_no))
                {
                    return new OpenApiResult<ModelAfInfos>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<ModelAfInfos> result = facilityBll.GetModelAfInfos(task_no);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<ModelAfInfos>
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
        /// 新增附属设施清单【基础数据】 
        /// </summary>
        /// <param name="model">监测指标数据</param>
        [HttpPost("addFacilitylist")]
        public OpenApiResult<bool> AddFacilitylist([FromBody] List<ModelAfFacilitylist> models)
        {
            try
            {
                if (models == null)
                {
                  return  new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = facilityBll.AddModelAfFacilitylist(models);
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
        /// 新增附属设施权重信息2 【基础数据】 
        /// </summary>
        /// <param name="model">监测指标数据</param>
        [HttpPost("addFacilityBridgeTypeweight2")]
        public OpenApiResult<bool> addbridgetypeweight2([FromBody] List<Modelbridgetypeweight> models)
        {
            try
            {
                if (models == null)
                {
                    return new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = facilityBll.addbridgetypeweight2(models);
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
        /// 新增附属子设施检查评分明细【分析数据】
        /// </summary>
        /// <param name="model">监测指标数据</param>
        [HttpPost("addFacilityCheckValue")]
        public OpenApiResult<bool> AddFacilityCheckValue([FromBody] List<ModelAfFacilityCheckValue> models)
        {
            try
            {
                if (models == null)
                {
                    new OpenApiResult<bool>
                    {
                        Data = false,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<bool> result = facilityBll.AddModelAfFacilityCheckValue(models);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = ex.Message
                };
            }
        }

       

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

                OpenApiResult<string> result = facilityBll.CreateTask(model);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<string>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = ex.Message
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
                OpenApiResult<TbModelResultMain> result = facilityBll.StartTask(task_no, CurrentUser.Id);
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
