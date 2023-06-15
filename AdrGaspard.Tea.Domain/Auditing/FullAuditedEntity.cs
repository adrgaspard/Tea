namespace AdrGaspard.Tea.Domain.Auditing
{
    [Serializable]
    public abstract class FullAuditedEntity<TKey> : AuditedEntity<TKey>, IHasDeletionTime
    {
        public DateTime? DeletionTime { get; private set; }

        public bool IsDeleted { get; private set; }

        protected FullAuditedEntity() : base() { }

        protected FullAuditedEntity(TKey key) : base(key) { }
    }
}
