namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    public interface ISortedResultRequest
    {
        IReadOnlyList<SortSpecificationRequest> Sorting { get; }
    }
}
