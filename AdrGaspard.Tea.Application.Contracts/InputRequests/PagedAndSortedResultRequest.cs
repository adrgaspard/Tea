namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    public class PagedAndSortedResultRequest : PagedResultRequest, IPagedAndSortedResultRequest
    {
        public required IReadOnlyList<SortSpecificationRequest> Sorting { get; init; }
    }
}
