using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data.Entities;
using Moq;
using NUnit.Framework;
using WebApplication2.Services;

namespace Tests.Charts
{
    [TestFixture]
    public class ChartDataServiceTests
    {
        private Mock<IResultService> _resultServiceMock;
        private ChartDataService _sut;

        [SetUp]
        public void Setup()
        {
            _resultServiceMock = new Mock<IResultService>();
            _sut = new ChartDataService(_resultServiceMock.Object);
        }

        [Test]
        public void CreateChartDatalist_returns_Empty_ChartDataList_When_Results_Have_No_Uniqu_Dates()
        {
            var results = new List<Result>();
            _resultServiceMock.Setup(x => x.GetUniqueDates(results)).Returns(new List<DateTime>().ToHashSet());

            // Act
            var result = _sut.CreateChartDatalist(results);
            // Assert
            Assert.That(result.ChartData.Count, Is.EqualTo(0));
        }

        [Test]
        public void CreateChartDatalist_returns_ChartDataList_WithChartData()
        {
            var student = new Student
            {
                Name = "name",
                SchoolClass = new SchoolClass("4B")
            };
            var result1 = new Result(student, 1, new ResultValue("Meeter", 20), DateTime.Now);
            var result2 = new Result(student, 1, new ResultValue("Meeter", 20), DateTime.Now.AddMonths(-1));
            var results = new List<Result>
            {
                result1, result2
            };
            _resultServiceMock.Setup(x => x.GetUniqueDates(results)).Returns(new List<DateTime>
            {
                result1.CreatedOn.Date, result2.CreatedOn.Date
            }.ToHashSet());

            // Act
            var result = _sut.CreateChartDatalist(results);
            // Assert
            Assert.That(result.ChartData.FirstOrDefault().Results.Count, Is.EqualTo(2));
        }

        [Test]
        public void CreateChartDatalist_returns_ChartDataList_WithSeverralStudents()
        {
            var student = new Student
            {
                Name = "name",
                SchoolClass = new SchoolClass ("4B")
            };
            var student2 = new Student
            {
                Name = "name2",
                SchoolClass = new SchoolClass ("4B")
            };
            var result1 = new Result(student, 1, new ResultValue("Meeter", 20), DateTime.Now);
            var result2 = new Result(student2, 1, new ResultValue("Meeter", 20), DateTime.Now);
            var results = new List<Result>
            {
                result1, result2
            };
            _resultServiceMock.Setup(x => x.GetUniqueDates(results)).Returns(new List<DateTime>
            {
                result1.CreatedOn.Date, result2.CreatedOn.Date
            }.ToHashSet());

            // Act
            var result = _sut.CreateChartDatalist(results);
            // Assert
            Assert.That(result.ChartData.Count, Is.EqualTo(2));
        }
        [Test]
        public void CreateChartDatalist_returns_ChartDataList_WithCorrectlyMappedStudent()
        {
            var student = new Student
            {
                Name = "name",
                SchoolClass = new SchoolClass ("4B")
            };
            var student2 = new Student
            {
                Name = "name2",
                SchoolClass = new SchoolClass ("4B")
            };
            var result1 = new Result(student, 1, new ResultValue("Meeter", 20), DateTime.Now);
            var result2 = new Result(student2, 1, new ResultValue("Meeter", 20), DateTime.Now);
            var results = new List<Result>
            {
                result1, result2
            };
            _resultServiceMock.Setup(x => x.GetUniqueDates(results)).Returns(new List<DateTime>
            {
                result1.CreatedOn.Date, result2.CreatedOn.Date
            }.ToHashSet());

            // Act
            var result = _sut.CreateChartDatalist(results);
            // Assert
            Assert.That(result.ChartData.FirstOrDefault().Name, Is.EqualTo("name"));
            Assert.That(result.ChartData.LastOrDefault().Name, Is.EqualTo("name2"));
        }

        [Test]
        public void CreateChartDatalist_returns_ChartDataList_WithChartData_OnlyUniqueDates()
        {
            var student = new Student
            {
                Name = "name",
                SchoolClass = new SchoolClass ("4B")
            };
            var result1 = new Result(student, 1, new ResultValue("Meeter", 20), DateTime.Now);
            var result2 = new Result(student, 1, new ResultValue("Meeter", 15), DateTime.Now);
            var results = new List<Result>
            {
                result1, result2
            };
            _resultServiceMock.Setup(x => x.GetUniqueDates(results)).Returns(new List<DateTime>
            {
                result1.CreatedOn.Date, result2.CreatedOn.Date
            }.ToHashSet());

            // Act
            var result = _sut.CreateChartDatalist(results);
            // Assert
            Assert.That(result.ChartData.FirstOrDefault().Results.Count, Is.EqualTo(1));

        }
        [Test]
        public void CreateChartDatalist_returns_ChartDataList_WithChartData_WithBestResult()
        {
            var student = new Student
            {
                Name = "name",
                SchoolClass = new SchoolClass ("4B")
            };
            var result1 = new Result(student, 1, new ResultValue("Meeter", 20), DateTime.Now);
            var result2 = new Result(student, 1, new ResultValue("Meeter", 15), DateTime.Now);
            var results = new List<Result>
            {
                result1, result2
            };
            _resultServiceMock.Setup(x => x.GetUniqueDates(results)).Returns(new List<DateTime>
            {
                result1.CreatedOn.Date, result2.CreatedOn.Date
            }.ToHashSet());

            // Act
            var result = _sut.CreateChartDatalist(results);
            // Assert
            Assert.That(result.ChartData.FirstOrDefault().Results.FirstOrDefault(), Is.EqualTo(20));

        }
    }
}