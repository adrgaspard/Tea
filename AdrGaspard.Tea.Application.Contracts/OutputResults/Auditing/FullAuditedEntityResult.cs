using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.Contracts.OutputResults.Auditing
{
    [Serializable]
    public abstract class FullAuditedEntityResult : AuditedEntityResult, IHasDeletionTime
    {
        public DateTime? DeletionTime { get; init; }

        public bool IsDeleted { get; init; }
    }

    [Serializable]
    public abstract class FullAuditedEntityResult<TKey> : FullAuditedEntityResult, IEntityResult<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; init; }
#pragma warning restore CS8618
    }
}