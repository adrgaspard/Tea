namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    public interface IListResponse<TItem>
    {
        IReadOnlyList<TItem> Items { get; }
    }
}
