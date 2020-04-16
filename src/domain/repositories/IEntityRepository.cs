using System.Collections.Generic;

namespace domain.repositories
{
    public interface IEntityRepository<EntityType>
    {
        void Save(EntityType target);
        EntityType Find(int id);
        IEnumerable<EntityType> All();
    }
}