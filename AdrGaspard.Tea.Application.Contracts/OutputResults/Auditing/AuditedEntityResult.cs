using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.Contracts.OutputResponses.Auditing
{
    [Serializable]
    public abstract class AuditedEntityResult : CreateAuditedEntityResult, IHasModificationTime
    {
        public DateTime LastModificationTime { get; init; }
    }

    [Serializable]
    public abstract class AuditedEntityResult<TKey> : AuditedEntityResult, IEntityResult<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; init; }
#pragma warning restore CS8618
    }
}