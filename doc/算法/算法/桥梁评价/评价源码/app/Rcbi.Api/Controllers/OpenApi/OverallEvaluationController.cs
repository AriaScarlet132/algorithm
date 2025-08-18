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
    ///  总体评价接口   V2
    /// </summary>
    [Route("v2/openApi/OverallEvaluation")]
    public class OverallEvaluationV2Controller : BaseApiController
    {
        OpBll opBll = new OpBll();
        BrBll brBll = new BrBll();
        private IUserService userService;
        public OverallEvaluationV2Controller(IUserService userService)
        {
            this.userService = userService;
        }
        #region 开启添加总体评价任务

        /// <summary>
        /// 添加总体评价任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("addOverallEvaluationTask")]
        public OpenApiResult<string> addOverallEvaluationTask([FromBody] OverallEvaluation model)
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

                //OpenApiResult<string> result = opBll.CreateTask_TJ(model);
                //向数据添加数据，
                OpenApiResult<string> result = brBll.CreateOverallEvaluationTask(model);
                //并向消息列队里插入数据
                CreateIispTask.SendOverallEvaluationTask(model, result.Data);
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
        /// 获取总体评价结果
        /// </summary>
        /// <param name="task_no"></param>
        /// <returns></returns>

        [HttpGet("getOverallEvaluationResult")]
        public OpenApiResult<List<tb_model_overall_eval2>> getOverallEvaluationResult(string task_no)
        {
            try
            {
                if (string.IsNullOrEmpty(task_no))
                {
                    return new OpenApiResult<List<tb_model_overall_eval2>>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                OpenApiResult<List<tb_model_overall_eval2>> result = brBll.getOverallEvaluationResult(task_no);
                return result;
            }
            catch (Exception ex)
            {
                return new OpenApiResult<List<tb_model_overall_eval2>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.SYSTEM_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SYSTEM_ERROR)
                };
            }
        }
        #endregion
    }
}
