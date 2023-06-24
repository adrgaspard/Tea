namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    [Serializable]
    public class LimitedResultRequest : ILimitedResultRequest
    {
        public required int MaxResultCount { get; init; }
    }
}
