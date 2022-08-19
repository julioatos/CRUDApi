using AutoMapper;
using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.DTOs;
using CRUDApi.Enums;
using CRUDApi.Exceptions;
using CRUDApi.Models;
using CRUDApi.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
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
            var scrumProfile = await _repository.Profile.GetByKeyAsync(ProfileKeys.SCRUM_MASTER);
            if (!(await _repository.DevelopmentTeam.HaveAnyProfile(developmentTeam.EmployesId, scrumProfile)))
                throw new MissingScrumMasterException();
            var devTeam = _mapper.Map<DevelopmentTeam>(developmentTeam);
            devTeam.Employees = new List<Employee>();
            foreach (var id in developmentTeam.EmployesId)
            {
                devTeam.Employees.Add(new Employee()
                {
                    Id = id
                });
            }
            //var query = Employees.Where(l1 => list2.Any(l2 => l2.g4 == l1.g2));
            //devTeam.Employees = (ICollection<Employee>)employees;
            _repository.DevelopmentTeam.Create(devTeam);
            await _repository.Save();
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

        public async Task UpdateDevelopmentTeam(DevelopmentTeamUpdateDTO developmentTeam)
        {
            var id = await _repository.DevelopmentTeam.GetById(developmentTeam.Id);
            if (id is null)
                throw new System.Exception();
            await _repository.DevelopmentTeam.Update(_mapper.Map<DevelopmentTeam>(developmentTeam));
            //await _repository.DevelopmentTeam.Update(_mapper.Map<DevelopmentTeam>(developmentTeam));
            await _repository.Save();
            return;
        }
        public async Task DeleteDevelopmentTeam(int id)
        {
            var team = await GetDevelopmentTeamById(id);
            _repository.DevelopmentTeam.Delete(_mapper.Map<DevelopmentTeam>(team));
            await _repository.Save();
            return;
        }

    }
}
