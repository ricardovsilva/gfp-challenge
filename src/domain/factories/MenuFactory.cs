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
                    new Dish() { DishType = DishTypes.ENTREE, TimeOfDay = TimeOfDay.MORNING, CanBeOrderedMultipleTimes = false, Description = "Eggs"},
                    new Dish() { DishType = DishTypes.SIDE, TimeOfDay = TimeOfDay.MORNING, CanBeOrderedMultipleTimes = false, Description = "Toast"},
                    new Dish() { DishType = DishTypes.DRINK, TimeOfDay = TimeOfDay.MORNING, CanBeOrderedMultipleTimes = true, Description = "Coffee"},
                    new Dish() { DishType = DishTypes.ENTREE, TimeOfDay = TimeOfDay.NIGHT, CanBeOrderedMultipleTimes = false, Description = "Steak"},
                    new Dish() { DishType = DishTypes.SIDE, TimeOfDay = TimeOfDay.NIGHT, CanBeOrderedMultipleTimes = false, Description = "Potato"},
                    new Dish() { DishType = DishTypes.DRINK, TimeOfDay = TimeOfDay.NIGHT, CanBeOrderedMultipleTimes = false, Description = "Wine"},
                    new Dish() { DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.NIGHT, CanBeOrderedMultipleTimes = false, Description = "Cake"},
                };

                MenuFactory.Default = new Menu()
                {
                    Dishes = dishes
                };
            }

            return Default;
        }
    }
}