using AdrGaspard.Tea.CommonTools;
using System.Linq.Expressions;

namespace AdrGaspard.Tea.Domain.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        Task<Result<TEntity>> GetOneAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<Result<TEntity?>> GetOneOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<Result<TEntity>> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<Result<TEntity?>> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<Result<IList<TEntity>>> GetManyAsync(CancellationToken cancellationToken = default);

        Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, CancellationToken cancellationToken = default);

        Task<Result<IList<TEntity>>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<Result<IList<TEntity>>> GetManyAsync(Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default);

        Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default);

        Task<Result<IList<TEntity>>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default);

        Task<Result<IList<TEntity>>> GetManyAsync(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, IComparable>> sort, CancellationToken cancellationToken = default);

        Task<Result<long>> GetCountAsync(CancellationToken cancellationToken = default);

        Task<Result<long>> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<Result<IQueryable<TEntity>>> GetQueryableAsync(CancellationToken cancellationToken = default);
    }

    public interface IReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        Task<Result<TEntity>> GetOneAsync(TKey id, CancellationToken cancellationToken = default);

        Task<Result<TEntity?>> GetOneOrDefaultAsync(TKey id, CancellationToken cancellationToken = default);

        Task<Result<TEntity>> GetSingleAsync(TKey id, CancellationToken cancellationToken = default);

        Task<Result<TEntity?>> GetSingleOrDefaultAsync(TKey id, CancellationToken cancellationToken = default);
    }
}
