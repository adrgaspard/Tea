namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    [Serializable]
    public class PagedResultResult<TItem> : ListResultResult<TItem>, IPagedResult<TItem>
    {
        public long TotalCount { get; init; }
    }
}