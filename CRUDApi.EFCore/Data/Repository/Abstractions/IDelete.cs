using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IDelete<TEntity>
    {
        void Delete(TEntity entity);
        /// <summary>
        /// Delete a range of Entity that have the expression conditions
        /// </summary>
        /// <param name="expression"></param>
        void Delete(Expression<Func<TEntity, bool>> expression);
    }
}
