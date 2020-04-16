using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

using domain.entities;
using domain.exceptions;

namespace tests.domain.entities
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void GetDishes_ReturnsArrayOfDishes()
        {
            var order = new Order(TimeOfDay.MORNING);
            order.AddDish(DishTypes.DRINK);
            order.AddDish(DishTypes.ENTREE);
            order.AddDish(DishTypes.SIDE);

            var actual = order.GetDishesTypes();
            actual.Should()
                .HaveCount(3)
                .And.BeEquivalentTo(new[] { DishTypes.DRINK, DishTypes.ENTREE, DishTypes.SIDE });
        }

        [TestMethod]
        public void AddDish_DrinkMultipleTimesAtMorning_AddsAllDrinks()
        {
            var order = new Order(TimeOfDay.MORNING);
            order.AddDish(DishTypes.DRINK);
            order.AddDish(DishTypes.DRINK);
            order.AddDish(DishTypes.DRINK);

            var actual = order.GetDishesTypes();
            actual.Should().NotBeEmpty()
                .And.HaveCount(3)
                .And.BeEquivalentTo(new[] { DishTypes.DRINK, DishTypes.DRINK, DishTypes.DRINK });
        }

        [TestMethod]
        public void AddDish_DrinkMultipleTimesAtNight_RaisesOrderValidationException()
        {
            var order = new Order(TimeOfDay.NIGHT);
            order.AddDish(DishTypes.DRINK);

            Action action = () => order.AddDish(DishTypes.DRINK);
            action.Should().Throw<OrderValidationException>();
        }

        [TestMethod]
        public void AddDish_DessertAtMorning_RaisesOrderValidationException()
        {
            var order = new Order(TimeOfDay.MORNING);
            Action action = () => order.AddDish(DishTypes.DESSERT);

            action.Should().Throw<OrderValidationException>();
        }

        [TestMethod()]
        public void AddDish_EntreeMultipleTimesAtAnyTimeOfDay_RaisesOrderValidationException()
        {
            var order = new Order(TimeOfDay.MORNING);
            order.AddDish(DishTypes.ENTREE);
            Action action = () => order.AddDish(DishTypes.ENTREE);

            action.Should().Throw<OrderValidationException>();
        }

        [TestMethod]
        public void AddDish_SideMultipleTimesAtAnyTimeOfDay_RaisesOrderValidationException()
        {
            var order = new Order(TimeOfDay.MORNING);
            order.AddDish(DishTypes.SIDE);
            Action action = () => order.AddDish(DishTypes.SIDE);

            action.Should().Throw<OrderValidationException>();
        }

        [TestMethod]
        public void AddDish_DessertMultipleTimesAtNight_RaisesOrderValidationException()
        {
            var order = new Order(TimeOfDay.NIGHT);
            order.AddDish(DishTypes.DESSERT);
            Action action = () => order.AddDish(DishTypes.DESSERT);

            action.Should().Throw<OrderValidationException>();
        }
    }
}