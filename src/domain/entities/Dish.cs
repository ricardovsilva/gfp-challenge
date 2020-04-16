namespace domain.entities
{
    public class Dish
    {
        public DishTypes DishType { get; }

        public Dish(DishTypes dishType)
        {
            this.DishType = dishType;
        }
    }
}