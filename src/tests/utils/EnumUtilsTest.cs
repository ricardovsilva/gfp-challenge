using domain.entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using utils;

namespace tests.utils
{
    [TestClass]
    public class EnumUtilsTest
    {
        [TestMethod]
        public void IsValidEnumOfType_TimeOfDayEnumWithMorningString_ReturnsTrue()
        {
            EnumUtils.IsValidEnumOfType("morning", typeof(TimeOfDay)).Should().BeTrue();
        }

        [TestMethod]
        public void IsValidEnumOfType_TimeOfDayEnumWithMorningUppercaseString_ReturnsTrue()
        {
            EnumUtils.IsValidEnumOfType("MORNING", typeof(TimeOfDay)).Should().BeTrue();
        }

        [TestMethod]
        public void IsValidEnumOfType_TimeOfDayEnumWithFooString_ReturnsFalse()
        {
            EnumUtils.IsValidEnumOfType("foo", typeof(TimeOfDay)).Should().BeFalse();
        }
    }
}