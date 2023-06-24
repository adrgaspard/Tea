namespace AdrGaspard.Tea.Application.Contracts.OutputResponses
{
    public interface IEntityResponse<TKey>
    {
        TKey Id { get; }
    }
}
