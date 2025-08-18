using Rcbi.Core.Extensions;

namespace Rcbi.Entity.Query
{
    public class ProjectQuery : LayuiQuery
    {
        public string ProjectName { get; set; }

        public override CommonQuery ToCommonQuery()
        {
            var query = this.Create();
            if (!ProjectName.IsNullOrEmpty())
            {
                #region 原写法
                //query.External = string.Format(" ( short_name like '%{0}%' or full_name like '%{0}%' ) ",
                //    ProjectName.Replace("'", "''")); 
                #endregion

                var str = ProjectName.Replace("'", "''");

                query.External = $" ( short_name like '%{str}%' or full_name like '%{str}%' ) ";
            }

            return query;
        }
    }
}
