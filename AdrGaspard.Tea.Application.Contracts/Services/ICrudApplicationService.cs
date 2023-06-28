using AdrGaspard.Tea.Application.Contracts.InputRequests;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface ICrudAppService<TEntityResult, in TKey> : ICrudAppService<TEntityResult, TKey, PagedAndSortedResultRequest>
    {
    }

    public interface ICrudAppService<TEntityResult, in TKey, in TGetListRequest> : ICrudAppService<TEntityResult, TKey, TGetListRequest, TEntityResult>
    {
    }

    public interface ICrudAppService<TEntityResult, in TKey, in TGetListRequest, in TCreateUpdateRequest> : ICrudAppService<TEntityResult, TKey, TGetListRequest, TCreateUpdateRequest, TCreateUpdateRequest>
    {
    }

    public interface ICrudAppService<TEntityResult, in TKey, in TGetListRequest, in TCreateRequest, in TUpdateRequest> : ICrudAppService<TEntityResult, TEntityResult, TKey, TGetListRequest, TCreateRequest, TUpdateRequest>
    {
    }

    public interface ICrudAppService<TEntityResult, TGetListResponse, in TKey, in TGetListRequest, in TCreateRequest, in TUpdateRequest> : IReadOnlyAppService<TEntityResult, TGetListResponse, TKey, TGetListRequest>, ICreateUpdateAppService<TEntityResult, TKey, TCreateRequest, TUpdateRequest>, IDeleteAppService<TKey>
    {
    }
}