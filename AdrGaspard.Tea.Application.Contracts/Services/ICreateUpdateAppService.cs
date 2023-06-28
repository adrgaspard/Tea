namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface ICreateUpdateAppService<TEntityResult, in TKey> : ICreateUpdateAppService<TEntityResult, TKey, TEntityResult, TEntityResult>
    {
    }

    public interface ICreateUpdateAppService<TEntityResult, in TKey, in TCreateUpdateRequest> : ICreateUpdateAppService<TEntityResult, TKey, TCreateUpdateRequest, TCreateUpdateRequest>
    {
    }

    public interface ICreateUpdateAppService<TEntityResult, in TKey, in TCreateRequest, in TUpdateRequest> : ICreateAppService<TEntityResult, TCreateRequest>, IUpdateAppService<TEntityResult, TKey, TUpdateRequest>
    {
    }
}