namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    [Serializable]
    public class ListResultResult<TItem> : IListResult<TItem>
    {
        public required IReadOnlyList<TItem> Items { get; init; }
    }
}