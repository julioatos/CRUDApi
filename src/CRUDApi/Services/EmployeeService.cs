using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;
using CRUDApi.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IRepositoryWrapper _repository;

        public EmployeeService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public void CreateEmployee(Employee employee)
        {
            _repository.Employee.Create(employee);
            _repository.Save();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _repository.Employee.GetById(id);
            return employee;
        }

        public async Task<ICollection<Employee>> GetEmployees()
        {
            return await _repository.Employee.GetAll();
        }

    }
}
