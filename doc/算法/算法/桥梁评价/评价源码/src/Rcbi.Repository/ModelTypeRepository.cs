using Rcbi.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.Repository
{
    public class ModelTypeRepository : BaseRepository<ModelType>
    {
        public IList<ModelType> GetFacility(string model_type)
        {
            var sql = " SELECT *  FROM tb_model_type WHERE type_code=@model_type;";
            return this.ExecuteReaderList(sql
                , this.DbHelper.CreateParameter("@model_type", model_type));
        }
    }
}
