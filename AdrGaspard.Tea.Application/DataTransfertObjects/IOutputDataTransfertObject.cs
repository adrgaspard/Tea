namespace AdrGaspard.Tea.Application.DataTransfertObjects
{
    public interface IOutputDataTransfertObject : IDataTransfertObject
    {
    }

    public interface IOutputDataTransfertObject<TEntity> : IOutputDataTransfertObject where TEntity : class
    {
    }
}
