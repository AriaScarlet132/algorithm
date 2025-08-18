using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Rcbi.Framework.Response
{
    public partial class ResultResponse<T> : BaseResponse
    {
        /// <summary>
        /// result response
        /// </summary>
        [XmlElement("result")]
        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
