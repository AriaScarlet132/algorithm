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
    /// 机电系统评估模型  V2
    /// </summary>
    [Route("v2/openApi/jdeva")]
    public class JdevaV2Controller : BaseApiController
    {
        JdxtBll jdxtBll = new JdxtBll();
        private IUserService userService;
        public JdevaV2Controller(IUserService userService)
        {
            this.userService = userService;
        }

        #region 查询
        /// <summary>
        /// 获取机电系统信息
        /// </summary>
        /// <param name="task_no">任务编号</param>
        [HttpGet("getModelJdInfos")]
        public OpenApiResult<ModelJdInfos> GetModelJdInfos(string task_no)
        {
            try
            {
                if (string.IsNullOrEmpty(task_no))
                {
                    return new OpenApiResult<ModelJdInfos>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<ModelJdInfos> result = jdxtBll.GetModelJdInfos(task_no);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<ModelJdInfos>
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
        ///  新增机电系统设备编码与重要度信息【基础数据】
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("addMesDevicetypeImp")]
        public OpenApiResult<bool> AddMesDevicetypeImp([FromBody] List<ModelMesDevicetypeImp> models)
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
                OpenApiResult<bool> result = jdxtBll.AddModelMesDevicetypeImp(models);
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
        ///  新增机电总分系数信息表【基础数据】V2
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("addMesParameterMesystem")]
        public OpenApiResult<bool> AddMesParameterMesystem([FromBody] List<ModelMesParameterMesystem> models)
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
                OpenApiResult<bool> result = jdxtBll.AddModelMesParameterMesystem(models);
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
        ///  新增评价等级与分值对应关系表【基础数据】V2
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("addMesCriteria")]
        public OpenApiResult<bool> AddMesCriteria([FromBody] List<ModelMesCriteria> models)
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
                OpenApiResult<bool> result = jdxtBll.AddModelMesCriteria(models);
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
        ///  新增机电系统设备清单信息【基础数据】
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("addMesEquipmentlist")]
        public OpenApiResult<bool> AddMesEquipmentlist([FromBody] List<ModelMesEquipmentlist> models)
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
                OpenApiResult<bool> result = jdxtBll.AddModelMesEquipmentlist(models);
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
        ///  新增机电系统设备数量统计信息【基础数据】
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        //[HttpPost("addMesEquipmentlistsummary")]
        //public OpenApiResult<bool> AddMesEquipmentlistsummary([FromBody] List<ModelMesEquipmentlistsummary> models)
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
        //        OpenApiResult<bool> result = jdxtBll.AddModelMesEquipmentlistsummary(models);
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
        ///  机电系统权重信息【基础数据】
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("addMesCriteriaMesystem")]
        public OpenApiResult<bool> addMesCriteriaMesystem([FromBody] List<ModelMesCriteriaMesystem> models)
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
                OpenApiResult<bool> result = jdxtBll.addMesCriteriaMesystem(models);
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
        ///  机电系统分系统权重信息【基础数据】
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("addMesCriteriaMidsystem")]
        public OpenApiResult<bool> addMesCriteriaMidsystem([FromBody] List<ModelMesCriteriaMidsystem> models)
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
                OpenApiResult<bool> result = jdxtBll.addMesCriteriaMidsystem(models);
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
        ///  机电系统评价指标权重信息【基础数据】
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("addMesSystemtypeWeights")]
        public OpenApiResult<bool> addMesSystemtypeWeights([FromBody] List<ModelMesSystemtypeWeights> models)
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
                OpenApiResult<bool> result = jdxtBll.addMesSystemtypeWeights(models);
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
        /// 新增待评价项目的机电系统设备运行情况信息【分析数据】
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        //[HttpPost("addMesDataOperation")]
        //public OpenApiResult<bool> AddMesDataOperation([FromBody] List<ModelMesDataOperation> models)
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
        //        OpenApiResult<bool> result = jdxtBll.AddModelMesDataOperation(models);
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
        /// 新增待评价项目的机电系统设备故障情况信息【分析数据】
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost("addMesDataFailure")]
        public OpenApiResult<bool> AddMesDataFailure([FromBody] List<ModelMesDataFailure> models)
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
                OpenApiResult<bool> result = jdxtBll.AddModelMesDataFailure(models);
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

                OpenApiResult<string> result = jdxtBll.CreateTask(model);
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
                OpenApiResult<TbModelResultMain> result = jdxtBll.StartTask(task_no, CurrentUser.Id);
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
