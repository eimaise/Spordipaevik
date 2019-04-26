using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;
using NUnit.Framework;
using WebApplication2.Mappers;

namespace Tests.Mappers
{
    [TestFixture]
    public class SchoolClassMapperTests
    {
        [Test]
        public void ToClassVm_maps_Name()
        {
            var schoolClasses = new List<SchoolClass>{new SchoolClass("12B"){Id = 12}};
            var sut = new SchoolClassMapper();

            // Act
            var result = sut.ToClassVm(schoolClasses);

            // Assert
            Assert.That(result.FirstOrDefault().Name,Is.EqualTo("12B"));
        }
        [Test]
        public void ToClassVm_maps_Id()
        {
            var schoolClasses = new List<SchoolClass>{new SchoolClass("12B"){Id = 12}};
            var sut = new SchoolClassMapper();

            // Act
            var result = sut.ToClassVm(schoolClasses);

            // Assert
            Assert.That(result.FirstOrDefault().Id,Is.EqualTo(12));
        }
        [Test]
        public void ToClassVm_maps__SeveralSchoolClasses()
        {
            var schoolClasses = new List<SchoolClass>{new SchoolClass("12B"){Id = 12},new SchoolClass("11B"){Id = 11}};
            var sut = new SchoolClassMapper();

            // Act
            var result = sut.ToClassVm(schoolClasses);

            // Assert
            Assert.That(result.Count(),Is.EqualTo(2));
        }
        [Test]
        public void ToClassResultVm_maps_ExerciseId()
        {
            var datetimes = new List<DateTime>{DateTime.Now}.ToHashSet();
            var sut = new SchoolClassMapper();

            // Act
            var result = sut.ToClassResultVm(11,22,1,datetimes);

            // Assert
            Assert.That(result.SelectedExerciseId,Is.EqualTo(11));
        }
        [Test]
        public void ToClassResultVm_maps_ClassId()
        {
            var datetimes = new List<DateTime>{DateTime.Now}.ToHashSet();
            var sut = new SchoolClassMapper();

            // Act
            var result = sut.ToClassResultVm(11,22,1,datetimes);

            // Assert
            Assert.That(result.ClassId,Is.EqualTo(22));
        }

        [Test]
        public void ToClassResultVm_maps_Gender()
        {
            var datetimes = new List<DateTime>{DateTime.Now}.ToHashSet();
            var sut = new SchoolClassMapper();

            // Act
            var result = sut.ToClassResultVm(11,22,1,datetimes);

            // Assert
            Assert.That(result.Gender,Is.EqualTo(1));
        }
        [Test]
        public void ToClassResultVm_maps_Datetimes()
        {
            var datetimes = new List<DateTime>{DateTime.Now,DateTime.Now.AddYears(-1)}.ToHashSet();
            var sut = new SchoolClassMapper();

            // Act
            var result = sut.ToClassResultVm(11,22,1,datetimes);

            // Assert
            Assert.That(result.Dates.Count,Is.EqualTo(2));
        }
        [Test]
        public void ToClassResultVm_maps_Gender_Woman()
        {
            var datetimes = new List<DateTime>{DateTime.Now}.ToHashSet();
            var sut = new SchoolClassMapper();

            // Act
            var result = sut.ToClassResultVm(11,22,2,datetimes);

            // Assert
            Assert.That(result.Gender,Is.EqualTo(2));
        }
    }
}