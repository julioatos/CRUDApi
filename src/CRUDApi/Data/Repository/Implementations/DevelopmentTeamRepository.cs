using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;

namespace CRUDApi.Data.Repository.Implementations
{
    public class DevelopmentTeamRepository : CRUDRepository<DevelopmentTeam, int>, IDevelopmentTeamRepository
    {
        public DevelopmentTeamRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {
        }
    }
}
