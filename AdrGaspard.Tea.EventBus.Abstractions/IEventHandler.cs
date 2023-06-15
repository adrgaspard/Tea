using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.EventBus.Abstractions
{

    public interface IEventHandler
    {
    }

    public interface IEventHandler<TEvent> : IEventHandler where TEvent : IntegrationEvent
    {
        Task<Result> Handle(TEvent @event);
    }
}
