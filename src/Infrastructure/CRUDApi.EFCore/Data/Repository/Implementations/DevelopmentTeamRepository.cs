using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Enums;
using CRUDApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            return await _ScrumTeamContext.Set<DevelopmentTeam>().Include(team => team.Employees).ThenInclude(employee => employee.Profile).ToListAsync();
        }

        public override async Task<DevelopmentTeam> GetById(int id)
        {
            return await _ScrumTeamContext.Set<DevelopmentTeam>().Include(team => team.Employees).ThenInclude(employee => employee.Profile).FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public override Task<DevelopmentTeam> Update(DevelopmentTeam entity)
        {
            _ScrumTeamContext.DevelopmentTeams.Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<bool> HaveAnyProfile(List<int> ids, Profile requestedProfile)
        {
            bool have = await _ScrumTeamContext.Employees.Where(e => ids.Contains(e.Id)).AnyAsync(e => e.Profile.Equals(requestedProfile));
            return have;
        }
    }
}
