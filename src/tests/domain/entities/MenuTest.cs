using System;
using domain.entities;
using domain.exceptions;
using domain.factories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests.domain.entities
{
    [TestClass]
    public class MenuTest
    {
        private Menu Menu { get; set; }

        public MenuTest()
        {
            this.Menu = MenuFactory.GetDefault();
        }

        [TestMethod]
        public void GetDish_ExistentDish_ReturnsDish()
        {
            var target = this.Menu.GetDish(TimeOfDay.MORNING, DishTypes.DRINK);
            target.DishType.Should().Be(DishTypes.DRINK);
            target.TimeOfDay.Should().Be(TimeOfDay.MORNING);
        }

        [TestMethod]
        public void GetDish_UnexistantDish_RaiseInvalidOrderException()
        {
            Action action = () => this.Menu.GetDish(TimeOfDay.MORNING, DishTypes.DESSERT);
            action.Should().Throw<InvalidOrderException>();
        }
    }
}