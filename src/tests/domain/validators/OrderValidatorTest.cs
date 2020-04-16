using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

using domain.entities;
using domain.exceptions;
using domain.validators;

namespace tests.domain.entities
{
    [TestClass]
    public class OrderValidatorTest
    {
        [TestMethod]
        public void AddValidation_NewDishTypeForMorning_IncrementsCounterByOne()
        {
            var target = new OrderValidator();
            target.AddValidation(DishTypes.DRINK, TimeOfDay.MORNING, multipleAllowed: true);
            target.GetRulesCounter().Should().Be(1);
        }

        [TestMethod]
        public void AddValidation_DishAndDayTimeAlreadyAdded_RaisesDishValidationAlreadyAddedException()
        {
            var target = new OrderValidator();
            Action action = () => target.AddValidation(DishTypes.DRINK, TimeOfDay.MORNING, multipleAllowed: true);
            action();

            action.Should().Throw<DishValidationAlreadyAddedException>();
        }

        [TestMethod]
        public void AddValidation_SameDishForTwoDifferentDayTimes_IncrementsCounterByTwo()
        {
            var target = new OrderValidator();
            Action<TimeOfDay> addDrinkRule = (TimeOfDay timeOfDay) => target.AddValidation(DishTypes.DRINK, timeOfDay, multipleAllowed: true);

            addDrinkRule(TimeOfDay.MORNING);
            addDrinkRule(TimeOfDay.NIGHT);

            target.GetRulesCounter().Should().Be(2);
        }

        [TestMethod]
        public void Validate_RuleAllowMultipleDrinks_GivenMultipleDrinks_NothingHappens()
        {
            var target = new OrderValidator();
            target.AddValidation(DishTypes.DRINK, TimeOfDay.MORNING, multipleAllowed: true);
            target.Validate(
                new[] { DishTypes.DRINK, DishTypes.DRINK, DishTypes.DRINK },
                TimeOfDay.MORNING
            );
        }

        [TestMethod]
        public void Validate_RuleDisallowMultipleDrinks_GivenMultipleDrinks_RaisesOrderValidationException()
        {
            var target = new OrderValidator();
            target.AddValidation(DishTypes.DRINK, TimeOfDay.MORNING, multipleAllowed: false);

            Action action = () => target.Validate(new[] { DishTypes.DRINK, DishTypes.DRINK }, TimeOfDay.MORNING);
            action.Should().Throw<OrderValidationException>();
        }
    }
}