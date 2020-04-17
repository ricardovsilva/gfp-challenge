using System.Collections.Generic;
using System.Linq;

using domain.exceptions;

namespace domain.entities
{
    public class Menu : IEntity
    {
        public Menu()
        {
            this.Dishes = new List<Dish>();
        }

        public int Id { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }

        public IEnumerable<TimeOfDay> TimesOfDay
        {
            get
            {
                return this.Dishes.Select(dish => dish.TimeOfDay).Distinct();
            }
        }

        public IEnumerable<Dish> GetDishesByTimeOfDay(TimeOfDay timeOfDay)
        {
            return this.Dishes.Where(dish => dish.TimeOfDay == timeOfDay);
        }

        public Dish GetDish(TimeOfDay timeOfDay, DishTypes dishType)
        {
            var dishes = this.GetDishesByTimeOfDay(timeOfDay);
            var dish = dishes.FirstOrDefault(_ => _.DishType == dishType);

            if (dish == null)
            {
                throw new InvalidOrderException($"Menu does not have ${dishType} at ${timeOfDay}");
            }

            return dish;
        }
    }
}