namespace Rcbi.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public static class CollectionExtension
    {
        //[DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return (collection == null) || (collection.Count == 0);
        }

        public static string ToJson<T>(this ICollection<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            return JsonConvert.SerializeObject(collection);
        }

        public static string ToJson<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            return JsonConvert.SerializeObject(collection);
        }
    }
}