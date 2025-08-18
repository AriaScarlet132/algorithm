using System;
using System.Collections.Generic;

namespace Rcbi.Entity
{
    /// <summary>
    /// 执行结果实体类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class OpreationResult<T> : List<T>
    {
        public bool IsSuccess 
        {
            get 
            {
                return this.Count == 0;
            }
        }

        public OpreationResult() 
        {
        }

        public OpreationResult(IEnumerable<T> items) 
        {
            this.AddRange(items);
        }

        public OpreationResult<T> AddWithSelf(T item) 
        {
            this.Add(item);
            return this;
        }
    }
}
