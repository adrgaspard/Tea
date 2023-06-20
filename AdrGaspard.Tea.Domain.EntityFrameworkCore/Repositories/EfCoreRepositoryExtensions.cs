using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.Domain.Repositories;

namespace AdrGaspard.Tea.Domain.EntityFrameworkCore.Repositories
{
    public static class EfCoreRepositoryExtensions
    {
        public static Result<IEfCoreRepository<TEntity>> ToEfCoreRepository<TEntity, TKey>(this IReadOnlyRepository<TEntity> repository) where TEntity : class, IEntity
        {
            return repository is IEfCoreRepository<TEntity> efCoreRepository
                ? Result.Success(efCoreRepository)
                : (Result<IEfCoreRepository<TEntity>>)new ArgumentException($"The repository does not implement {typeof(IEfCoreRepository<TEntity>).Name}");
        }

        public static Result<IEfCoreRepository<TEntity, TKey>> ToEfCoreRepository<TEntity, TKey>(this IReadOnlyRepository<TEntity, TKey> repository) where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
        {
            return repository is IEfCoreRepository<TEntity, TKey> efCoreRepository
                ? Result.Success(efCoreRepository)
                : (Result<IEfCoreRepository<TEntity, TKey>>)new ArgumentException($"The repository does not implement {typeof(IEfCoreRepository<TEntity, TKey>).Name}");
        }
    }
}
