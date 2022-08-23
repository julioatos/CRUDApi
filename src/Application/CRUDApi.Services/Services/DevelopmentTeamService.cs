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
            var team = await _repository.DevelopmentTeam.GetById(developmentTeam.Id);
            if (team is null)
                throw new System.Exception();
            team.CreationDate = developmentTeam.CreationDate;
            team.Active = developmentTeam.Active;
            var employee = await _repository.Employee.GetEmployeesById(developmentTeam.EmployeesIds.ToArray());
            team.Employees = employee;
            await _repository.DevelopmentTeam.Update(team);
            await _repository.Save();
        }
        public async Task DeleteDevelopmentTeam(int id)
        {
            var team = await _repository.DevelopmentTeam.GetById(id);
            _repository.DevelopmentTeam.Delete(team);
            await _repository.Save();
        }

    }
}
