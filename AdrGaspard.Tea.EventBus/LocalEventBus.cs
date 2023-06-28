using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.EventBus
{
    public class LocalEventBus : EventBusBase, ILocalEventBus, IDistributedEventBus
    {
        public override Task<Result> PublishAsync<TEvent>(TEvent @event)
        {
            OnEventReceived(typeof(TEvent), @event);
            return Task.FromResult(Result.Ok);
        }
    }
}