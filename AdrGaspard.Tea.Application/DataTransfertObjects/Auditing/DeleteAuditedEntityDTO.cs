using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{
    public abstract class DeleteAuditedEntityDTO : SoftDeleteEntityDTO, IHasDeletionTime
    {
        public DateTime? DeletionTime { get; set; }
    }

    public abstract class DeleteAuditedEntityDTO<TKey> : DeleteAuditedEntityDTO
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
