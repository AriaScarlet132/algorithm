using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rcbi.AspNetCore.Helper
{
    /// <summary>
    /// 日期格式化，格式化 yyyy-MM-dd
    /// </summary>
    public class DateFormat : IsoDateTimeConverter
    {
        /// <summary>
        /// 默认日期格式
        /// </summary>
        public DateFormat() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss"; }
        /// <summary> 
        /// 日期格式
        /// </summary>
        public DateFormat(string format) { DateTimeFormat = format; }
    }
}
