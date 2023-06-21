namespace AdrGaspard.Tea.Application.DataTransfertObjects
{
    public interface IEntityDto<TKey> : IOutputDto
    {
        TKey Id { get; set; }
    }
}
