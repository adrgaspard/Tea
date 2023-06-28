namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    public class PagedAndSortedResultRequest : PagedResultRequest, IPagedAndSortedResultRequest
    {
        public IReadOnlyList<SortSpecificationRequest> Sorting { get; init; }
    }
}