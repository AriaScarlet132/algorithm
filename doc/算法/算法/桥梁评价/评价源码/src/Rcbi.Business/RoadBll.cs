using Rcbi.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Rcbi.Entity.Enums;
using Rcbi.Entity.OpenApi;
using Rcbi.AspNetCore.Helper;
using System.Linq;
using Rcbi.Entity.Domain;
using System.Threading.Tasks;

namespace Rcbi.Business
{
    public class RoadBll
    {
        RoadRepository roadRepository = new RoadRepository();
        /// <summary>
        /// 道路信息
        /// </summary>
        public OpenApiResult<ModelRoadInfos> GetModelRoadInfos(string task_no)
        {
            ModelRoadInfos data = new ModelRoadInfos();

            //计算结果数据
            var modelRoadResultLane = roadRepository.GetModelRoadResultLane(task_no);
            var modelRoadResultSections = roadRepository.GetModelRoadResultSection(task_no);
            var modelRoadResultLine = roadRepository.GetModelRoadResultLine(task_no);
            var modelRoadResultAll = roadRepository.GetModelRoadResultAll(task_no);

            data.ModelRoadResultAll = modelRoadResultAll;
            data.ModelRoadLineInfos = new List<ModelRoadLineInfos>();
            foreach (var LineItem in modelRoadResultLine)
            {
                ModelRoadLineInfos LineInfo = new ModelRoadLineInfos();
                LineInfo.ModelRoadResultLine = LineItem;
                LineInfo.ModelRoadLaneInfos = new List<ModelRoadLaneInfos>();
                foreach (var LaneItem in modelRoadResultLane.Where(a => a.line_no == LineItem.line_no))
                {
                    ModelRoadLaneInfos LaneInfo = new ModelRoadLaneInfos();
                    LaneInfo.ModelRoadResultLane = LaneItem;
                    LaneInfo.ModelRoadResultSectionInfos = new ModelRoadResultSectionInfos();
                    LaneInfo.ModelRoadResultSectionInfos.ModelRoadResultSections = modelRoadResultSections.Where(a => a.lane_no == LaneItem.lane_no && a.line_no == LaneItem.line_no).ToList();
                    LineInfo.ModelRoadLaneInfos.Add(LaneInfo);
                }
                data.ModelRoadLineInfos.Add(LineInfo);
            }
            return new OpenApiResult<ModelRoadInfos>
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
                model_type = "LMEVA"
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
            var result = IispBll.StartTask(task, UserId, "LMEVA");
            return result;
        }



