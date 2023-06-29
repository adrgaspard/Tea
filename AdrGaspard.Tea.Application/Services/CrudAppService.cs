using AdrGaspard.Tea.Application.Contracts.InputRequests;
using AdrGaspard.Tea.Application.Contracts.Mapping;
using AdrGaspard.Tea.Application.Contracts.OutputResults;
using AdrGaspard.Tea.Application.Contracts.Services;
using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.Domain;
using AdrGaspard.Tea.Domain.Repositories;

namespace AdrGaspard.Tea.Application.Services
{
    public abstract class CrudAppService<TEntity, TEntityResult, TKey> : CrudAppService<TEntity, TEntityResult, IPagedResult<TEntityResult>, TKey, PagedResultRequest, TEntityResult, TEntityResult>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected CrudAppService(IRepository<TEntity, TKey> repository, IMapper<Exception, ErrorResult> errorMapper, IMapper<TEntity, TEntityResult> valueMapper)
            : base(repository, errorMapper, valueMapper)
        {
        }
    }

    public abstract class CrudAppService<TEntity, TEntityResult, TKey, TCreateRequest, TUpdateRequest> : CrudAppService<TEntity, TEntityResult, IPagedResult<TEntityResult>, TKey, PagedResultRequest, TCreateRequest, TUpdateRequest>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected CrudAppService(IRepository<TEntity, TKey> repository, IMapper<Exception, ErrorResult> errorMapper, IMapper<TEntity, TEntityResult> valueMapper)
            : base(repository, errorMapper, valueMapper)
        {
        }
    }

    public abstract class CrudAppService<TEntity, TEntityResult, TGetListResponse, TKey, TGetListRequest, TCreateRequest, TUpdateRequest>
        : ReadOnlyAppService<TEntity, TEntityResult, TGetListResponse, TKey, TGetListRequest>,
        ICrudAppService<TEntityResult, TGetListResponse, TKey, TGetListRequest, TCreateRequest, TUpdateRequest>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
        where TGetListRequest : IPagedResultRequest
    {
        protected readonly IRepository<TEntity, TKey> _repository;

        protected CrudAppService(IRepository<TEntity, TKey> repository, IMapper<Exception, ErrorResult> errorMapper, IMapper<TEntity, TEntityResult> valueMapper)
            : base(repository, errorMapper, valueMapper)
        {
            _repository = repository;
        }

        public async Task<Response<TEntityResult>> CreateAsync(TCreateRequest input, CancellationToken token = default)
        {
            Result<TEntity> createQuery = await _repository.InsertOneAsync(MapEntityFromCreateRequest(input), true, token);
            return createQuery.ToResponse(_valueMapper.Map, _errorMapper.Map);
        }

        public async Task<Response> DeleteAsync(TKey id, CancellationToken token = default)
        {
            Result<TEntity> getQuery = await _repository.GetOneAsync(id, token);
            Result deleteQuery = await getQuery.MatchAsync(async entity => await _repository.DeleteOneAsync(entity, true, token), error => error);
            return deleteQuery.ToResponse(_errorMapper.Map);
        }

        public async Task<Response<TEntityResult>> UpdateAsync(TKey id, TUpdateRequest input, CancellationToken token = default)
        {
            Result<TEntity> getQuery = (await _repository.GetOneAsync(id, token)).Match<Result<TEntity>>(entity => MapEntityFromUpdateRequest(entity, input), error => error);
            Result updateQuery = await getQuery.MatchAsync(async entity => await _repository.UpdateOneAsync(entity, true, token), error => error);
            return getQuery.With(updateQuery).ToResponse(_valueMapper.Map, _errorMapper.Map);
        }

        protected abstract TEntity MapEntityFromCreateRequest(TCreateRequest createRequest);

        protected abstract TEntity MapEntityFromUpdateRequest(TEntity entity, TUpdateRequest updateRequest);
    }
}