namespace AdrGaspard.Tea.Domain.Auditing
{
    [Serializable]
    public abstract class CreateAuditedEntity<TKey> : Entity<TKey>, IHasCreationTime
    {
        public DateTime CreationTime { get; private set; }

        protected CreateAuditedEntity() : base() { }

        protected CreateAuditedEntity(TKey key) : base(key) { }
    }
}
