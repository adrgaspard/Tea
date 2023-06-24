using System.ComponentModel;

namespace AdrGaspard.Tea.Application.Contracts.InputRequests
{
    public class SortSpecificationRequest
    {
        public required ListSortDirection SortDirection { get; init; }

        public required string PropertyName { get; init; }
    }
}
