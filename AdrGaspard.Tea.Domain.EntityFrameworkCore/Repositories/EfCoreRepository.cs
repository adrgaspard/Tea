using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AdrGaspard.Tea.Domain.EntityFrameworkCore.Repositories
{
    public class EfCoreRepository<TDbContext, TEntity, TKey> : RepositoryBase<TEntity, TKey>, IEfCoreRepository<TEntity, TKey> where TDbContext : DbContext where TEntity : class, IEntity<TKey>
    {
        protected readonly TDbContext _context;
        protected readonly DbSet<TEntity> _set;

        public EfCoreRepository(TDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            _context = context;
            _set = context.Set<TEntity>();
            if (_set is null)
            {
                throw new NullReferenceException($"The provided DbContext does not have a DbSet<{_entityType.Name}>");
            }
        }

        public async Task<Result<int>> BulkDeleteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.ExecuteDeleteAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public async Task<Result<int>> BulkDeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.Where(predicate).ExecuteDeleteAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public async Task<Result<int>> BulkUpdateAsync(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> propertyCalls, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.ExecuteUpdateAsync(propertyCalls, cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public async Task<Result<int>> BulkUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> propertyCalls, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.Where(predicate).ExecuteUpdateAsync(propertyCalls, cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result> DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            try
            {
                if (_entityTypeIsDeletedProperty is null)
                {
                    _set.RemoveRange(entities);
                }
                else
                {
                    if (_entityTypeDeletionTimeProperty is not null)
                    {
                        foreach (TEntity entity in entities)
                        {
                            _entityTypeIsDeletedProperty.SetValue(entity, true);
                            _entityTypeDeletionTimeProperty.SetValue(entity, DateTime.UtcNow);
                        }
                    }
                    else
                    {
                        foreach (TEntity entity in entities)
                        {
                            _entityTypeIsDeletedProperty.SetValue(entity, true);
                        }
                    }
                }
                if (autoSave)
                {
                    _ = await SaveChangesAsync(cancellationToken);
                }
                return Result.Ok;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result> DeleteOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            try
            {
                if (_entityTypeIsDeletedProperty is null)
                {
                    _ = _set.Remove(entity);
                }
                else
                {
                    _entityTypeIsDeletedProperty.SetValue(entity, true);
                    _entityTypeDeletionTimeProperty?.SetValue(entity, DateTime.UtcNow);
                }
                if (autoSave)
                {
                    _ = await SaveChangesAsync(cancellationToken);
                }
                return Result.Ok;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<long>> GetCountAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.CountAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<long>> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.CountAsync(predicate, cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<IList<TEntity>>> GetManyAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.ToListAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.Skip(skipCount).Take(maxResultCount).ToListAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<IList<TEntity>>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.Where(predicate).ToListAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<IList<TEntity>>> GetManyAsync(Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.OrderBy(sort).ToListAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.Where(predicate).Skip(skipCount).Take(maxResultCount).ToListAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.OrderBy(sort).Skip(skipCount).Take(maxResultCount).ToListAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<IList<TEntity>>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.Where(predicate).OrderBy(sort).ToListAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.Where(predicate).OrderBy(sort).Skip(skipCount).Take(maxResultCount).ToListAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<TEntity>> GetOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.FirstAsync(predicate, cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<TEntity>> GetOneAsync(TKey id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.FirstAsync(entity => entity.Id!.Equals(id), cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<TEntity?>> GetOneOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.FirstOrDefaultAsync(predicate, cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<TEntity?>> GetOneOrDefaultAsync(TKey id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.FirstOrDefaultAsync(entity => entity.Id!.Equals(id), cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override Task<Result<IQueryable<TEntity>>> GetQueryableAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Result.Success<IQueryable<TEntity>>(_set));
        }

        public override async Task<Result<TEntity>> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.SingleAsync(predicate, cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<TEntity>> GetSingleAsync(TKey id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.SingleAsync(entity => entity.Id!.Equals(id), cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<TEntity?>> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.SingleOrDefaultAsync(predicate, cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<TEntity?>> GetSingleOrDefaultAsync(TKey id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _set.SingleOrDefaultAsync(entity => entity.Id!.Equals(id), cancellationToken);
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result> HardDeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            try
            {
                _set.RemoveRange(entities);
                if (autoSave)
                {
                    _ = await SaveChangesAsync(cancellationToken);
                }
                return Result.Ok;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result> HardDeleteOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            try
            {
                _ = _set.Remove(entity);
                if (autoSave)
                {
                    _ = await SaveChangesAsync(cancellationToken);
                }
                return Result.Ok;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result> InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            try
            {
                await _set.AddRangeAsync(entities, cancellationToken);
                if (_entityTypeCreationTimeProperty is not null)
                {
                    if (_entityTypeModificationTimeProperty is not null)
                    {
                        foreach (TEntity entity in entities)
                        {
                            _entityTypeCreationTimeProperty.SetValue(entity, DateTime.UtcNow);
                            _entityTypeModificationTimeProperty.SetValue(entity, DateTime.UtcNow);
                        }
                    }
                    else
                    {
                        foreach (TEntity entity in entities)
                        {
                            _entityTypeCreationTimeProperty.SetValue(entity, DateTime.UtcNow);
                        }
                    }
                }
                if (autoSave)
                {
                    _ = await SaveChangesAsync(cancellationToken);
                }
                return Result.Ok;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result<TEntity>> InsertOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            try
            {
                _ = await _set.AddAsync(entity, cancellationToken);
                _entityTypeCreationTimeProperty?.SetValue(entity, DateTime.UtcNow);
                _entityTypeModificationTimeProperty?.SetValue(entity, DateTime.UtcNow);
                if (autoSave)
                {
                    _ = await SaveChangesAsync(cancellationToken);
                }
                return entity;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result> UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            try
            {
                _set.UpdateRange(entities);
                if (_entityTypeModificationTimeProperty is not null)
                {
                    foreach (TEntity entity in entities)
                    {
                        _entityTypeModificationTimeProperty.SetValue(entity, DateTime.UtcNow);
                    }
                }
                if (autoSave)
                {
                    _ = await SaveChangesAsync(cancellationToken);
                }
                return Result.Ok;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        public override async Task<Result> UpdateOneAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            try
            {
                _ = _set.Update(entity);
                _entityTypeModificationTimeProperty?.SetValue(entity, DateTime.UtcNow);
                if (autoSave)
                {
                    _ = await SaveChangesAsync(cancellationToken);
                }
                return Result.Ok;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }

        protected override async Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _ = await _context.SaveChangesAsync(cancellationToken);
                return Result.Ok;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }
    }
}
