namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    [Serializable]
    public class PagedResultResponse<TItem> : ListResultResponse<TItem>, IPagedResponse<TItem>
    {
        public required long TotalCount { get; init; }
    }
}
