using CRUDApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Implementations
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class, IEntityBase<TKey> 
    {
        protected readonly ScrumTeamContext _ScrumTeamContext;

        public RepositoryBase(ScrumTeamContext scrumTeamContext)
        {
            _ScrumTeamContext=scrumTeamContext;
        }

        public virtual void Create(TEntity entity)
        {
            _ScrumTeamContext.Set<TEntity>().Add(entity);
        }

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await _ScrumTeamContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(TKey id)
        {
            return await _ScrumTeamContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

    }
}
