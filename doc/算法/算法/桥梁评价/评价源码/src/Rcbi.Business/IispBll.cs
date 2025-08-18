using Rcbi.AspNetCore.Helper;
using Rcbi.Core;
using Rcbi.Core.Extensions;
using Rcbi.Entity;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Enums;
using Rcbi.Entity.OpenApi;
using Rcbi.Entity.Query;
using Rcbi.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Rcbi.Business
{
    public class IispBll
    {
        /// <summary>
        /// 获取用户，分页
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IPagedList<TbModelResultMain> GetPagedList(CommonQuery query,IList<Project> projects)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            if (projects == null || projects.Count <= 0)
            {
                return new PagedList<TbModelResultMain>(
                    new List<TbModelResultMain>(),
                    query.PageIndex,
                    query.PageSize,
                    0);
            }
            using (IispRepository db = new IispRepository())
            {
                int total;
                var dt = db.GetList(query, projects, out total);
                return new PagedList<TbModelResultMain>(
                    dt.ToList<TbModelResultMain>(),
                    query.PageIndex,
                    query.PageSize,
                    total);
            }
        }

        public static bool DeleteById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            using (IispRepository db = new IispRepository())
            {
                bool result = db.DeleteById(id);
                return result;
            }
        }

        public static TbModelResultMain GetDetailById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            using (IispRepository db = new IispRepository())
            {
                var dt = db.GetDetailById(id);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0].ToEntity<TbModelResultMain>();
                }
                else
                {
                    return new TbModelResultMain();
                }
            }
        }

        public static IList<ModelType> GetFacilityTypeByModel(string model_type)
        {
            if (string.IsNullOrEmpty(model_type))
            {
                throw new ArgumentNullException("model_type");
            }
            IList<ModelType> result = new List<ModelType>();
            using (ModelTypeRepository db = new ModelTypeRepository())
            {
                result = db.GetFacility(model_type);
            }
            return result;
        }

        public static string CreateTask(TbModelResultMain model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            using (IispRepository db = new IispRepository())
            {
                string result = db.InsertModel(model);
                return result;
            }
        }

        /// <summary>
        /// 开始任务
        /// </summary>
        /// <returns></returns>
        public static OpenApiResult<TbModelResultMain> StartTask(string task_no, int? UserId, string model_type)
        {
            using (IispRepository db = new IispRepository())
            {
                TbModelResultMain modelResultMain = db.GetModelResultMain(task_no);
                //参数验证
                bool isvisible = ParamsCheck(modelResultMain, UserId, model_type);
                if (!isvisible)
                {
                    return new OpenApiResult<TbModelResultMain>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                    };
                }
                //状态验证
                if (modelResultMain.modelstatus.ToLower() != "preparing")
                {
                    return new OpenApiResult<TbModelResultMain>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.MODEL_STATUS_ERROR,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.MODEL_STATUS_ERROR)
                    };
                }
                bool result = UpdateTaskStatus(modelResultMain.id.ToString());
                if (!result)
                {
                    return new OpenApiResult<TbModelResultMain>
                    {
                        Data = null,
                        Status = (int)OpenApiResultStatus.FAIL,
                        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.FAIL)
                    };
                }
                return new OpenApiResult<TbModelResultMain>
                {
                    Data = modelResultMain,
                    Status = (int)OpenApiResultStatus.SUCCESS,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
                };
            }
        }

        /// <summary>
        /// 参数验证
        /// </summary>
        public static bool ParamsCheck(TbModelResultMain modelResultMain, int? UserId, string model_type)
        {
            if (modelResultMain == null)
                return false;
            IList<Project> projects = ProjectBll.GetProjects(UserId);
            if (projects.Where(a => a.ProjectCode == modelResultMain.projectid).ToList().Count <= 0)
            {
                return false;
            }
            IList<ModelType> facilitys = IispBll.GetFacilityTypeByModel(model_type);
            if (facilitys.Where(a => a.facility_type == modelResultMain.facility_type).ToList().Count <= 0)
            {
                return false;
            }
            if (modelResultMain.datasource_startdate == null)
            {
                return false;
            }
            if (modelResultMain.datasource_enddate == null)
            {
                return false;
            }
            return true;
        }

        public static bool UpdateTask(TbModelResultMain model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            using (IispRepository db = new IispRepository())
            {
                bool result = db.UpdateTask(model);
                return result;
            }
        }

        public static bool UpdateTaskStatus(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            using (IispRepository db = new IispRepository())
            {
                bool result = db.UpdateTaskStatus(id);
                return result;
            }
        }

        /// <summary>
        /// 获取任务编号
        /// </summary>
        /// <returns></returns>
        public static string GetTaskNo(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            using (IispRepository db = new IispRepository())
            {
                string result = db.GetTaskNo(id);
                return result;
            }
        }
    }
}
