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
    public class FacilityBll
    {
        FacilityRepository facilityRepository = new FacilityRepository();

        /// <summary>
        /// 附属设施信息
        /// </summary>
        public OpenApiResult<ModelAfInfos> GetModelAfInfos(string task_no)
        {
            ModelAfInfos data = new ModelAfInfos();
            data.ModelAFResult = facilityRepository.GetModelAFResult(task_no);
            data.ModelAFResultCategorys = facilityRepository.GetModelAFResultCategorys(task_no); ;
            data.ModelAFResultTypes = facilityRepository.GetModelAFResultTypes(task_no);
            data.ModelAFResultLines = facilityRepository.GetModelAFResultLine(task_no);
            return new OpenApiResult<ModelAfInfos>
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
            var result = IispBll.StartTask(task, UserId, "AFEVA");
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
                model_type = "AFEVA"
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
        /// 新增附属设施清单
        /// </summary>
        public OpenApiResult<bool> AddModelAfFacilitylist(List<ModelAfFacilitylist> models)
        {
            foreach (var item in models)
            {
                item.CheckDate = item.CheckDate.Date;
                string id = facilityRepository.RepeatCheckList(item);
                if (!string.IsNullOrEmpty(id))
                {
                    facilityRepository.UpdateList(item, id);
                }
                else
                {
                    facilityRepository.AddList(item);
                }
                //facilityRepository.AddList(item);
            }

            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增附属设施清单
        /// </summary>
        public OpenApiResult<bool> AddModelAfFacilitylist2(List<ModelAfFacilitylist2> models)
        {
            foreach (var item in models)
            {
                item.CheckDate = item.CheckDate.Date;
                string id = facilityRepository.RepeatCheckList(item);
                if (!string.IsNullOrEmpty(id))
                {
                    facilityRepository.UpdateList(item, id);
                }
                else
                {
                    facilityRepository.AddList(item);
                }
                //facilityRepository.AddList(item);
            }

            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增附属子设施检查评分明细
        /// </summary>
        public OpenApiResult<bool> AddModelAfFacilityCheckValue(List<ModelAfFacilityCheckValue> models)
        {
            foreach (var item in models)
            {
                //item.CheckDate = item.CheckDate.Value.Date;
                //string id = facilityRepository.RepeatCheckCheckValues(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    facilityRepository.UpdateCheckValues(item, id);
                //}
                //else
                //{
                //    facilityRepository.AddCheckValues(item);
                //}
                facilityRepository.AddCheckValues(item);
            }

            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        /// <summary>
        /// 新增附属子设施检查评分明细
        /// </summary>
        public OpenApiResult<bool> AddModelAfFacilityCheckValue(List<ModelAfFacilityCheckValue2> models)
        {
            foreach (var item in models)
            {
                //item.CheckDate = item.CheckDate.Value.Date;
                //string id = facilityRepository.RepeatCheckCheckValues(item);
                //if (!string.IsNullOrEmpty(id))
                //{
                //    facilityRepository.UpdateCheckValues(item, id);
                //}
                //else
                //{
                //    facilityRepository.AddCheckValues(item);
                //}
                facilityRepository.AddCheckValues(item);
            }

            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }


        /// <summary>
        /// 新增附属设施检查评分标准数据
        /// </summary>
        public OpenApiResult<bool> AddAfFacilityMarkSpec(List<ModelAFFacilityMarkSpec> models)
        {
            foreach (var item in models)
            {
                string id = facilityRepository.RepeatCheckMarkSpec(item);
                if (!string.IsNullOrEmpty(id))
                {
                    facilityRepository.UpdateMarkSpec(item, id);
                }
                else
                {
                    facilityRepository.AddMarkSpec(item);
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
        /// 新增附属子设施量汇总数据
        /// </summary>
        public OpenApiResult<bool> AddAfFacilityNum(List<ModelAFFacilityNum> models)
        {
            foreach (var item in models)
            {
                string id = facilityRepository.RepeatCheckNum(item);
                if (!string.IsNullOrEmpty(id))
                {
                    facilityRepository.UpdateNum(item, id);
                }
                else
                {
                    facilityRepository.AddNum(item);
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
        /// 新增附属分设施评价结果数据
        /// </summary>
        public OpenApiResult<bool> AddAfTypeWeight(List<ModelAFTypeWeight> models)
        {
            foreach (var item in models)
            {
                string id = facilityRepository.RepeatCheckTypeWeight(item);
                if (!string.IsNullOrEmpty(id))
                {
                    facilityRepository.UpdateTypeWeight(item, id);
                }
                else
                {
                    facilityRepository.AddTypeWeight(item);
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
        /// 新增附属分设施评价结果数据
        /// </summary>
        public OpenApiResult<bool> addbridgetypeweight2(List<Modelbridgetypeweight> models)
        {
            foreach (var item in models)
            {
                string id = facilityRepository.RepeatCheckBridgeTypeWeight(item);
                if (!string.IsNullOrEmpty(id))
                {
                    facilityRepository.UpdateTypeWeight(item, id);
                }
                else
                {
                    facilityRepository.AddTypeWeight(item);
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
        /// 新增附属设施检查评分标准数据
        /// </summary>
        public OpenApiResult<bool> addbridgefacilitymarkspec2(List<Modelbridgefacilitymarkspec> models)
        {
            foreach (var item in models)
            {
                string id = facilityRepository.RepeatCheckbridgeMarkSpec(item);
                if (!string.IsNullOrEmpty(id))
                {
                    facilityRepository.UpdateMarkSpec(item, id);
                }
                else
                {
                    facilityRepository.AddMarkSpec(item);
                }
            }
            return new OpenApiResult<bool>
            {
                Data = true,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        #region 附属子设施检查评分明细Web
        public OpenApiResult<List<ModelAfCheckValueQuery>> GetModelAfCheckValueList(ModelAfCheckValueQuery model, out int count)
        {
            if (string.IsNullOrEmpty(model.project_code)|| string.IsNullOrEmpty(model.task_no))
            {
                count = 0;
                return new OpenApiResult<List<ModelAfCheckValueQuery>>
                {
                    Data = null,
                    Status = (int)OpenApiResultStatus.PARAMETER_CHECK_ERROR,
                    Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.PARAMETER_CHECK_ERROR)
                };
            }

            List<ModelAfCheckValueQuery> result = facilityRepository.GetModelAfCheckValueList(model, out count).ToList();
            return new OpenApiResult<List<ModelAfCheckValueQuery>>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> DeleteModelAfCheckValue(int id)
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

            bool result = facilityRepository.DeleteModelAfCheckValue(id);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }
        public OpenApiResult<bool> AddModelAfCheckValue(ModelAfCheckValueQuery model)
        {
            bool result = facilityRepository.AddModelAfCheckValue(model);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public OpenApiResult<bool> UpdateModelAfCheckValue(int id, string field, string value)
        {
            bool result = facilityRepository.UpdateModelAfCheckValue(id, field, value);
            return new OpenApiResult<bool>
            {
                Data = result,
                Status = (int)OpenApiResultStatus.SUCCESS,
                Message = EnumHelper.GetEnumDescription(OpenApiResultStatus.SUCCESS)
            };
        }

        public bool AddModelAfCheckValueList(List<ModelAfCheckValueQuery> list)
        {
            facilityRepository.DeleteModelAfCheckValue(list[0].task_no);
            bool result= facilityRepository.AddModelAfCheckValueList(list);
            return result;
        }

        /// <summary>
        /// 实体-excel映射
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public ModelAfCheckValueQuery CheckValueMapping(ICell[] cell, string project_code, string task_no)
        {
            ModelAfCheckValueQuery result = null;
            try
            {
                result = new ModelAfCheckValueQuery
                {
                    FacilityName = cell[0].ToString(),
                    FacilityName_Code = cell[1].ToString(),
                    CheckMarkValue = Convert.ToInt32(cell[2].ToString()),
                    CheckDesp = cell[3].ToString(),
                    CheckPic = cell[4].ToString(),
                    CheckPerson = cell[5].ToString(),
                    CheckDate = Convert.ToDateTime(cell[6].ToString()),
                    CheckMemo = cell[7].ToString(),
                    task_no = task_no,
                    project_code = project_code
                };
            }
            catch (Exception) { }
            return result;
        }

        public bool CheckValueUploadFile(IFormFile file, string project_code, string task_no)
        {
            bool result = false;
            List<ModelAfCheckValueQuery> list = new List<ModelAfCheckValueQuery>();
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

                    ModelAfCheckValueQuery model = CheckValueMapping(cell, project_code, task_no);
                    if (model == null)
                    {
                        continue;
                    }
                    list.Add(model);
                }
                if (list.Count > 0)
                {
                    result = AddModelAfCheckValueList(list);
                }
            }
            return result;
        }

        public IList<ModelAfFacilitylist> GetModelAfFacilityList(string project_code)
        {
            return facilityRepository.GetModelAfFacilityList(project_code);
        }
        #endregion
    }
}
