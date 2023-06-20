using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{
    public abstract class SoftDeleteEntityDTO : IOutputDataTransfertObject, ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }

    public abstract class SoftDeleteEntityDTO<TKey> : SoftDeleteEntityDTO
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
