namespace AdrGaspard.Tea.Application.OutputResponses
{
    public interface IListResponse<TItem>
    {
        IReadOnlyList<TItem> Items { get; }
    }
}
