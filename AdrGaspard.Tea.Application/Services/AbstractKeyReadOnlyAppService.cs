using AdrGaspard.Tea.Application.Contracts.InputRequests;
using AdrGaspard.Tea.Application.Contracts.Mapping;
using AdrGaspard.Tea.Application.Contracts.OutputResults;
using AdrGaspard.Tea.Application.Contracts.Services;
using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.Domain;
using AdrGaspard.Tea.Domain.Repositories;

namespace AdrGaspard.Tea.Application.Services
{
    public abstract class AbstractKeyReadOnlyAppService<TEntity, TEntityResult, TKey> : AbstractKeyReadOnlyAppService<TEntity, TEntityResult, TEntityResult, TKey, PagedAndSortedResultRequest>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected AbstractKeyReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository, IMapper<Exception, ErrorResult> errorMapper, IMapper<TEntity, TEntityResult> valueMapper)
            : base(repository, errorMapper, valueMapper)
        {
        }
    }

    public abstract class AbstractKeyReadOnlyAppService<TEntity, TEntityResult, TKey, TGetListRequest> : AbstractKeyReadOnlyAppService<TEntity, TEntityResult, TEntityResult, TKey, TGetListRequest>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
        where TGetListRequest : IPagedResultRequest
    {
        protected AbstractKeyReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository, IMapper<Exception, ErrorResult> errorMapper, IMapper<TEntity, TEntityResult> valueMapper)
            : base(repository, errorMapper, valueMapper)
        {
        }
    }

    public abstract class AbstractKeyReadOnlyAppService<TEntity, TEntityResult, TGetListResponse, TKey, TGetListRequest> : IReadOnlyAppService<TEntityResult, TGetListResponse, TKey, TGetListRequest>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
        where TGetListRequest : IPagedResultRequest
    {
        protected readonly IReadOnlyRepository<TEntity, TKey> _repository;
        protected readonly IMapper<Exception, ErrorResult> _errorMapper;
        protected readonly IMapper<TEntity, TEntityResult> _valueMapper;

        protected AbstractKeyReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository, IMapper<Exception, ErrorResult> errorMapper, IMapper<TEntity, TEntityResult> valueMapper)
        {
            _repository = repository;
            _errorMapper = errorMapper;
            _valueMapper = valueMapper;
        }

        public virtual async Task<Response<TEntityResult>> GetAsync(TKey id, CancellationToken token = default)
        {
            Result<TEntity> query = await _repository.GetOneAsync(id, token);
            return query.ToResponse(_valueMapper.Map, error => null!);
        }

        public virtual async Task<Response<IPagedResult<TEntityResult>>> GetListAsync(TGetListRequest input, CancellationToken token = default)
        {
            Result<long> countQuery = await _repository.GetCountAsync(token);
            Result<IList<TEntity>> getQuery = await _repository.GetManyAsync(input.SkipCount, input.MaxResultCount, token);
            return getQuery.With(countQuery).ToResponse<(IList<TEntity>, long), IPagedResult<TEntityResult>>(
                data => new PagedResult<TEntityResult>()
                {
                    Items = data.Item1.Select(_valueMapper.Map).ToList(),
                    TotalCount = data.Item2
                },
                _errorMapper.Map);
        }
    }
}