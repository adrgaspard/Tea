namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface ICreateUpdateAppService<TEntityResponse, in TKey> : ICreateUpdateAppService<TEntityResponse, TKey, TEntityResponse, TEntityResponse>
    {
    }

    public interface ICreateUpdateAppService<TEntityResponse, in TKey, in TCreateUpdateRequest> : ICreateUpdateAppService<TEntityResponse, TKey, TCreateUpdateRequest, TCreateUpdateRequest>
    {
    }

    public interface ICreateUpdateAppService<TEntityResponse, in TKey, in TCreateRequest, in TUpdateRequest> : ICreateAppService<TEntityResponse, TCreateRequest>, IUpdateAppService<TEntityResponse, TKey, TUpdateRequest>
    {
    }
}