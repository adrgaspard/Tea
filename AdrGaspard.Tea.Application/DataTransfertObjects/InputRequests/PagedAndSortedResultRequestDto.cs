using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.InputRequests
{
    public class PagedAndSortedResultRequestDto : PagedResultRequestDto, IPagedAndSortedResultRequest
    {
        public IReadOnlyList<SortSpecificationDto> Sorting { get; set; }

        public PagedAndSortedResultRequestDto()
        {
            Sorting = Empty<SortSpecificationDto>.ReadOnlyList;
        }
    }
}
