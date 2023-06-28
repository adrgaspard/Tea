using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.Contracts.OutputResponses.Auditing
{
    [Serializable]
    public abstract class CreateAuditedEntityResponse : IHasCreationTime
    {
        public DateTime CreationTime { get; init; }
    }

    [Serializable]
    public abstract class CreateAuditedEntityResponse<TKey> : CreateAuditedEntityResponse, IEntityResponse<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; init; }
#pragma warning restore CS8618
    }
}