using NUnit.Framework;
using WebApplication2;

namespace Tests
{
    [TestFixture]
    public class SecureTokenGeneratorTests
    {
        [Test]
        public void Generate_Generates_Token_With_Given_Length()
        {
            var tokenGenerator = new SecureTokenGenerator();

            // Act
            var result = tokenGenerator.Generate(190);

            // Assert
            Assert.That(result.Length, Is.EqualTo(190));
        }
    }
}