namespace AdrGaspard.Tea.Application.Contracts.OutputResults
{
    public interface IEntityResult<TKey>
    {
        TKey Id { get; }
    }
}