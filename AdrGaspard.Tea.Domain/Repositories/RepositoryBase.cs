using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.Domain.Auditing;
using System.Data;
using System.Reflection;

namespace AdrGaspard.Tea.Domain.Repositories
{
    public abstract class RepositoryBase<TEntity> : ReadOnlyRepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class, IEntity
    {
        protected static readonly Type _entityType;
        protected static readonly PropertyInfo? _entityTypeCreationTimeProperty;
        protected static readonly PropertyInfo? _entityTypeModificationTimeProperty;
        protected static readonly PropertyInfo? _entityTypeIsDeletedProperty;
        protected static readonly PropertyInfo? _entityTypeDeletionTimeProperty;

        static RepositoryBase()
        {
            _entityType = typeof(TEntity);
            _entityTypeCreationTimeProperty = _entityType.IsAssignableFrom(typeof(IHasCreationTime)) ? _entityType.GetProperty(nameof(IHasCreationTime.CreationTime)) : null;
            _entityTypeModificationTimeProperty = _entityType.IsAssignableFrom(typeof(IHasModificationTime)) ? _entityType.GetProperty(nameof(IHasModificationTime.LastModificationTime)) : null;
            _entityTypeIsDeletedProperty = _entityType.IsAssignableFrom(typeof(ISoftDelete)) ? _entityType.GetProperty(nameof(ISoftDelete.IsDeleted)) : null;
            _entityTypeDeletionTimeProperty = _entityType.IsAssignableFrom(typeof(IHasDeletionTime)) ? _entityType.GetProperty(nameof(IHasDeletionTime.DeletionTime)) : null;
            foreach (PropertyInfo? prop in new List<PropertyInfo?>(4) { _entityTypeCreationTimeProperty, _entityTypeModificationTimeProperty, _entityTypeIsDeletedProperty, _entityTypeDeletionTimeProperty })
            {
                if (prop is PropertyInfo property && !property.CanWrite)
                {
                    throw new ReadOnlyException($"You must define the property {_entityType.Name}.{property.Name} setter (it can be private but can't be an init field).");
                }
            }
        }

        public virtual async Task<Result> DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (TEntity entity in entities)
            {
                Result result = await DeleteOneAsync(entity, cancellationToken: cancellationToken);
                if (result.IsFailure)
                {
                    return result;
                }
            }
            if (autoSave)
            {
                _ = await SaveChangesAsync(cancellationToken);
            }
            return Result.Ok;
        }

        public abstract Task<Result> DeleteOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        public virtual async Task<Result> InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (TEntity entity in entities)
            {
                Result<TEntity> result = await InsertOneAsync(entity, cancellationToken: cancellationToken);
                if (result.IsFailure)
                {
                    return result.Error;
                }
            }
            if (autoSave)
            {
                _ = await SaveChangesAsync(cancellationToken);
            }
            return Result.Ok;
        }

        public abstract Task<Result<TEntity>> InsertOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        public virtual async Task<Result> UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (TEntity entity in entities)
            {
                Result result = await UpdateOneAsync(entity, cancellationToken: cancellationToken);
                if (result.IsFailure)
                {
                    return result;
                }
            }
            if (autoSave)
            {
                _ = await SaveChangesAsync(cancellationToken);
            }
            return Result.Ok;
        }

        public abstract Task<Result> UpdateOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        public abstract Task<Result> HardDeleteOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        public virtual async Task<Result> HardDeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (TEntity entity in entities)
            {
                Result result = await HardDeleteOneAsync(entity, cancellationToken: cancellationToken);
                if (result.IsFailure)
                {
                    return result;
                }
            }
            if (autoSave)
            {
                _ = await SaveChangesAsync(cancellationToken);
            }
            return Result.Ok;
        }

        protected abstract Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public abstract class RepositoryBase<TEntity, TKey> : RepositoryBase<TEntity>, IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        public abstract Task<Result<TEntity>> GetOneAsync(TKey id, CancellationToken cancellationToken = default);

        public abstract Task<Result<TEntity?>> GetOneOrDefaultAsync(TKey id, CancellationToken cancellationToken = default);

        public abstract Task<Result<TEntity>> GetSingleAsync(TKey id, CancellationToken cancellationToken = default);

        public abstract Task<Result<TEntity?>> GetSingleOrDefaultAsync(TKey id, CancellationToken cancellationToken = default);
    }
}