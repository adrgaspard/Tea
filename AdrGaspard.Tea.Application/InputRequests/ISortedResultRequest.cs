namespace AdrGaspard.Tea.Application.InputRequests
{
    public interface ISortedResultRequest
    {
        IReadOnlyList<SortSpecificationRequest> Sorting { get; set; }
    }
}
