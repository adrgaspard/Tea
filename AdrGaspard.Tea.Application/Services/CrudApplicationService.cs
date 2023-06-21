using AdrGaspard.Tea.Application.DataTransfertObjects;
using AdrGaspard.Tea.Application.DataTransfertObjects.InputRequests;
using AdrGaspard.Tea.Application.DataTransfertObjects.OutputResults;
using AdrGaspard.Tea.CommonTools;
using AdrGaspard.Tea.Domain;
using AdrGaspard.Tea.Domain.Repositories;

namespace AdrGaspard.Tea.Application.Services
{
    public abstract class CrudApplicationService<TEntity, TEntityDto, TKey, TGetManyInput, TCreateInput, TUpdateInput> : ICrudApplicationService<TEntityDto, TKey, TGetManyInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TKey>
        where TEntityDto : IEntityDto<TKey>
        where TKey : IEquatable<TKey>
        where TGetManyInput : IPagedResultRequest
        where TCreateInput : IInputDto
        where TUpdateInput : IInputDto
    {
        protected readonly IRepository<TEntity, TKey> _repository;
        protected readonly IMapper<TEntity, TEntityDto> _mapper;

        protected CrudApplicationService(IRepository<TEntity, TKey> repository, IMapper<TEntity, TEntityDto> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Result<TEntityDto>> CreateAsync(TCreateInput input)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TEntityDto>> GetAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IPagedResult<TEntityDto>>> GetListAsync(TGetManyInput input)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TEntityDto>> UpdateAsync(TKey id, TUpdateInput input)
        {
            throw new NotImplementedException();
        }
    }
}
