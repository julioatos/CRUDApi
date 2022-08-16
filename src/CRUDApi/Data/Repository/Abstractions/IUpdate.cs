using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IUpdate<TEntity, TKey>
    {
        Task<TEntity> Update(TKey id);
    }
}
