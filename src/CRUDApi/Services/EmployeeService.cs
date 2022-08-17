using AutoMapper;
using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.DTOs;
using CRUDApi.Exceptions;
using CRUDApi.Models;
using CRUDApi.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateEmployeeAsync(EmployeeCreateDTO employee)
        {
            var profile = await _repository.Profile.GetById(employee.ProfileID);
            if (profile == null)
                throw new EntityNotFoundException();
            _repository.Employee.Create(_mapper.Map<Employee>(employee));
            await _repository.Save();
        }

        public async Task<EmployeeReadDTO> GetEmployeeById(int id)
        {
            var employee = await _repository.Employee.GetById(id);
            return _mapper.Map<EmployeeReadDTO>(employee);
        }

        public async Task<ICollection<EmployeeReadDTO>> GetEmployees()
        {
            var employee = await _repository.Employee.GetAll();
            return _mapper.Map<ICollection<EmployeeReadDTO>>(employee);
        }

    }
}
