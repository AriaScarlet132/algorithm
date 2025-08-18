using System;

using Rcbi.Core.Extensions;

namespace Rcbi.Entity.Query
{
    public class UserQuery : LayuiQuery
    {
        public string UserName { get; set; }

        public string KeyWord { get; set; }

        public override CommonQuery ToCommonQuery()
        {
            var query = this.Create();
            if (!UserName.IsNullOrEmpty())
                query.Filters.Add(new Filter() { Filed = "user_name", Op = "like", Data = UserName });
            if (!KeyWord.IsNullOrEmpty())
                query.External = string.Format("(real_name like '%{0}%' or email like '%{0}%' or mobile like '%{0}%')", KeyWord.Replace("'", "''"));

            return query;
        }
    }
}
