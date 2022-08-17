using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Implementations
{
    public class DevelopmentTeamRepository : CRUDRepository<DevelopmentTeam, int>, IDevelopmentTeamRepository
    {
        public DevelopmentTeamRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {
        }

        public override async Task<ICollection<DevelopmentTeam>> GetAll()
        {
            return await _ScrumTeamContext.Set<DevelopmentTeam>().Include(team => team.Employees).ToListAsync();
    
        }
    }
}
