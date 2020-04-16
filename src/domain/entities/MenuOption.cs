using System.Collections.Generic;

namespace domain.entities
{
    public class MenuOption
    {
        public TimeOfDay TimeOfDay { get; }
        private IList<Dish> Dishes { get; set; }

        public MenuOption(TimeOfDay timeOfDay)
        {
            this.TimeOfDay = timeOfDay;
        }

        public void AddDish(Dish dish)
        {
        }
    }
}