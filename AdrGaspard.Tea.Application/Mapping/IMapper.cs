using AdrGaspard.Tea.Domain;

namespace AdrGaspard.Tea.Application.Mapping
{
    public interface IMapper<TEntity, TDto>
    {
        TDto Map(TEntity entity);
    }
}
