namespace AdrGaspard.Tea.Application.DataTransfertObjects.InputRequests
{
    public interface ISortedResultRequest
    {
        IReadOnlyList<SortSpecificationDto> Sorting { get; set; }
    }
}
