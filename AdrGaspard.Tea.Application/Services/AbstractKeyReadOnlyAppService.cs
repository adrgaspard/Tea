using AdrGaspard.Tea.Application.Contracts.InputRequests;
using AdrGaspard.Tea.Application.Contracts.Mapping;
using AdrGaspard.Tea.Application.Contracts.OutputResponses;
using AdrGaspard.Tea.Application.Contracts.Services;
using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.Domain;
using AdrGaspard.Tea.Domain.Repositories;

namespace AdrGaspard.Tea.Application.Services
{
    public abstract class AbstractKeyReadOnlyAppService<TEntity, TEntityResponse, TKey> : AbstractKeyReadOnlyAppService<TEntity, TEntityResponse, TEntityResponse, TKey, PagedAndSortedResultRequest>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected AbstractKeyReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository, IMapper<TEntity, TEntityResponse> mapper) : base(repository, mapper)
        {
        }
    }

    public abstract class AbstractKeyReadOnlyAppService<TEntity, TEntityResponse, TKey, TGetListRequest> : AbstractKeyReadOnlyAppService<TEntity, TEntityResponse, TEntityResponse, TKey, TGetListRequest>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
        where TGetListRequest : IPagedResultRequest
    {
        protected AbstractKeyReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository, IMapper<TEntity, TEntityResponse> mapper) : base(repository, mapper)
        {
        }
    }

    public abstract class AbstractKeyReadOnlyAppService<TEntity, TEntityResponse, TGetListResponse, TKey, TGetListRequest> : IReadOnlyAppService<TEntityResponse, TGetListResponse, TKey, TGetListRequest>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
        where TGetListRequest : IPagedResultRequest
    {
        protected readonly IReadOnlyRepository<TEntity, TKey> _repository;
        protected readonly IMapper<TEntity, TEntityResponse> _mapper;

        protected AbstractKeyReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository, IMapper<TEntity, TEntityResponse> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<Result<TEntityResponse>> GetAsync(TKey id, CancellationToken token = default)
        {
            Result<TEntity> query = await _repository.GetOneAsync(id, token);
            return query.Match<Result<TEntityResponse>>(entity => _mapper.Map(entity), error => error);
        }

        public virtual async Task<Result<IPagedResponse<TEntityResponse>>> GetListAsync(TGetListRequest input, CancellationToken token = default)
        {
            Result<long> countQuery = await _repository.GetCountAsync(token);
            Result<IList<TEntity>> getQuery = await _repository.GetManyAsync(input.SkipCount, input.MaxResultCount, token);
            return await countQuery.MatchAsync(count =>
                getQuery.Match<Result<IPagedResponse<TEntityResponse>>>(entities => new PagedResultResponse<TEntityResponse>()
                {
                    Items = entities.Select(entity => _mapper.Map(entity)).ToList(),
                    TotalCount = count,
                }, error => error)
            , error => error);
        }
    }
}
