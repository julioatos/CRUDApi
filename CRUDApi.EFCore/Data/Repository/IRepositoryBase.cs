using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;

namespace CRUDApi.Data.Repository
{
    public interface IRepositoryBase<TEntity, TKey> : 
        IAdd<TEntity>, IGetAll<TEntity>, IGetById<TEntity, TKey> where TEntity : class, IEntityBase<TKey>
    {

    }
}
