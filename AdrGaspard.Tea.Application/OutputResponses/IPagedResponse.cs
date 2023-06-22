namespace AdrGaspard.Tea.Application.OutputResponses
{
    public interface IPagedResponse<TItem> : IListResponse<TItem>, IHasTotalCount
    {
    }
}
