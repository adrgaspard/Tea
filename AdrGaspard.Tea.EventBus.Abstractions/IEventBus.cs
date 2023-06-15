using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdrGaspard.Tea.EventBus.Abstractions
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent eventData) where TEvent : class;

        Task PublishAsync(Type eventType, object eventData);

        IDisposable Subscribe<TEvent>(Func<TEvent, Task> action) where TEvent : class;

        IDisposable Subscribe<TEvent, THandler>() where TEvent : class where THandler : IEventHandler, new();

        IDisposable Subscribe(Type eventType, IEventHandler handler);

        void Unsubscribe<TEvent>(Func<TEvent, Task> action) where TEvent : class;

        void Unsubscribe<TEvent>(ILocalEventHandler<TEvent> handler) where TEvent : class;

        void Unsubscribe(Type eventType, IEventHandler handler);

        void UnsubscribeAll<TEvent>() where TEvent : class;

        void UnsubscribeAll(Type eventType);
    }
}
