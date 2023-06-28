namespace AdrGaspard.Tea.Domain.Auditing
{
    [Serializable]
    public abstract class AuditedEntity<TKey> : CreateAuditedEntity<TKey>, IHasModificationTime where TKey : IEquatable<TKey>
    {
        protected AuditedEntity() : base()
        {
        }

        protected AuditedEntity(TKey key) : base(key)
        {
        }

        public DateTime LastModificationTime { get; private set; }
    }
}