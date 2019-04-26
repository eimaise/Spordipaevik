using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;
using NUnit.Framework;
using WebApplication2.Mappers;

namespace Tests.Mappers
{
    [TestFixture]
    public class ExerciseMapperTests
    {
        [Test]
        public void ToExerciseListVm_maps_Id()
        {
            var exercises = new List<Exercise>{new Exercise("jooks",1){Id = 12}};
            var sut = new ExerciseMapper();

            // Act
            var result = sut.ToExerciseListVm(exercises);

            // Assert
            Assert.That(result.FirstOrDefault().Id,Is.EqualTo(12));
        }

        [Test]
        public void ToExerciseListVm_maps_Name()
        {
            var exercises = new List<Exercise>{new Exercise("jooks",1){Id = 12}};
            var sut = new ExerciseMapper();

            // Act
            var result = sut.ToExerciseListVm(exercises);

            // Assert
            Assert.That(result.FirstOrDefault().Name,Is.EqualTo("jooks"));
        }

        [Test]
        public void ToExerciseListVm_maps_Comment()
        {
            var exercises = new List<Exercise>{new Exercise("jooks",1,"comment"){Id = 12}};
            var sut = new ExerciseMapper();

            // Act
            var result = sut.ToExerciseListVm(exercises);

            // Assert
            Assert.That(result.FirstOrDefault().Comment,Is.EqualTo("comment"));
        }

        [Test]
        public void ToExerciseListVm_maps_AllExercises()
        {
            var exercises = new List<Exercise>{new Exercise("jooks",1,"comment"){Id = 12},new Exercise("hype",1)};
            var sut = new ExerciseMapper();

            // Act
            var result = sut.ToExerciseListVm(exercises);

            // Assert
            Assert.That(result.Count(),Is.EqualTo(2));
        }
    }
}