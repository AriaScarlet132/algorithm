using System;
using System.ComponentModel;
using System.Globalization;

namespace Rcbi.Core.Extensions
{
    public static class ObjectExtension
    {
        public static bool IsNullOrEmpty(this object value)
        {
            //如果为null
            if (value == null)
            {
                return true;
            }

            //如果为""
            if (value.GetType() == typeof(String))
            {
                if (value.ToString().IsNullOrEmpty())
                {
                    return true;
                }
            }

            //如果为DBNull
            if (value.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }

        /// <summary>
        /// Casts the current object to a type.
        /// </summary>  
        /// <typeparam name="T">The type to cast the value to.</typeparam>
        /// <param name="target">The object to cast.</param>
        /// <returns>A casted value.</returns>
        public static T As<T>(this object target) where T : class
        {
            return (T)target;
        }

        /// <summary>
        /// Converts the value.
        /// </summary>
        /// <param name="target">The object to convert.</param>
        /// <typeparam name="T">The type to convert the value to.</typeparam>
        /// <returns>A converted value.</returns>
        public static T To<T>(this object target)
            where T : struct
        {
            if (typeof(T) == typeof(Guid))
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(target.ToString());
            }

            return (T)Convert.ChangeType(target, typeof(T), CultureInfo.InvariantCulture);
        }
    }
}
