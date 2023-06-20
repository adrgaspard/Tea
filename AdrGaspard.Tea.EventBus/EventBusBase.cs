using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.EventBus.Exceptions;
using System.Reflection;

namespace AdrGaspard.Tea.EventBus
{
    public abstract class EventBusBase : IEventBus, IDisposable
    {
        private const string HandleMethodName = nameof(IEventHandler<IntegrationEvent>.Handle);
        private static readonly Type GenericEventHandlerInterfaceType;
        private readonly Dictionary<Type, SortedSet<Subscription>> _subscriptions;
        private readonly Dictionary<Type, MethodInfo> _eventHandlerConstructedTypes;
        private readonly object _mutex;
        private bool _isDisposed;
        private long _LastsubscriptionId;

        static EventBusBase()
        {
            GenericEventHandlerInterfaceType = typeof(IEventHandler<>);
        }

        protected EventBusBase()
        {
            _subscriptions = new();
            _eventHandlerConstructedTypes = new();
            _mutex = new();
            _isDisposed = false;
            _LastsubscriptionId = 0;
        }

        public virtual void Dispose()
        {
            lock (_mutex)
            {
                _isDisposed = true;
                _subscriptions.Clear();
            }
            GC.SuppressFinalize(this);
        }

        public abstract Task<Result> PublishAsync<TEvent>(TEvent @event) where TEvent : IntegrationEvent;

        public virtual Result<IDisposable> Subscribe<TEvent, THandler>()
            where TEvent : IntegrationEvent
            where THandler : IEventHandler<TEvent>, new()
        {
            return Subscribe(new THandler());
        }

        public virtual Result<IDisposable> Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IntegrationEvent
        {
            Type eventType = typeof(TEvent);
            Subscription subscription;
            lock (_mutex)
            {
                if (_isDisposed)
                {
                    return new DisposedEventBusException(this);
                }
                subscription = new(++_LastsubscriptionId, eventType, handler, OnSubscriptionDisposed);
                if (!_eventHandlerConstructedTypes.ContainsKey(eventType))
                {
                    _eventHandlerConstructedTypes.Add(eventType, GenericEventHandlerInterfaceType.MakeGenericType(eventType).GetMethod(HandleMethodName)!);
                }
                if (!_subscriptions.ContainsKey(eventType))
                {
                    _subscriptions.Add(eventType, new());
                }
                _ = _subscriptions[eventType].Add(subscription);
            }
            return subscription;
        }

        public virtual void Unsubscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IntegrationEvent
        {
            if (handler is not null)
            {
                lock (_mutex)
                {
                    if (_subscriptions.TryGetValue(typeof(TEvent), out SortedSet<Subscription>? set))
                    {
                        _ = set.RemoveWhere(subscription => ReferenceEquals(handler, subscription.EventHandler));
                    }
                }
            }
        }

        public virtual void UnsubscribeAll<TEvent>() where TEvent : IntegrationEvent
        {
            lock (_mutex)
            {
                _ = _subscriptions.Remove(typeof(TEvent));
            }
        }

        protected virtual void OnEventReceived(Type eventType, IntegrationEvent @event)
        {
            if (_subscriptions.TryGetValue(eventType, out SortedSet<Subscription>? set))
            {
                foreach (Subscription subcription in set)
                {
                    _ = Task.Run(() => _eventHandlerConstructedTypes[eventType].Invoke(subcription.EventHandler, new[] { @event }));
                }
            }
        }

        private void OnSubscriptionDisposed(Subscription subscription)
        {
            lock (_mutex)
            {
                if (_subscriptions.TryGetValue(subscription.EventType, out SortedSet<Subscription>? set))
                {
                    _ = set.Remove(subscription);
                }
            }
        }
    }
}