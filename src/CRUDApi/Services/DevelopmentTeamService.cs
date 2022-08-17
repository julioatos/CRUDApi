using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;
using CRUDApi.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services
{
    public class DevelopmentTeamService : IDevelopmentTeamService
    {
        private readonly IRepositoryWrapper _repository;
        public DevelopmentTeamService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public void CreateDevelopmentTeam(DevelopmentTeam developmentTeam)
        {
            _repository.DevelopmentTeam.Create(developmentTeam);
            _repository.Save();
        }

        public async Task DeleteDevelopmentTeam(int id)
        {
            var team = await GetDevelopmentTeamById(id);
            _repository.DevelopmentTeam.Delete(team);
            return;
        }

        public async Task<DevelopmentTeam> GetDevelopmentTeamById(int id)
        {
            var developmentTeam = await _repository.DevelopmentTeam.GetById(id);
            return developmentTeam;
        }

        public async Task<ICollection<DevelopmentTeam>> GetDevelopmentTeams()
        {
            var developmentTeams = await _repository.DevelopmentTeam.GetAll();
            return developmentTeams;
        }

        public async Task UpdateDevelopmentTeam(int id)
        {
            var team = await GetDevelopmentTeamById(id);
            await _repository.DevelopmentTeam.Update(team);
            return;
        }
    }
}
