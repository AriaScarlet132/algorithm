using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Rcbi.Core.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex WebUrlExpression = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex EmailExpression = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex StripHTMLExpression = new Regex("<\\S[^><]*>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        private static readonly char[] IllegalUrlCharacters = new[] { ';', '/', '\\', '?', ':', '@', '&', '=', '+', '$', ',', '<', '>', '#', '%', '.', '!', '*', '\'', '"', '(', ')', '[', ']', '{', '}', '|', '^', '`', '~', '–', '‘', '’', '“', '”', '»', '«' };

        //[DebuggerStepThrough]
        public static bool IsWebUrl(this string target)
        {
            return !string.IsNullOrEmpty(target) && WebUrlExpression.IsMatch(target);
        }

        //[DebuggerStepThrough]
        public static bool IsEmail(this string target)
        {
            return !string.IsNullOrEmpty(target) && EmailExpression.IsMatch(target);
        }

        //[DebuggerStepThrough]
        public static string NullSafe(this string target)
        {
            return (target ?? string.Empty).Trim();
        }

        //[DebuggerStepThrough]
        public static string Hash(this string target)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = Encoding.Unicode.GetBytes(target);
                byte[] hash = md5.ComputeHash(data);

                return Convert.ToBase64String(hash);
            }
        }

        //[DebuggerStepThrough]
        public static string StripHtml(this string target)
        {
            return StripHTMLExpression.Replace(target, string.Empty);
        }

        //[DebuggerStepThrough]
        public static Guid ToGuid(this string target)
        {
            Guid result = Guid.Empty;

            if ((!string.IsNullOrEmpty(target)) && (target.Trim().Length == 22))
            {
                string encoded = string.Concat(target.Trim().Replace("-", "+").Replace("_", "/"), "==");

                try
                {
                    byte[] base64 = Convert.FromBase64String(encoded);

                    result = new Guid(base64);
                }
                catch (FormatException)
                {
                }
            }

            return result;
        }

        //[DebuggerStepThrough]
        public static T ToEnum<T>(this string target, T defaultValue) where T : IComparable, IFormattable
        {
            T convertedValue = defaultValue;

            if (!string.IsNullOrEmpty(target))
            {
                try
                {
                    convertedValue = (T)Enum.Parse(typeof(T), target.Trim(), true);
                }
                catch (ArgumentException)
                {
                }
            }

            return convertedValue;
        }

        //[DebuggerStepThrough]
        public static string UrlEncode(this string target)
        {
            return HttpUtility.UrlEncode(target);
        }

        //[DebuggerStepThrough]
        public static string UrlDecode(this string target)
        {
            return HttpUtility.UrlDecode(target);
        }

        //[DebuggerStepThrough]
        public static string AttributeEncode(this string target)
        {
            return HttpUtility.HtmlAttributeEncode(target);
        }

        //[DebuggerStepThrough]
        public static string HtmlEncode(this string target)
        {
            return HttpUtility.HtmlEncode(target);
        }

        //[DebuggerStepThrough]
        public static string HtmlDecode(this string target)
        {
            return HttpUtility.HtmlDecode(target);
        }

        public static string Replace(this string target, ICollection<string> oldValues, string newValue)
        {
            oldValues.ForEach(oldValue => target = target.Replace(oldValue, newValue));
            return target;
        }

        public static string SubstringLength(this string target, int length, string ifGreaterAddEnd = "...")
        {
            if (!string.IsNullOrWhiteSpace(target) && target.Length > length)
                return target.Substring(0, length) + ifGreaterAddEnd;
            else
                return target;
        }

        /// <summary>
        /// 为空或者""
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// 判断是否是日期
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string source)
        {
            if (source.IsNullOrEmpty())
                return false;

            DateTime dt;

            return DateTime.TryParse(source, out dt);
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Formator(this string source, params object[] args)
        {
            if (source.IsNullOrEmpty())
                return source;

            return string.Format(source, args);
        }

        /// <summary>
        /// 判断字符长度是否大于给的的长度
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool IsGreaterThan(this string source, int length)
        {
            if (source == null) return false;
            return source.Length > length;
        }

        /// <summary>
        ///  去掉空格,如果值为null,则返回默认值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToTrim(this string source, string defaultVal = "")
        {
            if (source == null) return defaultVal;
            return source.Trim();
        }

        public static Boolean IsNumeric(this String str)
        {
            Int32 temp_big_int;
            var is_number = Int32.TryParse(str, out temp_big_int);
            return is_number;
        }

        public static Boolean IsDecimal(this String str)
        {
            Decimal temp_big_int;
            var is_number = Decimal.TryParse(str, out temp_big_int);
            return is_number;
        }

        /// <summary>
        /// Deserializes the current JSON string to a object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="target">The JSON string to deserialize.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        public static T ToObject<T>(this string target)
        {
            return target == null ? default(T) : JsonConvert.DeserializeObject<T>(target);
        }

        /// <summary>
        /// Deserializes the current JSON string to a collection of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the collection to deserialize to.</typeparam>
        /// <param name="target">The JSON string to deserialize.</param>
        /// <returns>The deserialized collection from the JSON string.</returns>
        public static IEnumerable<T> ToList<T>(this string target)
        {
            return target == null ? null : JsonConvert.DeserializeObject<IEnumerable<T>>(target);
        }

        public static string TrimStart(this string source, string trim, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (source == null)
            {
                return null;
            }

            string s = source;
            while (s.StartsWith(trim, stringComparison))
            {
                s = s.Substring(trim.Length);
            }

            return s;
        }

        /// <summary>
        /// 分割逗号的字符串为List<string>
        /// </summary>
        /// <param name="csvList"></param>
        /// <param name="nullOrWhitespaceInputReturnsNull">nullorwhitespace字符串是否返回空对象</param>
        /// <returns></returns>
        public static List<string> SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(s => s.Trim())
                .ToList();
        }

        public static bool IsNullOrWhitespace(this string s)
        {
            return String.IsNullOrWhiteSpace(s);
        }

    }
}
