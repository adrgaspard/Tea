using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.InputRequests
{
    public class PagedAndSortedResultRequest : PagedResultRequest, IPagedAndSortedResultRequest
    {
        public IReadOnlyList<SortSpecificationRequest> Sorting { get; set; }

        public PagedAndSortedResultRequest()
        {
            Sorting = Empty<SortSpecificationRequest>.ReadOnlyList;
        }
    }
}
