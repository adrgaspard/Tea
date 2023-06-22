using AdrGaspard.Tea.Application.OutputResponses;
using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.OutputResponses.Auditing
{
    [Serializable]
    public abstract class SoftDeleteEntityResponse : ISoftDelete
    {
        public bool IsDeleted { get; init; }
    }

    [Serializable]
    public abstract class SoftDeleteEntityResponse<TKey> : SoftDeleteEntityResponse, IEntityResponse<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; init; }
#pragma warning restore CS8618
    }
}
