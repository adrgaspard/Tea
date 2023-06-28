namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    public interface IEntityResult<TKey>
    {
        TKey Id { get; }
    }
}