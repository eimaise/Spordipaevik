using Core.Data.Entities;
using NUnit.Framework;

namespace Tests.Entities
{
    [TestFixture]
    public class SchoolClassTests
    {
        [Test]
        public void SetFinishedStatus_Sets_IsFinished_Status_To_True()
        {
            var schoolClass = new SchoolClass("11B");
            // Act
            schoolClass.SetFinishedStatus(true);
            // Assert
            Assert.That(schoolClass.IsFinished,Is.True);
        }

        [Test]
        public void SetFinishedStatus_Sets_IsFinished_Status_To_False()
        {
            var schoolClass = new SchoolClass("11B",true);
            // Act
            schoolClass.SetFinishedStatus(false);
            // Assert
            Assert.That(schoolClass.IsFinished,Is.False);
        }

        [Test]
        public void ChangeName_Changes_Name()
        {
            var schoolClass = new SchoolClass("11B",true);
            // Act
            schoolClass.ChangeName("12B");
            // Assert
            Assert.That(schoolClass.Name,Is.EqualTo("12B"));
        }
    }
    [TestFixture]
    public class TeacherRegistrationTests
    {
        [TestCase(true)]
        public void SetTokenStatus_Sets_TokenStatus(bool status)
        {
            var schoolClass = new TeacherRegistration("token",!status,"test@test.ee");
            // Act
            schoolClass.SetTokenStatus(status);

            // Assert
            Assert.That(schoolClass.Used,Is.EqualTo(status));
        }

    }
}