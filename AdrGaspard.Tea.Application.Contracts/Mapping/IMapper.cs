namespace AdrGaspard.Tea.Application.Contracts.Mapping
{
    public interface IMapper<TEntity, TDto>
    {
        TDto Map(TEntity entity);
    }
}