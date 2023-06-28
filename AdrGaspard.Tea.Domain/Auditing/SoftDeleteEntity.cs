namespace AdrGaspard.Tea.Domain.Auditing
{
    [Serializable]
    public abstract class SoftDeleteEntity<TKey> : Entity<TKey>, ISoftDelete where TKey : IEquatable<TKey>
    {
        protected SoftDeleteEntity() : base()
        {
        }

        protected SoftDeleteEntity(TKey key) : base(key)
        {
        }

        public bool IsDeleted { get; private set; }
    }
}