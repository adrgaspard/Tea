namespace AdrGaspard.Tea.Application.DataTransfertObjects.InputRequests
{
    public interface ILimitedResultRequest
    {
        int MaxResultCount { get; set; }
    }
}
