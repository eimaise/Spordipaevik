using NUnit.Framework;
using WebApplication2;

namespace Tests
{
    [TestFixture]
    public class SecureTokenGeneratorTests
    {
        [TestCase(12)]
        [TestCase(190)]
        public void Generate_Generates_Token_With_Given_Length(int length)
        {
            var tokenGenerator = new SecureTokenGenerator();

            // Act
            var result = tokenGenerator.Generate(length);

            // Assert
            Assert.That(result.Length, Is.EqualTo(length));
        }
    }
}