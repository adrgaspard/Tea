using AdrGaspard.Tea.Application.Contracts.InputRequests;
using AdrGaspard.Tea.Application.Contracts.OutputResponses;
using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface IReadOnlyAppService<TEntityResponse, in TKey> : IReadOnlyAppService<TEntityResponse, TEntityResponse, TKey, PagedAndSortedResultRequest>
    {
    }

    public interface IReadOnlyAppService<TEntityResponse, in TKey, in TGetListRequest> : IReadOnlyAppService<TEntityResponse, TEntityResponse, TKey, TGetListRequest>
    {
    }

    public interface IReadOnlyAppService<TEntityResponse, TGetListResponse, in TKey, in TGetListRequest>
    {
        Task<Result<TEntityResponse>> GetAsync(TKey id, CancellationToken token = default);

        Task<Result<IPagedResponse<TEntityResponse>>> GetListAsync(TGetListRequest input, CancellationToken token = default);
    }
}