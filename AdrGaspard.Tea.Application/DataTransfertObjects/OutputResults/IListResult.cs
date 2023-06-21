namespace AdrGaspard.Tea.Application.DataTransfertObjects.OutputResults
{
    public interface IListResult<TItem>
    {
        IReadOnlyList<TItem> Items { get; set; }
    }
}
