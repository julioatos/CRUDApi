using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IGetAll<T>
    {
        Task<ICollection<T>> GetAll();
    }
}
