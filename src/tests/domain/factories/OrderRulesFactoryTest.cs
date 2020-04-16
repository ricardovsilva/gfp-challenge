using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

using domain.entities;
using domain.factories;
using domain.validators;

namespace tests.domain.factories
{
    [TestClass]
    public class OrderValidatorFactoryTest
    {
        private readonly IOrderValidator DefaultOrderValidator;

        public OrderValidatorFactoryTest()
        {
            this.DefaultOrderValidator = OrderValidatorFactory.GetDefault();
        }

        [TestMethod]
        public void GetDefault_HaveSevenElements()
        {
            DefaultOrderValidator.GetRulesCounter().Should().Be(7);
        }

        [TestMethod]
        public void GetDefault_HaveMorningAndNight()
        {
            DefaultOrderValidator.GetTimesOfDay()
                .Should().BeEquivalentTo(new[] { TimeOfDay.NIGHT, TimeOfDay.MORNING });
        }
    }
}