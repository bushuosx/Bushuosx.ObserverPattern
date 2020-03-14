using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bushuosx.ObserverPattern
{
    public interface ISubscriber<TSubject>
    {
        /// <summary>
        /// 订阅者的资源处理机制。
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        Task ProcessAsync(TSubject subject);

        /// <summary>
        /// 由提供者传递的消息
        /// </summary>
        /// <param name="publiserMessage"></param>
        /// <returns></returns>
        Task PubliserMessageAsync(PubliserMessage publiserMessage);
    }
}
