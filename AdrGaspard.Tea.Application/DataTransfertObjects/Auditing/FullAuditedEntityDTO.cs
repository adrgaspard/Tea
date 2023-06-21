using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{
    [Serializable]
    public abstract class FullAuditedEntityDto : AuditedEntityDto, IHasDeletionTime
    {
        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }
    }

    [Serializable]
    public abstract class FullAuditedEntityDto<TKey> : FullAuditedEntityDto
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
