namespace AdrGaspard.Tea.Domain
{
    public interface IEntity
    {
        object[] GetKey();
    }

    public interface IEntity<TKey> : IEntity where TKey : IEquatable<TKey>
    {
        TKey Id { get; }
    }
}