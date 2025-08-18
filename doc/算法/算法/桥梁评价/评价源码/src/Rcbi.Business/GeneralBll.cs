using System.Collections.Generic;
using System.Data;

using Rcbi.Entity;
using Rcbi.Core.Extensions;
using Rcbi.Entity.Domain;
using Rcbi.Repository;
using Rcbi.Core;
using Rcbi.Entity.Query;
using System.Linq;
using System;

namespace Rcbi.Business
{
    public class GeneralBll
    {
        /// <summary>
        /// 根据编码获取字典配置
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static IList<GeneralContent> GetGeneralsByCode(string code)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetGeneralsByCode(code).ToList<GeneralContent>();
            }
        }

        /// <summary>
        /// 根据编码获取字典配置，带父级
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static IList<GeneralContent> GetGeneralsByCodeOfParent(string code)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetGeneralsByCodeOfParent(code).ToList<GeneralContent>();
            }
        }

        public static IList<GeneralContent> GetGeneralsByCodeOfChild(string code)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetGeneralsByCodeOfChild(code).ToList<GeneralContent>();
            }
        }

        /// <summary>
        /// 所有字典类型
        /// </summary>
        /// <returns></returns>
        public static IList<General> GetAllTypes()
        {
            using (var db = new GeneralRepository())
            {
                return db.GetAllTypes().ToList<General>();
            }
        }

        /// <summary>
        /// 所有字典父级类型
        /// </summary>
        /// <returns></returns>
        public static IList<GeneralContent> GetParentTypes()
        {
            using (var db = new GeneralRepository())
            {
                return db.GetParentTypes().ToList<GeneralContent>();
            }
        }

        /// <summary>
        /// 获取通用类容
        /// </summary>
        /// <returns></returns>
        public static DataTable GetParentTypes(string GenrealCode)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetContents(GenrealCode);
            }
        }
        /// <summary>
        /// 通用表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static IList<GeneralContent> GetAllGeneral(BaseQueryEntity query)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetAllGeneral(query).ToList<GeneralContent>();
            }
        }

        public static IList<GeneralContent> GetGeneralsByCodeAndKey(string code, string key)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetGeneralsByCodeAndKey(code, key).ToList<GeneralContent>();
            }
        }

        public static IList<GeneralType> GetGeneralType()
        {
            using (var db = new GeneralRepository())
            {
                return db.GetGeneralType().ToList<GeneralType>();
            }
        }

        public static IList<General> GetGeneral(int general_type_id)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetGeneral(general_type_id).ToList<General>();
            }
        }

        public static IList<GeneralContent> GetGeneralContent(string general_code)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetGeneralContent(general_code).ToList<GeneralContent>();
            }
        }

        public static IList<GeneralContent> GetGeneralContent(string general_code, string general_key)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetGeneralContent(general_code, general_key).ToList<GeneralContent>();
            }
        }

        public static DataTable GetGeneralFields(string general_code)
        {
            using (var db = new GeneralRepository())
            {
                return db.GetGeneralFields(general_code);
            }
        }

        public static bool IsExists(string general_code, string general_key)
        {
            using (var db = new GeneralRepository())
            {
                return db.IsExists(general_code, general_key);
            }
        }

        public static List<ModelFINConProjectUnitCount> GetModelFINConProjectUnitCountBatch(string taskno)
        {
            using (var db = new CostAnalysisRepository())
            {
                return db.GetModelFINConProjectUnitCountBatch(taskno).ToList();
            }
        }

        public static List<ModelFINConProjectCount> GetModelFINConProjectCountBatch(string taskno)
        {
            using (var db = new CostAnalysisRepository())
            {
                return db.GetModelFINConProjectCountBatch(taskno).ToList();
            }
        }

        public static List<MdelFINConIndiscount> GetMdelFINConIndiscountBatch(string taskno)
        {
            using (var db = new CostAnalysisRepository())
            {
                return db.GetMdelFINConIndiscountBatch(taskno).ToList();
            }
        }
        public static List<ModelFINConFeeDiscount> GetInsertModelFINConFeeDiscountBatchs(string taskno)
        {
            using (var db = new CostAnalysisRepository())
            {
                return db.GetInsertModelFINConFeeDiscountBatchs(taskno).ToList();
            }
        }

        public static ModelFINConMain GetModelFINConMain(string taskno)
        {
            ModelFINConMain modelFINConMain = new ModelFINConMain();
            using (var db = new CostAnalysisRepository())
            {
                modelFINConMain = db.GetModelFINConMain(taskno);
            }
            if (modelFINConMain == null)
            {
                return modelFINConMain;
            }
            IList<GeneralContent> TaskModel = GeneralBll.GetGeneralsByCode("TaskModel");
            TaskModel = TaskModel.Where(a => a.GeneralKey == modelFINConMain.TaskModel).ToList();
            if (TaskModel != null && TaskModel.Count > 0)
            {
                modelFINConMain.TaskModel = TaskModel[0].Content;
            }
            return modelFINConMain;
        }

        public static bool DeleteModelFINMaterialPrice(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("id");
            }
            using (CostAnalysisRepository db = new CostAnalysisRepository())
            {
                bool result = db.DeleteModelFINMaterialPrice(id);
                return result;
            }
        }

        public static bool AddModelFINMaterialPrice(List<ModelFINMaterialPrice> list)
        {
            if (list == null || list.Count <= 0)
            {
                return false;
            }
            using (CostAnalysisRepository db = new CostAnalysisRepository())
            {
                bool result = db.AddModelFINMaterialPrice(list);
                return result;
            }
        }

        public static bool UpdateModelFINMaterialPrice(int id, string field, string value)
        {
            if(field== "materialPrice")
            {
                if (!value.IsDecimal())
                {
                    throw new Exception("材料单价不是数字");
                }
            }
            using (CostAnalysisRepository db = new CostAnalysisRepository())
            {
                bool result = db.UpdateModelFINMaterialPrice(id,field,value);
                return result;
            }
        }
    }
}
