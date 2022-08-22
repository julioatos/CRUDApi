using CRUDApi.Data.Repository.Abstractions;
using CRUDApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace CRUDApi.Data.Repository.Implementations
{
    public class CRUDRepository<TEntity, TKey> :
        RepositoryBase<TEntity, TKey>, IUpdate<TEntity, TKey>, IDelete<TEntity> where TEntity : class, IEntityBase<TKey>
    {
        public CRUDRepository(ScrumTeamContext scrumTeamContext) : base(scrumTeamContext)
        {
        }

        public void Delete(TEntity entity)
        {
            _ScrumTeamContext.Set<TEntity>().Remove(entity);
        }

        public async void Delete(Expression<Func<TEntity, bool>> expression)
        {
            //Expression<Func<TEntity, bool>> x = entity => entity.Id.Equals(0);
            var entities = await this._ScrumTeamContext.Set<TEntity>().Where(expression).ToListAsync();
            _ScrumTeamContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual Task<TEntity> Update(TEntity entity)
        {
            _ScrumTeamContext.Entry(entity).State= EntityState.Modified;
            var helper = _ScrumTeamContext.Set<TEntity>().Update(entity);
            return Task.FromResult(helper.Entity);
        }

    }
}
