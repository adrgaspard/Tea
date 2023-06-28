namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    [Serializable]
    public class PagedResultResponse<TItem> : ListResultResponse<TItem>, IPagedResponse<TItem>
    {
        public long TotalCount { get; init; }
    }
}