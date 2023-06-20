using System.ComponentModel;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.InputRequests
{
    public interface ISortedResultRequest
    {
        ListSortDirection SortDirection { get; set; }

        string PropertyName { get; set; }

        ISortedResultRequest? NextSortCriteria { get; set; }
    }
}
