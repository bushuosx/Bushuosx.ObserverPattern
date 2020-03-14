using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bushuosx.ObserverPattern
{
    public interface IPublisher<TSubject>
    {
        /// <summary>
        /// 由资源产生方调用，提供者会将此资源转发给订阅者
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        List<Task> Publish(TSubject subject);

        /// <summary>
        /// 发起订阅，等待执行资源处理。
        /// </summary>
        /// <param name="subscriber"></param>
        /// <returns>订阅者可以保留此项，需要时可以解除订阅</returns>
        IDisposable Subscribe(ISubscriber<TSubject> subscriber);

        /// <summary>
        /// 由订阅者调用，解除订阅
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="_subscriptionStmap"></param>
        void Unsubscribe(ISubscriber<TSubject> subscriber, DateTime _subscriptionStmap);
    }
}
