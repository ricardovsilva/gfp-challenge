using System.Linq;
using Microsoft.EntityFrameworkCore;

using domain.interfaces;

namespace infra.database
{
    public class Database : IDatabase
    {
        private readonly DbContext Context;

        public Database(DbContext context)
        {
            this.Context = context;
        }

        public TEntity Find<TEntity>(int id)
            where TEntity : class
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : class
        {
            return this.Context.Set<TEntity>().AsNoTracking();
        }

        public void Insert<TEntity>(TEntity entity)
            where TEntity : class
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public void Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            throw new System.NotImplementedException();
        }
    }
}