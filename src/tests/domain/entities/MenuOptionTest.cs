using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using FluentAssertions;

using domain.entities;
using domain.exceptions;

namespace tests.domain.entities
{
    [TestClass]
    public class MenuOptionTest
    {
        [TestMethod]
        public void AddDish_DesertAtMorningTime_RaiseInvalidDishException()
        {
            var menu = new MenuOption(TimeOfDay.MORNING);
            var dish = new Dish(DishTypes.DESSERT);

            Action action = () => menu.AddDish(dish);
            action.Should().Throw<InvalidOptionException>();
        }

        [TestMethod]
        public void AddDish_DesertAtNight_NothingHappens()
        {
            var menu = new MenuOption(TimeOfDay.NIGHT);
            var dish = new Dish(DishTypes.DESSERT);

            menu.AddDish(dish);
        }
    }
}

