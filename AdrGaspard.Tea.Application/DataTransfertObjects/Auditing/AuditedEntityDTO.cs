using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{

    [Serializable]
    public abstract class AuditedEntityDto : CreateAuditedEntityDto, IHasModificationTime
    {
        public DateTime LastModificationTime { get; set; }
    }

    [Serializable]
    public abstract class AuditedEntityDto<TKey> : AuditedEntityDto
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
