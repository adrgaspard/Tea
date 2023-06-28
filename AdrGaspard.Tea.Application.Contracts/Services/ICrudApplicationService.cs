using AdrGaspard.Tea.Application.Contracts.InputRequests;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface ICrudAppService<TEntityResponse, in TKey> : ICrudAppService<TEntityResponse, TKey, PagedAndSortedResultRequest>
    {
    }

    public interface ICrudAppService<TEntityResponse, in TKey, in TGetListRequest> : ICrudAppService<TEntityResponse, TKey, TGetListRequest, TEntityResponse>
    {
    }

    public interface ICrudAppService<TEntityResponse, in TKey, in TGetListRequest, in TCreateUpdateRequest> : ICrudAppService<TEntityResponse, TKey, TGetListRequest, TCreateUpdateRequest, TCreateUpdateRequest>
    {
    }

    public interface ICrudAppService<TEntityResponse, in TKey, in TGetListRequest, in TCreateRequest, in TUpdateRequest> : ICrudAppService<TEntityResponse, TEntityResponse, TKey, TGetListRequest, TCreateRequest, TUpdateRequest>
    {
    }

    public interface ICrudAppService<TEntityResponse, TGetListResponse, in TKey, in TGetListRequest, in TCreateRequest, in TUpdateRequest> : IReadOnlyAppService<TEntityResponse, TGetListResponse, TKey, TGetListRequest>, ICreateUpdateAppService<TEntityResponse, TKey, TCreateRequest, TUpdateRequest>, IDeleteAppService<TKey>
    {
    }
}