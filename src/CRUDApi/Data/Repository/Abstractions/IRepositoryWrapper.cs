namespace CRUDApi.Data.Repository.Abstractions
{
    public interface IRepositoryWrapper<TEntity, TKey> : 
        IRepositoryBase<TEntity, TKey>, IUpdate<TEntity, TKey>, IDelete<TEntity>
    {
        IRepositoryBase<TEntity, TKey> RepositoryBase { get; }
        IUpdate<TEntity, TKey> Update { get; }
        IDelete<TEntity> Delete { get; }

        void Save();
    }
}
