using CRUDApi.Models;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IProfileRepository : IRepositoryBase<Profile, int>
    {
        public Task<Profile> GetByKeyAsync(string key);
    }
}
