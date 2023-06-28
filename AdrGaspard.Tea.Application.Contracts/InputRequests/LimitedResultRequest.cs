namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    [Serializable]
    public class LimitedResultRequest : ILimitedResultRequest
    {
        public int MaxResultCount { get; init; }
    }
}