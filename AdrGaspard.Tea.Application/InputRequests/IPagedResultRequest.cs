namespace AdrGaspard.Tea.Application.InputRequests
{
    public interface IPagedResultRequest : ILimitedResultRequest
    {
        int SkipCount { get; set; }
    }
}
