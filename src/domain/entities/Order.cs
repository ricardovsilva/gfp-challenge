using System;
using System.Collections.Generic;

namespace domain.entities
{
    public class Order
    {
        public TimeOfDay TimeOfDay { get; }

        public Order(TimeOfDay timeofDay)
        {
            this.TimeOfDay = timeofDay;
        }

        public void AddDish(DishTypes dRINK)
        {
        }

        public IEnumerable<DishTypes> GetDishesTypes()
        {
            return null;
        }
    }
}