using System.Collections.Generic;

namespace domain.interfaces
{
    public interface IEntityRepository<EntityType>
    {
        void Save(EntityType target);
        EntityType Find(int id);
        IEnumerable<EntityType> GetAll();
    }
}