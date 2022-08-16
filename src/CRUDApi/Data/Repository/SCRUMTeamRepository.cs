using CRUDApi.Data.Repository.Abstractions;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository
{
    public class SCRUMTeamRepository<TEntity> : IAdd<TEntity>
    {
        private readonly ScrumTeamContext _context;

        public SCRUMTeamRepository(ScrumTeamContext context)
        {
            _context=context;
        }

        public Task<TEntity> Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return Task.FromResult(entity);
        }

        
    }
}