        /// <summary>
        /// 新增线路基本信息
        /// </summary>
        public OpenApiResult<bool> AddModelRoadLineInfo(List<ModelRoadLineInfo> models)
        {
            foreach (var model in models)
            {
                string id = roadRepository.RepeatCheckModelRoadLineInfo(model);
                if (!string.IsNullOrEmpty(id))
                {
                    roadRepository.UpdateModelRoadLineInfo(model, id);
                }
                else
                {
                    roadRepository.AddModelRoadLineInfo(model);
                }
                //roadRepository.AddModelRoadLineInfo(model);
            }

            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增车道基本信息
        /// </summary>
        public OpenApiResult<bool> AddModelRoadLaneInfo(List<ModelRoadLaneInfo> models)
        {
            foreach (var model in models)
            {
                string id = roadRepository.RepeatCheckModelRoadLaneInfo(model);
                if (!string.IsNullOrEmpty(id))
                {
                    roadRepository.UpdateModelRoadLaneInfo(model,id);
                }
                else
                {
                    roadRepository.AddModelRoadLaneInfo(model);
                }
                //roadRepository.AddModelRoadLaneInfo(model);
            }

            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        /// <summary>
        /// 新增监测指标数据
        /// </summary>
        public OpenApiResult<bool> AddModelRoadIRI(List<ModelRoadIRI> models)
        {
            foreach (var model in models)
            {
                //model.date = model.date.Value.Date;
                //string id = roadRepository.RepeatCheckModelRoadIRI(model);
                //if ( !string.IsNullOrEmpty(id))
                //{
                //    roadRepository.UpdateModelRoadIRI(model,id);
                //}
                //else
                //{
                //    roadRepository.AddModelRoadIRI(model);
                //}
                roadRepository.AddModelRoadIRI(model);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增监测指标数据
        /// </summary>
        public OpenApiResult<bool> AddModelRoadIRIForm(ModelRoadIRI model)
        {
            model.date = model.date.Value.Date;
            bool result = roadRepository.AddModelRoadIRI(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 修改监测指标数据
        /// </summary>
        public OpenApiResult<bool> UpdateModelRoadIRI(int id, string field, string value)
        {
            bool result = roadRepository.UpdateModelRoadIRI(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 批量新增监测指标数据
        /// </summary>
        public OpenApiResult<bool> InsertModelRoadIRIList(List<ModelRoadIRI> list, string task_no)
        {
            roadRepository.DeleteModelRoadIRIByTaskNo(task_no);
            roadRepository.InsertModelRoadIRIList(list);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 删除监测指标数据
        /// </summary>
        public OpenApiResult<bool> DeleteModelRoadIRI(int id)
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

            bool result = roadRepository.DeleteModelRoadIRI(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        /// <summary>
        /// 获取监测指标数据List
        /// </summary>
        public OpenApiResult<List<ModelRoadIRIQuery>> GetModelRoadIRIList(ModelRoadIRIQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code))
            {
                count = 0;
                return new OpenApiResult<List<ModelRoadIRIQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            List<ModelRoadIRIQuery> result = roadRepository.GetModelRoadIRIList(model, out count).ToList();
            if (result != null && result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].project_name = model.project_name;
                }
            }
            return new OpenApiResult<List<ModelRoadIRIQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        /// <summary>
        /// 新增路面病害数据
        /// </summary>
        public OpenApiResult<bool> AddModelRoadDamage(List<ModelRoadDamage> models)
        {
            foreach (var model in models)
            {
                //model.date = model.date.Value.Date;
                //string id = roadRepository.RepeatCheckModelRoadDamage(model);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    roadRepository.UpdateModelRoadDamage(model,id);
                //}
                //else
                //{
                //    roadRepository.AddModelRoadDamage(model);
                //}
                roadRepository.AddModelRoadDamage(model);
            }

            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增路面病害数据
        /// </summary>
        public OpenApiResult<bool> AddModelRoadDamageForm(ModelRoadDamage model)
        {
            model.date = model.date.Value.Date;
            bool result = roadRepository.AddModelRoadDamage(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 批量新增面病害数据
        /// </summary>
        public OpenApiResult<bool> InsertModelRoadDamageList(List<ModelRoadDamage> list, string task_no)
        {
            roadRepository.DeleteModelRoadDamageByTaskNo(task_no);
            roadRepository.InsertModelRoadDamageList(list);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 修改路面病害数据
        /// </summary>
        public OpenApiResult<bool> UpdateModelRoadDamage(int id, string field, string value)
        {
            bool result = roadRepository.UpdateModelRoadDamage(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 删除路面病害数据
        /// </summary>
        public OpenApiResult<bool> DeleteModelRoadDamage(int id)
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

            bool result = roadRepository.DeleteModelRoadDamage(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 获取路面病害数据List
        /// </summary>
        public OpenApiResult<List<ModelRoadDamageQuery>> GetModelRoadDamageList(ModelRoadDamageQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code))
            {
                count = 0;
                return new OpenApiResult<List<ModelRoadDamageQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            List<ModelRoadDamageQuery> result = roadRepository.GetModelRoadDamageList(model, out count).ToList();
            if (result != null && result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].project_name = model.project_name;
                }
            }
            return new OpenApiResult<List<ModelRoadDamageQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        /// <summary>
        /// 新增路面检测单信息
        /// </summary>
        public OpenApiResult<bool> AddModelRoadCheckUnitInfo(List<ModelRoadCheckUnitInfo> models)
        {
            foreach (var model in models)
            {
                //string id = roadRepository.RepeatCheckModelRoadCheckUnitInfo(model);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    roadRepository.UpdateModelRoadCheckUnitInfo(model,id);
                //}
                //else
                //{
                //    roadRepository.AddModelRoadCheckUnitInfo(model);
                //}
                roadRepository.AddModelRoadCheckUnitInfo(model);
            }

            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增路面检测单信息
        /// </summary>
        public OpenApiResult<bool> AddModelRoadCheckUnitInfoForm(ModelRoadCheckUnitInfo model)
        {
            bool result = roadRepository.AddModelRoadCheckUnitInfo(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }



        /// <summary>
        /// 批量新增路面检测单信息
        /// </summary>
        public OpenApiResult<bool> InsertModelRoadCheckUnitInfoList(List<ModelRoadCheckUnitInfo> list, string task_no)
        {
            roadRepository.DeleteModelRoadCheckUnitInfoByTaskNo(task_no);
            roadRepository.InsertModelRoadCheckUnitInfoList(list);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 修改路面检测单信息
        /// </summary>
        public OpenApiResult<bool> UpdateModelRoadCheckUnitInfo(int id, string field, string value)
        {
            bool result = roadRepository.UpdateModelRoadCheckUnitInfo(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 批量新增待评价项目的路面病害信息表v2
        /// </summary>
        public OpenApiResult<bool> InsertModelRoadDataCheckvalue(List<ModelRoadDataCheckvalue> list)
        {
            roadRepository.InsertModelRoadDataCheckvalueList(list);
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 修改待评价项目的路面病害信息表 v2
        /// </summary>
        public OpenApiResult<bool> UpdateModelRoadDataCheckvalue(ModelRoadDataCheckvalue model,int id)
        {
            bool result = roadRepository.UpdateModelRoadDataCheckvalue(model, id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 删除路面检测单信息
        /// </summary>
        public OpenApiResult<bool> DeleteModelRoadCheckUnitInfo(int id)
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

            bool result = roadRepository.DeleteModelRoadCheckUnitInfo(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 获取路面检测单List
        /// </summary>
        public OpenApiResult<List<ModelRoadCheckUnitInfoQuery>> GetModelRoadCheckUnitInfo(ModelRoadCheckUnitInfoQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code))
            {
                count = 0;
                return new OpenApiResult<List<ModelRoadCheckUnitInfoQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            List<ModelRoadCheckUnitInfoQuery> result = roadRepository.GetModelRoadCheckUnitInfoList(model, out count).ToList();
            if (result != null && result.Count > 0)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].project_name = model.project_name;
                }
            }
            return new OpenApiResult<List<ModelRoadCheckUnitInfoQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }




    }
}
