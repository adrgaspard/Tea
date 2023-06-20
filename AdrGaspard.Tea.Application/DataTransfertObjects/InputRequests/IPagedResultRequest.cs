namespace AdrGaspard.Tea.Application.DataTransfertObjects.InputRequests
{
    public interface IPagedResultRequest : ILimitedResultRequest
    {
        int SkipCount { get; set; }
    }
}
