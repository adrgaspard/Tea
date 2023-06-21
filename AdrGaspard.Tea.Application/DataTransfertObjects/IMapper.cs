namespace AdrGaspard.Tea.Application.DataTransfertObjects
{
    public interface IMapper<TEntity, TDto> where TEntity : class where TDto : IOutputDto
    {
        TDto Map(TEntity entity);
    }
}
