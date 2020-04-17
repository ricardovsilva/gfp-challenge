using System.Collections.Generic;

using domain.entities;
using domain.interfaces;

namespace service.repositories
{
    public class BaseRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity
    {
        public IDatabase Database { get; }
        public BaseRepository(IDatabase database)
        {
            this.Database = database;
        }

        public void Save(TEntity target)
        {
            if (this.Database.Find<TEntity>(target.Id) != null)
            {
                this.Database.Insert(target);
            }
            else
            {
                this.Database.Update(target);
            }
        }

        public TEntity Find(int id)
        {
            return this.Database.Find<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Database.GetAll<TEntity>();
        }
    }
}