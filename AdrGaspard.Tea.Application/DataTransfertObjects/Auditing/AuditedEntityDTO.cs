using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{
    public abstract class AuditedEntityDTO : CreateAuditedEntityDTO, IHasModificationTime
    {
        public DateTime LastModificationTime { get; set; }
    }

    public abstract class AuditedEntityDTO<TKey> : AuditedEntityDTO
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
