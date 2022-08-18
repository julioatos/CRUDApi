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

        public override Task<DevelopmentTeam> Update(DevelopmentTeam entity)
        {
            _ScrumTeamContext.Entry(entity).State=EntityState.Modified;
            //foreach (Employee item in entity.Employees)
            //{
            //    _ScrumTeamContext.Entry(item).State=EntityState.Unchanged;
            //}
            return Task.FromResult(entity);
        }
    }
}
