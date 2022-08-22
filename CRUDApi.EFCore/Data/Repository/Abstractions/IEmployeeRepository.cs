using CRUDApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IEmployeeRepository : IRepositoryBase<Employee, int>
    {
        Task<ICollection<Employee>> GetEmployeesById(int[] ids);
    }
}
