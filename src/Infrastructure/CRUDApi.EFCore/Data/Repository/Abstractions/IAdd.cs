using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IAdd<TEntity>
    {
        void Create(TEntity entity);
    }
}
