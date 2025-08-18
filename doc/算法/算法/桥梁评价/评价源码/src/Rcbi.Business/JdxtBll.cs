using Rcbi.AspNetCore.Helper;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Enums;
using Rcbi.Entity.OpenApi;
using Rcbi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rcbi.Business
{
    public class JdxtBll
    {
        JdxtRepository jdxtRepository = new JdxtRepository();

        /// <summary>
        /// 机电信息
        /// </summary>
        public OpenApiResult<ModelJdInfos> GetModelJdInfos(string task_no)
        {
            ModelJdInfos data = new ModelJdInfos();
            IList<ModelMesResultMesystem> modelMesResultMesystems = jdxtRepository.GetModelMesResultMesystem(task_no);
            if (modelMesResultMesystems == null || modelMesResultMesystems.Count <= 0)
            {
                return new OpenApiResult<ModelJdInfos>
                {
                    Data = data,
                    Status = (int)OpenApiResultStatus.SUCCESS,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
                };
            }
            data.ModelMesResultMesystems = modelMesResultMesystems[0];
            IList<ModelMesResultEquipment> modelMesResultEquipments = jdxtRepository.GetModelMesResultEquipment(task_no);
            IList<ModelMesResultMidsystem> modelMesResultMidsystems = jdxtRepository.GetModelMesResultMidsystem(task_no);
            IList<ModelMesResultSubsystem> modelMesResultSubsystems = jdxtRepository.GetModelMesResultSubsystem(task_no);
            data.ModelMesResultEquipments = modelMesResultEquipments != null ? modelMesResultEquipments.ToList() : null;
            data.ModelMesResultMidsystems = modelMesResultMidsystems != null ? modelMesResultMidsystems.ToList() : null;
            data.ModelMesResultSubsystems = modelMesResultSubsystems != null ? modelMesResultSubsystems.ToList() : null;
            return new OpenApiResult<ModelJdInfos>
            {
                Data = data,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <returns></returns>
        public OpenApiResult<string> CreateTask(ModelResultMainRequest model)
        {
            DateTime dtNow = DateTime.Now;
            TbModelResultMain table = new TbModelResultMain
            {
                datasource_enddate = model.datasource_enddate,
                datasource_startdate = model.datasource_startdate,
                projectid = model.Project_Code,
                facility_type = model.facility_type,
                callback_url = model.callback_url,
                model_type = "JDEVA"
            };
            table.taskno = table.projectid + "-" + dtNow.ToString("yyyyMMddHHmmss");
            table.is_delete = 0;
            table.is_submit = "1";

            string ret = IispBll.CreateTask(table);
            if (!string.IsNullOrEmpty(ret))
            {
                return new OpenApiResult<string>
                {
                    Data = table.taskno,
                    Status = (int)OpenApiResultStatus.SUCCESS,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
                };
            }
            else
            {
                return new OpenApiResult<string>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.FAIL,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.FAIL)
                };
            }
        }

        /// <summary>
        /// 开始任务
        /// </summary>
        /// <returns></returns>
        public OpenApiResult<TbModelResultMain> StartTask(string task, int? UserId)
        {
            var result = IispBll.StartTask(task, UserId, "JDEVA");
            return result;
        }

        /// <summary>
        /// 新增tb_model_mes_devicetype_imp
        /// </summary>
        public OpenApiResult<bool> AddModelMesDevicetypeImp(List<ModelMesDevicetypeImp> models)
        {
            foreach (var item in models)
            {
                string id = jdxtRepository.RepeatCheckModelMesDevicetypeImp(item);
                if (!string.IsNullOrEmpty(id))
                {
                    jdxtRepository.UpdateModelMesDevicetypeImp(item, id);
                }
                else
                {
                    jdxtRepository.AddModelMesDevicetypeImp(item);
                }
                //jdxtRepository.AddModelMesDevicetypeImp(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_mes_parameter_mesystem 机电总分系数信息表 v2
        /// </summary>
        public OpenApiResult<bool> AddModelMesParameterMesystem(List<ModelMesParameterMesystem> models)
        {
            foreach (var item in models)
            {
                //string id = jdxtRepository.RepeatCheckModelMesParameterMesystem(item);
                 if (!string.IsNullOrEmpty(item.id))
                //if (item.id>0 || item.id!=null)
                {
                    int id =Convert.ToInt32(item.id);
                    jdxtRepository.UpdateModelMesParameterMesystem(item, id);
                }
                else
                {
                    jdxtRepository.AddModelMesParameterMesystem(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        /// <summary>
        /// 新增tb_model_mes_parameter_mesystem 机电总分系数信息表 v2
        /// </summary>
        public OpenApiResult<bool> AddModelMesCriteria(List<ModelMesCriteria> models)
        {
            foreach (var item in models)
            {
                //string id = jdxtRepository.RepeatCheckModelMesCriteria(item);
                if (!string.IsNullOrEmpty(item.id))
                {
                    int id = Convert.ToInt32(item.id);
                    jdxtRepository.UpdateModelMesCriteria(item, id);
                }
                else
                {
                    jdxtRepository.AddModelMesCriteria(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        /// <summary>
        /// 新增tb_model_mes_equipmentlist
        /// </summary>
        public OpenApiResult<bool> AddModelMesEquipmentlist(List<ModelMesEquipmentlist> models)
        {
            foreach (var item in models)
            {
                string id = jdxtRepository.RepeatCheckModelMesEquipmentlist(item);
                if (!string.IsNullOrEmpty(id))
                {
                    jdxtRepository.UpdateModelMesEquipmentlist(item, id);
                }
                else
                {
                    jdxtRepository.AddModelMesEquipmentlist(item);
                }
                //jdxtRepository.AddModelMesEquipmentlist(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        /// <summary>
        /// 新增tb_model_mes_equipmentlistsummary
        /// </summary>
        public OpenApiResult<bool> AddModelMesEquipmentlistsummary(List<ModelMesEquipmentlistsummary> models)
        {
            foreach (var item in models)
            {
                string id = jdxtRepository.RepeatCheckModelMesEquipmentlistsummary(item);
                if (!string.IsNullOrEmpty(id))
                {
                    jdxtRepository.UpdateModelMesEquipmentlistsummary(item, id);
                }
                else
                {
                    jdxtRepository.AddModelMesEquipmentlistsummary(item);
                }
                //jdxtRepository.AddModelMesEquipmentlistsummary(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_mes_data_operation
        /// </summary>
        public OpenApiResult<bool> AddModelMesDataOperation(List<ModelMesDataOperation> models)
        {
            foreach (var item in models)
            {
                //string id = jdxtRepository.RepeatCheckModelMesDataOperation(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    jdxtRepository.UpdateModelMesDataOperation(item, id);
                //}
                //else
                //{
                //    jdxtRepository.AddModelMesDataOperation(item);
                //}
                jdxtRepository.AddModelMesDataOperation(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_mes_data_failure
        /// </summary>
        public OpenApiResult<bool> AddModelMesDataFailure(List<ModelMesDataFailure> models)
        {
            foreach (var item in models)
            {
                //string id = jdxtRepository.RepeatCheckModelMesDataFailure(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    jdxtRepository.UpdateModelMesDataFailure(item, id);
                //}
                //else
                //{
                //    jdxtRepository.AddModelMesDataFailure(item);
                //}
                jdxtRepository.AddModelMesDataFailure(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        #region 2020年12月1日

        public OpenApiResult<List<ModelMesDataOperationList>> GetModelJdevaList(ModelMesDataOperationQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code))
            {
                count = 0;
                return new OpenApiResult<List<ModelMesDataOperationList>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            List<ModelMesDataOperationList> result = jdxtRepository.GetModelJdevaList(model, out count).ToList();
            //if (result != null && result.Count > 0)
            //{
            //    for (int i = 0; i < result.Count; i++)
            //    {
            //        result[i].project_name = model.project_name;
            //    }
            //}
            return new OpenApiResult<List<ModelMesDataOperationList>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelMesDataOperationForm(ModelMesDataOperationList model)
        {
            model.BeginningOperation = model.BeginningOperation.Value.Date;
            model.EndingOperation = model.EndingOperation.Value.Date;
            model.Datapushdate = model.Datapushdate.Value;

            bool result = jdxtRepository.AddModelMesDataOperationForm(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> DeleteModelMesDataOperation(int id)
        {
            if (id == 0)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            bool result = jdxtRepository.DeleteModelMesDataOperation(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> InsertModelMesDataOperationList(List<ModelMesDataOperationList> list, string task_no)
        {
            jdxtRepository.DeleteModelMesDataOperationByTaskNo(task_no);
            jdxtRepository.InsertModelMesDataOperationList(list);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #region 新步骤2020年12月2日 MesDataFailure

        public OpenApiResult<List<ModelMesDataFailureList>> GetModelMesDataFailureList(ModelMesDataFailureQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code))
            {
                count = 0;
                return new OpenApiResult<List<ModelMesDataFailureList>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            List<ModelMesDataFailureList> result = jdxtRepository.GetModelMesDataFailureList(model, out count).ToList();
            return new OpenApiResult<List<ModelMesDataFailureList>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelMesDataFailureForm(ModelMesDataFailureList model)
        {
            model.BeginningFailure = model.BeginningFailure.Value.Date;
            model.EndingFailure = model.EndingFailure.Value.Date;
            model.Datapushdate = model.Datapushdate.Value;

            bool result = jdxtRepository.AddModelMesDataFailureForm(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> DeleteModelMesDataFailure(int id)
        {
            if (id == 0)
            {
                return new OpenApiResult<bool>
                {
                    Data = false,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            bool result = jdxtRepository.DeleteModelMesDataFailure(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> InsertModelMesDataFailureList(List<ModelMesDataFailureList> list, string task_no)
        {
            jdxtRepository.DeleteModelMesDataFailureByTaskNo(task_no);
            jdxtRepository.InsertModelMesDataFailureList(list);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        public List<ModelMesEquipmentlist> GetModelMesEquipmentListByProjectCode(string projectCode)
        {
            if (string.IsNullOrEmpty(projectCode))
            {
                return new List<ModelMesEquipmentlist>();
            }

            return jdxtRepository.GetModelMesEquipmentListByProjectCode(projectCode).ToList();
        }
        #endregion

        /// <summary>
        /// 新增tb_model_mes_criteria_mesystem
        /// </summary>
        public OpenApiResult<bool> addMesCriteriaMesystem(List<ModelMesCriteriaMesystem> models)
        {
            foreach (var item in models)
            {
                //string id = jdxtRepository.RepeatCheckMesCriteriaMesystem(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    jdxtRepository.UpdateMesCriteriaMesystem(item, id);
                //}
                //else
                //{
                //    jdxtRepository.AddMesCriteriaMesystem(item);
                //}
                jdxtRepository.AddMesCriteriaMesystem(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_mes_criteria_midsystem
        /// </summary>
        public OpenApiResult<bool> addMesCriteriaMidsystem(List<ModelMesCriteriaMidsystem> models)
        {
            foreach (var item in models)
            {
                //string id = jdxtRepository.RepeatCheckMesCriteriaMesystem(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    jdxtRepository.UpdateMesCriteriaMesystem(item, id);
                //}
                //else
                //{
                //    jdxtRepository.AddMesCriteriaMesystem(item);
                //}
                jdxtRepository.addMesCriteriaMidsystem(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_mes_systemtype_weights
        /// </summary>
        public OpenApiResult<bool> addMesSystemtypeWeights(List<ModelMesSystemtypeWeights> models)
        {
            foreach (var item in models)
            {
                //string id = jdxtRepository.RepeatCheckMesCriteriaMesystem(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    jdxtRepository.UpdateMesCriteriaMesystem(item, id);
                //}
                //else
                //{
                //    jdxtRepository.AddMesCriteriaMesystem(item);
                //}
                jdxtRepository.addMesSystemtypeWeights(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
    }
}