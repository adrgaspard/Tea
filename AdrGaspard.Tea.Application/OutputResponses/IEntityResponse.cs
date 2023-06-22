namespace AdrGaspard.Tea.Application.OutputResponses
{
    public interface IEntityResponse<TKey>
    {
        TKey Id { get; }
    }
}
