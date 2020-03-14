using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Bushuosx.ObserverPattern
{
    public class Publisher<TSubject> : IPublisher<TSubject>
    {
        //private readonly ConcurrentQueue<TSubject> _subjects = new ConcurrentQueue<TSubject>();
        private readonly ConcurrentDictionary<ISubscriber<TSubject>, DateTime> _subscribers = new ConcurrentDictionary<ISubscriber<TSubject>, DateTime>();

        public virtual List<Task> Publish(TSubject subject)
        {
            //_subjects.Enqueue(subject);

            List<Task> rst = new List<Task>();
            foreach (var sber in _subscribers)
            {
                rst.Add(sber.Key.ProcessAsync(subject));
            }
            return rst;
        }


        public IDisposable Subscribe(ISubscriber<TSubject> subscriber)
        {
            var stmap = DateTime.Now;
            //如果键已存在，Tryadd会返回false
            if (_subscribers.TryAdd(subscriber, stmap))
            {
                return new Unsubscriber<TSubject>(this, subscriber, stmap);
            }
            else
            {
                return null;
            }
        }

        public void Unsubscribe(ISubscriber<TSubject> subscriber, DateTime stmap)
        {
            if (_subscribers.ContainsKey(subscriber))
            {
                if (stmap == _subscribers[subscriber])
                {
                    _subscribers.TryRemove(subscriber, out var guid);
                }
                else
                {
                    //攻击警告
                }
            }
        }
    }
}
