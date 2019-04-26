using System;
using Core.Data.Entities;
using NUnit.Framework;
using WebApplication2.Mappers;

namespace Tests.Mappers
{
    [TestFixture]
    public class ResultMapperTests
    {
        private ResultMapper _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ResultMapper();
        }

        [TestCase(12)]
        [TestCase(23)]
        public void ToLeaderBoardResultVm_maps_ResultValue(int value)
        {
            var result = new Result(new Student{Name = "name",SchoolClass = new SchoolClass("12B")},1,new ResultValue("Meeter",value),DateTime.Now);

            // Act
            var mapperResult = _sut.ToLeaderBoardResultVm(result);

            // Assert
            Assert.That(mapperResult.ResultValue,Is.EqualTo(value));
        }

        [Test]
        public void ToLeaderBoardResultVm_maps_Student_Name()
        {
            var result = new Result(new Student{Name = "name",SchoolClass = new SchoolClass("12B")},1,new ResultValue("Meeter",12),DateTime.Now);

            // Act
            var mapperResult = _sut.ToLeaderBoardResultVm(result);

            // Assert
            Assert.That(mapperResult.Name,Is.EqualTo("name"));
        }
        [Test]
        public void ToLeaderBoardResultVm_maps_Created_on()
        {
            var dateTime = DateTime.Now;
            var result = new Result(new Student{Name = "name",SchoolClass = new SchoolClass("12B")},1,new ResultValue("Meeter",12),dateTime);

            // Act
            var mapperResult = _sut.ToLeaderBoardResultVm(result);

            // Assert
            Assert.That(mapperResult.DateTime,Is.EqualTo(dateTime));
        }
    }
}