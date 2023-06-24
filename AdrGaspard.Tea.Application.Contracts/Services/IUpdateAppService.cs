using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface IUpdateAppService<TEntityResponse, in TKey> : IUpdateAppService<TEntityResponse, TKey, TEntityResponse>
    {
    }

    public interface IUpdateAppService<TEntityResponse, in TKey, in TUpdateRequest>
    {
        Task<Result<TEntityResponse>> UpdateAsync(TKey id, TUpdateRequest input, CancellationToken token = default);
    }
}
