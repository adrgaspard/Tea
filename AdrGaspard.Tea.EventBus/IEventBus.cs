using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.EventBus
{
    public interface IEventBus
    {
        Task<Result> PublishAsync<TEvent>(TEvent @event) where TEvent : IntegrationEvent;

        Result<IDisposable> Subscribe<TEvent, THandler>() where TEvent : IntegrationEvent where THandler : IEventHandler<TEvent>, new();

        Result<IDisposable> Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IntegrationEvent;

        void Unsubscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IntegrationEvent;

        void UnsubscribeAll<TEvent>() where TEvent : IntegrationEvent;
    }
}
