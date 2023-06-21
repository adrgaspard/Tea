using System.ComponentModel;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.InputRequests
{
    public class SortSpecificationDto : IInputDataTransfertObject
    {
        public ListSortDirection SortDirection { get; set; }

        public string PropertyName { get; set; }

        public SortSpecificationDto()
        {
            PropertyName = "";
        }

        public SortSpecificationDto(ListSortDirection sortDirection, string propertyName)
        {
            SortDirection = sortDirection;
            PropertyName = propertyName;
        }
    }
}
