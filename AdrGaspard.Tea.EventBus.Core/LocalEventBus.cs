using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.EventBus.Abstractions;

namespace AdrGaspard.Tea.EventBus.Core
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
