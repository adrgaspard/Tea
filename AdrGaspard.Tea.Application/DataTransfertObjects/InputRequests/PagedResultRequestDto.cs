using System.ComponentModel.DataAnnotations;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.InputRequests
{
    [Serializable]
    public class PagedResultRequestDto : LimitedResultRequestDto, IPagedResultRequest
    {
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
    }
}
