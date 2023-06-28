namespace AdrGaspard.Tea.Domain.Auditing
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
    }
}