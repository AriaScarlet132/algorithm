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
    public class TjBll
    {
        TjRepository tjRepository = new TjRepository();

        /// <summary>
        /// 土建信息
        /// </summary>
        public OpenApiResult<ModelTjInfos> GetModelTjInfos(string task_no)
        {
            ModelTjInfos data = new ModelTjInfos();
            data.ModelTjResultTunnelstructuretypes = tjRepository.GetModelTjResultTunnelstructuretype(task_no).ToList();
            data.ModelTjResultTunnelstructureatts = tjRepository.GetModelTjResultTunnelstructureatt(task_no).ToList();
            data.ModelTjResultTunnelsections = tjRepository.GetModelTjResultTunnelsection(task_no).ToList();
            data.ModelTjResultTunnellines = tjRepository.GetModelTjResultTunnelline(task_no).ToList();
            data.ModelTjResultTunnels = tjRepository.GetModelTjResultTunnel(task_no).ToList();
            data.ModelTjResultComponenttypes = tjRepository.GetModelTjResultComponenttype(task_no).ToList();
            return new OpenApiResult<ModelTjInfos>
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
        /// 新增tb_model_tj_data_defects
        /// </summary>
        public OpenApiResult<bool> AddModelTjDataDefects(List<ModelTjDataDefects> models)
        {
            foreach (var item in models)
            {
                //item.Date = item.Date.Value.Date;
                //string id = tjRepository.RepeatCheckModelTjDataDefects(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    tjRepository.UpdateModelTjDataDefects(item, id);
                //}
                //else
                //{
                //    tjRepository.AddModelTjDataDefects(item);
                //}
                tjRepository.AddModelTjDataDefects(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }



        /// <summary>
        /// 新增tb_model_tj_data_deformation
        /// </summary>
        public OpenApiResult<bool> AddModelTjDataDeformation(List<ModelTjDataDeformation> models)
        {
            foreach (var item in models)
            {
                //item.Date = item.Date.Value.Date;
                //string id = tjRepository.RepeatCheckModelTjDataDeformation(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    tjRepository.UpdateModelTjDataDeformation(item, id);
                //}
                //else
                //{
                //    tjRepository.AddModelTjDataDeformation(item);
                //}
                tjRepository.AddModelTjDataDeformation(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_tj_data_diffsedimentation   V2
        /// </summary>
        public OpenApiResult<bool> AddModelTjDataDiffsedimentation(List<ModelTjDataDiffsedimentation> models)
        {
            foreach (var item in models)
            {
               
                string id = tjRepository.RepeatCheckModelTjDataDiffsedimentation(item);
                //if (!string.IsNullOrEmpty(item.ID))
                if (!string.IsNullOrEmpty(id))
                {
                    int id2 = Convert.ToInt32(id);
                    tjRepository.UpdateModelTjDataDiffsedimentation(item, id2);
                }
                else
                {
                    tjRepository.AddModelTjDataDiffsedimentation(item);
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
        /// 新增tb_model_tj_data_leakage   V2
        /// </summary>
        public OpenApiResult<bool> AddModelTjDataLeakage(List<ModelTjDataLeakage> models)
        {
            foreach (var item in models)
            {

                string id = tjRepository.RepeatCheckModelTjDataLeakage(item);
                if (!string.IsNullOrEmpty(id))
                {
                    int id2 = Convert.ToInt32(id);
                    tjRepository.UpdateModelTjDataLeakage(item, id2);
                }
                else
                {
                    tjRepository.AddModelTjDataLeakage(item);
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
        /// 新增tb_model_tj_data_sedimentation
        /// </summary>
        public OpenApiResult<bool> AddModelTjDataSedimentation(List<ModelTjDataSedimentation> models)
        {
            foreach (var item in models)
            {
                //item.Start_Date = item.Start_Date.Value.Date;
                //item.End_Date = item.End_Date.Date;
                //string id = tjRepository.RepeatCheckModelTjDataSedimentation(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    tjRepository.UpdateModelTjDataSedimentation(item, id);
                //}
                //else
                //{
                //    tjRepository.AddModelTjDataSedimentation(item);
                //}
                tjRepository.AddModelTjDataSedimentation(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_tj_data_segmentring
        /// </summary>
        public OpenApiResult<bool> AddModelTjDataSegmentring(List<ModelTjDataSegmentring> models)
        {
            foreach (var item in models)
            {
                string id = tjRepository.RepeatCheckModelTjDataSegmentring(item);
                if (!string.IsNullOrEmpty(id))
                {
                    tjRepository.UpdateModelTjDataSegmentring(item, id);
                }
                else
                {
                    tjRepository.AddModelTjDataSegmentring(item);
                }
                //tjRepository.AddModelTjDataSegmentring(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_tj_data_structurefacility
        /// </summary>
        public OpenApiResult<bool> AddModelTjDataStructurefacility(List<ModelTjDataStructurefacility> models)
        {
            foreach (var item in models)
            {
                string id = tjRepository.RepeatCheckModelTjDataStructurefacility(item);
                if (!string.IsNullOrEmpty(id))
                {
                    tjRepository.UpdateModelTjDataStructurefacility(item, id);
                }
                else
                {
                    tjRepository.AddModelTjDataStructurefacility(item);
                }
                // tjRepository.AddModelTjDataStructurefacility(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_tj_line
        /// </summary>
        public OpenApiResult<bool> AddModelTjLine(List<ModelTjLine> models)
        {
            foreach (var item in models)
            {
                string id = tjRepository.RepeatCheckModelTjLine(item);
                if (!string.IsNullOrEmpty(id))
                {
                    tjRepository.UpdateModelTjLine(item, id);
                }
                else
                {
                    tjRepository.AddModelTjLine(item);
                }
                // tjRepository.AddModelTjLine(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_tj_structureclassification
        /// </summary>
        public OpenApiResult<bool> AddModelTjStructureclassification(List<ModelTjStructureclassification> models)
        {
            foreach (var item in models)
            {
                string id = tjRepository.RepeatCheckModelTjStructureclassification(item);
                if (!string.IsNullOrEmpty(id))
                {
                    tjRepository.UpdateModelTjStructureclassification(item, id);
                }
                else
                {
                    tjRepository.AddModelTjStructureclassification(item);
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
        /// 新增tb_model_tj_structuretypeweights     土建分类表  v2
        /// </summary>
        public OpenApiResult<bool> AddModelTjStructuretypeweights(List<ModelTjStructuretypeweights> models)
        {
            foreach (var item in models)
            {
                //string id = tjRepository.RepeatCheckModelTjStructuretypeweights(item);
                //if (!string.IsNullOrEmpty(id))
                if (!string.IsNullOrEmpty(item.ID))
                {
                    int id = Convert.ToInt32(item.ID);
                    tjRepository.UpdateModelTjStructuretypeweights(item, id);
                }
                else
                {
                    tjRepository.AddModelTjStructuretypeweights(item);
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
        /// 新增tb_model_tj_structuretypeweights     土建分类表  v2
        /// </summary>
        public OpenApiResult<bool> AddTjDataModelRoadDataCheckvalue(List<ModelRoadDataCheckvalue> models)
        {
            foreach (var item in models)
            {
                string id = tjRepository.RepeatCheckModelRoadDataCheckvalue(item);
                if (!string.IsNullOrEmpty(id))
                //if (!string.IsNullOrEmpty(item.ID))
                {
                    int id2 = Convert.ToInt32(id);
                    tjRepository.UpdateModelRoadDataCheckvalue(item, id2);
                }
                else
                {
                    tjRepository.InsertModelRoadDataCheckvalue(item);
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
        /// 新增tb_model_tj_tunnelsection
        /// </summary>
        public OpenApiResult<bool> AddModelTjTunnelsection(List<ModelTjTunnelsection> models)
        {
            foreach (var item in models)
            {
                string id = tjRepository.RepeatCheckModelTjTunnelsection(item);
                if (!string.IsNullOrEmpty(id))
                {
                    tjRepository.UpdateModelTjTunnelsection(item, id);
                }
                else
                {
                    tjRepository.AddModelTjTunnelsection(item);
                }
                //tjRepository.AddModelTjTunnelsection(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_tj_tunnelstructuretype
        /// </summary>
        public OpenApiResult<bool> AddModelTjTunnelstructuretype(List<ModelTjTunnelstructuretype> models)
        {
            foreach (var item in models)
            {
                string id = tjRepository.RepeatCheckModelTjTunnelstructuretype(item);
                if (!string.IsNullOrEmpty(id))
                {
                    tjRepository.UpdateModelTjTunnelstructuretype(item, id);
                }
                else
                {
                    tjRepository.AddModelTjTunnelstructuretype(item);
                }
                // tjRepository.AddModelTjTunnelstructuretype(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增tb_model_tj_weights
        /// </summary>
        public OpenApiResult<bool> AddModelTjWeights(List<ModelTjWeights> models)
        {
            foreach (var item in models)
            {
                string id = tjRepository.RepeatCheckModelTjWeights(item);
                if (!string.IsNullOrEmpty(id))
                {
                    tjRepository.UpdateModelTjWeights(item, id);
                }
                else
                {
                    tjRepository.AddModelTjWeights(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        #region 项目的结构缺陷信息Web
        public OpenApiResult<List<ModelTjDataDefectsQuery>> GetModelTjDefectsList(ModelTjDataDefectsQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code)||string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelTjDataDefectsQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            List<ModelTjDataDefectsQuery> result = tjRepository.GetModelTjDefectsList(model, out count).ToList();
            return new OpenApiResult<List<ModelTjDataDefectsQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> DeleteModelTjDefects(int id)
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

            bool result = tjRepository.DeleteModelTjDefects(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelTjDefects(ModelTjDataDefectsQuery model)
        {
            bool result = tjRepository.AddModelTjDefects(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public bool AddModelTjDefectsList(List<ModelTjDataDefectsQuery> list)
        {
            tjRepository.DeleteModelTjDefects(list[0].task_no);
            bool result = tjRepository.AddModelTjDefectsList(list);
            return result;
        }
        public OpenApiResult<bool> UpdateModelTjDefects(int id, string field, string value)
        {
            bool result = tjRepository.UpdateModelTjDefects(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        /// <summary>
        /// 实体-excel映射
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public ModelTjDataDefectsQuery DefectsMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelTjDataDefectsQuery result = null;
            try
            {
                result = new ModelTjDataDefectsQuery
                {
                    Date = Convert.ToDateTime(cell[0].ToString()),
                    Line = cell[1].ToString(),
                    StructureSection = cell[2].ToString(),
                    ManagementUnit = cell[3].ToString(),
                    StructureAtt = cell[4].ToString(),
                    StructureType = cell[5].ToString(),
                    ComponentType = cell[6].ToString(),
                    Mileage = cell[7].ToString(),
                    Defect = cell[8].ToString(),
                    DefectType = cell[9].ToString(),
                    DefectSeverity = cell[10].ToString(),
                    DefectDescription = cell[11].ToString(),
                    RingNumber = cell[12].ToString(),
                    project_code = project_code,
                    task_no = task_no
                };
            }
            catch (Exception) { }
            return result;
        }

        public bool DefectsUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List <ModelTjDataDefectsQuery> list = new List<ModelTjDataDefectsQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ?
                             new HSSFWorkbook(ms).GetSheetAt(0) :
                             new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1,
                   rowNum = sheet.LastRowNum;

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

                    ModelTjDataDefectsQuery model = DefectsMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelTjDefectsList(list);
                }
            }
            return result;
        }
        #endregion

        #region 项目的收敛变形信息Web
        public OpenApiResult<List<ModelTjDataDeformationQuery>> GetModelTjDeformationList(ModelTjDataDeformationQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelTjDataDeformationQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            List<ModelTjDataDeformationQuery> result = tjRepository.GetModelTjDeformationList(model, out count).ToList();
            return new OpenApiResult<List<ModelTjDataDeformationQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> DeleteModelTjDeformation(int id)
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

            bool result = tjRepository.DeleteModelTjDeformation(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelTjDeformation(ModelTjDataDeformationQuery model)
        {
            bool result = tjRepository.AddModelTjDeformation(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public bool AddModelTjDeformationList(List<ModelTjDataDeformationQuery> list)
        {
            tjRepository.DeleteModelTjDeformation(list[0].task_no);
            bool result = tjRepository.AddModelTjDeformationList(list);
            return result;
        }
        public OpenApiResult<bool> UpdateModelTjDeformation(int id, string field, string value)
        {
            bool result = tjRepository.UpdateModelTjDeformation(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        /// <summary>
        /// 实体-excel映射
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public ModelTjDataDeformationQuery DeformationMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelTjDataDeformationQuery result = null;
            try
            {
                result = new ModelTjDataDeformationQuery
                {
                    station = cell[0].ToString(),
                    code = cell[1].ToString(),
                    valueName = cell[2].ToString(),
                    valueCode = cell[3].ToString(),
                    deformationValue = Convert.ToDecimal(cell[4].ToString()),
                    date = Convert.ToDateTime(cell[5].ToString()),
                    project_code = project_code,
                    task_no = task_no
                };
            }
            catch (Exception) { }
            return result;
        }

        public bool DeformationUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelTjDataDeformationQuery> list = new List<ModelTjDataDeformationQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ?
                             new HSSFWorkbook(ms).GetSheetAt(0) :
                             new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1,
                   rowNum = sheet.LastRowNum;

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

                    ModelTjDataDeformationQuery model = DeformationMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }

                if (list.Count > 0)
                {
                    result = AddModelTjDeformationList(list);
                }
                
            }
            return result;
        }
        #endregion

        #region 项目的沉降信息模板Web
        public OpenApiResult<List<ModelTjDataSedimentationQuery>> GetModelTjSedimentationList(ModelTjDataSedimentationQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code) || string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelTjDataSedimentationQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            List<ModelTjDataSedimentationQuery> result = tjRepository.GetModelTjSedimentationList(model, out count).ToList();
            return new OpenApiResult<List<ModelTjDataSedimentationQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> DeleteModelTjSedimentation(int id)
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

            bool result = tjRepository.DeleteModelTjSedimentation(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> AddModelTjSedimentation(ModelTjDataSedimentationQuery model)
        {
            bool result = tjRepository.AddModelTjSedimentation(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public bool AddModelTjSedimentationList(List<ModelTjDataSedimentationQuery> list)
        {
            tjRepository.DeleteModelTjSedimentation(list[0].task_no);
            bool result = tjRepository.AddModelTjSedimentationList(list);
            return result;
        }
        public OpenApiResult<bool> UpdateModelTjSedimentation(int id, string field, string value)
        {
            bool result = tjRepository.UpdateModelTjSedimentation(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        /// <summary>
        /// 实体-excel映射
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public ModelTjDataSedimentationQuery SedimentationMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelTjDataSedimentationQuery result = null;
            try
            {
                result = new ModelTjDataSedimentationQuery
                {
                    Code_R = cell[0].ToString(),
                    Value_R = cell[1].ToString(),
                    Code_L = cell[2].ToString(),
                    Value_L = cell[3].ToString(),
                    station = cell[4].ToString(),
                    start_date = Convert.ToDateTime(cell[5].ToString()),
                    end_date = Convert.ToDateTime(cell[6].ToString()),
                    project_code = project_code,
                    task_no = task_no
                };
            }
            catch (Exception) { }
            return result;
        }

        public bool SedimentationUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelTjDataSedimentationQuery> list = new List<ModelTjDataSedimentationQuery>();
            var filePath = file.FileName.Split('.');
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var sheet = filePath[1].ToLower() == ".xls" ?
                             new HSSFWorkbook(ms).GetSheetAt(0) :
                             new XSSFWorkbook(ms).GetSheetAt(0);
                IRow row = null;
                int startRow = 1,
                   rowNum = sheet.LastRowNum;

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

                    ModelTjDataSedimentationQuery model = SedimentationMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelTjSedimentationList(list);
                }
               
            }
            return result;
        }
        #endregion

        #region  待评价项目的损坏类型信息

        /// <summary>
        /// 新增tb_model_road_damagetype
        /// </summary>
        public OpenApiResult<bool> InsertModelRoadDamageType(List<ModelRoadDamageType> models)
        {
            foreach (var item in models)
            {
                //item.Date = item.Date.Value.Date;
                //string id = tjRepository.RepeatCheckModelTjDataDefects(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    tjRepository.UpdateModelTjDataDefects(item, id);
                //}
                //else
                //{
                //    tjRepository.AddModelTjDataDefects(item);
                //}
                tjRepository.InsertModelRoadDamageType(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

        #region  待评价项目的检测信息

        /// <summary>
        /// 新增tb_model_road_checkunitinfo
        /// </summary>
        public OpenApiResult<bool> InsertModelRoadCheckUnitInfo(List<ModelRoadCheckUnitInfo> models)
        {
            foreach (var item in models)
            {
                string id = tjRepository.RepeatCheckModelRoadCheckUnitInfo(item);
                if (!string.IsNullOrEmpty(id))
                {
                    tjRepository.UpdateModelRoadCheckUnitInfo(item, id);
                }
                else
                {
                    tjRepository.InsertModelRoadCheckUnitInfo(item);
                }
                //tjRepository.InsertModelRoadDamageType(item);
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        #endregion

    }
}