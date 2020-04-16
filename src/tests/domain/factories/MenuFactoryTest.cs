using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

using domain.entities;
using domain.factories;
using System.Linq;

namespace tests.domain.factories
{
    [TestClass]
    public class MenuFactoryTest
    {
        private readonly Menu DefaultMenu;

        public MenuFactoryTest()
        {
            this.DefaultMenu = MenuFactory.GetDefault();
        }

        [TestMethod]
        public void GetDefault_HaveSevenElements()
        {
            DefaultMenu.Dishes.Count().Should().Be(7);
        }

        [TestMethod]
        public void GetDefault_HaveMorningAndNight()
        {
            DefaultMenu.TimesOfDay.Should().BeEquivalentTo(new[] { TimeOfDay.NIGHT, TimeOfDay.MORNING });
        }
    }
}