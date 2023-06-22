using System.ComponentModel.DataAnnotations;

namespace AdrGaspard.Tea.Application.InputRequests
{
    [Serializable]
    public class PagedResultRequest : LimitedResultRequest, IPagedResultRequest
    {
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
    }
}
