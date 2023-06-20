using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{
    public abstract class FullAuditedEntityDTO : AuditedEntityDTO, IHasDeletionTime
    {
        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }
    }

    public abstract class FullAuditedEntityDTO<TKey> : FullAuditedEntityDTO
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
