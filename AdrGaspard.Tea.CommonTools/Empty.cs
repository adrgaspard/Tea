using System.Collections.ObjectModel;

namespace AdrGaspard.Tea.CommonTools
{
    public class Empty<TItem>
    {
        public static readonly IReadOnlyList<TItem> ReadOnlyList = new ReadOnlyCollection<TItem>(_list);
        private static readonly List<TItem> _list = new(0);
    }
}