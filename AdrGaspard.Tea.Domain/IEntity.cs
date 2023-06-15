namespace AdrGaspard.Tea.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
