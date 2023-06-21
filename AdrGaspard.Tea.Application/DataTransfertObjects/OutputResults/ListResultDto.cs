using AdrGaspard.Tea.CommonTools;

namespace AdrGaspard.Tea.Application.DataTransfertObjects.OutputResults
{
    [Serializable]
    public class ListResultDto<TItem> : IListResult<TItem>
    {
        public IReadOnlyList<TItem> Items { get; set; }

        public ListResultDto()
        {
            Items = Empty<TItem>.ReadOnlyList;
        }

        public ListResultDto(IReadOnlyList<TItem> items)
        {
            Items = items ?? Empty<TItem>.ReadOnlyList;
        }
    }
}
