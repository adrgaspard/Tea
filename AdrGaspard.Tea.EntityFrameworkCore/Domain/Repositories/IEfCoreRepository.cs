using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.Domain;
using AdrGaspard.Tea.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AdrGaspard.Tea.EntityFrameworkCore.Domain.Repositories
{
    public interface IEfCoreRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        Task<Result<int>> BulkDeleteAsync(CancellationToken cancellationToken = default);

        Task<Result<int>> BulkDeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<Result<int>> BulkUpdateAsync(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> propertyCalls, CancellationToken cancellationToken = default);

        Task<Result<int>> BulkUpdateAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> propertyCalls, CancellationToken cancellationToken = default);
    }
}
