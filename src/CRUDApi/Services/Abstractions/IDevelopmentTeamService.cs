using CRUDApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services.Abstractions
{
    public interface IDevelopmentTeamService
    {
        public void CreateDevelopmentTeam(DevelopmentTeam developmentTeam);
        public Task<ICollection<DevelopmentTeam>> GetDevelopmentTeams();
        public Task<DevelopmentTeam> GetDevelopmentTeamById(int id);

        public Task UpdateDevelopmentTeam(int id);

        public Task DeleteDevelopmentTeam(int id);
    }
}
