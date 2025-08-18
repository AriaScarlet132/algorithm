using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.Framework.Helper
{
    public class DTreeNode
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("basicData")]
        public object BasicData { get; set; }

        [JsonProperty("spread")]
        public bool Spread { get; set; }
        
        [JsonProperty("checkArr")]
        public CheckStatus CheckArr { get; set; }

        public class CheckStatus
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("isChecked")]
            public string IsChecked { get; set; }
        }
    }
}
