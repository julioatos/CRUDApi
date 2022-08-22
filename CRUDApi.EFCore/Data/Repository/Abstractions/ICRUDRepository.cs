using CRUDApi.Models;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface ICRUDRepository<TEntity, TKey> : 
        IRepositoryBase<TEntity, TKey>, IUpdate<TEntity, TKey>, IDelete<TEntity> where TEntity : class, IEntityBase<TKey>
    {
    }
}
