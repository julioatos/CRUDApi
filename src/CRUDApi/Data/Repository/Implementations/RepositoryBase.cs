﻿using CRUDApi.Models;
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

        public void Create(TEntity entity)
        {
            _ScrumTeamContext.Set<TEntity>().Add(entity);
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _ScrumTeamContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await _ScrumTeamContext.Set<TEntity>().SingleAsync(e => e.Id.Equals(id));
        }

    }
}
