using System.Collections.Generic;
using Core;
using Core.AppServices;
using Core.AppServices.Excercise;
using Core.AppServices.Units;
using Core.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using WebApplication2;
using WebApplication2.Controllers;
using WebApplication2.Mappers;
using WebApplication2.ViewModels.Exercises;
using WebApplication2.ViewModels.Students;

namespace Tests
{
    [TestFixture]
    public class ExerciseControllerTests
    {
        private Mock<Messages> _messages;
        private ExerciseController _sut;

        [SetUp]
        public void Setup()
        {
            _messages = new Mock<Messages>();

            _sut = new ExerciseController(_messages.Object)
            {
            };
        }

        [Test]
        public void Index_Returns_View_With_ExerciseList()
        {
            _messages.Setup(x => x.Dispatch(It.IsAny<GetExerciseListQuery>()))
                .Returns(new List<Exercise>());

            // Act
            var result = (ViewResult) _sut.Index("");

            // Assert
            Assert.That(result.Model, Is.TypeOf<List<Exercise>>());
        }

        [Test]
        public void Create_Returns_View_With_UnitList()
        {
            _messages.Setup(x => x.Dispatch(It.IsAny<GetUnitListQuery>()))
                .Returns(new List<Unit>());

            // Act
            var result = (ViewResult) _sut.Create();

            // Assert
            Assert.That(result.Model, Is.TypeOf<AddExerciseVm>());
        }

        [Test]
        public void Create_Returns_View_With_Model()
        {
            _messages.Setup(x => x.Dispatch(It.IsAny<GetUnitListQuery>()))
                .Returns(new List<Unit>{Unit.CreateValueUnit("meeter")});

            // Act
            var result = (ViewResult) _sut.Create();
            var model = (AddExerciseVm) result.Model;

            // Assert
            Assert.That(result.Model, Is.TypeOf<AddExerciseVm>());
            Assert.That(model.Units.Count,Is.EqualTo(1));
        }
    }
}