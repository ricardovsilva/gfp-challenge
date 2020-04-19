using System.Collections.Generic;
using domain.entities;

namespace domain.interfaces
{
    public interface IDishService
    {
        IEnumerable<Dish> All();
        Dish Find(TimeOfDay timeOfDay, DishTypes dishType);
    }
}