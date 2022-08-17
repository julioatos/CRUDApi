using AutoMapper;
using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.DTOs;
using CRUDApi.Models;
using CRUDApi.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services
{
    public class DevelopmentTeamService : IDevelopmentTeamService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public DevelopmentTeamService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateDevelopmentTeam(DevelopmentTeamCreateDTO developmentTeam)
        {
            _repository.DevelopmentTeam.Create(_mapper.Map<DevelopmentTeam>(developmentTeam));
            await _repository.Save();
        }

        public async Task DeleteDevelopmentTeam(int id)
        {
            var team = await GetDevelopmentTeamById(id);
            _repository.DevelopmentTeam.Delete(_mapper.Map<DevelopmentTeam>(team));
            return;
        }

        public async Task<DevelopmentTeamReadDTO> GetDevelopmentTeamById(int id)
        {
            var developmentTeam = await _repository.DevelopmentTeam.GetById(id);
            return _mapper.Map<DevelopmentTeamReadDTO>(developmentTeam);
        }

        public async Task<ICollection<DevelopmentTeamReadDTO>> GetDevelopmentTeams()
        {
            var developmentTeams = await _repository.DevelopmentTeam.GetAll();
            return _mapper.Map<ICollection<DevelopmentTeamReadDTO>>(developmentTeams);
        }

        public async Task UpdateDevelopmentTeam(int id)
        {
            var team = await GetDevelopmentTeamById(id);
            await _repository.DevelopmentTeam.Update(_mapper.Map<DevelopmentTeam>(team));
            return;
        }
    }
}
