namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    public interface IListResult<TItem>
    {
        IReadOnlyList<TItem> Items { get; }
    }
}