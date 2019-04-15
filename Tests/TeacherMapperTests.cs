using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;
using NUnit.Framework;
using WebApplication2.Mappers;

namespace Tests
{
    [TestFixture]
    public class TeacherMapperTests
    {
        private TeacherMapper _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new TeacherMapper();
        }

        [Test]
        public void ToStudentsListVm_Return_TeacherListVm()
        {
            // Act
            var result = _sut.ToStudentsListVm(new List<ApplicationUser>());
            // Assert
            Assert.That(result.Teachers.Count, Is.EqualTo(0));
        }

        [Test]
        public void ToStudentsListVm_Return_TeacherListVm_with_mapped_Name()
        {
            // Act
            var result = _sut.ToStudentsListVm(new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Name = "name"
                }
            });
            // Assert
            Assert.That(result.Teachers.FirstOrDefault().Name, Is.EqualTo("name"));
        }

        [Test]
        public void ToStudentsListVm_Return_TeacherListVm_with_mapped_Email()
        {
            // Act
            var result = _sut.ToStudentsListVm(new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Email = "Email"
                }
            });
            // Assert
            Assert.That(result.Teachers.FirstOrDefault().Email, Is.EqualTo("Email"));
        }

        [Test]
        public void ToStudentsListVm_Return_TeacherListVm_with_Several_Vm()
        {
            // Act
            var result = _sut.ToStudentsListVm(new List<ApplicationUser>
            {
                new ApplicationUser
                {
                },
                new ApplicationUser()
            });
            // Assert
            Assert.That(result.Teachers.Count, Is.EqualTo(2));
        }
    }
}