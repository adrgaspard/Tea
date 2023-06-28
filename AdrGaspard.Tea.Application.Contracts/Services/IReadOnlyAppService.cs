using AdrGaspard.Tea.Application.Contracts.InputRequests;
using AdrGaspard.Tea.Application.Contracts.OutputResponses;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface IReadOnlyAppService<TEntityResult, in TKey> : IReadOnlyAppService<TEntityResult, TEntityResult, TKey, PagedAndSortedResultRequest>
    {
    }

    public interface IReadOnlyAppService<TEntityResult, in TKey, in TGetListRequest> : IReadOnlyAppService<TEntityResult, TEntityResult, TKey, TGetListRequest>
    {
    }

    public interface IReadOnlyAppService<TEntityResult, TGetListResponse, in TKey, in TGetListRequest>
    {
        Task<Response<TEntityResult>> GetAsync(TKey id, CancellationToken token = default);

        Task<Response<IPagedResult<TEntityResult>>> GetListAsync(TGetListRequest input, CancellationToken token = default);
    }
}