namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    [Serializable]
    public class PagedResultRequest : LimitedResultRequest, IPagedResultRequest
    {
        public required int SkipCount { get; init; }
    }
}
