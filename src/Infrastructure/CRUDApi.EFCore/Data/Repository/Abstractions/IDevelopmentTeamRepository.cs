using CRUDApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IDevelopmentTeamRepository : ICRUDRepository<DevelopmentTeam, int>
    {
        public Task<bool> HaveAnyProfile(List<int> ids, Profile requestedProfile);
    }
}
