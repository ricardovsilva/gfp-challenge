using System.Collections.Generic;

namespace infra
{
    public interface IDatabase
    {
        IEnumerable<TEntity> All<TEntity>();
        TEntity Find<TEntity>(int id);
        TEntity Insert<TEntity>(TEntity entity);
        TEntity Update<TEntity>(TEntity entity);
    }
}