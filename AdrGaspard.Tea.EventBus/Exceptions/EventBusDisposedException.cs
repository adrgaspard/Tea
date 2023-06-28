namespace AdrGaspard.Tea.EventBus.Exceptions
{
    public class DisposedEventBusException : EventBusException
    {
        public DisposedEventBusException(IEventBus eventBus) : base(eventBus, "A disposed event bus was used by an operation!")
        {
        }
    }
}