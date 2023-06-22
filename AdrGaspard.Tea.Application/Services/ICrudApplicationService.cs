using AdrGaspard.Tea.Application.InputRequests;
using AdrGaspard.Tea.Application.OutputResponses;
using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.Services
{
    public interface ICrudApplicationService<TEntityResponse, TKey, TGetManyInput, TCreateInput, TUpdateInput> : IApplicationService
        where TEntityResponse : IEntityResponse<TKey>
        where TGetManyInput : IPagedResultRequest
    {
        Task<Result<TEntityResponse>> GetAsync(TKey id);

        Task<Result<IPagedResponse<TEntityResponse>>> GetListAsync(TGetManyInput input);

        Task<Result<TEntityResponse>> CreateAsync(TCreateInput input);

        Task<Result<TEntityResponse>> UpdateAsync(TKey id, TUpdateInput input);

        Task<Result> DeleteAsync(TKey id);
    }
}
