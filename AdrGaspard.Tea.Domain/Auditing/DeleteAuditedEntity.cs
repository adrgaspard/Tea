namespace AdrGaspard.Tea.Domain.Auditing
{
    [Serializable]
    public abstract class DeleteAuditedEntity<TKey> : SoftDeleteEntity<TKey>, IHasDeletionTime where TKey : IEquatable<TKey>
    {
        protected DeleteAuditedEntity() : base()
        {
        }

        protected DeleteAuditedEntity(TKey key) : base(key)
        {
        }

        public DateTime? DeletionTime { get; private set; }
    }
}