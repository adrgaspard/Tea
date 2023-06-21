namespace AdrGaspard.Tea.Application.DataTransfertObjects.OutputResults
{
    public interface IPagedResult<TItem> : IListResult<TItem>, IHasTotalCount
    {
    }
}
