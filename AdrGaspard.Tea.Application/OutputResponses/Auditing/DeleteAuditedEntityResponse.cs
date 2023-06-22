using AdrGaspard.Tea.Application.OutputResponses;
using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.OutputResponses.Auditing
{
    [Serializable]
    public abstract class DeleteAuditedEntityResponse : SoftDeleteEntityResponse, IHasDeletionTime
    {
        public DateTime? DeletionTime { get; init; }
    }

    [Serializable]
    public abstract class DeleteAuditedEntityResponse<TKey> : DeleteAuditedEntityResponse, IEntityResponse<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; init; }
#pragma warning restore CS8618
    }
}
