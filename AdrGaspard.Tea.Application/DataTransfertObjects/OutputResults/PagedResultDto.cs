namespace AdrGaspard.Tea.Application.DataTransfertObjects.OutputResults
{
    [Serializable]
    public class PagedResultDto<TItem> : ListResultDto<TItem>, IPagedResult<TItem>
    {
        public long TotalCount { get; set; }

        public PagedResultDto() : base() { }

        public PagedResultDto(long totalCount, IReadOnlyList<TItem> items) : base(items)
        {
            TotalCount = totalCount;
        }
    }
}
