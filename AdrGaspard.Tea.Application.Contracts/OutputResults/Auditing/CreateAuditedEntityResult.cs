using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.Contracts.OutputResults.Auditing
{
    [Serializable]
    public abstract class CreateAuditedEntityResult : IHasCreationTime
    {
        public DateTime CreationTime { get; init; }
    }

    [Serializable]
    public abstract class CreateAuditedEntityResult<TKey> : CreateAuditedEntityResult, IEntityResult<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; init; }
#pragma warning restore CS8618
    }
}