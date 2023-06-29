namespace AdrGaspard.Tea.Application.Contracts.OutputResults
{
    public interface IPagedResult<TItem> : IListResult<TItem>, IHasTotalCount
    {
    }
}