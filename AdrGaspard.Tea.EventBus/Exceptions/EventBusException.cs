using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.EventBus.Exceptions
{
    public class EventBusException : ErrorException
    {
        public EventBusException(IEventBus eventBus) : base($"An unknown {nameof(EventBusException)} occured!")
        {
            EventBus = eventBus;
        }

        public EventBusException(IEventBus eventBus, string? message) : base(message)
        {
            EventBus = eventBus;
        }

        public EventBusException(IEventBus eventBus, string? message, Exception? innerException) : base(message, innerException)
        {
            EventBus = eventBus;
        }

        public IEventBus EventBus { get; }
    }
}