using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{
    [Serializable]
    public abstract class CreateAuditedEntityDto : IOutputDto, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
    }

    [Serializable]
    public abstract class CreateAuditedEntityDto<TKey> : CreateAuditedEntityDto, IEntityDto<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
