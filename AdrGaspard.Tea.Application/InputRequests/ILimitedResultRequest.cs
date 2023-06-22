namespace AdrGaspard.Tea.Application.InputRequests
{
    public interface ILimitedResultRequest
    {
        int MaxResultCount { get; set; }
    }
}
