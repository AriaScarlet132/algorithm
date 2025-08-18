using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Headers;

namespace Rcbi.Framework.TypeFormatter
{
    /*
    /// <summary>
    /// JSONP Formatter
    /// </summary>
    public class JsonpMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public string Callback { get; private set; }

        public JsonpMediaTypeFormatter(string callback = null) 
        {
            this.Callback = callback;
        }

        public override Task WriteToStreamAsync(Type type, 
            object value, 
            Stream writeStream, 
            HttpContent content, 
            TransportContext transportContext)
        {
            if (string.IsNullOrEmpty(this.Callback)) {
                return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }

            try
            {
                this.WriteToStream(type, value, writeStream, content);
                return Task.FromResult<AsyncVoid>(new AsyncVoid());
            }
            catch (Exception ex) {
                TaskCompletionSource<AsyncVoid> source = new TaskCompletionSource<AsyncVoid>();
                source.SetException(ex);
                return source.Task;
            }
        }

        private void WriteToStream(Type type, 
            object value, 
            Stream writeStream, 
            HttpContent content) 
        {
            var effectiveEncoding = this.SelectCharacterEncoding(content == null ? null : content.Headers);
            if (content != null)
                content.Headers.ContentType = new MediaTypeHeaderValue("application/javascript");
            var serializer = JsonSerializer.Create(this.SerializerSettings);
            using (var jsonWriter = this.CreateJsonWriter(type, writeStream, effectiveEncoding))
            {
                jsonWriter.CloseOutput = false;
                jsonWriter.WriteRaw(this.Callback + "(");
                serializer.Serialize(jsonWriter, value);
                jsonWriter.WriteRaw(")");
                jsonWriter.Flush();
            }
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type,
            HttpRequestMessage request,
            MediaTypeHeaderValue mediaType) 
        {
            if (request.Method != HttpMethod.Get) 
            {
                return this;
            }

            string callback;
            if (request.GetQueryNameValuePairs().ToDictionary(pair => pair.Key,
                pair => pair.Value).TryGetValue("callback", out callback)) 
            {
                return new JsonpMediaTypeFormatter(callback);
            }

            return this;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct AsyncVoid 
        {
        }
    }*/
}