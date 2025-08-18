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

namespace Rcbi.Api.Controllers.OpenApiV2
{
    /// <summary>
    ///  隧道信息   V2
    /// </summary>
    [Route("v2/openApi/TunnelModelInfo")]
    public class tunnelmodelInfoController : Controller
    {
        
        OpBll opBll = new OpBll();
        BrBll brBll = new BrBll();
        private IUserService userService;
        public tunnelmodelInfoController(IUserService userService)
        {
            this.userService = userService;
        }

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

    }
}
