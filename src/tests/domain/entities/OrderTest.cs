using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

using domain.entities;
using domain.exceptions;
using domain.factories;

namespace tests.domain.entities
{
    [TestClass]
    public class OrderTest
    {
        private readonly Menu Menu;

        public OrderTest()
        {
            Menu = MenuFactory.GetDefault();
        }

        [TestMethod]
        public void GetDishes_ReturnsArrayOfDishes()
        {
            var order = new Order();
            order.AddDish(Menu.GetDish(TimeOfDay.MORNING, DishTypes.DRINK));
            order.AddDish(Menu.GetDish(TimeOfDay.MORNING, DishTypes.ENTREE));
            order.AddDish(Menu.GetDish(TimeOfDay.MORNING, DishTypes.SIDE));

            order.Dishes.Select(_ => _.DishType)
                .Should()
                .HaveCount(3)
                .And.BeEquivalentTo(new[] { DishTypes.DRINK, DishTypes.ENTREE, DishTypes.SIDE });
        }

        [TestMethod]
        public void AddDish_DrinkMultipleTimesAtMorning_AddsAllDrinks()
        {
            var order = new Order();
            order.AddDish(Menu.GetDish(TimeOfDay.MORNING, DishTypes.DRINK));
            order.AddDish(Menu.GetDish(TimeOfDay.MORNING, DishTypes.DRINK));
            order.AddDish(Menu.GetDish(TimeOfDay.MORNING, DishTypes.DRINK));

            order.Dishes.Select(_ => _.DishType)
                .Should()
                .NotBeEmpty()
                .And.HaveCount(3)
                .And.BeEquivalentTo(new[] { DishTypes.DRINK, DishTypes.DRINK, DishTypes.DRINK });
        }

        [TestMethod]
        public void AddDish_DrinkMultipleTimesAtNight_RaisesInvalidOrderException()
        {
            var order = new Order();
            Action action = () => order.AddDish(Menu.GetDish(TimeOfDay.NIGHT, DishTypes.DRINK));
            action();
            action.Should().Throw<InvalidOrderException>();
        }

        [TestMethod]
        public void AddDish_DessertAtMorning_RaisesInvalidOrderException()
        {
            var order = new Order();
            Action action = () => order.AddDish(Menu.GetDish(TimeOfDay.MORNING, DishTypes.DESSERT));

            action.Should().Throw<InvalidOrderException>();
        }

        [TestMethod()]
        public void AddDish_EntreeMultipleTimesAtAnyTimeOfDay_RaisesInvalidOrderException()
        {
            var order = new Order();
            Action action = () => order.AddDish(Menu.GetDish(TimeOfDay.MORNING, DishTypes.ENTREE));
            action();
            action.Should().Throw<InvalidOrderException>();
        }

        [TestMethod]
        public void AddDish_SideMultipleTimesAtAnyTimeOfDay_RaisesInvalidOrderException()
        {
            var order = new Order();
            Action action = () => order.AddDish(Menu.GetDish(TimeOfDay.MORNING, DishTypes.SIDE));
            action();
            action.Should().Throw<InvalidOrderException>();
        }

        [TestMethod]
        public void AddDish_DessertMultipleTimesAtNight_RaisesInvalidOrderException()
        {
            var order = new Order();
            Action action = () => order.AddDish(Menu.GetDish(TimeOfDay.NIGHT, DishTypes.DESSERT));
            action();
            action.Should().Throw<InvalidOrderException>();
        }
    }
}