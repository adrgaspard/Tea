using AdrGaspard.Tea.Application.InputRequests;
using AdrGaspard.Tea.Application.Mapping;
using AdrGaspard.Tea.Application.OutputResponses;
using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.Domain;
using AdrGaspard.Tea.Domain.Repositories;

namespace AdrGaspard.Tea.Application.Services
{
    public abstract class CrudApplicationService<TEntity, TEntityResponse, TKey, TGetManyInput, TCreateInput, TUpdateInput> : ICrudApplicationService<TEntityResponse, TKey, TGetManyInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TKey>
        where TEntityResponse : IEntityResponse<TKey>
        where TKey : IEquatable<TKey>
        where TGetManyInput : IPagedResultRequest
    {
        protected readonly IRepository<TEntity, TKey> _repository;
        protected readonly IMapper<TEntity, TEntityResponse> _mapper;

        protected CrudApplicationService(IRepository<TEntity, TKey> repository, IMapper<TEntity, TEntityResponse> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Result<TEntityResponse>> CreateAsync(TCreateInput input)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TEntityResponse>> GetAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IPagedResponse<TEntityResponse>>> GetListAsync(TGetManyInput input)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TEntityResponse>> UpdateAsync(TKey id, TUpdateInput input)
        {
            throw new NotImplementedException();
        }
    }
}
