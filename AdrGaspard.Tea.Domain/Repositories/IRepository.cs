using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Domain.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        Task<Result<TEntity>> InsertOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<Result> InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<Result> UpdateOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<Result> UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<Result> DeleteOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<Result> DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<Result> HardDeleteOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<Result> HardDeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);
    }

    public interface IRepository<TEntity, TKey> : IRepository<TEntity>, IReadOnlyRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
    }
}
