using System;
using System.Collections.Generic;
using Core;
using Core.AppServices;
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
using WebApplication2.ViewModels.Students;

namespace Tests
{
    [TestFixture]
    public class AdminControllerTests
    {
        private Mock<IUrlHelperFactory> _urlHelperFactory;
        private Mock<IActionContextAccessor> _actionContextAccessor;
        private Mock<ISecureTokenGenerator> _secureTokenGenerator;
        private Mock<IStudentMapper> _studentMapper;
        private AdminController _sut;
        private Mock<Messages> _messages;

        [SetUp]
        public void Setup()
        {
            _urlHelperFactory = new Mock<IUrlHelperFactory>();
            _actionContextAccessor = new Mock<IActionContextAccessor>();
            _secureTokenGenerator = new Mock<ISecureTokenGenerator>();
            _messages = new Mock<Messages>();

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            _studentMapper = new Mock<IStudentMapper>();
            _sut = new AdminController(_urlHelperFactory.Object, _actionContextAccessor.Object,
                _secureTokenGenerator.Object, _messages.Object, _studentMapper.Object)
            {
                TempData = tempData
            };
        }

        [Test]
        public void Index_Returns_View_With_Model()
        {
            // Act
            var result = (ViewResult) _sut.Index(null);
            // Assert
            Assert.That(result.Model, Is.TypeOf<AdminStudentsListVm>());
        }

        [Test]
        public void Index_Returns_View_With_Given_Model()
        {
            var model = new AdminStudentsListVm();
            model.Students = new List<AdminStudentVm>
            {
                new AdminStudentVm()
            };
            // Act
            var result = (ViewResult) _sut.Index(model);
            var resultModel = (AdminStudentsListVm) result.Model;

            // Assert
            Assert.That(resultModel.Students.Count, Is.EqualTo(1));
        }

        [Test]
        public void FindStudent_returns_ViewResult_With_Model()
        {
            var students = new List<Student> { };
            _messages.Setup(x => x.Dispatch(It.Is<GetStudentListQuery>(c => c.Name == "name")))
                .Returns(students);
            _studentMapper.Setup(x => x.ToStudentsListVm(students)).Returns(new AdminStudentsListVm
            {
                Students = new List<AdminStudentVm>
                {
                    new AdminStudentVm()
                }
            });

            // Act
            var result = (ViewResult) _sut.FindStudent("name");
            var resultModel = (AdminStudentsListVm) result.Model;

            // Assert
            Assert.That(resultModel.Students.Count, Is.EqualTo(1));
        }

        [Test]
        public void SendRegistrationInvite_returns_notFoundResult_WhenStudentIsNotFound()
        {
            // Act
            var result = _sut.SendRegistrationInvite(2);
            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public void SendRegistrationInvite_returns_RedirectToActionResult()
        {
            var student = new Student { };
            _messages.Setup(x => x.Dispatch(It.Is<GetStudentQuery>(c => c.Id == 1)))
                .Returns(student);
            _secureTokenGenerator.Setup(x => x.Generate(20)).Returns("token");

            // Act
            var result = _sut.SendRegistrationInvite(1);
            // Assert
            Assert.That(result, Is.TypeOf<RedirectToActionResult>());
            _messages.Verify(x => x.Dispatch(It.Is<StudentInviteCommand>(c => c.Token == "token")), Times.Once);
        }

        [Test]
        public void NotRegisteredStudents_returns_ViewResult()
        {
            _studentMapper.Setup(x => x.ToStudentsListVm(It.IsAny<List<Student>>())).Returns(new AdminStudentsListVm());
            // Act
            var result = (ViewResult) _sut.NotRegisteredStudents();

            // Assert
            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}