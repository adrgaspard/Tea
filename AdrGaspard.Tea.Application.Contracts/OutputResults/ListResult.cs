namespace AdrGaspard.Tea.Application.Contracts.OutputResults
{
    [Serializable]
    public class ListResult<TItem> : IListResult<TItem>
    {
        public IReadOnlyList<TItem> Items { get; init; }
    }
}