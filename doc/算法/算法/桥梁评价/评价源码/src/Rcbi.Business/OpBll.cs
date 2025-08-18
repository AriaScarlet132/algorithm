using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Rcbi.AspNetCore.Helper;
using Rcbi.Entity.Domain;
using Rcbi.Entity.Enums;
using Rcbi.Entity.OpenApi;
using Rcbi.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rcbi.Business
{
    public class OpBll
    {
        OpRepository opRepository = new OpRepository();

        /// <summary>
        /// 运营服务信息
        /// </summary>
        public OpenApiResult<ModelOpInfos> GetModelOpInfos(string task_no)
        {
            ModelOpInfos data = new ModelOpInfos();
            data.ModelOpResultAll = opRepository.GetModelOpResultAll(task_no);
            data.ModelOpResultClassification = opRepository.GetModelOpResultClassification(task_no);
            data.ModelOpResultCsi = opRepository.GetModelOpResultCsi(task_no);
            data.ModelOpResultMsi = opRepository.GetModelOpResultMsi(task_no);
            data.ModelOpResultTsi = opRepository.GetModelOpResultTsi(task_no);
            data.ModelOpResultSsi = opRepository.GetModelOpResultSsi(task_no);
            data.ModelOpResultIndexevaluation = opRepository.GetModelOpResultIndexevaluation(task_no);
            data.ModelOpResultMidevaluation = opRepository.ModelOpResultMidevaluation(task_no);
            return new OpenApiResult<ModelOpInfos>
            {
                Data = data,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 开始任务
        /// </summary>
        /// <returns></returns>
        public OpenApiResult<TbModelResultMain> StartTask(string task, int? UserId)
        {
            var result = IispBll.StartTask(task, UserId, "OSEVA");
            return result;
        }
        public OpenApiResult<TbModelResultMain> StartTask_tj(string task, int? UserId)
        {
            var result = IispBll.StartTask(task, UserId, "TJEVA");
            return result;
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
                model_type = "OSEVA"
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
        /// 创建任务 土建，桥梁
        /// </summary>
        /// <returns></returns>
        public OpenApiResult<string> CreateTask_TJ(ModelResultMainRequest model)
        {
            DateTime dtNow = DateTime.Now;
            TbModelResultMain table = new TbModelResultMain
            {
                datasource_enddate = model.datasource_enddate,
                datasource_startdate = model.datasource_startdate,
                projectid = model.Project_Code,
                facility_type = model.facility_type,
                callback_url = model.callback_url,
                model_type = "TJEVA"
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
        /// 新增用户服务指标评价等级
        /// </summary>
        public OpenApiResult<bool> AddModelOpCsiCriteria(List<ModelOpCsiCriteria> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpCsiCriteria(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpCsiCriteria(item, id);
                }
                else
                {
                    opRepository.AddModelOpCsiCriteria(item);
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
        /// 新增内业管理服务指标评价等级
        /// </summary>
        public OpenApiResult<bool> AddModelOpMsiCriteria(List<ModelOpMsiCriteria> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpMsiCriteria(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpMsiCriteria(item, id);
                }
                else
                {
                    opRepository.AddModelOpMsiCriteria(item);
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
        /// 新增FWCI指数评价等级
        /// </summary>
        public OpenApiResult<bool> AddModelOpFwciCriteria(List<ModelOpFwciCriteria> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpFwciCriteria(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpFwciCriteria(item, id);
                }
                else
                {
                    opRepository.AddModelOpFwciCriteria(item);
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
        /// 新增安全服务指标评价等级
        /// </summary>
        public OpenApiResult<bool> AddModelOpSsiCriteria(List<ModelOpSsiCriteria> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpSsiCriteria(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpSsiCriteria(item, id);
                }
                else
                {
                    opRepository.AddModelOpSsiCriteria(item);
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
        /// 新增交通服务指标评价等级
        /// </summary>
        public OpenApiResult<bool> AddModelOpTsiCriteria(List<ModelOpTsiCriteria> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpTsiCriteria(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpTsiCriteria(item, id);
                }
                else
                {
                    opRepository.AddModelOpTsiCriteria(item);
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
        /// 新增CO一氧化碳指数业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpCodata(List<ModelOpCodata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpCodata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpCodata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpCodata(item);
                //}
                opRepository.AddModelOpCodata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增交牵引排堵TEI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpTeidata(List<ModelOpTeidata> models)
        {
            foreach (var item in models)
            {
                //item.MonitorDate = item.MonitorDate.Date;
                //string id = opRepository.RepeatCheckModelOpTeidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpTeidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpTeidata(item);
                //}
                opRepository.AddModelOpTeidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增交通流量DTI线路业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDtidata(List<ModelOpDtidata> models)
        {
            foreach (var item in models)
            {
                //item.MonitorDate = item.MonitorDate.Date;
                //string id = opRepository.RepeatCheckModelOpDtidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpDtidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpDtidata(item);
                //}
                opRepository.AddModelOpDtidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增交通畅通率DFR业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDfrdata(List<ModelOpDfrdata> models)
        {
            foreach (var item in models)
            {
                //item.MonitorDate = item.MonitorDate.Date;
                //string id = opRepository.RepeatCheckModelOpDfrdata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpDfrdata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpDfrdata(item);
                //}
                opRepository.AddModelOpDfrdata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增交通路面荷载LR业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpLrdata(List<ModelOpLrdata> models)
        {
            foreach (var item in models)
            {
                //item.MonitorDate = item.MonitorDate.Date;
                //string id = opRepository.RepeatCheckModelOpLrdata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpLrdata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpLrdata(item);
                //}
                opRepository.AddModelOpLrdata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增亮度或照度BI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpBidata(List<ModelOpBidata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpBidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpBidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpBidata(item);
                //}
                opRepository.AddModelOpBidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增内业成本绩效MCI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpMcidata(List<ModelOpMcidata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpMcidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpMcidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpMcidata(item);
                //}
                opRepository.AddModelOpMcidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增内业报编制MBI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpMbidata(List<ModelOpMbidata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpMbidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpMbidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpMbidata(item);
                //}
                opRepository.AddModelOpMbidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增内业档案资料信息化MII业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpMiidata(List<ModelOpMiidata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpMiidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpMiidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpMiidata(item);
                //}
                opRepository.AddModelOpMiidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增内业管理制度MSSI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpMssidata(List<ModelOpMssidata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpMssidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpMssidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpMssidata(item);
                //}
                opRepository.AddModelOpMssidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增可吸入颗粒物浓度PM2.5业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpPmdata(List<ModelOpPmdata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpPmdata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpPmdata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpPmdata(item);
                //}
                opRepository.AddModelOpPmdata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增噪音DI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDidata(List<ModelOpDidata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpDidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpDidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpDidata(item);
                //}
                opRepository.AddModelOpDidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增安全事故率RV业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpRvdata(List<ModelOpRvdata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpRvdata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpRvdata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpRvdata(item);
                //}
                opRepository.AddModelOpRvdata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增用户满意度UCVI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpUcvidata(List<ModelOpUcvidata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpUcvidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpUcvidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpUcvidata(item);
                //}
                opRepository.AddModelOpUcvidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增用户舒适度UCI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpUcidata(List<ModelOpUcidata> models)
        {
            foreach (var item in models)
            {
                //item.InvestDate = item.InvestDate.Date;
                //string id = opRepository.RepeatCheckModelOpUcidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpUcidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpUcidata(item);
                //}
                opRepository.AddModelOpUcidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增能见度VI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpVidata(List<ModelOpVidata> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpVidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpVidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpVidata(item);
                //}
                opRepository.AddModelOpVidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增行驶速率DSI业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDsidata(List<ModelOpDsidata> models)
        {
            foreach (var item in models)
            {
                //item.MonitorDate = item.MonitorDate.Date;
                //string id = opRepository.RepeatCheckModelOpDsidata(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    opRepository.UpdateModelOpDsidata(item, id);
                //}
                //else
                //{
                //    opRepository.AddModelOpDsidata(item);
                //}
                opRepository.AddModelOpDsidata(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增隧道交通流量业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpTunneltrafficinfo(List<ModelOpTunneltrafficinfo> models)
        {
            foreach (var item in models)
            {
                item.BuildStartDate = item.BuildStartDate.Date;
                item.BuildEndDate = item.BuildEndDate.Date;
                item.CommitDate = item.CommitDate.Date;
                item.OpstartDate = item.OpstartDate.Date;
                item.BigMaintainStartDate = item.BigMaintainStartDate.Date;
                item.BigMaintainEndDate = item.BigMaintainEndDate.Date;
                item.NewContractStartDate = item.NewContractStartDate.Date;
                item.NewContractEndDate = item.NewContractStartDate.Date;
                string id = opRepository.RepeatCheckModelOpTunneltrafficinfo(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpTunneltrafficinfo(item, id);
                }
                else
                {
                    opRepository.AddModelOpTunneltrafficinfo(item);
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
        /// 新增隧道基础业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpTunnelbasicinfo(List<ModelOpTunnelbasicinfo> models)
        {
            foreach (var item in models)
            {
                //item.BuildStartDate = item.BuildStartDate.Date;
                //item.BuildEndDate = item.BuildEndDate.Date;
                //item.CommitDate = item.CommitDate.Date;
                //item.OpstartDate = item.OpstartDate.Date;
                //item.BigMaintainStartDate = item.BigMaintainStartDate.Date;
                //item.BigMaintainEndDate = item.BigMaintainEndDate.Date;
                string id = opRepository.RepeatCheckModelOpTunnelbasicinfo(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpTunnelbasicinfo(item, id);
                }
                else
                {
                    opRepository.AddModelOpTunnelbasicinfo(item);
                }
                //opRepository.AddModelOpTunnelbasicinfo(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增隧道线路基本业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpLineinfo(List<ModelOpLineinfo> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpLineinfo(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpLineinfo(item, id);
                }
                else
                {
                    opRepository.AddModelOpLineinfo(item);
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
        /// 新增车道线路基本业务信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpLaneinfo(List<ModelOpLaneinfo> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpLaneinfo(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpLaneinfo(item, id);
                }
                else
                {
                    opRepository.AddModelOpLaneinfo(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #region CO一氧化碳指数业务信息Web
        public OpenApiResult<List<ModelOpCodataQuery>> GetModelOpCodataList(ModelOpCodataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpCodataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpCodataQuery> result = opRepository.GetModelOpCodataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpCodataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpCodata(int id)
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
            bool result = opRepository.DeleteModelOpCodata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpCodata(ModelOpCodataQuery model)
        {
            bool result = opRepository.AddModelOpCodata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpCodataList(List<ModelOpCodataQuery> list)
        {
            opRepository.DeleteModelOpCodata(list[0].task_no);
            bool result = opRepository.AddModelOpCodataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpCodata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpCodata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpCodataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpCodataQuery> list = new List<ModelOpCodataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpCodataQuery model = ModelOpCodataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpCodataList(list);
                }
            }
            return result;
        }

        public ModelOpCodataQuery ModelOpCodataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpCodataQuery result = null;
            try
            {
                result = new ModelOpCodataQuery
                {
                    LineCode = cell[0].ToString(),
                    Position = cell[1].ToString(),
                    Mileage = cell[2].ToString(),
                    DeviceNo = cell[3].ToString(),
                    MonitorYear = cell[4].ToString(),
                    MonitorMonth = cell[5].ToString(),
                    MonitorData = Convert.ToDecimal(cell[6].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 交牵引排堵TEI业务信息Web
        public OpenApiResult<List<ModelOpTeidataQuery>> GetModelOpTeidataList(ModelOpTeidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpTeidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpTeidataQuery> result = opRepository.GetModelOpTeidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpTeidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpTeidata(int id)
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
            bool result = opRepository.DeleteModelOpTeidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpTeidata(ModelOpTeidataQuery model)
        {
            bool result = opRepository.AddModelOpTeidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpTeidataList(List<ModelOpTeidataQuery> list)
        {
            opRepository.DeleteModelOpTeidata(list[0].task_no);
            bool result = opRepository.AddModelOpTeidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpTeidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpTeidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpTeidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpTeidataQuery> list = new List<ModelOpTeidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpTeidataQuery model = ModelOpTeidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpTeidataList(list);
                }
            }
            return result;
        }

        public ModelOpTeidataQuery ModelOpTeidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpTeidataQuery result = null;
            try
            {
                result = new ModelOpTeidataQuery
                {
                    LineCode = cell[0].ToString(),
                    MonitorDate = Convert.ToDateTime(cell[1].ToString()),
                    M1amount = Convert.ToInt32(cell[2].ToString()),
                    M2amount = Convert.ToInt32(cell[3].ToString()),
                    Totalinday = Convert.ToInt32(cell[4].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 交通流量DTI线路业务信息Web
        public OpenApiResult<List<ModelOpDtidataQuery>> GetModelOpDtidataList(ModelOpDtidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpDtidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpDtidataQuery> result = opRepository.GetModelOpDtidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpDtidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpDtidata(int id)
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
            bool result = opRepository.DeleteModelOpDtidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpDtidata(ModelOpDtidataQuery model)
        {
            bool result = opRepository.AddModelOpDtidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpDtidataList(List<ModelOpDtidataQuery> list)
        {
            opRepository.DeleteModelOpDtidata(list[0].task_no);
            bool result = opRepository.AddModelOpDtidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpDtidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpDtidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpDtidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpDtidataQuery> list = new List<ModelOpDtidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpDtidataQuery model = ModelOpDtidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpDtidataList(list);
                }
            }
            return result;
        }

        public ModelOpDtidataQuery ModelOpDtidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpDtidataQuery result = null;
            try
            {
                result = new ModelOpDtidataQuery
                {
                    LineCode = cell[0].ToString(),
                    MonitorDate = Convert.ToDateTime(cell[1].ToString()),
                    TunneltrafficTotal = Convert.ToInt32(cell[2].ToString()),
                    TunneltrafficMax = Convert.ToInt32(cell[3].ToString()),
                    Tunneltraffic57 = Convert.ToInt32(cell[4].ToString()),
                    Tunneltraffic1719 = Convert.ToInt32(cell[5].ToString()),
                    Lane1 = cell[6].ToString(),
                    Lane1Trafficnum = Convert.ToInt32(cell[7].ToString()),
                    Lane1Traffic57 = Convert.ToInt32(cell[8].ToString()),
                    Lane1Traffic1719 = Convert.ToInt32(cell[9].ToString()),
                    Lane2 = cell[10].ToString(),
                    Lane2Trafficnum = Convert.ToInt32(cell[11].ToString()),
                    Lane2Traffic57 = Convert.ToInt32(cell[12].ToString()),
                    Lane2Traffic1719 = Convert.ToInt32(cell[13].ToString()),
                    Lane3 = cell[14].ToString(),
                    Lane3Trafficnum = Convert.ToInt32(cell[15].ToString()),
                    Lane3Traffic57 = Convert.ToInt32(cell[16].ToString()),
                    Lane3Traffic1719 = Convert.ToInt32(cell[17].ToString()),
                    Lane4 = cell[18].ToString(),
                    Lane4Trafficnum = Convert.ToInt32(cell[19].ToString()),
                    Lane4Traffic57 = Convert.ToInt32(cell[20].ToString()),
                    Lane4Traffic1719 = Convert.ToInt32(cell[21].ToString()),
                    Lane5 = cell[22].ToString(),
                    Lane5Trafficnum = Convert.ToInt32(cell[23].ToString()),
                    Lane5Traffic57 = Convert.ToInt32(cell[24].ToString()),
                    Lane5Traffic1719 = Convert.ToInt32(cell[25].ToString()),
                    Lane6 = cell[26].ToString(),
                    Lane61Trafficnum = Convert.ToInt32(cell[27].ToString()),
                    Lane6Traffic57 = Convert.ToInt32(cell[28].ToString()),
                    Lane6Traffic1719 = Convert.ToInt32(cell[29].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 交通畅通率DFR业务信息Web
        public OpenApiResult<List<ModelOpDfrdataQuery>> GetModelOpDfrdataList(ModelOpDfrdataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpDfrdataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpDfrdataQuery> result = opRepository.GetModelOpDfrdataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpDfrdataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpDfrdata(int id)
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
            bool result = opRepository.DeleteModelOpDfrdata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpDfrdata(ModelOpDfrdataQuery model)
        {
            bool result = opRepository.AddModelOpDfrdata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpDfrdataList(List<ModelOpDfrdataQuery> list)
        {
            opRepository.DeleteModelOpDfrdata(list[0].task_no);
            bool result = opRepository.AddModelOpDfrdataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpDfrdata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpDfrdata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpDfrdataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpDfrdataQuery> list = new List<ModelOpDfrdataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpDfrdataQuery model = ModelOpDfrdataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpDfrdataList(list);
                }
            }
            return result;
        }

        public ModelOpDfrdataQuery ModelOpDfrdataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpDfrdataQuery result = null;
            try
            {
                result = new ModelOpDfrdataQuery
                {
                    LineCode = cell[0].ToString(),
                    MonitorDate = Convert.ToDateTime(cell[1].ToString()),
                    DelayTimes = Convert.ToDecimal(cell[2].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 交通路面荷载LR业务信息Web
        public OpenApiResult<List<ModelOpLrdataQuery>> GetModelOpLrdataList(ModelOpLrdataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpLrdataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpLrdataQuery> result = opRepository.GetModelOpLrdataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpLrdataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpLrdata(int id)
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
            bool result = opRepository.DeleteModelOpLrdata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpLrdata(ModelOpLrdataQuery model)
        {
            bool result = opRepository.AddModelOpLrdata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpLrdataList(List<ModelOpLrdataQuery> list)
        {
            opRepository.DeleteModelOpLrdata(list[0].task_no);
            bool result = opRepository.AddModelOpLrdataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpLrdata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpLrdata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpLrdataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpLrdataQuery> list = new List<ModelOpLrdataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpLrdataQuery model = ModelOpLrdataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpLrdataList(list);
                }
            }
            return result;
        }

        public ModelOpLrdataQuery ModelOpLrdataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpLrdataQuery result = null;
            try
            {
                result = new ModelOpLrdataQuery
                {
                    LineCode = cell[0].ToString(),
                    MonitorDate = Convert.ToDateTime(cell[1].ToString()),
                    TotalCar = Convert.ToInt32(cell[2].ToString()),
                    SmallCarAmount = Convert.ToInt32(cell[3].ToString()),
                    BigCarAmount = Convert.ToInt32(cell[4].ToString()),
                    MediumCarAmount = Convert.ToInt32(cell[5].ToString()),
                    TruckAmount = Convert.ToInt32(cell[6].ToString()),
                    BusAmount1 = Convert.ToInt32(cell[7].ToString()),
                    BusAmount2 = Convert.ToInt32(cell[8].ToString()),
                    BusAmount3 = Convert.ToInt32(cell[9].ToString()),
                    BusAmount4 = Convert.ToInt32(cell[10].ToString()),
                    VanAmount1 = Convert.ToInt32(cell[11].ToString()),
                    VanAmount2 = Convert.ToInt32(cell[12].ToString()),
                    VanAmount3 = Convert.ToInt32(cell[13].ToString()),
                    VanAmount4 = Convert.ToInt32(cell[14].ToString()),
                    VanAmount5 = Convert.ToInt32(cell[15].ToString()),
                    TruckAmount1 = Convert.ToInt32(cell[16].ToString()),
                    TruckAmount2 = Convert.ToInt32(cell[17].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 亮度或照度BI业务信息Web
        public OpenApiResult<List<ModelOpBidataQuery>> GetModelOpBidataList(ModelOpBidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpBidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpBidataQuery> result = opRepository.GetModelOpBidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpBidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpBidata(int id)
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
            bool result = opRepository.DeleteModelOpBidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpBidata(ModelOpBidataQuery model)
        {
            bool result = opRepository.AddModelOpBidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpBidataList(List<ModelOpBidataQuery> list)
        {
            opRepository.DeleteModelOpBidata(list[0].task_no);
            bool result = opRepository.AddModelOpBidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpBidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpBidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpBidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpBidataQuery> list = new List<ModelOpBidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpBidataQuery model = ModelOpBidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpBidataList(list);
                }
            }
            return result;
        }

        public ModelOpBidataQuery ModelOpBidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpBidataQuery result = null;
            try
            {
                result = new ModelOpBidataQuery
                {
                    LineCode = cell[0].ToString(),
                    Position = cell[1].ToString(),
                    Mileage = cell[2].ToString(),
                    Deviceno = cell[3].ToString(),
                    MonitorYear = cell[4].ToString(),
                    MonitorMonth = cell[5].ToString(),
                    MonitorData = Convert.ToDecimal(cell[6].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion
        #region 内业成本绩效MCI业务信息Web
        public OpenApiResult<List<ModelOpMcidataQuery>> GetModelOpMcidataList(ModelOpMcidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpMcidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpMcidataQuery> result = opRepository.GetModelOpMcidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpMcidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpMcidata(int id)
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
            bool result = opRepository.DeleteModelOpMcidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpMcidata(ModelOpMcidataQuery model)
        {
            bool result = opRepository.AddModelOpMcidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpMcidataList(List<ModelOpMcidataQuery> list)
        {
            opRepository.DeleteModelOpMcidata(list[0].task_no);
            bool result = opRepository.AddModelOpMcidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpMcidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpMcidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpMcidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpMcidataQuery> list = new List<ModelOpMcidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpMcidataQuery model = ModelOpMcidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpMcidataList(list);
                }
            }
            return result;
        }

        public ModelOpMcidataQuery ModelOpMcidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpMcidataQuery result = null;
            try
            {
                result = new ModelOpMcidataQuery
                {
                    Month = Convert.ToInt32(cell[0].ToString()),
                    RealCost = Convert.ToDecimal(cell[1].ToString()),
                    RealPerformance = Convert.ToDecimal(cell[2].ToString()),
                    RealDate = Convert.ToDateTime(cell[3].ToString()),
                    PlanCost = Convert.ToDecimal(cell[4].ToString()),
                    PlanPerformance = Convert.ToDecimal(cell[5].ToString()),
                    PlanDate = Convert.ToDateTime(cell[6].ToString()),
                    DocYear = cell[7].ToString(),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 内业报编制MBI业务信息Web
        public OpenApiResult<List<ModelOpMbidataQuery>> GetModelOpMbidataList(ModelOpMbidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpMbidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpMbidataQuery> result = opRepository.GetModelOpMbidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpMbidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpMbidata(int id)
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
            bool result = opRepository.DeleteModelOpMbidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpMbidata(ModelOpMbidataQuery model)
        {
            bool result = opRepository.AddModelOpMbidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpMbidataList(List<ModelOpMbidataQuery> list)
        {
            opRepository.DeleteModelOpMbidata(list[0].task_no);
            bool result = opRepository.AddModelOpMbidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpMbidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpMbidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpMbidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpMbidataQuery> list = new List<ModelOpMbidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpMbidataQuery model = ModelOpMbidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpMbidataList(list);
                }
            }
            return result;
        }

        public ModelOpMbidataQuery ModelOpMbidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpMbidataQuery result = null;
            try
            {
                result = new ModelOpMbidataQuery
                {
                    DocCode = cell[0].ToString(),
                    DocName_Spec = cell[1].ToString(),
                    DocName_Company = cell[2].ToString(),
                    DocComplete = Convert.ToInt32(cell[3].ToString()),
                    DocCommitdate = Convert.ToDateTime(cell[4].ToString()),
                    DocYear = cell[5].ToString(),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 内业档案资料信息化MII业务信息Web
        public OpenApiResult<List<ModelOpMiidataQuery>> GetModelOpMiidataList(ModelOpMiidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpMiidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpMiidataQuery> result = opRepository.GetModelOpMiidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpMiidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpMiidata(int id)
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
            bool result = opRepository.DeleteModelOpMiidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpMiidata(ModelOpMiidataQuery model)
        {
            bool result = opRepository.AddModelOpMiidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpMiidataList(List<ModelOpMiidataQuery> list)
        {
            opRepository.DeleteModelOpMiidata(list[0].task_no);
            bool result = opRepository.AddModelOpMiidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpMiidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpMiidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpMiidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpMiidataQuery> list = new List<ModelOpMiidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpMiidataQuery model = ModelOpMiidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpMiidataList(list);
                }
            }
            return result;
        }

        public ModelOpMiidataQuery ModelOpMiidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpMiidataQuery result = null;
            try
            {
                result = new ModelOpMiidataQuery
                {
                    DocCode = cell[0].ToString(),
                    DocName_Spec = cell[1].ToString(),
                    DocName_Company = cell[2].ToString(),
                    DocYear = cell[3].ToString(),
                    DocComplete = Convert.ToInt32(cell[4].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 内业管理制度MSSI业务信息Web
        public OpenApiResult<List<ModelOpMssidataQuery>> GetModelOpMssidataList(ModelOpMssidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpMssidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpMssidataQuery> result = opRepository.GetModelOpMssidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpMssidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpMssidata(int id)
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
            bool result = opRepository.DeleteModelOpMssidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpMssidata(ModelOpMssidataQuery model)
        {
            bool result = opRepository.AddModelOpMssidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpMssidataList(List<ModelOpMssidataQuery> list)
        {
            opRepository.DeleteModelOpMssidata(list[0].task_no);
            bool result = opRepository.AddModelOpMssidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpMssidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpMssidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpMssidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpMssidataQuery> list = new List<ModelOpMssidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpMssidataQuery model = ModelOpMssidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpMssidataList(list);
                }
            }
            return result;
        }

        public ModelOpMssidataQuery ModelOpMssidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpMssidataQuery result = null;
            try
            {
                result = new ModelOpMssidataQuery
                {
                    DocType = cell[0].ToString(),
                    DocName_Spec = cell[1].ToString(),
                    DocName_Company = cell[2].ToString(),
                    DocComplete = Convert.ToInt32(cell[3].ToString()),
                    DocCommitDate = Convert.ToDateTime(cell[4].ToString()),
                    DocYear = cell[5].ToString(),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion



        #region 可吸入颗粒物浓度PM2.5业务信息Web
        public OpenApiResult<List<ModelOpPmdataQuery>> GetModelOpPmdataList(ModelOpPmdataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpPmdataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpPmdataQuery> result = opRepository.GetModelOpPmdataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpPmdataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpPmdata(int id)
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
            bool result = opRepository.DeleteModelOpPmdata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpPmdata(ModelOpPmdataQuery model)
        {
            bool result = opRepository.AddModelOpPmdata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpPmdataList(List<ModelOpPmdataQuery> list)
        {
            opRepository.DeleteModelOpPmdata(list[0].task_no);
            bool result = opRepository.AddModelOpPmdataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpPmdata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpPmdata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpPmdataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpPmdataQuery> list = new List<ModelOpPmdataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpPmdataQuery model = ModelOpPmdataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpPmdataList(list);
                }
            }
            return result;
        }

        public ModelOpPmdataQuery ModelOpPmdataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpPmdataQuery result = null;
            try
            {
                result = new ModelOpPmdataQuery
                {
                    LineCode = cell[0].ToString(),
                    Position = cell[1].ToString(),
                    Mileage = cell[2].ToString(),
                    DeviceNo = cell[3].ToString(),
                    MonitorYear = cell[4].ToString(),
                    MonitorMonth = cell[5].ToString(),
                    MonitorData = Convert.ToDecimal(cell[6].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 噪音DI业务信息Web
        public OpenApiResult<List<ModelOpDidataQuery>> GetModelOpDidataList(ModelOpDidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpDidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpDidataQuery> result = opRepository.GetModelOpDidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpDidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpDidata(int id)
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
            bool result = opRepository.DeleteModelOpDidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpDidata(ModelOpDidataQuery model)
        {
            bool result = opRepository.AddModelOpDidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpDidataList(List<ModelOpDidataQuery> list)
        {
            opRepository.DeleteModelOpDidata(list[0].task_no);
            bool result = opRepository.AddModelOpDidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpDidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpDidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpDidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpDidataQuery> list = new List<ModelOpDidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpDidataQuery model = ModelOpDidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpDidataList(list);
                }
            }
            return result;
        }

        public ModelOpDidataQuery ModelOpDidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpDidataQuery result = null;
            try
            {
                result = new ModelOpDidataQuery
                {
                    LineCode = cell[0].ToString(),
                    Position = cell[1].ToString(),
                    Mileage = cell[2].ToString(),
                    DeviceNo = cell[3].ToString(),
                    MonitorYear = cell[4].ToString(),
                    MonitorMonthDay = cell[5].ToString(),
                    MonitorDataDay = Convert.ToDecimal(cell[6].ToString()),
                    MonitorMonthNight = cell[7].ToString(),
                    MonitorDataNight = Convert.ToDecimal(cell[8].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 安全事故率RV业务信息Web
        public OpenApiResult<List<ModelOpRvdataQuery>> GetModelOpRvdataList(ModelOpRvdataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpRvdataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpRvdataQuery> result = opRepository.GetModelOpRvdataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpRvdataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpRvdata(int id)
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
            bool result = opRepository.DeleteModelOpRvdata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpRvdata(ModelOpRvdataQuery model)
        {
            bool result = opRepository.AddModelOpRvdata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpRvdataList(List<ModelOpRvdataQuery> list)
        {
            opRepository.DeleteModelOpRvdata(list[0].task_no);
            bool result = opRepository.AddModelOpRvdataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpRvdata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpRvdata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpRvdataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpRvdataQuery> list = new List<ModelOpRvdataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpRvdataQuery model = ModelOpRvdataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpRvdataList(list);
                }
            }
            return result;
        }

        public ModelOpRvdataQuery ModelOpRvdataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpRvdataQuery result = null;
            try
            {
                result = new ModelOpRvdataQuery
                {
                    LineCode = cell[0].ToString(),
                    MonitorYear = Convert.ToInt32(cell[1].ToString()),
                    MonitorMonth = Convert.ToInt32(cell[2].ToString()),
                    Accident_Num = Convert.ToInt32(cell[3].ToString()),
                    Broke_Down = Convert.ToInt32(cell[4].ToString()),
                    Average_Stream = Convert.ToDecimal(cell[5].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 用户满意度UCVI业务信息Web
        public OpenApiResult<List<ModelOpUcvidataQuery>> GetModelOpUcvidataList(ModelOpUcvidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpUcvidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpUcvidataQuery> result = opRepository.GetModelOpUcvidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpUcvidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpUcvidata(int id)
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
            bool result = opRepository.DeleteModelOpUcvidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpUcvidata(ModelOpUcvidataQuery model)
        {
            bool result = opRepository.AddModelOpUcvidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpUcvidataList(List<ModelOpUcvidataQuery> list)
        {
            opRepository.DeleteModelOpUcvidata(list[0].task_no);
            bool result = opRepository.AddModelOpUcvidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpUcvidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpUcvidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpUcvidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpUcvidataQuery> list = new List<ModelOpUcvidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpUcvidataQuery model = ModelOpUcvidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpUcvidataList(list);
                }
            }
            return result;
        }

        public ModelOpUcvidataQuery ModelOpUcvidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpUcvidataQuery result = null;
            try
            {
                result = new ModelOpUcvidataQuery
                {
                    DataYear = cell[0].ToString(),
                    DataMonth = cell[1].ToString(),
                    DelayAmount = cell[2].ToString(),
                    HandleAmount = Convert.ToDecimal(cell[3].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 用户舒适度UCI业务信息Web
        public OpenApiResult<List<ModelOpUcidataQuery>> GetModelOpUcidataList(ModelOpUcidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpUcidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpUcidataQuery> result = opRepository.GetModelOpUcidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpUcidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpUcidata(int id)
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
            bool result = opRepository.DeleteModelOpUcidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpUcidata(ModelOpUcidataQuery model)
        {
            bool result = opRepository.AddModelOpUcidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpUcidataList(List<ModelOpUcidataQuery> list)
        {
            opRepository.DeleteModelOpUcidata(list[0].task_no);
            bool result = opRepository.AddModelOpUcidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpUcidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpUcidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpUcidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpUcidataQuery> list = new List<ModelOpUcidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpUcidataQuery model = ModelOpUcidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpUcidataList(list);
                }
            }
            return result;
        }

        public ModelOpUcidataQuery ModelOpUcidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpUcidataQuery result = null;
            try
            {
                result = new ModelOpUcidataQuery
                {
                    InvestDate = Convert.ToDateTime(cell[0].ToString()),
                    InvestContent = cell[1].ToString(),
                    CustomerAge = cell[2].ToString(),
                    CustomerSex = cell[3].ToString(),
                    SatisfactsCore = Convert.ToDecimal(cell[4].ToString()),
                    UnsatisFactreason = cell[5].ToString(),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 能见度VI业务信息Web
        public OpenApiResult<List<ModelOpVidataQuery>> GetModelOpVidataList(ModelOpVidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpVidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpVidataQuery> result = opRepository.GetModelOpVidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpVidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpVidata(int id)
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
            bool result = opRepository.DeleteModelOpVidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpVidata(ModelOpVidataQuery model)
        {
            bool result = opRepository.AddModelOpVidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpVidataList(List<ModelOpVidataQuery> list)
        {
            opRepository.DeleteModelOpVidata(list[0].task_no);
            bool result = opRepository.AddModelOpVidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpVidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpVidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpVidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpVidataQuery> list = new List<ModelOpVidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpVidataQuery model = ModelOpVidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpVidataList(list);
                }
            }
            return result;
        }

        public ModelOpVidataQuery ModelOpVidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpVidataQuery result = null;
            try
            {
                result = new ModelOpVidataQuery
                {
                    linecode = cell[0].ToString(),
                    position = cell[1].ToString(),
                    mileage = cell[2].ToString(),
                    deviceno = cell[3].ToString(),
                    monitoryear = Convert.ToInt32(cell[4].ToString()),
                    monitormonth = Convert.ToInt32(cell[5].ToString()),
                    monitordata = Convert.ToDecimal(cell[6].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion


        #region 行驶速率DSI业务信息Web
        public OpenApiResult<List<ModelOpDsidataQuery>> GetModelOpDsidataList(ModelOpDsidataQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpDsidataQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpDsidataQuery> result = opRepository.GetModelOpDsidataList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpDsidataQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpDsidata(int id)
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
            bool result = opRepository.DeleteModelOpDsidata(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpDsidata(ModelOpDsidataQuery model)
        {
            bool result = opRepository.AddModelOpDsidata(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpDsidataList(List<ModelOpDsidataQuery> list)
        {
            opRepository.DeleteModelOpDsidata(list[0].task_no);
            bool result = opRepository.AddModelOpDsidataList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpDsidata(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpDsidata(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpDsidataUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpDsidataQuery> list = new List<ModelOpDsidataQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpDsidataQuery model = ModelOpDsidataMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpDsidataList(list);
                }
            }
            return result;
        }

        public ModelOpDsidataQuery ModelOpDsidataMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpDsidataQuery result = null;
            try
            {
                result = new ModelOpDsidataQuery
                {
                    LineCode = cell[0].ToString(),
                    MonitorDate = Convert.ToDateTime(cell[1].ToString()),
                    MonitorLength = Convert.ToDecimal(cell[2].ToString()),
                    PassTime = Convert.ToDecimal(cell[3].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 隧道交通流量业务信息Web
        public OpenApiResult<List<ModelOpTunneltrafficinfoQuery>> GetModelOpTunneltrafficinfoList(ModelOpTunneltrafficinfoQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpTunneltrafficinfoQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpTunneltrafficinfoQuery> result = opRepository.GetModelOpTunneltrafficinfoList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpTunneltrafficinfoQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpTunneltrafficinfo(int id)
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
            bool result = opRepository.DeleteModelOpTunneltrafficinfo(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpTunneltrafficinfo(ModelOpTunneltrafficinfoQuery model)
        {
            bool result = opRepository.AddModelOpTunneltrafficinfo(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpTunneltrafficinfoList(List<ModelOpTunneltrafficinfoQuery> list)
        {
            opRepository.DeleteModelOpTunneltrafficinfo(list[0].task_no);
            bool result = opRepository.AddModelOpTunneltrafficinfoList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpTunneltrafficinfo(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpTunneltrafficinfo(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpTunneltrafficinfoUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpTunneltrafficinfoQuery> list = new List<ModelOpTunneltrafficinfoQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpTunneltrafficinfoQuery model = ModelOpTunneltrafficinfoMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpTunneltrafficinfoList(list);
                }
            }
            return result;
        }

        public ModelOpTunneltrafficinfoQuery ModelOpTunneltrafficinfoMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpTunneltrafficinfoQuery result = null;
            try
            {
                result = new ModelOpTunneltrafficinfoQuery
                {
                    BuildStartDate = Convert.ToDateTime(cell[0].ToString()),
                    BuildEndDate = Convert.ToDateTime(cell[1].ToString()),
                    CommitDate = Convert.ToDateTime(cell[2].ToString()),
                    OpstartDate = Convert.ToDateTime(cell[3].ToString()),
                    BigMaintainStartDate = Convert.ToDateTime(cell[4].ToString()),
                    BigMaintainEndDate = Convert.ToDateTime(cell[5].ToString()),
                    EntryAmount = Convert.ToInt32(cell[6].ToString()),
                    ExitAmount = Convert.ToInt32(cell[7].ToString()),
                    StructureType = cell[8].ToString(),
                    TunnelDirection = cell[9].ToString(),
                    CqType = cell[10].ToString(),
                    Crossriver = cell[11].ToString(),
                    Opattribute = cell[12].ToString(),
                    TunnelLength = Convert.ToDecimal(cell[13].ToString()),
                    TunnelWidth = Convert.ToDecimal(cell[14].ToString()),
                    TunnelPureWidth = Convert.ToDecimal(cell[15].ToString()),
                    TunnelShape = cell[16].ToString(),
                    CqThick = Convert.ToDecimal(cell[17].ToString()),
                    CqStrength = Convert.ToDecimal(cell[18].ToString()),
                    DesignSpeed = Convert.ToDecimal(cell[19].ToString()),
                    DesignLoading = Convert.ToDecimal(cell[20].ToString()),
                    DesignFlowing = Convert.ToDecimal(cell[21].ToString()),
                    OwnerUnit = cell[22].ToString(),
                    DesignUnit = cell[23].ToString(),
                    ContructUnit = cell[24].ToString(),
                    OperationUnit = cell[25].ToString(),
                    NewContractStartDate = Convert.ToDateTime(cell[26].ToString()),
                    NewContractEndDate = Convert.ToDateTime(cell[27].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 隧道基础业务信息Web
        public OpenApiResult<List<ModelOpTunnelbasicinfoQuery>> GetModelOpTunnelbasicinfoList(ModelOpTunnelbasicinfoQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpTunnelbasicinfoQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpTunnelbasicinfoQuery> result = opRepository.GetModelOpTunnelbasicinfoList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpTunnelbasicinfoQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpTunnelbasicinfo(int id)
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
            bool result = opRepository.DeleteModelOpTunnelbasicinfo(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpTunnelbasicinfo(ModelOpTunnelbasicinfoQuery model)
        {
            bool result = opRepository.AddModelOpTunnelbasicinfo(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpTunnelbasicinfoList(List<ModelOpTunnelbasicinfoQuery> list)
        {
            opRepository.DeleteModelOpTunnelbasicinfo(list[0].task_no);
            bool result = opRepository.AddModelOpTunnelbasicinfoList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpTunnelbasicinfo(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpTunnelbasicinfo(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpTunnelbasicinfoUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpTunnelbasicinfoQuery> list = new List<ModelOpTunnelbasicinfoQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpTunnelbasicinfoQuery model = ModelOpTunnelbasicinfoMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpTunnelbasicinfoList(list);
                }
            }
            return result;
        }

        public ModelOpTunnelbasicinfoQuery ModelOpTunnelbasicinfoMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpTunnelbasicinfoQuery result = null;
            try
            {
                result = new ModelOpTunnelbasicinfoQuery
                {
                    BuildStartDate = Convert.ToDateTime(cell[0].ToString()),
                    BuildEndDate = Convert.ToDateTime(cell[1].ToString()),
                    CommitDate = Convert.ToDateTime(cell[2].ToString()),
                    OpstartDate = Convert.ToDateTime(cell[3].ToString()),
                    BigMaintainStartDate = Convert.ToDateTime(cell[4].ToString()),
                    BigMaintainEndDate = Convert.ToDateTime(cell[5].ToString()),
                    EntryAmount = Convert.ToInt32(cell[6].ToString()),
                    ExitAmount = Convert.ToInt32(cell[7].ToString()),
                    StructureType = cell[8].ToString(),
                    TunnelDirection = cell[9].ToString(),
                    CqType = cell[10].ToString(),
                    CrosSriver = cell[11].ToString(),
                    Opattribute = cell[12].ToString(),
                    TunnelLength = Convert.ToDecimal(cell[13].ToString()),
                    TunnelWidth = Convert.ToDecimal(cell[14].ToString()),
                    TunnelPureWidth = Convert.ToDecimal(cell[15].ToString()),
                    TunnelShape = cell[16].ToString(),
                    CqThick = Convert.ToDecimal(cell[17].ToString()),
                    CqStrength = Convert.ToDecimal(cell[18].ToString()),
                    DesignSpeed = Convert.ToDecimal(cell[19].ToString()),
                    DesignLoading = Convert.ToDecimal(cell[20].ToString()),
                    DesignShaft = Convert.ToDecimal(cell[21].ToString()),
                    DesignFlowing = Convert.ToDecimal(cell[22].ToString()),
                    OwnerUnit = cell[23].ToString(),
                    DesignUnit = cell[24].ToString(),
                    ContructUnit = cell[25].ToString(),
                    OperationUnit = cell[26].ToString(),
                    NewContractStartDate = Convert.ToDateTime(cell[27].ToString()),
                    NewContractEndDate = Convert.ToDateTime(cell[28].ToString()),
                    DesignBi = Convert.ToDecimal(cell[29].ToString()),
                    DesignDi = Convert.ToDecimal(cell[30].ToString()),
                    DesignPm = Convert.ToDecimal(cell[31].ToString()),
                    DesignCo = Convert.ToDecimal(cell[32].ToString()),
                    DesignVi = Convert.ToDecimal(cell[33].ToString()),
                    DesignMCIScore = Convert.ToDecimal(cell[34].ToString()),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 隧道线路基本业务信息Web
        public OpenApiResult<List<ModelOpLineinfoQuery>> GetModelOpLineinfoList(ModelOpLineinfoQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpLineinfoQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpLineinfoQuery> result = opRepository.GetModelOpLineinfoList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpLineinfoQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpLineinfo(int id)
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
            bool result = opRepository.DeleteModelOpLineinfo(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpLineinfo(ModelOpLineinfoQuery model)
        {
            bool result = opRepository.AddModelOpLineinfo(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpLineinfoList(List<ModelOpLineinfoQuery> list)
        {
            opRepository.DeleteModelOpLineinfo(list[0].task_no);
            bool result = opRepository.AddModelOpLineinfoList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpLineinfo(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpLineinfo(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpLineinfoUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpLineinfoQuery> list = new List<ModelOpLineinfoQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpLineinfoQuery model = ModelOpLineinfoMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpLineinfoList(list);
                }
            }
            return result;
        }

        public ModelOpLineinfoQuery ModelOpLineinfoMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpLineinfoQuery result = null;
            try
            {
                result = new ModelOpLineinfoQuery
                {
                    LineName = cell[0].ToString(),
                    LineCode = cell[1].ToString(),
                    LineLength = Convert.ToDecimal(cell[2].ToString()),
                    ProjectName = cell[3].ToString(),
                    Memo = cell[4].ToString(),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 隧道车道基本业务信息Web
        public OpenApiResult<List<ModelOpLaneinfoQuery>> GetModelOpLaneinfoList(ModelOpLaneinfoQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelOpLaneinfoQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }
            List<ModelOpLaneinfoQuery> result = opRepository.GetModelOpLaneinfoList(model, out count).ToList();
            return new OpenApiResult<List<ModelOpLaneinfoQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelOpLaneinfo(int id)
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
            bool result = opRepository.DeleteModelOpLaneinfo(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpLaneinfo(ModelOpLaneinfoQuery model)
        {
            bool result = opRepository.AddModelOpLaneinfo(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelOpLaneinfoList(List<ModelOpLaneinfoQuery> list)
        {
            opRepository.DeleteModelOpLaneinfo(list[0].task_no);
            bool result = opRepository.AddModelOpLaneinfoList(list);
            return result;
        }

        public OpenApiResult<bool> UpdateModelOpLaneinfo(int id, string field, string value)
        {
            bool result = opRepository.UpdateModelOpLaneinfo(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool ModelOpLaneinfoUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelOpLaneinfoQuery> list = new List<ModelOpLaneinfoQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ? new HSSFWorkbook(ms).GetSheetAt(0) : new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1, rowNum = sheet.LastRowNum;
                if (rowNum < startRow)
                    throw new InvalidOperationException("导入数据不能为空");
                DateTime dt_now = DateTime.Now;
                for (var i = startRow; i <= rowNum; i++)
                {
                    row = sheet.GetRow(i);
                    ICell[] cell = new ICell[row.LastCellNum];
                    int j = 0;
                    for (; j < row.LastCellNum; j++)
                    {
                        cell[j] = row.GetCell(j);
                        if (cell[j] == null)
                        {
                            break;
                        }
                    }
                    if (j < row.LastCellNum)
                    {
                        continue;
                    }
                    ModelOpLaneinfoQuery model = ModelOpLaneinfoMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelOpLaneinfoList(list);
                }
            }
            return result;
        }

        public ModelOpLaneinfoQuery ModelOpLaneinfoMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelOpLaneinfoQuery result = null;
            try
            {
                result = new ModelOpLaneinfoQuery
                {
                    LineCode = cell[0].ToString(),
                    LaneCode = cell[1].ToString(),
                    LaneWidth = Convert.ToDecimal(cell[2].ToString()),
                    LaneLength = Convert.ToDecimal(cell[3].ToString()),
                    ProjectName = cell[4].ToString(),
                    Memo = cell[5].ToString(),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        #endregion

        #region 8.0 运营服务评价接口
       
        public OpenApiResult<bool> AddModelOpBridgeBasicInfo(List<ModelOpBridgeBasicInfo> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpBridgeBasicInfo(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpBridgeBasicInfo(item, id);
                }
                else
                {
                    opRepository.AddModelOpBridgeBasicInfo(item);
                }
                //opRepository.AddModelOpBridgeBasicInfo(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpTrafficDriveSpeed(List<ModelOpTrafficDriveSpeed> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpTrafficDriveSpeed(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpTrafficDriveSpeed(item, id);
                }
                else
                {
                    opRepository.AddModelOpTrafficDriveSpeed(item);
                }
                // opRepository.AddModelOpTrafficDriveSpeed(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpTrafficFlow(List<ModelOpTrafficFlow> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpTrafficFlow(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpTrafficFlow(item, id);
                }
                else
                {
                    opRepository.AddModelOpTrafficFlow(item);
                }
                //opRepository.AddModelOpTrafficFlow(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpTrafficFenceInfluence(List<ModelOpTrafficFenceInfluence> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpTrafficFenceInfluence(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpTrafficFenceInfluence(item, id);
                }
                else
                {
                    opRepository.AddModelOpTrafficFenceInfluence(item);
                }
                // opRepository.AddModelOpTrafficFenceInfluence(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpTrafficAccident(List<ModelOpTrafficAccident> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpTrafficAccident(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpTrafficAccident(item, id);
                }
                else
                {
                    opRepository.AddModelOpTrafficAccident(item);
                }
                //opRepository.AddModelOpTrafficAccident(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpDeviceMaterialComplete(List<ModelOpDeviceMaterialComplete> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpDeviceMaterialComplete(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpDeviceMaterialComplete(item, id);
                }
                else
                {
                    opRepository.AddModelOpDeviceMaterialComplete(item);
                }
                //opRepository.AddModelOpDeviceMaterialComplete(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpEmergencyResponse(List<ModelOpEmergencyResponse> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpEmergencyResponse(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpEmergencyResponse(item, id);
                }
                else
                {
                    opRepository.AddModelOpEmergencyResponse(item);
                }
               // opRepository.AddModelOpEmergencyResponse(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpComplaintResponse(List<ModelOpComplaintResponse> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpComplaintResponse(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpComplaintResponse(item, id);
                }
                else
                {
                    opRepository.AddModelOpComplaintResponse(item);
                }
                //opRepository.AddModelOpComplaintResponse(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpValidComplaint(List<ModelOpValidComplaint> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpValidComplaint(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpValidComplaint(item, id);
                }
                else
                {
                    opRepository.AddModelOpValidComplaint(item);
                }
                // opRepository.AddModelOpValidComplaint(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpReleaseInfoAccuracy(List<ModelOpReleaseInfoAccuracy> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpReleaseInfoAccuracy(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpReleaseInfoAccuracy(item, id);
                }
                else
                {
                    opRepository.AddModelOpReleaseInfoAccuracy(item);
                }
                //opRepository.AddModelOpReleaseInfoAccuracy(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpReleaseInfoTimeliness(List<ModelOpReleaseInfoTimeliness> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpReleaseInfoTimeliness(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpReleaseInfoTimeliness(item, id);
                }
                else
                {
                    opRepository.AddModelOpReleaseInfoTimeliness(item);
                }
                //opRepository.AddModelOpReleaseInfoTimeliness(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelOpValidComplaintHandle(List<ModelOpValidComplaintHandle> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.CheckModelOpValidComplaintHandle(item);
                if (!string.IsNullOrEmpty(id))
                {
                    opRepository.UpdateModelOpValidComplaintHandle(item, id);
                }
                else
                {
                    opRepository.AddModelOpValidComplaintHandle(item);
                }
                // opRepository.AddModelOpValidComplaintHandle(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        
        public OpenApiResult<ModelOpBridgeInfos> GetBridgeModelOpResults(string task_no)
        {
            ModelOpBridgeInfos data = new ModelOpBridgeInfos();
            data.tsi_result = opRepository.GetModelOpBridgeResultTSI(task_no);
            data.ssi_result = opRepository.GetModelOpBridgeResultSSI(task_no);
            data.esi_result = opRepository.GetModelOpBridgeResultESI(task_no);
            data.usi_result = opRepository.GetModelOpBridgeResultUSI(task_no);
            data.mid_evaluation_result = opRepository.GetModelOpBridgeResultMID(task_no);
            data.all_evaluation_result = opRepository.GetModelOpBridgeResultAllEVA(task_no);


            return new OpenApiResult<ModelOpBridgeInfos>
            {
                Data = data,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 新增v2接口
        #region 运营服务评价指标权重信息表


        
        public OpenApiResult<List<ModelOpevaWeightInfo>> GetWeightinfo(string IndexName, string ParentIndex)
        {
            List<ModelOpevaWeightInfo> m = opRepository.GetModel<ModelOpevaWeightInfo>(IndexName, ParentIndex, "tb_model_op_weight");
            return new OpenApiResult<List<ModelOpevaWeightInfo>>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增运营服务评价指标权重信息表
        /// </summary>
        public OpenApiResult<bool> AddModelWeightinfo(List<ModelOpevaWeightInfo> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelWeightinfo(item);
                string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelWeightinfo(item);
                }
                else
                {
                    opRepository.AddModelWeightinfo(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> DeleteModelWeightinfo(List<ModelOpevaWeightInfo> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_weight");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 评价等级与分值对应关系表

        /// <summary>
        /// 获取评价等级与分值对应关系表
        /// </summary>
        /// <param name="IndexName"></param>
        /// <param name="ParentIndex"></param>
        /// <returns></returns>
        public OpenApiResult<List<ModelOpCriteria>> GetModelOpCriteria(string IndexName, string ParentIndex)
        {
            List<ModelOpCriteria> m = opRepository.GetModel<ModelOpCriteria>(IndexName, ParentIndex, "tb_model_table_op_criteria");
            return new OpenApiResult<List<ModelOpCriteria>>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增评价等级与分值对应关系表
        /// </summary>
        public OpenApiResult<bool> AddCriteriaInfo(List<ModelOpCriteria> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckCriteriaInfo(item);
                string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpCriteria(item);
                }
                else
                {
                    opRepository.AddModelOpCriteria(item);
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
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpCriteria(List<ModelOpCriteria> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_table_op_criteria");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 待评价项目的保洁效果信息表

        /// <summary>
        /// 待评价项目的保洁效果信息表
        /// </summary>
        /// <param name="task_no">任务号</param>
        /// <returns></returns>
        public OpenApiResult<List<ModelOpDataClean>> GetModelOpDataClean(string task_no)
        {
            List<ModelOpDataClean> m = opRepository.GetModel<ModelOpDataClean>(task_no, "", "tb_model_op_data_clean");
            return new OpenApiResult<List<ModelOpDataClean>>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增或编辑待评价项目的保洁效果信息表
        /// </summary>
        public OpenApiResult<bool> AddModelOpDataClean(List<ModelOpDataClean> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpDataClean(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpDataClean(item);
                }
                else
                {
                    opRepository.AddModelOpDataClean(item);
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
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpDataClean(List<ModelOpDataClean> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_data_clean");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 待评价项目的废水排放合格率信息
        /// <summary>
        /// 待评价项目的废水排放合格率信息
        /// </summary>
        /// <param name="task_no">任务号</param>
        /// <returns></returns>
        public OpenApiResult<List<ModelOpDataEffluent>> GetModelOpDataEffluent(string task_no)
        {
            List<ModelOpDataEffluent> m = opRepository.GetModel<ModelOpDataEffluent>(task_no, "", "tb_model_op_data_effluent");
            return new OpenApiResult<List<ModelOpDataEffluent>>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增待评价项目的废水排放合格率信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDataEffluent(List<ModelOpDataEffluent> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpDataEffluent(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpDataEffluent(item);
                }
                else
                {
                    opRepository.AddModelOpDataEffluent(item);
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
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpDataEffluent(List<ModelOpDataEffluent> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_data_effluent");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 待评价项目的应急响应及时率信息
        /// <summary>
        /// 待评价项目的应急响应及时率信息
        /// </summary>
        /// <param name="task_no">任务号</param>
        /// <returns></returns>
        public OpenApiResult<List<ModelOpDataEri>> GetModelOpDataEri(string task_no)
        {
            List<ModelOpDataEri> m = opRepository.GetModel<ModelOpDataEri>(task_no, "", "tb_model_op_data_eri");
            return new OpenApiResult<List<ModelOpDataEri>>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增待评价项目的应急响应及时率信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDataEri(List<ModelOpDataEri> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpDataEri(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpDataEri(item);
                }
                else
                {
                    opRepository.AddModelOpDataEri(item);
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
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpDataEri(List<ModelOpDataEri> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_data_eri");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 待评价项目的节能环保信息
        /// <summary>
        /// 待评价项目的节能环保信息
        /// </summary>
        /// <param name="task_no">任务号</param>
        /// <returns></returns>
        public OpenApiResult<List<ModelOpDataEs>> GetModelOpDataEs(string task_no)
        {
            List<ModelOpDataEs> m = opRepository.GetModel<ModelOpDataEs>(task_no, "", "tb_model_op_data_es");
            return new OpenApiResult<List<ModelOpDataEs>>
            {
                Data = m,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增待评价项目的节能环保信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDataEs(List<ModelOpDataEs> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpDataEs(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpDataEs(item);
                }
                else
                {
                    opRepository.AddModelOpDataEs(item);
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
        /// 编辑待评价项目的节能环保信息
        /// </summary>
        public OpenApiResult<bool> UpdateModelOpDataEs(List<ModelOpDataEs> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpDataEs(item);
                //if (!string.IsNullOrEmpty(item.id))
                //{
                //    opRepository.UpdateModelOpDataEs(item);
                //}
                //else
                //{
                //    opRepository.AddModelOpDataEs(item);
                //}
                opRepository.UpdateModelOpDataEs(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpDataEs(List<ModelOpDataEs> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_data_es");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 待评价项目的高峰期烟雾浓度信息
        /// <summary>
        /// 待评价项目的高峰期烟雾浓度信息
        /// </summary>
        /// <param name="task_no">任务号</param>
        /// <returns></returns>
        //public OpenApiResult<List<ModelOpDataK>> GetModelOpDataEs(string task_no)
        //{
        //    List<ModelOpDataK> m = opRepository.GetModel<ModelOpDataEs>(task_no, "", "tb_model_op_data_k");
        //    return new OpenApiResult<List<ModelOpDataK>>
        //    {
        //        Data = m,
        //        Status = (int)OpenApiResultStatus.SUCCESS,
        //        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
        //    };
        //}

        /// <summary>
        /// 新增待评价项目的高峰期烟雾浓度信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDataK(List<ModelOpDataK> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpDataK(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpDataK(item);
                }
                else
                {
                    opRepository.AddModelOpDataK(item);
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
        /// 编辑待评价项目的高峰期烟雾浓度信息
        /// </summary>
        public OpenApiResult<bool> UpdateModelOpDataK(List<ModelOpDataK> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpDataEs(item);
                //if (!string.IsNullOrEmpty(item.id))
                //{
                //    opRepository.UpdateModelOpDataEs(item);
                //}
                //else
                //{
                //    opRepository.AddModelOpDataEs(item);
                //}
                opRepository.UpdateModelOpDataK(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpDataK(List<ModelOpDataK> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_data_k");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 待评价项目的标线光度性能信息
        /// <summary>
        /// 待评价项目的标线光度性能信息
        /// </summary>
        /// <param name="task_no">任务号</param>
        /// <returns></returns>
        //public OpenApiResult<List<ModelOpDataK>> GetModelOpDataEs(string task_no)
        //{
        //    List<ModelOpDataK> m = opRepository.GetModel<ModelOpDataEs>(task_no, "", "tb_model_op_data_k");
        //    return new OpenApiResult<List<ModelOpDataK>>
        //    {
        //        Data = m,
        //        Status = (int)OpenApiResultStatus.SUCCESS,
        //        Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
        //    };
        //}

        /// <summary>
        /// 新增待评价项目的标线光度性能信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDataNBI(List<ModelOpDataNBI> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpDataNBI(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpDataNBI(item);
                }
                else
                {
                    opRepository.AddModelOpDataNBI(item);
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
        /// 编辑待评价项目的标线光度性能信息
        /// </summary>
        public OpenApiResult<bool> UpdateModelOpDataNBI(List<ModelOpDataNBI> models)
        {
            foreach (var item in models)
            {
                //string id = opRepository.RepeatCheckModelOpDataEs(item);
                //if (!string.IsNullOrEmpty(item.id))
                //{
                //    opRepository.UpdateModelOpDataEs(item);
                //}
                //else
                //{
                //    opRepository.AddModelOpDataEs(item);
                //}
                opRepository.UpdateModelOpDataNBI(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpDataNBI(List<ModelOpDataNBI> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_data_nbi");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 待评价项目的安全生产事故信息

        /// <summary>
        /// 新增待评价项目的安全生产事故信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDataSafety(List<ModelOpDataSafety> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpDataSafety(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpDataSafety(item);
                }
                else
                {
                    opRepository.AddModelOpDataSafety(item);
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
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpDataSafety(List<ModelOpDataSafety> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_data_safety");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 待评价项目的高峰期平均行驶速度信息

        /// <summary>
        /// 新增待评价项目的高峰期平均行驶速度信息
        /// </summary>
        public OpenApiResult<bool> AddModelOpDataSpeed(List<ModelOpDataSpeed> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpDataSpeed(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpDataSpeed(item);
                }
                else
                {
                    opRepository.AddModelOpDataSpeed(item);
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
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpDataSpeed(List<ModelOpDataSpeed> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_data_speed");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region 待评价项目的通行影响率信息

        /// <summary>
        /// 新增
        /// </summary>
        public OpenApiResult<bool> AddModelOpDataTraff(List<ModelOpDataTraff> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpDataTraff(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    item.ID = id;
                    opRepository.UpdateModelOpDataTraff(item);
                }
                else
                {
                    opRepository.AddModelOpDataTraff(item);
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
        /// 删除模型数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public OpenApiResult<bool> DeleteModelOpDataTraff(List<ModelOpDataTraff> models)
        {
            foreach (var item in models)
            {
                opRepository.DeleteModel(item.ID, "tb_model_op_data_trafficinfluence");
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpBidata(List<ModelOpBidataQuery2>  models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckModelOpBidataQuery(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    //item.ID = id;
                    opRepository.UpdateModelOpBidataQuery(item, id);
                }
                else
                {
                    //opRepository.AddModelOpDataSpeed(item);
                    opRepository.AddModelOpBidataQuery(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelOpTeidata2(List<ModelOpTeidata2> models)
        {
            foreach (var item in models)
            {
                string id = opRepository.RepeatCheckOpTeidata2(item);
                //string id = item.ID;
                if (!string.IsNullOrEmpty(id))
                {
                    //item.ID = id;
                    opRepository.UpdateModelOpTeidata2(item, id);
                }
                else
                {
                    //opRepository.AddModelOpDataSpeed(item);
                    opRepository.AddModelOpTeidata2(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion
        #endregion

    }
}