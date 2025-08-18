using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.iisp.Consumer
{
    public interface IPublisher
    {
        /// <summary>
        /// 释放资源。
        /// </summary>
        void Dispose();
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        void Publish<T>(T message) where T : class;
        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="channelName"></param>
        void Publish(string message, string channelName);
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        Task PublishAsync<T>(T message) where T : class;
    }
}
