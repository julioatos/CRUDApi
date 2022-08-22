using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IGetById<TEntity, TKey>
    {
        Task<TEntity> GetById(TKey id);

    }
}
