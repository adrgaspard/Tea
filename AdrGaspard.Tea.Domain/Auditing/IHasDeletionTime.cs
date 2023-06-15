namespace AdrGaspard.Tea.Domain.Auditing
{
    public interface IHasDeletionTime : ISoftDelete
    {
        DateTime? DeletionTime { get; }
    }
}
