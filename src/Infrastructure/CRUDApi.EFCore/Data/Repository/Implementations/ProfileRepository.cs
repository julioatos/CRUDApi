using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Implementations
{
    public class ProfileRepository : RepositoryBase<Profile, int>, IProfileRepository
    {
        public ProfileRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {
        }

        public async Task<Profile> GetByKeyAsync(string key)
        {
            var profile = await _ScrumTeamContext.Set<Profile>().FirstOrDefaultAsync(t => t.Key.Equals(key)); 
            return profile;
        }
    }
}
