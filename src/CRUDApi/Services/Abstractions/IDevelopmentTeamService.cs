using CRUDApi.DTOs;
using CRUDApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services.Abstractions
{
    public interface IDevelopmentTeamService
    {
        public Task CreateDevelopmentTeam(DevelopmentTeamCreateDTO developmentTeam);
        public Task<ICollection<DevelopmentTeamReadDTO>> GetDevelopmentTeams();
        public Task<DevelopmentTeamReadDTO> GetDevelopmentTeamById(int id);
        public Task UpdateDevelopmentTeam(DevelopmentTeamUpdateDTO developmentTeam);
        public Task DeleteDevelopmentTeam(int id);
    }
}
