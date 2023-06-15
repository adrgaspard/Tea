namespace AdrGaspard.Tea.Domain.Auditing
{
    [Serializable]
    public abstract class DeleteAuditedEntity<TKey> : SoftDeleteEntity<TKey>, IHasDeletionTime
    {
        public DateTime? DeletionTime { get; private set; }

        protected DeleteAuditedEntity() : base() { }

        protected DeleteAuditedEntity(TKey key) : base(key) { }
    }
}
