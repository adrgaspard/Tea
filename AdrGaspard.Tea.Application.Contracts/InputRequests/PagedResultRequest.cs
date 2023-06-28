namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    [Serializable]
    public class PagedResultRequest : LimitedResultRequest, IPagedResultRequest
    {
        public int SkipCount { get; init; }
    }
}