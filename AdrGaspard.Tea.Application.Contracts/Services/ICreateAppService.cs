using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface ICreateAppService<TEntityResponse> : ICreateAppService<TEntityResponse, TEntityResponse>
    {
    }

    public interface ICreateAppService<TEntityResponse, in TCreateRequest>
    {
        Task<Result<TEntityResponse>> CreateAsync(TCreateRequest input, CancellationToken token = default);
    }
}