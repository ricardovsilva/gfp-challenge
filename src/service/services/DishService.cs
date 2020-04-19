using System.Collections.Generic;
using System.Linq;
using domain.entities;
using domain.interfaces;

namespace service.services
{
    public class DishService : IDishService
    {
        private readonly IEntityRepository<Dish> DishRepository;

        public DishService(IEntityRepository<Dish> DishRepository)
        {
            this.DishRepository = DishRepository;
        }

        public IEnumerable<Dish> All()
        {
            return DishRepository.GetAll();
        }

        public Dish Find(TimeOfDay timeOfDay, DishTypes dishType)
        {
            return this.All().FirstOrDefault(_ => _.TimeOfDay == timeOfDay && _.DishType == dishType);
        }
    }
}