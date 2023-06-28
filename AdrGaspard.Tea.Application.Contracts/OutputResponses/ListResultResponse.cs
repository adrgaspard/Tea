namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    [Serializable]
    public class ListResultResponse<TItem> : IListResponse<TItem>
    {
        public IReadOnlyList<TItem> Items { get; init; }
    }
}