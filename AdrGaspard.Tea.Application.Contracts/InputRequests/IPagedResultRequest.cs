namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    public interface IPagedResultRequest : ILimitedResultRequest
    {
        int SkipCount { get; }
    }
}