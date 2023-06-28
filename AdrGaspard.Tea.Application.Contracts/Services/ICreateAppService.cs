using AdrGaspard.Tea.Application.Contracts.OutputResponses;

namespace AdrGaspard.Tea.Application.Contracts.Services
{
    public interface ICreateAppService<TEntityResult> : ICreateAppService<TEntityResult, TEntityResult>
    {
    }

    public interface ICreateAppService<TEntityResult, in TCreateRequest>
    {
        Task<Response<TEntityResult>> CreateAsync(TCreateRequest input, CancellationToken token = default);
    }
}