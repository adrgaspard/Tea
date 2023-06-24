namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    [Serializable]
    public class ListResultResponse<TItem> : IListResponse<TItem>
    {
        public required IReadOnlyList<TItem> Items { get; init; }
    }
}
