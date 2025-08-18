using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Rcbi.Framework.Response
{
    public partial class PagingResponse<T> : BaseResponse
    {
        /// <summary>
        /// extra data
        /// </summary>
        [JsonProperty("extraData")]
        [XmlElement("extraData")]
        public object ExtraData { get; set; }

        /// <summary>
        /// data items
        /// </summary>
        [JsonProperty("items")]
        [XmlElement("items")]
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// total count
        /// </summary>
        [JsonProperty("total")]
        [XmlElement("total")]
        public int Total { get; set; }
    }
}
