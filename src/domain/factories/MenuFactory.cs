using System.Collections.Generic;
using domain.entities;

namespace domain.factories
{
    public static class MenuFactory
    {
        private static Menu Default
        {
            get; set;
        }

        public static Menu GetDefault()
        {
            if (MenuFactory.Default == null)
            {
                var dishes = new List<Dish>()
                {
                    new Dish() { Id = 1, DishType = DishTypes.ENTREE, TimeOfDay = TimeOfDay.MORNING, CanBeOrderedMultipleTimes = false, Description = "Eggs"},
                    new Dish() { Id = 2, DishType = DishTypes.SIDE, TimeOfDay = TimeOfDay.MORNING, CanBeOrderedMultipleTimes = false, Description = "Toast"},
                    new Dish() { Id = 3, DishType = DishTypes.DRINK, TimeOfDay = TimeOfDay.MORNING, CanBeOrderedMultipleTimes = true, Description = "Coffee"},
                    new Dish() { Id = 4, DishType = DishTypes.ENTREE, TimeOfDay = TimeOfDay.NIGHT, CanBeOrderedMultipleTimes = false, Description = "Steak"},
                    new Dish() { Id = 5, DishType = DishTypes.SIDE, TimeOfDay = TimeOfDay.NIGHT, CanBeOrderedMultipleTimes = false, Description = "Potato"},
                    new Dish() { Id = 6, DishType = DishTypes.DRINK, TimeOfDay = TimeOfDay.NIGHT, CanBeOrderedMultipleTimes = false, Description = "Wine"},
                    new Dish() { Id = 7, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.NIGHT, CanBeOrderedMultipleTimes = false, Description = "Cake"},
                };

                MenuFactory.Default = new Menu()
                {
                    Dishes = dishes,
                    Id = 1,
                };
            }

            return Default;
        }
    }
}