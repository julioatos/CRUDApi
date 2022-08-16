using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;

namespace CRUDApi.Data.Repository.Implementations
{
    public class EmployeeRepository: RepositoryBase<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {

        }
    }
}
