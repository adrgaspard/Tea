namespace AdrGaspard.Tea.Application.Contracts.OutputResults
{
    public interface IListResult<TItem>
    {
        IReadOnlyList<TItem> Items { get; }
    }
}