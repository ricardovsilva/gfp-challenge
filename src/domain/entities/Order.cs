using System.Collections.Generic;
using System.Linq;
using domain.exceptions;

namespace domain.entities
{
    public class Order : IEntity
    {
        public Order()
        {
            this.OrderDishes = new List<OrderDish>();
        }

        public virtual List<OrderDish> OrderDishes { get; set; }
        public List<Dish> Dishes
        {
            get
            {
                return this.OrderDishes.Select(_ => _.Dish).ToList();
            }
        }
        public int Id { get; set; }

        public void AddDish(Dish dish)
        {
            if (!dish.CanBeOrderedMultipleTimes)
            {
                var alreadyAdded = this.OrderDishes.Any(_ => _.Dish == dish);
                if (alreadyAdded)
                {
                    throw new InvalidOrderException($"You cannot order {dish.Description} multiple times");
                }
            }

            this.OrderDishes.Add(new OrderDish { Dish = dish });
        }
    }
}