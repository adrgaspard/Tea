using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.EventBus.Abstractions;

namespace AdrGaspard.Tea.EventBus.Core.Exceptions
{
    public class EventBusException : ErrorException
    {
        public IEventBus EventBus { get; }

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
    }
}
