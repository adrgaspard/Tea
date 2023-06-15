﻿namespace AdrGaspard.Tea.Domain.Auditing
{
    [Serializable]
    public abstract class AuditedEntity<TKey> : CreateAuditedEntity<TKey>, IHasModificationTime
    {
        public DateTime LastModificationTime { get; private set; }

        protected AuditedEntity() : base() { }

        protected AuditedEntity(TKey key) : base(key) { }
    }
}