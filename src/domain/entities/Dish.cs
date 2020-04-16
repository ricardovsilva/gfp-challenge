using System.Collections.Generic;

namespace domain.entities
{
    public class Dish : IEntity
    {
        public DishTypes DishType { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public bool CanBeOrderedMultipleTimes { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public IList<Menu> Menus { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Dish)obj;
            if (this.Id == 0 && other.Id == 0)
            {
                return this.TimeOfDay == other.TimeOfDay && this.DishType == other.DishType;
            }

            return other.Id == this.Id;
        }
    }
}