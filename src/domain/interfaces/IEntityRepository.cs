using System.Linq;

namespace domain.interfaces
{
    public interface IEntityRepository<EntityType>
    {
        void Save(EntityType target);
        EntityType Find(int id);
        IQueryable<EntityType> GetAll();
    }
}