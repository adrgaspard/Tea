namespace AdrGaspard.Tea.Application.Contracts.OutputResults
{
    [Serializable]
    public class PagedResult<TItem> : ListResult<TItem>, IPagedResult<TItem>
    {
        public long TotalCount { get; init; }
    }
}