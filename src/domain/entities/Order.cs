using System.Collections.Generic;
using System.Linq;
using domain.exceptions;

namespace domain.entities
{
    public class Order : IEntity
    {
        public Order()
        {
            this._dishes = new List<Dish>();
        }

        private IList<Dish> _dishes;
        public IList<Dish> Dishes
        {
            get
            {
                return new List<Dish>(this._dishes);
            }
        }
        public int Id { get; set; }

        public void AddDish(Dish dish)
        {
            if (!dish.CanBeOrderedMultipleTimes)
            {
                var alreadyAdded = this.Dishes.FirstOrDefault(_ => _ == dish) != null;
                if (alreadyAdded)
                {
                    throw new InvalidOrderException($"You cannot order {dish.Description} multiple times");
                }
            }

            this._dishes.Add(dish);
        }
    }
}