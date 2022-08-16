using CRUDApi.Models;

namespace CRUDApi.Data.Repository.Implementations
{
    public class EmployeeRepository<TEntity, TKey> : RepositoryBase<TEntity, TKey> where TEntity : Employee, IEntityBase<TKey>
    {
        public EmployeeRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {

        }
    }
}
