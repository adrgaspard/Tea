using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{
    public abstract class CreateAuditedEntityDTO : IOutputDataTransfertObject, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
    }

    public abstract class CreateAuditedEntityDTO<TKey> : CreateAuditedEntityDTO
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
