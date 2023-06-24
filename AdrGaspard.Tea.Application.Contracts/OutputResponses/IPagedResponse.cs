namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    public interface IPagedResponse<TItem> : IListResponse<TItem>, IHasTotalCount
    {
    }
}
