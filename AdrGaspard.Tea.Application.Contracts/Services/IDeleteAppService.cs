using AdrGaspard.Tea.Application.Contracts.OutputResults;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface IDeleteAppService<in TKey>
    {
        Task<Response> DeleteAsync(TKey id, CancellationToken token = default);
    }
}