using CRUDApi.Models;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IEmployeeRepository<TEntity, TKey> : 
        IRepositoryBase<TEntity, TKey> where TEntity : class, IEntityBase<TKey>
    {
    }
}
