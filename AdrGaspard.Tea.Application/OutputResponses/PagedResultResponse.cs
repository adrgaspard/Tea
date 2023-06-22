namespace AdrGaspard.Tea.Application.OutputResponses
{
    [Serializable]
    public class PagedResultResponse<TItem> : ListResultResponse<TItem>, IPagedResponse<TItem>
    {
        public long TotalCount { get; init; }

        public PagedResultResponse() : base() { }

        public PagedResultResponse(long totalCount, IReadOnlyList<TItem> items) : base(items)
        {
            TotalCount = totalCount;
        }
    }
}
