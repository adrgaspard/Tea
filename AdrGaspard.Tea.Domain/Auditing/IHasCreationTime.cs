namespace AdrGaspard.Tea.Domain.Auditing
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; }
    }
}