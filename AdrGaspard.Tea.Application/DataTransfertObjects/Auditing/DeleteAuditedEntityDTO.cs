using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{
    [Serializable]
    public abstract class DeleteAuditedEntityDto : SoftDeleteEntityDto, IHasDeletionTime
    {
        public DateTime? DeletionTime { get; set; }
    }

    [Serializable]
    public abstract class DeleteAuditedEntityDto<TKey> : DeleteAuditedEntityDto, IEntityDto<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
