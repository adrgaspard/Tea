namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    public interface ILimitedResultRequest
    {
        int MaxResultCount { get; }
    }
}