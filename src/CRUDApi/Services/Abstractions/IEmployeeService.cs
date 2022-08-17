using CRUDApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services.Abstractions
{
    public interface IEmployeeService
    {
        public void CreateEmployee(Employee employee);
        public Task<ICollection<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int id);
    }
}
