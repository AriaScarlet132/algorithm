using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.iisp.Publisher
{
    public interface ISubscriber
    {
        /// <summary>
        ///
        /// </summary>
        void Dispose();
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channelName"></param>
        /// <returns></returns>
        void Subscribe(string channelName, Action<string> callback);
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channelName"></param>
        /// <returns></returns>
        Task<T> SubscribeAsync<T>(string channelName) where T : class;
    }
}
