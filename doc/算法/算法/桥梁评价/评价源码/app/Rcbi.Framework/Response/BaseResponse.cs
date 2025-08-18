using System;
using System.Xml.Serialization;

using Newtonsoft.Json;
using Rcbi.Entity.Enums;
using Rcbi.Core.Json;

namespace Rcbi.Framework.Response
{
    [Serializable]
    public abstract partial class BaseResponse
    {
        private ContentType _contentType;

        public BaseResponse() : this(ContentType.Json)
        {
        }
        public BaseResponse(ContentType contentType) 
        {
            this._contentType = contentType;
        }
        /// <summary>
        /// success
        /// </summary>
        [JsonProperty("success")]
        [XmlElement("success")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or set errors message
        /// </summary>
        [JsonProperty("errors")]
        [XmlElement("errors")]
        public object Errors { get; set; }

        /// <summary>
        /// the content type
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public ContentType ContentType 
        {
            get {
                return this._contentType;
            }
            set {
                this._contentType = value;
            }
        }

        public override string ToString()
        {
            switch (_contentType)
            {
                case ContentType.Json:
                    return this.ToJsonString();
                case ContentType.Xml:
                    throw new InvalidCastException("no support xml serializer");
                default:
                    throw new InvalidCastException("no support serializer");
            }
        }
    }
}
