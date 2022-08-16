using CRUDApi.Models;

namespace CRUDApi.Data.Repository.Implementations
{
    public class DevelopmentTeamRepository<TEntity, TKey> : 
        CRUDRepository<TEntity, TKey> where TEntity : Employee, IEntityBase<TKey>
    {
        public DevelopmentTeamRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {
        }
    }
}
