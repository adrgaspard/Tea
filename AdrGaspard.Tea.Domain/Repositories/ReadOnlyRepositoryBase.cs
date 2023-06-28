using AdrGaspard.Tea.CommonTools;
using System.Linq.Expressions;

namespace AdrGaspard.Tea.Domain.Repositories
{
    public abstract class ReadOnlyRepositoryBase<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        public abstract Task<Result<TEntity>> GetOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<Result<TEntity?>> GetOneOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<Result<TEntity>> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<Result<TEntity?>> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<Result<IList<TEntity>>> GetManyAsync(CancellationToken cancellationToken = default);

        public abstract Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, CancellationToken cancellationToken = default);

        public abstract Task<Result<IList<TEntity>>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<Result<IList<TEntity>>> GetManyAsync(Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default);

        public abstract Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default);

        public abstract Task<Result<IList<TEntity>>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default);

        public abstract Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default);

        public abstract Task<Result<long>> GetCountAsync(CancellationToken cancellationToken = default);

        public abstract Task<Result<long>> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<Result<IQueryable<TEntity>>> GetQueryableAsync(CancellationToken cancellationToken = default);
    }

    public abstract class ReadOnlyRepositoryBase<TEntity, TKey> : ReadOnlyRepositoryBase<TEntity>, IReadOnlyRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        public abstract Task<Result<TEntity>> GetOneAsync(TKey id, CancellationToken cancellationToken = default);

        public abstract Task<Result<TEntity?>> GetOneOrDefaultAsync(TKey id, CancellationToken cancellationToken = default);

        public abstract Task<Result<TEntity>> GetSingleAsync(TKey id, CancellationToken cancellationToken = default);

        public abstract Task<Result<TEntity?>> GetSingleOrDefaultAsync(TKey id, CancellationToken cancellationToken = default);
    }
}