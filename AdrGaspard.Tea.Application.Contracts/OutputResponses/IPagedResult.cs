namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    public interface IPagedResult<TItem> : IListResult<TItem>, IHasTotalCount
    {
    }
}