namespace AdrGaspard.Tea.Application.DataTransfertObjects
{
    public interface IMapper<TEntity, TDto> where TEntity : class where TDto : IOutputDataTransfertObject<TEntity>
    {
        TDto Map(TEntity entity);
    }
}
