using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Implementations
{
    public class EmployeeRepository: RepositoryBase<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {
            
        }

        public override void Create(Employee entity)
        {
            _ScrumTeamContext.Set<Employee>().Attach(entity);
        }

        public override async Task<ICollection<Employee>> GetAll()
        {
            return await _ScrumTeamContext.Set<Employee>().Include(employee => employee.Profile).ToListAsync();
        }

        public override async Task<Employee> GetById(int id)
        {
            return await _ScrumTeamContext.Set<Employee>().Include(employee => employee.Profile).SingleAsync(employee => employee.Id.Equals(id));
        }

        public async Task<ICollection<Employee>> GetEmployeesById(int[] ids)
        {
            List<Employee> employees = new();
            foreach (var employeesId in ids)
            {
                employees.Add(await GetById(employeesId));
            }
            return employees;
        }
    }
}
