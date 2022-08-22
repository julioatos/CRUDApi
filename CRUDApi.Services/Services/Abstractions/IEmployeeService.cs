using CRUDApi.DTOs;
using CRUDApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Services.Abstractions
{
    public interface IEmployeeService
    {
        public Task CreateEmployeeAsync(EmployeeCreateDTO employee);
        public Task<ICollection<EmployeeReadDTO>> GetEmployees();
        public Task<EmployeeReadDTO> GetEmployeeById(int id);
    }
}
