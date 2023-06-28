using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.Contracts.OutputResponses.Auditing
{
    [Serializable]
    public abstract class DeleteAuditedEntityResult : SoftDeleteEntityResult, IHasDeletionTime
    {
        public DateTime? DeletionTime { get; init; }
    }

    [Serializable]
    public abstract class DeleteAuditedEntityResult<TKey> : DeleteAuditedEntityResult, IEntityResult<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; init; }
#pragma warning restore CS8618
    }
}