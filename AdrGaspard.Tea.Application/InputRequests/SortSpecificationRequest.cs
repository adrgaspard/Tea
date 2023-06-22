using System.ComponentModel;

namespace AdrGaspard.Tea.Application.InputRequests
{
    public class SortSpecificationRequest
    {
        public ListSortDirection SortDirection { get; set; }

        public string PropertyName { get; set; }

        public SortSpecificationRequest()
        {
            PropertyName = "";
        }

        public SortSpecificationRequest(ListSortDirection sortDirection, string propertyName)
        {
            SortDirection = sortDirection;
            PropertyName = propertyName;
        }
    }
}
