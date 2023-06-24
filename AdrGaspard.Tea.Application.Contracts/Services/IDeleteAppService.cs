using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface IDeleteAppService<in TKey>
    {
        Task<Result> DeleteAsync(TKey id, CancellationToken token = default);
    }
}
