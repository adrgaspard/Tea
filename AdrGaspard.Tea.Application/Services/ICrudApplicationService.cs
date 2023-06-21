using AdrGaspard.Tea.Application.DataTransfertObjects;
using AdrGaspard.Tea.Application.DataTransfertObjects.InputRequests;
using AdrGaspard.Tea.Application.DataTransfertObjects.OutputResults;
using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.Services
{
    public interface ICrudApplicationService<TEntityDto, TKey, TGetManyInput, TCreateInput, TUpdateInput> : IApplicationService
        where TEntityDto : IEntityDto<TKey>
        where TGetManyInput : IPagedResultRequest
        where TCreateInput : IInputDto
        where TUpdateInput : IInputDto
    {
        Task<Result<TEntityDto>> GetAsync(TKey id);

        Task<Result<IPagedResult<TEntityDto>>> GetListAsync(TGetManyInput input);

        Task<Result<TEntityDto>> CreateAsync(TCreateInput input);

        Task<Result<TEntityDto>> UpdateAsync(TKey id, TUpdateInput input);

        Task<Result> DeleteAsync(TKey id);
    }
}
