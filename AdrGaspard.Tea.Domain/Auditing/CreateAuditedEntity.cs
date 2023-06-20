namespace AdrGaspard.Tea.Domain.Auditing
{
    [Serializable]
    public abstract class CreateAuditedEntity<TKey> : Entity<TKey>, IHasCreationTime where TKey : IEquatable<TKey>
    {
        public DateTime CreationTime { get; private set; }

        protected CreateAuditedEntity() : base() { }

        protected CreateAuditedEntity(TKey key) : base(key) { }
    }
}
