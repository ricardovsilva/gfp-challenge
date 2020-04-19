using System.Collections.Generic;
using System.Linq;

namespace domain.interfaces
{
    public interface IDatabase
    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity Find<TEntity>(int id) where TEntity : class;
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Commit();
    }
}