using Core.Helpers;
using NUnit.Framework;

namespace Tests.Helpers
{
    [TestFixture]
    public class HelpersTests
    {
        [TestCase("12A",12)]
        [TestCase("1B",1)]
        [TestCase("2A",2)]
        [TestCase("12C",12)]
        [TestCase("11D",11)]
        public void Helper_Removes_Class_Letter(string className,int expectedValue)
        {
            // Act
            var result = Helper.GetClassNumberFromClassName(className);
            // Assert
            Assert.That(result,Is.EqualTo(expectedValue));
        }
    }
}