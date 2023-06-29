using AdrGaspard.Tea.Domain.Auditing;

namespace AdrGaspard.Tea.Application.Contracts.OutputResults.Auditing
{
    [Serializable]
    public abstract class SoftDeleteEntityResult : ISoftDelete
    {
        public bool IsDeleted { get; init; }
    }

    [Serializable]
    public abstract class SoftDeleteEntityResult<TKey> : SoftDeleteEntityResult, IEntityResult<TKey>
    {
#pragma warning disable CS8618
        public TKey Id { get; init; }
#pragma warning restore CS8618
    }
}