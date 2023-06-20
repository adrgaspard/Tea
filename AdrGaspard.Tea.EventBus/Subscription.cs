namespace AdrGaspard.Tea.EventBus
{
    internal sealed class Subscription : IDisposable, IComparable<Subscription>
    {
        public readonly Type EventType;
        public readonly IEventHandler EventHandler;
        private readonly long _id;
        private readonly Action<Subscription> _unsubscribeMethod;

        internal Subscription(long id, Type eventType, IEventHandler eventHandler, Action<Subscription> unsubscribeAction)
        {
            _id = id;
            EventType = eventType;
            EventHandler = eventHandler;
            _unsubscribeMethod = unsubscribeAction;
        }

        public int CompareTo(Subscription? other)
        {
            if (other is not null)
            {
                if (_id == other._id)
                {
                    return 0;
                }
                if (_id < other._id)
                {
                    return -1;
                }
            }
            return 1;
        }

        public void Dispose()
        {
            _unsubscribeMethod(this);
        }
    }
}
