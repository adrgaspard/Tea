using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.Auditing
{
    [Serializable]
    public abstract class SoftDeleteEntityDto : IOutputDataTransfertObject, ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }

    [Serializable]
    public abstract class SoftDeleteEntityDto<TKey> : SoftDeleteEntityDto
    {
#pragma warning disable CS8618
        public TKey Id { get; set; }
#pragma warning restore CS8618
    }
}
