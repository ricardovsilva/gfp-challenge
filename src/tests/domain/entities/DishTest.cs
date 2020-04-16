using domain.entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests.domain.entities
{
    [TestClass]
    public class DishTest
    {
        [TestMethod]
        public void TwoDishesWithIdZero_WithSameDishTypeAndTimeOfDay_AreEqual()
        {
            var dish1 = new Dish() { Id = 0, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.MORNING };
            var dish2 = new Dish() { Id = 0, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.MORNING };

            dish1.Should().Be(dish2);
        }

        [TestMethod]
        public void TwoDishesWithIdZero_WithDifferentDishType_AreNotEqual()
        {
            var dish1 = new Dish() { Id = 0, DishType = DishTypes.DRINK, TimeOfDay = TimeOfDay.MORNING };
            var dish2 = new Dish() { Id = 0, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.MORNING };

            dish1.Should().NotBe(dish2);
        }

        [TestMethod]
        public void TwoDishesWithIdZero_WithDifferentTimeOfDay_AreNotEqual()
        {
            var dish1 = new Dish() { Id = 0, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.MORNING };
            var dish2 = new Dish() { Id = 0, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.NIGHT };

            dish1.Should().NotBe(dish2);
        }

        [TestMethod]
        public void TwoDishesWithSameId_IdNotEqualToZero_AreEqual()
        {
            var dish1 = new Dish() { Id = 10, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.MORNING };
            var dish2 = new Dish() { Id = 10, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.NIGHT };

            dish1.Should().Be(dish2);
        }

        [TestMethod]
        public void TwoDishesWithDifferentIds_OneOfIdsIsDifferentThanZero_AreNotEqual()
        {
            var dish1 = new Dish() { Id = 10, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.MORNING };
            var dish2 = new Dish() { Id = 0, DishType = DishTypes.DESSERT, TimeOfDay = TimeOfDay.NIGHT };

            dish1.Should().NotBe(dish2);
        }
    }
}