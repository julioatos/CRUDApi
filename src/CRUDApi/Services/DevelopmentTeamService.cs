using AutoMapper;
using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.DTOs;
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

            var devTeam = _mapper.Map<DevelopmentTeam>(developmentTeam);
            devTeam.Employees = new List<Employee>();
            foreach (var id in developmentTeam.EmployesId)
            {
                devTeam.Employees.Add(new Employee()
                {
                    Id = id
                });
            }

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
