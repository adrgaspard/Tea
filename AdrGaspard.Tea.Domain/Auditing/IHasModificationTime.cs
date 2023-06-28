namespace AdrGaspard.Tea.Domain.Auditing
{
    public interface IHasModificationTime
    {
        DateTime LastModificationTime { get; }
    }
}