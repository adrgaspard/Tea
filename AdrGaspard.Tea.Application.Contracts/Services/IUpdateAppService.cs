using AdrGaspard.Tea.Application.Contracts.OutputResults;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface IUpdateAppService<TEntityResult, in TKey> : IUpdateAppService<TEntityResult, TKey, TEntityResult>
    {
    }

    public interface IUpdateAppService<TEntityResult, in TKey, in TUpdateRequest>
    {
        Task<Response<TEntityResult>> UpdateAsync(TKey id, TUpdateRequest input, CancellationToken token = default);
    }
}