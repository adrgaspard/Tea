using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.OutputResponses
{
    [Serializable]
    public class ListResultResponse<TItem> : IListResponse<TItem>
    {
        public IReadOnlyList<TItem> Items { get; init; }

        public ListResultResponse()
        {
            Items = Empty<TItem>.ReadOnlyList;
        }

        public ListResultResponse(IReadOnlyList<TItem> items)
        {
            Items = items ?? Empty<TItem>.ReadOnlyList;
        }
    }
}
